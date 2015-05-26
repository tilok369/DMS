namespace Document_Management_System
{
    partial class FileList
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
            this.fileListPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // fileListPanel
            // 
            this.fileListPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fileListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileListPanel.Location = new System.Drawing.Point(0, 0);
            this.fileListPanel.Name = "fileListPanel";
            this.fileListPanel.Size = new System.Drawing.Size(589, 325);
            this.fileListPanel.TabIndex = 0;
            // 
            // FileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(590, 325);
            this.Controls.Add(this.fileListPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileList";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FileList";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fileListPanel;
    }
}