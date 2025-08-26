using GMap.NET.WindowsForms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DroneFlightAnalyzer.Util
{
    public static class SmallzFFmpegRenderer
    {

        private static void GenerateMinimapFrames(List<DroneData> dataPoints, GMapOverlay flightpathOverlay, GMapControl mapControl)
        {
            for (int frameIndex = 1; frameIndex < dataPoints.Count; frameIndex++)
            {
                // Update map on UI thread
                mapControl.Position = dataPoints[frameIndex - 1].CoordsAsPointLatLng();
                mapControl.Zoom = 17;

                // Update the map overlay and draw
                MapForm.DrawFlightPath(mapControl, flightpathOverlay, dataPoints.Take(frameIndex).ToList(), frameIndex, true);
            }
        }

        public static async Task<bool> RenderVideo(List<DroneData> dataPoints, GMapOverlay flightpathOverlay, GMapControl mapControl)
        {
            Stopwatch watch = Stopwatch.StartNew();

            // Step 1: Clear old files
            DJIDataReader.ClearTempFiles();

            // Step 2: Generate minimap frames
            GenerateMinimapFrames(dataPoints, flightpathOverlay, mapControl);

            watch.Stop();
            Debug.WriteLine($"Frame generation took {watch.Elapsed.TotalSeconds}s");

            // Step 3: Render video w/ minimap overlay
            watch.Restart();
            string pathToMP4 = MainForm.filePath;

            await Task.Run(() =>
            {
                DJIDataReader.RunFFmpegCommand($"-i \"{pathToMP4}\" -framerate 1 -i temp/frame_%d.png"
                        + " -filter_complex \"[1:v]format=rgba[ovl];[0:v][ovl]overlay=10:10\""
                        + $" -c:v {VideoEncoder.SelectedEncoder} -pix_fmt yuv420p -crf 18 {MapForm.OUTPUT_PATH}{Path.GetFileName(pathToMP4)}_flight.mp4");
            });
            
            watch.Stop();

            Debug.WriteLine($"Finished rendering {MapForm.OUTPUT_PATH}{Path.GetFileName(pathToMP4)}");
            Debug.WriteLine($"Render took {watch.Elapsed.TotalSeconds} seconds");
            return true;
        }

    }
}
