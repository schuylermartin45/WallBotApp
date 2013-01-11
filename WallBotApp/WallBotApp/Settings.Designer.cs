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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.fileFormatBox = new System.Windows.Forms.ComboBox();
            this.vidSetBtn = new System.Windows.Forms.Button();
            this.audDevBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // vidDevBox
            // 
            this.vidDevBox.FormattingEnabled = true;
            this.vidDevBox.Location = new System.Drawing.Point(95, 3);
            this.vidDevBox.Name = "vidDevBox";
            this.vidDevBox.Size = new System.Drawing.Size(262, 21);
            this.vidDevBox.TabIndex = 0;
            // 
            // audioDevBox
            // 
            this.audioDevBox.FormattingEnabled = true;
            this.audioDevBox.Location = new System.Drawing.Point(95, 3);
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
            this.panel1.Size = new System.Drawing.Size(360, 29);
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
            this.panel2.Size = new System.Drawing.Size(360, 33);
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
            this.pathBox.Location = new System.Drawing.Point(95, 28);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(262, 20);
            this.pathBox.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pathBox);
            this.panel3.Controls.Add(this.browseBtn);
            this.panel3.Location = new System.Drawing.Point(12, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 51);
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
            this.panel4.Location = new System.Drawing.Point(15, 220);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(357, 30);
            this.panel4.TabIndex = 6;
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
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.fileFormatBox);
            this.panel5.Location = new System.Drawing.Point(12, 86);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(360, 33);
            this.panel5.TabIndex = 3;
            this.panel5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "File format:";
            // 
            // fileFormatBox
            // 
            this.fileFormatBox.FormattingEnabled = true;
            this.fileFormatBox.Items.AddRange(new object[] {
            ".wmv",
            ".mp4",
            ".avi"});
            this.fileFormatBox.Location = new System.Drawing.Point(95, 3);
            this.fileFormatBox.Name = "fileFormatBox";
            this.fileFormatBox.Size = new System.Drawing.Size(61, 21);
            this.fileFormatBox.TabIndex = 1;
            // 
            // vidSetBtn
            // 
            this.vidSetBtn.ForeColor = System.Drawing.Color.Black;
            this.vidSetBtn.Location = new System.Drawing.Point(12, 191);
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
            this.audDevBtn.Location = new System.Drawing.Point(220, 191);
            this.audDevBtn.Name = "audDevBtn";
            this.audDevBtn.Size = new System.Drawing.Size(149, 23);
            this.audDevBtn.TabIndex = 8;
            this.audDevBtn.Text = "Audio Device Settings";
            this.audDevBtn.UseVisualStyleBackColor = true;
            this.audDevBtn.Click += new System.EventHandler(this.audDevBtn_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(308, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(384, 262);
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
        private System.Windows.Forms.ComboBox fileFormatBox;
        private System.Windows.Forms.Button vidSetBtn;
        private System.Windows.Forms.Button audDevBtn;
        private System.Windows.Forms.Button button1;
    }
}