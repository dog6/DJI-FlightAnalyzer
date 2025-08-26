using System;
using System.Windows.Forms;
using DroneFlightAnalyzer.Util;

namespace DroneFlightAnalyzer
{
    public partial class MapSettingsForm : Form
    {

        public static MapForm mapForm;
        public MapSettingsForm()
        {
            InitializeComponent();
        }

        private void MapSettingsForm_Load(object sender, EventArgs e)
        {
            LoadSetValues();
        }

        private void LoadSetValues()
        {
            UpdateVideoEncoderComboBox();
            fontComboBox.SelectedText = MapForm.FONT; // set default font in combo box

            // Set speed text boxes
            slowSpeedTextBox.Text = SmallzGraphing.CINEMA_SPEED.ToString();
            normalSpeedTextBox.Text = SmallzGraphing.NORMAL_SPEED.ToString();
        }

        private void UpdateVideoEncoderComboBox() => videoEncoderComboBox.SelectedItem = videoEncoderComboBox.GetItemText(VideoEncoder.SelectedEncoder);

        private void videoEncoderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedVideoEncoderIndex = videoEncoderComboBox.SelectedIndex;
            VideoEncoder.SelectedEncoder = VideoEncoder.Encoders[selectedVideoEncoderIndex];
            UpdateVideoEncoderComboBox();
        }
        private void fontComboBox_SelectedIndexChanged(object sender, EventArgs e) => MapForm.FONT = fontComboBox.SelectedItem.ToString();
        private void selectOutputFolderButton_Click(object sender, EventArgs e)
        {

            // Let user select a folder to output files too
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select output folder";
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = fbd.SelectedPath;
                    MapForm.OUTPUT_PATH = selectedPath + "\\";
                    MessageBox.Show($"Selected folder: {MapForm.OUTPUT_PATH } as new output folder");
                }
            }

        }
        private void slowSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SmallzGraphing.CINEMA_SPEED = int.Parse(slowSpeedTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed changing slow speed to '{slowSpeedTextBox.Text}'\nError:\n\n{ex.Message}");
            }
            if (mapForm != null)
                mapForm.Refresh();
        }
        private void normalSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SmallzGraphing.NORMAL_SPEED = int.Parse(normalSpeedTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed changing normal speed to '{normalSpeedTextBox.Text}'\nError:\n\n{ex.Message}");
            }
            if (mapForm != null)
                mapForm.RefreshMap();
        }
        private System.Drawing.Color SetMapPlotColor(System.Drawing.Color defaultColor)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = defaultColor;

                if (cd.ShowDialog() == DialogResult.OK)
                {
                    return cd.Color;
                }
                return defaultColor;
            }

            
        }
        
        private void fastSpeedColorSelector_Clicked(object sender, EventArgs e) => SmallzGraphing.FAST_SPEED_COLOR = SetMapPlotColor(SmallzGraphing.FAST_SPEED_COLOR);
        private void normalSpeedColorSelector_Clicked(object sender, EventArgs e) => SmallzGraphing.NORMAL_SPEED_COLOR = SetMapPlotColor(SmallzGraphing.NORMAL_SPEED_COLOR);
        private void slowSpeedColorSelector_Clicked(object sender, EventArgs e) => SmallzGraphing.CINEMA_SPEED_COLOR = SetMapPlotColor(SmallzGraphing.CINEMA_SPEED_COLOR);
    
    }
}
