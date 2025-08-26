using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DroneFlightAnalyzer.Util;

namespace DroneFlightAnalyzer
{

    public enum DistanceUnit
    {
        Meters,
        Kilometers,
        Feet,
        Yards,
        Miles
    }

    public enum SpeedUnit
    {
        meters_per_second,
        kph,
        mph
    }

    

    public partial class MainForm : Form
    {
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        private string loadedMP4File = "";
        private Form MapForm;

        // define colors
        private ScottPlot.Color COLOR_WHITE = ScottPlot.Color.FromColor(System.Drawing.Color.White);
        private ScottPlot.Color COLOR_RED = ScottPlot.Color.FromColor(System.Drawing.Color.Red);
        private ScottPlot.Color COLOR_BLUE = ScottPlot.Color.FromColor(System.Drawing.Color.Blue);
        private ScottPlot.Color COLOR_GREEN = ScottPlot.Color.FromColor(System.Drawing.Color.Green);
        private ScottPlot.Color COLOR_LIME_GREEN = ScottPlot.Color.FromColor(System.Drawing.Color.LimeGreen);
        private ScottPlot.Color COLOR_ORANGE = ScottPlot.Color.FromColor(System.Drawing.Color.Orange);
        private ScottPlot.Color COLOR_AQUA = ScottPlot.Color.FromColor(System.Drawing.Color.Aquamarine);

        public static string filePath;
        string tempDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ".djiflightanalyzer",
                "tempdata.vtt"
        );

        public MainForm()
        {
            InitializeComponent();

            LoadGraphPlots();
        }

        void LoadGraphPlots()
        {
            // Add the FormsPlot to the panel
            FormsPlot1.Plot.XLabel("Seconds");
            FormsPlot1.Plot.YLabel("Meters / m/s");

            panel1.Controls.Add(FormsPlot1);
            FormsPlot1.Plot.SetStyle(SmallzGraphing.GetPlotStyle());

            altitudeComboBox.SelectedItem = altitudeComboBox.Items[(int)DJIDataReader.selectedAltitudeUnit];
            distanceUnitComboBox.SelectedItem = distanceUnitComboBox.Items[(int)DJIDataReader.selectedDistanceUnit];
            comboBox1.SelectedItem = comboBox1.Items[(int)DJIDataReader.selectedSpeedUnit];
        }

        private void buttonSelectMP4_Click(object sender, EventArgs e) => OnSelectMP4ButtonClicked();

        async void OnSelectMP4ButtonClicked()
        {
            FormsPlot1.Plot.Clear();
            DJIDataReader.activeDroneData.Clear();

            // Open file dialog to pick .mp4 file
            loadingBar.Visible = true;
            OpenFileDialog ofd = new OpenFileDialog
            {
                CheckPathExists = true,
                Filter = "MP4 files (*.mp4)|*.mp4",
                Title = "Select Drone Flight MP4 File"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                loadedMP4File = filePath;
                Trace.WriteLine($"Selected MP4: {filePath}");

                if (!DJIDataReader.IsGPACInstalled())
                {
                    Trace.TraceError($"GPAC is not installed. Cannot process: {filePath}");
                    MessageBox.Show(
                        "Oops!\nGPAC is not installed.\n\nPlease install it from:\nhttps://gpac.io/downloads/gpac-nightly-builds/",
                        "Missing Dependency",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return; // Prevent further processing
                }

                // Extract .vtt from .mp4 using GPAC or MP4Box
                string cmd = $" -i \"{filePath}\" -o \"{tempDataPath}\"";
                await Task.Run(() => DJIDataReader.RunGPACCommand(cmd));
                Trace.WriteLine($"GPAC Executed: {cmd}");

                // Extract data from .vtt file
                DJIDataReader.activeDroneData = await TryExtractingFlightDataFromTempVTTData();

                UpdateGraph();
                loadingBar.Visible = false; // hide loading bar
            }
        }

        public async Task<List<DroneData>> TryExtractingFlightDataFromTempVTTData()
        {
            List<DroneData> data = new List<DroneData>();
            if (System.IO.File.Exists(tempDataPath))
            {
                openVideoButton.Visible = true;
                data = await DJIDataReader.ExtractDroneData(tempDataPath, loadingBar);
                Trace.WriteLine($"Extracted .vtt data from {tempDataPath} successfully");
            }else
            {
                MessageBox.Show("Failed to extract .vtt data from {tempDataPath}");
            }
            return data;
        }

        public void PlotSelectedData(List<DroneData> data)
        {
            FormsPlot1.Plot.Title(loadedMP4File);   
            if (data.Count <= 0) {
                return;
            }
            FormsPlot1.Plot.Clear();

            if (visibleDataCheckedList.GetItemChecked(0))
            {
                SmallzGraphing.PlotFloatData(data.Select(d => d.Altitude).ToArray(), COLOR_AQUA, FormsPlot1);
            }

            // dist data
            if (visibleDataCheckedList.GetItemChecked(1))
            {
                SmallzGraphing.PlotFloatData(data.Select(d => d.Distance).ToArray(), COLOR_LIME_GREEN, FormsPlot1);
            }

            // hs data
            if (visibleDataCheckedList.GetItemChecked(2))
            {
                SmallzGraphing.PlotFloatData(data.Select(d => d.HorizontalSpeed).ToArray(), COLOR_ORANGE, FormsPlot1);
            }

            // vs data
            if (visibleDataCheckedList.GetItemChecked(3))
            {
                SmallzGraphing.PlotFloatData(data.Select(d => d.VeritcalSpeed).ToArray(), COLOR_BLUE, FormsPlot1);
            }

            // coordiantes
            if (visibleDataCheckedList.GetItemChecked(4))
            {
                SmallzGraphing.PlotFloatData(data.Select(d => d.Coordinates.Longitude).ToArray(), COLOR_RED, FormsPlot1);

            }
            if (visibleDataCheckedList.GetItemChecked(5))
            {
                SmallzGraphing.PlotFloatData(data.Select(d => d.Coordinates.Latitude).ToArray(), COLOR_GREEN, FormsPlot1);

            }
            if (visibleDataCheckedList.GetItemChecked(6))
            {
                SmallzGraphing.PlotFloatData(data.Select(d => d.Coordinates.Elevation).ToArray(), COLOR_BLUE, FormsPlot1);
            }
            
            FormsPlot1.Refresh();
        }
        
        private void visibleDataCheckedList_SelectedIndexChanged(object sender, EventArgs e) => UpdateGraph();

        // opens video file with default video player
        private void openVideoButton_Click(object sender, EventArgs e) => DJIDataReader.OpenVideoFile(loadedMP4File);
    
        // always converting from default units ( meters || m/s )
        private List<DroneData> ConvertDroneData(List<DroneData> droneData)
        {

            List<DroneData> result = new List<DroneData>();

            foreach (var data in droneData)
            {
                // Convert drone data to imperial units
                float newDistance = DJIDataReader.ConvertDistance(data.Distance, DJIDataReader.selectedDistanceUnit);
                float newAltitude = DJIDataReader.ConvertDistance(data.Altitude, DJIDataReader.selectedAltitudeUnit);
                float newElevation = DJIDataReader.ConvertDistance(data.Coordinates.Elevation, DJIDataReader.selectedDistanceUnit);

                float newHorzSpeed = DJIDataReader.ConvertSpeed(data.HorizontalSpeed, DJIDataReader.selectedSpeedUnit);
                float newVertSpeed = DJIDataReader.ConvertSpeed(data.VeritcalSpeed, DJIDataReader.selectedSpeedUnit);
                FormsPlot1.Plot.YLabel($"{DJIDataReader.GetAltitudeLabel()}{DJIDataReader.GetDistanceLabel()} / {DJIDataReader.GetSpeedLabel()}");

                DroneData convertedData = new DroneData(new Coords(data.Coordinates.Longitude, data.Coordinates.Latitude, newElevation),  
                                                        newAltitude,      
                                                        newDistance,
                                                        newVertSpeed,
                                                        newHorzSpeed);
                result.Add(convertedData);
            }

            return result;

        }

        public List<DroneData> GetConvertedDroneData() => ConvertDroneData(DJIDataReader.activeDroneData);
        
        void UpdateGraph()
        {
            var dataToDisplay = ConvertDroneData(DJIDataReader.activeDroneData);
            PlotSelectedData(dataToDisplay);
        }

        // display unit for distance is changed
        private void distanceUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DJIDataReader.selectedDistanceUnit = (DistanceUnit)distanceUnitComboBox.SelectedIndex;
            UpdateGraph();
        }

        // display unit for speed is changed
        private void speedUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DJIDataReader.selectedSpeedUnit = (SpeedUnit)comboBox1.SelectedIndex;
            UpdateGraph();
        }

        // display unit for altitude is changed
        private void altitudeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DJIDataReader.selectedAltitudeUnit = (DistanceUnit)altitudeComboBox.SelectedIndex;
            UpdateGraph();
        }

        // opens form that visualizes flight GPS data
        private void mapButton_Click(object sender, EventArgs e)
        {
            MapForm = new MapForm();
            MapForm.Show();
        }

    }
}
