namespace DroneFlightAnalyzer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonSelectMP4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.visibleDataCheckedList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.openVideoButton = new System.Windows.Forms.Button();
            this.distanceUnitComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mapButton = new System.Windows.Forms.Button();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.label4 = new System.Windows.Forms.Label();
            this.altitudeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelectMP4
            // 
            this.buttonSelectMP4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectMP4.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.buttonSelectMP4.Location = new System.Drawing.Point(489, 410);
            this.buttonSelectMP4.Name = "buttonSelectMP4";
            this.buttonSelectMP4.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectMP4.TabIndex = 0;
            this.buttonSelectMP4.Text = "Select";
            this.buttonSelectMP4.UseVisualStyleBackColor = true;
            this.buttonSelectMP4.Click += new System.EventHandler(this.buttonSelectMP4_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 381);
            this.panel1.TabIndex = 1;
            // 
            // visibleDataCheckedList
            // 
            this.visibleDataCheckedList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.visibleDataCheckedList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.visibleDataCheckedList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.visibleDataCheckedList.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visibleDataCheckedList.ForeColor = System.Drawing.Color.White;
            this.visibleDataCheckedList.FormattingEnabled = true;
            this.visibleDataCheckedList.Items.AddRange(new object[] {
            "Altitude",
            "Distance",
            "Horz. Speed",
            "Vert. Speed",
            "Latitude",
            "Longitude",
            "Elevation"});
            this.visibleDataCheckedList.Location = new System.Drawing.Point(12, 425);
            this.visibleDataCheckedList.Name = "visibleDataCheckedList";
            this.visibleDataCheckedList.Size = new System.Drawing.Size(122, 60);
            this.visibleDataCheckedList.TabIndex = 2;
            this.visibleDataCheckedList.SelectedValueChanged += new System.EventHandler(this.visibleDataCheckedList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Show/Hide Graph";
            // 
            // loadingBar
            // 
            this.loadingBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingBar.ForeColor = System.Drawing.Color.Aquamarine;
            this.loadingBar.Location = new System.Drawing.Point(12, 496);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(552, 11);
            this.loadingBar.TabIndex = 4;
            this.loadingBar.Visible = false;
            // 
            // openVideoButton
            // 
            this.openVideoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openVideoButton.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.openVideoButton.Location = new System.Drawing.Point(489, 439);
            this.openVideoButton.Name = "openVideoButton";
            this.openVideoButton.Size = new System.Drawing.Size(75, 23);
            this.openVideoButton.TabIndex = 5;
            this.openVideoButton.Text = "Watch";
            this.openVideoButton.UseVisualStyleBackColor = true;
            this.openVideoButton.Visible = false;
            this.openVideoButton.Click += new System.EventHandler(this.openVideoButton_Click);
            // 
            // distanceUnitComboBox
            // 
            this.distanceUnitComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.distanceUnitComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.distanceUnitComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distanceUnitComboBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.distanceUnitComboBox.ForeColor = System.Drawing.Color.White;
            this.distanceUnitComboBox.FormattingEnabled = true;
            this.distanceUnitComboBox.Items.AddRange(new object[] {
            "Meters",
            "Kilometers",
            "Feet",
            "Yards",
            "Miles"});
            this.distanceUnitComboBox.Location = new System.Drawing.Point(333, 437);
            this.distanceUnitComboBox.Name = "distanceUnitComboBox";
            this.distanceUnitComboBox.Size = new System.Drawing.Size(142, 23);
            this.distanceUnitComboBox.TabIndex = 7;
            this.distanceUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.distanceUnitComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(236, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Distance Unit:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "m/s",
            "kph",
            "mph"});
            this.comboBox1.Location = new System.Drawing.Point(333, 464);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 23);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.speedUnitComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(254, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Speed Unit:";
            // 
            // mapButton
            // 
            this.mapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mapButton.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.mapButton.Location = new System.Drawing.Point(489, 466);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(75, 23);
            this.mapButton.TabIndex = 11;
            this.mapButton.Text = "Map";
            this.mapButton.UseVisualStyleBackColor = true;
            this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(236, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Altitude Unit:";
            // 
            // altitudeComboBox
            // 
            this.altitudeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.altitudeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.altitudeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.altitudeComboBox.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.altitudeComboBox.ForeColor = System.Drawing.Color.White;
            this.altitudeComboBox.FormattingEnabled = true;
            this.altitudeComboBox.Items.AddRange(new object[] {
            "Meters",
            "Kilometers",
            "Feet",
            "Yards",
            "Miles"});
            this.altitudeComboBox.Location = new System.Drawing.Point(333, 409);
            this.altitudeComboBox.Name = "altitudeComboBox";
            this.altitudeComboBox.Size = new System.Drawing.Size(142, 23);
            this.altitudeComboBox.TabIndex = 12;
            this.altitudeComboBox.SelectedIndexChanged += new System.EventHandler(this.altitudeComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(576, 516);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.altitudeComboBox);
            this.Controls.Add(this.mapButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.distanceUnitComboBox);
            this.Controls.Add(this.openVideoButton);
            this.Controls.Add(this.loadingBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.visibleDataCheckedList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSelectMP4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DJI Flight Analyzer v1.0";
            //((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectMP4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox visibleDataCheckedList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar loadingBar;
        private System.Windows.Forms.Button openVideoButton;
        private System.Windows.Forms.ComboBox distanceUnitComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button mapButton;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox altitudeComboBox;
    }
}

