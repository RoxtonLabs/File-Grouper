namespace File_Grouper
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.patternBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupUpdown = new System.Windows.Forms.NumericUpDown();
            this.copyProgress = new System.Windows.Forms.ProgressBar();
            this.groupButton = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupUpdown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browseButton);
            this.groupBox1.Controls.Add(this.dirBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select the folder containing the files you wish to group:";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(206, 19);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // dirBox
            // 
            this.dirBox.Location = new System.Drawing.Point(7, 21);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(193, 20);
            this.dirBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.patternBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enter a search pattern (leave empty to match all):";
            // 
            // patternBox
            // 
            this.patternBox.Location = new System.Drawing.Point(6, 19);
            this.patternBox.Name = "patternBox";
            this.patternBox.Size = new System.Drawing.Size(275, 20);
            this.patternBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupUpdown);
            this.groupBox3.Location = new System.Drawing.Point(13, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 49);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Choose the number of groups:";
            // 
            // groupUpdown
            // 
            this.groupUpdown.Location = new System.Drawing.Point(7, 20);
            this.groupUpdown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.groupUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.groupUpdown.Name = "groupUpdown";
            this.groupUpdown.Size = new System.Drawing.Size(274, 20);
            this.groupUpdown.TabIndex = 0;
            this.groupUpdown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.groupUpdown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // copyProgress
            // 
            this.copyProgress.Location = new System.Drawing.Point(20, 177);
            this.copyProgress.Name = "copyProgress";
            this.copyProgress.Size = new System.Drawing.Size(193, 23);
            this.copyProgress.TabIndex = 3;
            // 
            // groupButton
            // 
            this.groupButton.Location = new System.Drawing.Point(219, 177);
            this.groupButton.Name = "groupButton";
            this.groupButton.Size = new System.Drawing.Size(75, 23);
            this.groupButton.TabIndex = 4;
            this.groupButton.Text = "Group";
            this.groupButton.UseVisualStyleBackColor = true;
            this.groupButton.Click += new System.EventHandler(this.groupButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 213);
            this.Controls.Add(this.copyProgress);
            this.Controls.Add(this.groupButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Group files by size";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupUpdown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox dirBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox patternBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown groupUpdown;
        private System.Windows.Forms.ProgressBar copyProgress;
        private System.Windows.Forms.Button groupButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}

