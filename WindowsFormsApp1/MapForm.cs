using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DroneFlightAnalyzer.Util;

namespace DroneFlightAnalyzer
{


    public partial class MapForm : Form
    {


        private GMapOverlay flightpathOverlay = new GMapOverlay();
        private static List<DroneData> droneDataPoints;

        private float trackValue;
        private bool watchingTrack = false;
        private static float totalFlightDistanceInKilometers;
        
        public static string FONT = "Arial";
        public static string OUTPUT_PATH = "";


        public MapForm()
        {
            InitializeComponent();
            droneDataPoints = DJIDataReader.activeDroneData.Where(d => d.Coordinates.Latitude != 0 && d.Coordinates.Longitude != 0).ToList();
            var dataCount = droneDataPoints.Count - 1;
            trackBar.Maximum = dataCount;
            trackBar.Value = dataCount;
            trackValue = trackBar.Value;
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            if (DJIDataReader.activeDroneData.Count > 0)
            {
                // Load map
                float lat = droneDataPoints[0].Coordinates.Latitude;
                float lng = droneDataPoints[0].Coordinates.Longitude;
                Debug.WriteLine($"Loading map.. @ coordinates Lat: {lat}, Long: {lng}");
                LoadMap(lat, lng);

                flightpathOverlay = new GMapOverlay();
                DrawFlightPath(previewMapControl, flightpathOverlay, droneDataPoints, (int)trackValue);
            }
        }

        public void RefreshMap()
        {
            DrawFlightPath(previewMapControl, flightpathOverlay, droneDataPoints, (int)trackValue);
        }

        private void LoadMap(double lat = -74.0060, double lng = 40.7128)
        {

            previewMapControl.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            previewMapControl.Position = new GMap.NET.PointLatLng(lat, lng);
            previewMapControl.MaxZoom = 18;
            previewMapControl.MinZoom = 0;
            previewMapControl.Zoom = 16;
        }

        public static void DrawFlightPath(GMapControl mapControl, GMapOverlay flightpathOverlay, List<DroneData> dataPoints, int maxIndex, bool saveFrame = false)
        {

            // Add each GPS point to flight path
            mapControl.Overlays.Clear();
            flightpathOverlay.Clear();

            // Plot flight on map and gather <float> totalFlightDistanceInKilometers
            totalFlightDistanceInKilometers = SmallzGraphing.PlotFlightOnMap(maxIndex, dataPoints, flightpathOverlay);

            // Add overlay to map
            mapControl.Overlays.Add(flightpathOverlay);

            // Add info markers
            SmallzGraphing.AddFlightInfoMarkers(flightpathOverlay, dataPoints, totalFlightDistanceInKilometers, maxIndex); 

            // Save minimap frame as image for use during rendering
            if (saveFrame)
                SaveMinimapFrame(dataPoints, mapControl, maxIndex);

        }

        private static void SaveMinimapFrame(List<DroneData> dataPoints, GMapControl mapControl, int maxIndex)
        {
            string frameName = $"temp/frame_{maxIndex}.png";
            Bitmap newMapFrame = new Bitmap(mapControl.Width, mapControl.Height);
            mapControl.DrawToBitmap(newMapFrame, new Rectangle(0, 0, mapControl.Height, mapControl.Height));

            float currentSpeed = (float)Math.Round(DJIDataReader.ConvertSpeed(dataPoints[dataPoints.Count - 1].HorizontalSpeed, DJIDataReader.selectedSpeedUnit), 1);
            float currentVerticalSpeed = (float)Math.Round(DJIDataReader.ConvertSpeed(dataPoints[dataPoints.Count - 1].VeritcalSpeed, DJIDataReader.selectedSpeedUnit), 1);
            float currentAltitude = (float)Math.Round(DJIDataReader.ConvertDistance(dataPoints[dataPoints.Count - 1].Altitude, DJIDataReader.selectedAltitudeUnit), 1);

            Graphics g = Graphics.FromImage(newMapFrame);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            RectangleF rectf = new RectangleF(20, 12, 350, 100);
            g.DrawString($"H Speed: {currentSpeed} {DJIDataReader.GetSpeedLabel()}"
                + $"\nV Speed: {currentVerticalSpeed} {DJIDataReader.GetSpeedLabel()}"
                + $"\nAltitude: {currentAltitude} {DJIDataReader.GetAltitudeLabel()}", new Font(FONT, 14, System.Drawing.FontStyle.Bold), Brushes.White, rectf);
            g.Flush();
            newMapFrame.Save(frameName);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            trackValue = trackBar.Value;
            DrawFlightPath(previewMapControl, flightpathOverlay, droneDataPoints, (int)trackValue);

            // Update time label
            timeLabel.Text = TimeSpan.FromSeconds(trackValue).ToString(@"hh\:mm\:ss");
            flightInfoLabel.Text = "";
        }

        private void PlayFlightRecording()
        {
            // Start track
            Task.Run(() =>
            {
                while (trackValue < trackBar.Maximum && watchingTrack)
                {

                    this.Invoke((MethodInvoker)(() =>
                    {
                        DrawFlightPath(previewMapControl, flightpathOverlay, droneDataPoints, (int)trackValue);

                        trackValue++;
                        if (trackValue >= trackBar.Maximum)
                        {
                            watchingTrack = false;
                            playFlightpathButton.Text = "Play";
                            trackValue = trackBar.Maximum;
                        }

                        trackBar.Value = (int)trackValue;
                    }));
                    Thread.Sleep(1000);
                }
            });
        }

        private void playFlightpathButton_Click(object sender, EventArgs e)
        {
            watchingTrack = !watchingTrack;
            if (watchingTrack)
            {
                PlayFlightRecording();
                playFlightpathButton.Text = "Pause";
            }else
            {
                playFlightpathButton.Text = "Play";
            }

        }

        private System.Windows.Forms.Timer renderTimer;
        private Stopwatch renderStopwatch;

        private async void renderNewVideo_Click(object sender, EventArgs e)
        {
            // Ensure single-click behavior (optional)
            //.Enabled = false;
            renderNewVideoButton.Enabled = false;
            // Initialize timer and stopwatch
            if (renderTimer == null)
            {
                renderTimer = new System.Windows.Forms.Timer();
                renderTimer.Interval = 500;
                renderTimer.Tick += (s, e2) =>
                {
                    statusLabel.Text = $"Rendering video... ({renderStopwatch.Elapsed.TotalSeconds:F1}s)";
                };
            }

            renderStopwatch = Stopwatch.StartNew();
            renderTimer.Start();

            try
            {
                statusLabel.Text = "Rendering video...";

                // Run the rendering process
                await SmallzFFmpegRenderer.RenderVideo(droneDataPoints, flightpathOverlay, previewMapControl);
                renderTimer.Stop();
                // Success message
                statusLabel.Text = $"Render finished in {renderStopwatch.Elapsed.TotalSeconds:F1}s";
            }
            catch (Exception ex)
            {
                // Show user-friendly error (you could log the full exception)
                renderTimer.Stop();
                statusLabel.Text = "Render failed: " + ex.Message;
                MessageBox.Show("An error occurred while rendering the video:\n\n" + ex.Message, "Render Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                renderTimer.Stop();
                renderStopwatch.Stop();
                renderNewVideoButton.Enabled = true;
            }
        }

        private void MapSettingsButton_Click(object sender, EventArgs e)
        {
            MapSettingsForm form = new MapSettingsForm();
            form.ShowDialog();
            MapSettingsForm.mapForm = this;
        }
    }
}
