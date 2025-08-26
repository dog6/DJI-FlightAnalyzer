namespace DroneFlightAnalyzer
{
    partial class MapSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapSettingsForm));
            this.videoEncoderComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.fontComboBox = new System.Windows.Forms.ComboBox();
            this.selectOutputFolderButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fastSpeedColorSelector = new System.Windows.Forms.Panel();
            this.normalSpeedColorSelector = new System.Windows.Forms.Panel();
            this.slowSpeedColorSelector = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.normalSpeedTextBox = new System.Windows.Forms.TextBox();
            this.slowSpeedTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoEncoderComboBox
            // 
            this.videoEncoderComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoEncoderComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoEncoderComboBox.ForeColor = System.Drawing.Color.White;
            this.videoEncoderComboBox.FormattingEnabled = true;
            this.videoEncoderComboBox.Items.AddRange(new object[] {
            "h264_nvenc",
            "h264_amf",
            "hevc_amf",
            "h264_vaapi",
            "hevc_vaapi",
            "libx264",
            "libx265"});
            this.videoEncoderComboBox.Location = new System.Drawing.Point(13, 59);
            this.videoEncoderComboBox.Name = "videoEncoderComboBox";
            this.videoEncoderComboBox.Size = new System.Drawing.Size(121, 23);
            this.videoEncoderComboBox.TabIndex = 0;
            this.videoEncoderComboBox.SelectedIndexChanged += new System.EventHandler(this.videoEncoderComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Video Encoder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 10F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Render Settings";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.fontComboBox);
            this.panel1.Controls.Add(this.selectOutputFolderButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.videoEncoderComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(182, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 309);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Font:";
            // 
            // fontComboBox
            // 
            this.fontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fontComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fontComboBox.ForeColor = System.Drawing.Color.White;
            this.fontComboBox.FormattingEnabled = true;
            this.fontComboBox.Items.AddRange(new object[] {
            "Arial",
            "Cascadia Code",
            "Impact",
            "Courier New",
            "Verdana",
            "Trebuchet",
            "Georgia",
            "Calibri",
            "Helvetica",
            "Segoe UI",
            "Corbel"});
            this.fontComboBox.Location = new System.Drawing.Point(13, 108);
            this.fontComboBox.Name = "fontComboBox";
            this.fontComboBox.Size = new System.Drawing.Size(121, 23);
            this.fontComboBox.TabIndex = 7;
            this.fontComboBox.SelectedIndexChanged += new System.EventHandler(this.fontComboBox_SelectedIndexChanged);
            // 
            // selectOutputFolderButton
            // 
            this.selectOutputFolderButton.ForeColor = System.Drawing.Color.Black;
            this.selectOutputFolderButton.Location = new System.Drawing.Point(136, 158);
            this.selectOutputFolderButton.Name = "selectOutputFolderButton";
            this.selectOutputFolderButton.Size = new System.Drawing.Size(34, 23);
            this.selectOutputFolderButton.TabIndex = 6;
            this.selectOutputFolderButton.Text = "...";
            this.selectOutputFolderButton.UseVisualStyleBackColor = true;
            this.selectOutputFolderButton.Click += new System.EventHandler(this.selectOutputFolderButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output folder:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(13, 160);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fastSpeedColorSelector);
            this.panel2.Controls.Add(this.normalSpeedColorSelector);
            this.panel2.Controls.Add(this.slowSpeedColorSelector);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.normalSpeedTextBox);
            this.panel2.Controls.Add(this.slowSpeedTextBox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 309);
            this.panel2.TabIndex = 5;
            // 
            // fastSpeedColorSelector
            // 
            this.fastSpeedColorSelector.BackColor = System.Drawing.Color.OrangeRed;
            this.fastSpeedColorSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fastSpeedColorSelector.Location = new System.Drawing.Point(93, 171);
            this.fastSpeedColorSelector.Name = "fastSpeedColorSelector";
            this.fastSpeedColorSelector.Size = new System.Drawing.Size(54, 15);
            this.fastSpeedColorSelector.TabIndex = 20;
            this.fastSpeedColorSelector.Click += new System.EventHandler(this.fastSpeedColorSelector_Clicked);
            // 
            // normalSpeedColorSelector
            // 
            this.normalSpeedColorSelector.BackColor = System.Drawing.Color.Lime;
            this.normalSpeedColorSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.normalSpeedColorSelector.Location = new System.Drawing.Point(93, 144);
            this.normalSpeedColorSelector.Name = "normalSpeedColorSelector";
            this.normalSpeedColorSelector.Size = new System.Drawing.Size(54, 15);
            this.normalSpeedColorSelector.TabIndex = 19;
            this.normalSpeedColorSelector.Click += new System.EventHandler(this.normalSpeedColorSelector_Clicked);
            // 
            // slowSpeedColorSelector
            // 
            this.slowSpeedColorSelector.BackColor = System.Drawing.Color.Yellow;
            this.slowSpeedColorSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.slowSpeedColorSelector.Location = new System.Drawing.Point(93, 119);
            this.slowSpeedColorSelector.Name = "slowSpeedColorSelector";
            this.slowSpeedColorSelector.Size = new System.Drawing.Size(54, 15);
            this.slowSpeedColorSelector.TabIndex = 18;
            this.slowSpeedColorSelector.Click += new System.EventHandler(this.slowSpeedColorSelector_Clicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "Fast Speed:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "Normal Speed:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Slow Speed:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(136, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "m/s";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(136, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "m/s";
            // 
            // normalSpeedTextBox
            // 
            this.normalSpeedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.normalSpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.normalSpeedTextBox.ForeColor = System.Drawing.Color.White;
            this.normalSpeedTextBox.Location = new System.Drawing.Point(93, 77);
            this.normalSpeedTextBox.Name = "normalSpeedTextBox";
            this.normalSpeedTextBox.Size = new System.Drawing.Size(40, 20);
            this.normalSpeedTextBox.TabIndex = 12;
            this.normalSpeedTextBox.TextChanged += new System.EventHandler(this.normalSpeedTextBox_TextChanged);
            // 
            // slowSpeedTextBox
            // 
            this.slowSpeedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.slowSpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slowSpeedTextBox.ForeColor = System.Drawing.Color.White;
            this.slowSpeedTextBox.Location = new System.Drawing.Point(93, 51);
            this.slowSpeedTextBox.Name = "slowSpeedTextBox";
            this.slowSpeedTextBox.Size = new System.Drawing.Size(40, 20);
            this.slowSpeedTextBox.TabIndex = 9;
            this.slowSpeedTextBox.TextChanged += new System.EventHandler(this.slowSpeedTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Normal Speed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Slow Speed:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 10F, System.Drawing.FontStyle.Underline);
            this.label5.Location = new System.Drawing.Point(5, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Flight Settings";
            // 
            // MapSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(373, 333);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cascadia Code", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapSettingsForm";
            this.Text = "Map Settings";
            this.Load += new System.EventHandler(this.MapSettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox videoEncoderComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button selectOutputFolderButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox fontComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox normalSpeedTextBox;
        private System.Windows.Forms.TextBox slowSpeedTextBox;
        private System.Windows.Forms.Panel fastSpeedColorSelector;
        private System.Windows.Forms.Panel normalSpeedColorSelector;
        private System.Windows.Forms.Panel slowSpeedColorSelector;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
    }
}