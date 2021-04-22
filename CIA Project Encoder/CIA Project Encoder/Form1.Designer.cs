namespace CIA_Project_Encoder
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
            this.picBoxStart = new System.Windows.Forms.PictureBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.txtBoxMessage = new System.Windows.Forms.RichTextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picBoxEnd = new System.Windows.Forms.PictureBox();
            this.fileBrowse = new System.Windows.Forms.OpenFileDialog();
            this.fileSave = new System.Windows.Forms.SaveFileDialog();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblCharCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxStart)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxStart
            // 
            this.picBoxStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxStart.Location = new System.Drawing.Point(7, 41);
            this.picBoxStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxStart.Name = "picBoxStart";
            this.picBoxStart.Size = new System.Drawing.Size(285, 269);
            this.picBoxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxStart.TabIndex = 0;
            this.picBoxStart.TabStop = false;
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(42, 362);
            this.btnEncode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(131, 58);
            this.btnEncode.TabIndex = 2;
            this.btnEncode.Text = "Encode Message";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // txtBoxMessage
            // 
            this.txtBoxMessage.Location = new System.Drawing.Point(248, 367);
            this.txtBoxMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxMessage.MaxLength = 256;
            this.txtBoxMessage.Name = "txtBoxMessage";
            this.txtBoxMessage.Size = new System.Drawing.Size(235, 84);
            this.txtBoxMessage.TabIndex = 3;
            this.txtBoxMessage.Text = "";
            this.txtBoxMessage.TextChanged += new System.EventHandler(this.txtBoxMessage_TextChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(300, 351);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(119, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Encode Message Here:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(548, 362);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 58);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Encoded Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(718, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // picBoxEnd
            // 
            this.picBoxEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxEnd.Location = new System.Drawing.Point(422, 41);
            this.picBoxEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxEnd.Name = "picBoxEnd";
            this.picBoxEnd.Size = new System.Drawing.Size(285, 269);
            this.picBoxEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxEnd.TabIndex = 7;
            this.picBoxEnd.TabStop = false;
            // 
            // fileBrowse
            // 
            this.fileBrowse.FileName = "openFileDialog1";
            this.fileBrowse.Filter = "PPM Files|*.ppm";
            // 
            // fileSave
            // 
            this.fileSave.Filter = "PPM Files|*.ppm";
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Enabled = false;
            this.lblSave.Location = new System.Drawing.Point(548, 315);
            this.lblSave.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(60, 13);
            this.lblSave.TabIndex = 8;
            this.lblSave.Text = "File Saved!";
            // 
            // lblCharCount
            // 
            this.lblCharCount.AutoSize = true;
            this.lblCharCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblCharCount.Enabled = false;
            this.lblCharCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCharCount.Location = new System.Drawing.Point(344, 453);
            this.lblCharCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.Size = new System.Drawing.Size(36, 13);
            this.lblCharCount.TabIndex = 9;
            this.lblCharCount.Text = "0/256";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Original Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Encoded Image:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 473);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCharCount);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.picBoxEnd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtBoxMessage);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.picBoxStart);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Encoder";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxStart)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxStart;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.RichTextBox txtBoxMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.PictureBox picBoxEnd;
        private System.Windows.Forms.OpenFileDialog fileBrowse;
        private System.Windows.Forms.SaveFileDialog fileSave;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblCharCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

