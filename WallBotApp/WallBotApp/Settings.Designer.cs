namespace WallBotApp
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            this.vidDevBox = new System.Windows.Forms.ComboBox();
            this.audioDevBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.browseBtn = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cycleBox = new System.Windows.Forms.TextBox();
            this.refreshBox = new System.Windows.Forms.TextBox();
            this.percentSkinBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maxCbBox = new System.Windows.Forms.TextBox();
            this.maxCrBox = new System.Windows.Forms.TextBox();
            this.minCrBox = new System.Windows.Forms.TextBox();
            this.minCbBox = new System.Windows.Forms.TextBox();
            this.maxYBox = new System.Windows.Forms.TextBox();
            this.minYBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vidSetBtn = new System.Windows.Forms.Button();
            this.audDevBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // vidDevBox
            // 
            this.vidDevBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.vidDevBox.FormattingEnabled = true;
            this.vidDevBox.Location = new System.Drawing.Point(125, 5);
            this.vidDevBox.Name = "vidDevBox";
            this.vidDevBox.Size = new System.Drawing.Size(262, 21);
            this.vidDevBox.TabIndex = 0;
            // 
            // audioDevBox
            // 
            this.audioDevBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.audioDevBox.FormattingEnabled = true;
            this.audioDevBox.Location = new System.Drawing.Point(125, 6);
            this.audioDevBox.Name = "audioDevBox";
            this.audioDevBox.Size = new System.Drawing.Size(262, 21);
            this.audioDevBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.vidDevBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 29);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Video Device:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.audioDevBox);
            this.panel2.Location = new System.Drawing.Point(12, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 33);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Audio Device:";
            // 
            // browseBtn
            // 
            this.browseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browseBtn.ForeColor = System.Drawing.Color.Black;
            this.browseBtn.Location = new System.Drawing.Point(3, 26);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 3;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // pathBox
            // 
            this.pathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pathBox.Location = new System.Drawing.Point(95, 28);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(292, 20);
            this.pathBox.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pathBox);
            this.panel3.Controls.Add(this.browseBtn);
            this.panel3.Location = new System.Drawing.Point(12, 203);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 51);
            this.panel3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Save Message Location:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.cancelBtn);
            this.panel4.Controls.Add(this.saveBtn);
            this.panel4.Location = new System.Drawing.Point(12, 289);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(387, 30);
            this.panel4.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(338, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.ForeColor = System.Drawing.Color.Black;
            this.cancelBtn.Location = new System.Drawing.Point(198, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.ForeColor = System.Drawing.Color.Black;
            this.saveBtn.Location = new System.Drawing.Point(92, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cycleBox);
            this.panel5.Controls.Add(this.refreshBox);
            this.panel5.Controls.Add(this.percentSkinBox);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.maxCbBox);
            this.panel5.Controls.Add(this.maxCrBox);
            this.panel5.Controls.Add(this.minCrBox);
            this.panel5.Controls.Add(this.minCbBox);
            this.panel5.Controls.Add(this.maxYBox);
            this.panel5.Controls.Add(this.minYBox);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(12, 86);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(390, 111);
            this.panel5.TabIndex = 3;
            // 
            // cycleBox
            // 
            this.cycleBox.Location = new System.Drawing.Point(279, 73);
            this.cycleBox.Name = "cycleBox";
            this.cycleBox.Size = new System.Drawing.Size(105, 20);
            this.cycleBox.TabIndex = 19;
            // 
            // refreshBox
            // 
            this.refreshBox.Location = new System.Drawing.Point(279, 47);
            this.refreshBox.Name = "refreshBox";
            this.refreshBox.Size = new System.Drawing.Size(105, 20);
            this.refreshBox.TabIndex = 18;
            // 
            // percentSkinBox
            // 
            this.percentSkinBox.Location = new System.Drawing.Point(279, 21);
            this.percentSkinBox.Name = "percentSkinBox";
            this.percentSkinBox.Size = new System.Drawing.Size(105, 20);
            this.percentSkinBox.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(222, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "# Cycles:";
            this.toolTip1.SetToolTip(this.label12, "Number of cycles of the skin detection algorithm until confirmation.");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(206, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Refresh (ms):";
            this.toolTip1.SetToolTip(this.label11, "Refresh rate of skin-detection algorithm in miliseconds");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "MIN";
            this.toolTip1.SetToolTip(this.label10, "Minimum value to detect.\r\nShould be an integer >= 16 ");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Cb";
            this.toolTip1.SetToolTip(this.label9, "Blue component factor");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Cr";
            this.toolTip1.SetToolTip(this.label8, "Red component factor");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "% Skin:";
            this.toolTip1.SetToolTip(this.label7, "Percentage of skin that should be covered by the webcam screen\r\nThis is a floatin" +
                    "g-point value. An entry of 0.152 will read in as \"15.2%\" ");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Y";
            this.toolTip1.SetToolTip(this.label6, "Luminosity factor");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "MAX";
            this.toolTip1.SetToolTip(this.label5, "Maximum value to detect.\r\nShould be an integer <= 235");
            // 
            // maxCbBox
            // 
            this.maxCbBox.Location = new System.Drawing.Point(94, 73);
            this.maxCbBox.Name = "maxCbBox";
            this.maxCbBox.Size = new System.Drawing.Size(50, 20);
            this.maxCbBox.TabIndex = 8;
            // 
            // maxCrBox
            // 
            this.maxCrBox.Location = new System.Drawing.Point(150, 73);
            this.maxCrBox.Name = "maxCrBox";
            this.maxCrBox.Size = new System.Drawing.Size(50, 20);
            this.maxCrBox.TabIndex = 7;
            // 
            // minCrBox
            // 
            this.minCrBox.Location = new System.Drawing.Point(150, 47);
            this.minCrBox.Name = "minCrBox";
            this.minCrBox.Size = new System.Drawing.Size(50, 20);
            this.minCrBox.TabIndex = 6;
            // 
            // minCbBox
            // 
            this.minCbBox.Location = new System.Drawing.Point(94, 47);
            this.minCbBox.Name = "minCbBox";
            this.minCbBox.Size = new System.Drawing.Size(50, 20);
            this.minCbBox.TabIndex = 5;
            // 
            // maxYBox
            // 
            this.maxYBox.Location = new System.Drawing.Point(38, 73);
            this.maxYBox.Name = "maxYBox";
            this.maxYBox.Size = new System.Drawing.Size(50, 20);
            this.maxYBox.TabIndex = 4;
            // 
            // minYBox
            // 
            this.minYBox.Location = new System.Drawing.Point(38, 47);
            this.minYBox.Name = "minYBox";
            this.minYBox.Size = new System.Drawing.Size(50, 20);
            this.minYBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "YCbCr and Skin Recognition:";
            // 
            // vidSetBtn
            // 
            this.vidSetBtn.ForeColor = System.Drawing.Color.Black;
            this.vidSetBtn.Location = new System.Drawing.Point(12, 260);
            this.vidSetBtn.Name = "vidSetBtn";
            this.vidSetBtn.Size = new System.Drawing.Size(149, 23);
            this.vidSetBtn.TabIndex = 7;
            this.vidSetBtn.Text = "Video Device Settings";
            this.vidSetBtn.UseVisualStyleBackColor = true;
            this.vidSetBtn.Click += new System.EventHandler(this.vidSetBtn_Click);
            // 
            // audDevBtn
            // 
            this.audDevBtn.ForeColor = System.Drawing.Color.Black;
            this.audDevBtn.Location = new System.Drawing.Point(250, 260);
            this.audDevBtn.Name = "audDevBtn";
            this.audDevBtn.Size = new System.Drawing.Size(149, 23);
            this.audDevBtn.TabIndex = 8;
            this.audDevBtn.Text = "Audio Device Settings";
            this.audDevBtn.UseVisualStyleBackColor = true;
            this.audDevBtn.Click += new System.EventHandler(this.audDevBtn_Click);
            // 
            // Settings
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(414, 331);
            this.Controls.Add(this.audDevBtn);
            this.Controls.Add(this.vidSetBtn);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox vidDevBox;
        private System.Windows.Forms.ComboBox audioDevBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button vidSetBtn;
        private System.Windows.Forms.Button audDevBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maxCbBox;
        private System.Windows.Forms.TextBox maxCrBox;
        private System.Windows.Forms.TextBox minCrBox;
        private System.Windows.Forms.TextBox minCbBox;
        private System.Windows.Forms.TextBox maxYBox;
        private System.Windows.Forms.TextBox minYBox;
        private System.Windows.Forms.TextBox cycleBox;
        private System.Windows.Forms.TextBox refreshBox;
        private System.Windows.Forms.TextBox percentSkinBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}