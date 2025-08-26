namespace DroneFlightAnalyzer
{
    partial class MapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.previewMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.playFlightpathButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.renderNewVideoButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.MapSettingsButton = new System.Windows.Forms.Button();
            this.flightInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // previewMapControl
            // 
            this.previewMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewMapControl.Bearing = 0F;
            this.previewMapControl.CanDragMap = true;
            this.previewMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.previewMapControl.GrayScaleMode = false;
            this.previewMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.previewMapControl.LevelsKeepInMemmory = 5;
            this.previewMapControl.Location = new System.Drawing.Point(12, 31);
            this.previewMapControl.MarkersEnabled = true;
            this.previewMapControl.MaxZoom = 2;
            this.previewMapControl.MinZoom = 2;
            this.previewMapControl.MouseWheelZoomEnabled = true;
            this.previewMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.previewMapControl.Name = "previewMapControl";
            this.previewMapControl.NegativeMode = false;
            this.previewMapControl.PolygonsEnabled = true;
            this.previewMapControl.RetryLoadTile = 0;
            this.previewMapControl.RoutesEnabled = true;
            this.previewMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.previewMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.previewMapControl.ShowTileGridLines = false;
            this.previewMapControl.Size = new System.Drawing.Size(557, 431);
            this.previewMapControl.TabIndex = 0;
            this.previewMapControl.Zoom = 0D;
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.Location = new System.Drawing.Point(12, 468);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(372, 45);
            this.trackBar.TabIndex = 1;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // playFlightpathButton
            // 
            this.playFlightpathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playFlightpathButton.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.playFlightpathButton.Location = new System.Drawing.Point(501, 468);
            this.playFlightpathButton.Name = "playFlightpathButton";
            this.playFlightpathButton.Size = new System.Drawing.Size(68, 23);
            this.playFlightpathButton.TabIndex = 2;
            this.playFlightpathButton.Text = "Play";
            this.playFlightpathButton.UseVisualStyleBackColor = true;
            this.playFlightpathButton.Click += new System.EventHandler(this.playFlightpathButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(381, 471);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(55, 15);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "00:00:00";
            // 
            // renderNewVideo
            // 
            this.renderNewVideoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.renderNewVideoButton.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.renderNewVideoButton.Location = new System.Drawing.Point(501, 496);
            this.renderNewVideoButton.Name = "renderNewVideo";
            this.renderNewVideoButton.Size = new System.Drawing.Size(68, 23);
            this.renderNewVideoButton.TabIndex = 4;
            this.renderNewVideoButton.Text = "Render";
            this.renderNewVideoButton.UseVisualStyleBackColor = true;
            this.renderNewVideoButton.Click += new System.EventHandler(this.renderNewVideo_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(9, 504);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 15);
            this.statusLabel.TabIndex = 5;
            // 
            // MapSettingsButton
            // 
            this.MapSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MapSettingsButton.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.MapSettingsButton.Location = new System.Drawing.Point(431, 496);
            this.MapSettingsButton.Name = "MapSettingsButton";
            this.MapSettingsButton.Size = new System.Drawing.Size(66, 23);
            this.MapSettingsButton.TabIndex = 6;
            this.MapSettingsButton.Text = "Settings";
            this.MapSettingsButton.UseVisualStyleBackColor = true;
            this.MapSettingsButton.Click += new System.EventHandler(this.MapSettingsButton_Click);
            // 
            // flightInfoLabel
            // 
            this.flightInfoLabel.AutoSize = true;
            this.flightInfoLabel.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.flightInfoLabel.ForeColor = System.Drawing.Color.White;
            this.flightInfoLabel.Location = new System.Drawing.Point(12, 9);
            this.flightInfoLabel.Name = "flightInfoLabel";
            this.flightInfoLabel.Size = new System.Drawing.Size(0, 15);
            this.flightInfoLabel.TabIndex = 7;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(581, 525);
            this.Controls.Add(this.flightInfoLabel);
            this.Controls.Add(this.MapSettingsButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.renderNewVideoButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.playFlightpathButton);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.previewMapControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapForm";
            this.Text = "Flight Map";
            this.Load += new System.EventHandler(this.MapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl previewMapControl;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button playFlightpathButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button renderNewVideoButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button MapSettingsButton;
        private System.Windows.Forms.Label flightInfoLabel;
    }
}