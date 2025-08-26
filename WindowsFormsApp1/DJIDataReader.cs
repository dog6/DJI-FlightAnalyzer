using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DroneFlightAnalyzer.Util;

namespace DroneFlightAnalyzer
{
    /// <summary>
    /// Converts & reads .vtt data from a .mp4 file
    /// that was recorded with a DJI drone.
    /// </summary>
    public static class DJIDataReader
    {

        const string REGEX_GPS = "GPS\\s\\(\\s*(n\\/a|[-\\d.]+),\\s*(n\\/a|[-\\d.]+),\\s*(n\\/a|[-\\d.]+)\\s*\\)";
        const string REGEX_ALTITUDE = "H\\s([\\d.]+)m";
        const string REGEX_DISTANCE = "D\\s(n\\/a|[-\\d.]+)m?";
        const string REGEX_HORIZONTAL_SPEED = "H\\.S\\s([-\\d.]+)";
        const string REGEX_VERTICAL_SPEED = "V\\.S\\s([-\\d.]+)";
        public static List<DroneData> activeDroneData = new List<DroneData>();

        public static DistanceUnit selectedDistanceUnit = DistanceUnit.Meters;
        public static DistanceUnit selectedAltitudeUnit = DistanceUnit.Meters;
        public static SpeedUnit selectedSpeedUnit = SpeedUnit.meters_per_second;
        public static async Task<List<DroneData>> ExtractDroneData(string filePath, System.Windows.Forms.ProgressBar progressBar)
        {
            progressBar.Value = 0;

            Regex gpsRegex = new Regex(REGEX_GPS);
            Regex altitudeRegex = new Regex(REGEX_ALTITUDE);
            Regex distanceRegex = new Regex(REGEX_DISTANCE);
            Regex vertSpeedRegex = new Regex(REGEX_VERTICAL_SPEED);
            Regex horzSpeedRegex = new Regex(REGEX_HORIZONTAL_SPEED);

            List<DroneData> data = new List<DroneData>();

            int lineCount = File.ReadLines(filePath).Count();

            await Task.Run(() =>
            {
            StreamReader reader = new StreamReader(filePath, Encoding.UTF8);
            int i = 0;
            while (!reader.EndOfStream)
            {
                // Process one line at a time — no big memory spike
                string line = reader.ReadLine();
                i++;
                if (line != "" && line[0] == 'F')
                {
                    Trace.WriteLine($"Parsing line {line}");
                    MatchCollection gpsMatches = gpsRegex.Matches(line);
                    Match altitudeMatch = altitudeRegex.Match(line);
                    Match distanceMatch = distanceRegex.Match(line);
                    Match vertSpeedMatch = vertSpeedRegex.Match(line);
                    Match horzSpeedMatch = horzSpeedRegex.Match(line);

                    float longitude = gpsMatches[0].Groups[1].Value != "n/a" ? float.Parse(gpsMatches[0].Groups[1].Value) : 0;
                    float latitude = gpsMatches[0].Groups[2].Value != "n/a" ? float.Parse(gpsMatches[0].Groups[2].Value) : 0;
                    float elevation = gpsMatches[0].Groups[3].Value != "n/a" ? float.Parse(gpsMatches[0].Groups[3].Value) : 0; // meters above sea level
                    Trace.WriteLine($"Distance: {distanceMatch.Groups[1].Value}");

                        try
                        {
                            float altitude = float.Parse(altitudeMatch.Groups[1].Value);
                            float distance = distanceMatch.Groups[1].Value != "n/a" ? float.Parse(distanceMatch.Groups[1].Value) : -1;
                            float vertSpeed = float.Parse(vertSpeedMatch.Groups[1].Value);
                            float horzSpeed = float.Parse(horzSpeedMatch.Groups[1].Value);

                            //Vec3 dronePosition = new Vec3();
                            Coords dronePosition = new Coords(longitude, latitude, elevation);

                            // Extract data from this line
                            data.Add(new DroneData(dronePosition, altitude, distance, vertSpeed, horzSpeed));
                        Trace.WriteLine($"Line #{i}: {line}");
                        } catch (Exception ex) { 
                            Trace.TraceError($"Failed to parse line #{i} from tempdata.vtt\nERROR: {ex.ToString()}");
                            data.Add(new DroneData(new Coords(), 0, 0, 0, 0));
                        }

                    }
                    else
                    {
                        continue;
                    }


                    // Update progress (invoke on UI thread)
                    int progress = (int)((i / (double)lineCount) * 100)+1;
                    progressBar.Invoke((Action)(() =>
                    {
                        Trace.WriteLine($"Progress {progress}");
                        progressBar.Value = Math.Min(progress, 100);
                    }));
                }


            });

            return data;


        }
        public static bool IsGPACInstalled()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "MP4Box",
                    Arguments = "-version",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    return process.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }
        public static void RunGPACCommand(string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "GPAC",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Trace.WriteLine($"Executing GPAC command: GPAC {arguments}");

            using (Process process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                Trace.WriteLine("GPAC Output:\n" + output);
                Trace.WriteLine("GPAC Errors:\n" + error);
            }
        }

        public static string GetAltitudeLabel() => GetDistanceLabel(selectedAltitudeUnit);
        public static string GetDistanceLabel() => GetDistanceLabel(selectedDistanceUnit);
        public static string GetSpeedLabel() => GetSpeedLabel(selectedSpeedUnit);

        public static float ConvertDistance(float distance, DistanceUnit newUnit)
        {
            float newDistance = 0f;
            switch (newUnit)
            {
                case DistanceUnit.Kilometers:
                    newDistance = distance / 1000; // m -> km
                    break;
                case DistanceUnit.Feet:
                    newDistance = distance * 3.281f; // m -> ft
                    break;
                case DistanceUnit.Yards:
                    newDistance = distance * 1.094f; // m -> y
                    break;
                case DistanceUnit.Miles:
                    newDistance = distance / 1609; // m -> mi
                    break;
                default:
                    newDistance = distance;
                    break;
            }
            return newDistance;
        }
        public static string GetDistanceLabel(DistanceUnit distanceUnit)
        {
            switch (distanceUnit)
            {
                case DistanceUnit.Feet:
                    return "ft";
                case DistanceUnit.Yards:
                    return "yrds";
                case DistanceUnit.Kilometers:
                    return "km";
                case DistanceUnit.Miles:
                    return "miles";
                default:
                case DistanceUnit.Meters:
                    return "m";
            }
        }
        public static string GetSpeedLabel(SpeedUnit speedUnit)
        {
            switch (speedUnit)
            {
                case SpeedUnit.kph:
                    return "kph";
                case SpeedUnit.mph:
                    return "mph";
                default:
                case SpeedUnit.meters_per_second:
                    return "m/s";
            }
        }

        public static float ConvertSpeed(float metersPerSecond, SpeedUnit newUnit)
        {
            float newValue = 0;
            switch (newUnit)
            {
                case SpeedUnit.kph:
                    newValue = metersPerSecond * 3.6f;
                    break;
                case SpeedUnit.mph:
                    newValue = metersPerSecond * 2.237f;
                    break;
                default:
                    newValue = metersPerSecond;
                    break;
            }
            return newValue;
        }
        public static Task RunFFmpegCommand(string args)
        {
            Process ffmpeg = new Process();
            ffmpeg.StartInfo.FileName = "C:/FFmpeg/bin/ffmpeg.exe"; // Or full path to ffmpeg.exe
            ffmpeg.StartInfo.Arguments = args;
            ffmpeg.StartInfo.CreateNoWindow = true;
            ffmpeg.StartInfo.UseShellExecute = false;
            ffmpeg.StartInfo.RedirectStandardOutput = true;
            ffmpeg.StartInfo.RedirectStandardError = true;

            bool result = false;
            ffmpeg.OutputDataReceived += (s, e) => result = true;
            ffmpeg.ErrorDataReceived += (s, e) => result = false;

            ffmpeg.Start();
            ffmpeg.BeginOutputReadLine();
            ffmpeg.BeginErrorReadLine();
            ffmpeg.WaitForExit();
            Debug.WriteLine($"Successfully executed FFMPEG command 'ffmpeg.exe {args}'");
            return Task.FromResult(result);
        }
       
        public static void ClearTempFiles()
        {
            if (Directory.Exists("temp"))
            {
                foreach (var file in Directory.GetFiles("temp/", "*.png").Concat(Directory.GetFiles("temp/", "*.mov")))
                {
                    File.Delete(file);
                }
                Debug.WriteLine($"Successfully cleared temp directory.");
            }else
            {
                var dir = Directory.CreateDirectory("temp"); // create temp directory
                Debug.WriteLine($"Created temp directory {dir.FullName}");
            }
        }

        public static void OpenVideoFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true // Required to use default app
                });
            }
            else
            {
                Debug.WriteLine("File not found.");
            }
        }


    }
}
