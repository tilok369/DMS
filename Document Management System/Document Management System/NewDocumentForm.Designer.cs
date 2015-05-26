namespace Document_Management_System
{
    partial class NewDocumentForm
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
            this.createOptionsPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.directory = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textRadioButton = new System.Windows.Forms.RadioButton();
            this.docxRadioButton = new System.Windows.Forms.RadioButton();
            this.docRadioButton = new System.Windows.Forms.RadioButton();
            this.odtRadioButton = new System.Windows.Forms.RadioButton();
            this.rtfRadioButton = new System.Windows.Forms.RadioButton();
            this.createOptionsPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createOptionsPanel
            // 
            this.createOptionsPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.createOptionsPanel.Controls.Add(this.label3);
            this.createOptionsPanel.Controls.Add(this.fileName);
            this.createOptionsPanel.Controls.Add(this.label2);
            this.createOptionsPanel.Controls.Add(this.label1);
            this.createOptionsPanel.Controls.Add(this.button2);
            this.createOptionsPanel.Controls.Add(this.checkBox1);
            this.createOptionsPanel.Controls.Add(this.button1);
            this.createOptionsPanel.Controls.Add(this.directory);
            this.createOptionsPanel.Controls.Add(this.groupBox1);
            this.createOptionsPanel.Location = new System.Drawing.Point(13, 0);
            this.createOptionsPanel.Name = "createOptionsPanel";
            this.createOptionsPanel.Size = new System.Drawing.Size(386, 228);
            this.createOptionsPanel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "e.g. your document location will be directory location+filename";
            // 
            // fileName
            // 
            this.fileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileName.Location = new System.Drawing.Point(166, 157);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(201, 20);
            this.fileName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "File Name(Without extension):";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select the folder where the document will be saved";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(292, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Create";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 206);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(185, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Open the document after creating";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(341, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // directory
            // 
            this.directory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.directory.Location = new System.Drawing.Point(16, 125);
            this.directory.Name = "directory";
            this.directory.Size = new System.Drawing.Size(319, 20);
            this.directory.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtfRadioButton);
            this.groupBox1.Controls.Add(this.odtRadioButton);
            this.groupBox1.Controls.Add(this.textRadioButton);
            this.groupBox1.Controls.Add(this.docxRadioButton);
            this.groupBox1.Controls.Add(this.docRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select the file format";
            // 
            // textRadioButton
            // 
            this.textRadioButton.AutoSize = true;
            this.textRadioButton.Location = new System.Drawing.Point(16, 66);
            this.textRadioButton.Name = "textRadioButton";
            this.textRadioButton.Size = new System.Drawing.Size(46, 17);
            this.textRadioButton.TabIndex = 2;
            this.textRadioButton.TabStop = true;
            this.textRadioButton.Text = "Text";
            this.textRadioButton.UseVisualStyleBackColor = true;
            this.textRadioButton.CheckedChanged += new System.EventHandler(this.textRadioButton_CheckedChanged);
            // 
            // docxRadioButton
            // 
            this.docxRadioButton.AutoSize = true;
            this.docxRadioButton.Location = new System.Drawing.Point(16, 43);
            this.docxRadioButton.Name = "docxRadioButton";
            this.docxRadioButton.Size = new System.Drawing.Size(50, 17);
            this.docxRadioButton.TabIndex = 1;
            this.docxRadioButton.TabStop = true;
            this.docxRadioButton.Text = "Docx";
            this.docxRadioButton.UseVisualStyleBackColor = true;
            this.docxRadioButton.CheckedChanged += new System.EventHandler(this.docxRadioButton_CheckedChanged);
            // 
            // docRadioButton
            // 
            this.docRadioButton.AutoSize = true;
            this.docRadioButton.Location = new System.Drawing.Point(16, 20);
            this.docRadioButton.Name = "docRadioButton";
            this.docRadioButton.Size = new System.Drawing.Size(45, 17);
            this.docRadioButton.TabIndex = 0;
            this.docRadioButton.TabStop = true;
            this.docRadioButton.Text = "Doc";
            this.docRadioButton.UseVisualStyleBackColor = true;
            this.docRadioButton.CheckedChanged += new System.EventHandler(this.docRadioButton_CheckedChanged);
            // 
            // odtRadioButton
            // 
            this.odtRadioButton.AutoSize = true;
            this.odtRadioButton.Location = new System.Drawing.Point(183, 19);
            this.odtRadioButton.Name = "odtRadioButton";
            this.odtRadioButton.Size = new System.Drawing.Size(42, 17);
            this.odtRadioButton.TabIndex = 3;
            this.odtRadioButton.TabStop = true;
            this.odtRadioButton.Text = "Odt";
            this.odtRadioButton.UseVisualStyleBackColor = true;
            this.odtRadioButton.CheckedChanged += new System.EventHandler(this.odtRadioButton_CheckedChanged);
            // 
            // rtfRadioButton
            // 
            this.rtfRadioButton.AutoSize = true;
            this.rtfRadioButton.Location = new System.Drawing.Point(183, 43);
            this.rtfRadioButton.Name = "rtfRadioButton";
            this.rtfRadioButton.Size = new System.Drawing.Size(39, 17);
            this.rtfRadioButton.TabIndex = 4;
            this.rtfRadioButton.TabStop = true;
            this.rtfRadioButton.Text = "Rtf";
            this.rtfRadioButton.UseVisualStyleBackColor = true;
            this.rtfRadioButton.CheckedChanged += new System.EventHandler(this.rtfRadioButton_CheckedChanged);
            // 
            // NewDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(413, 231);
            this.Controls.Add(this.createOptionsPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewDocumentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a new Document";
            this.createOptionsPanel.ResumeLayout(false);
            this.createOptionsPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel createOptionsPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox directory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton textRadioButton;
        private System.Windows.Forms.RadioButton docxRadioButton;
        private System.Windows.Forms.RadioButton docRadioButton;
        private System.Windows.Forms.RadioButton rtfRadioButton;
        private System.Windows.Forms.RadioButton odtRadioButton;

    }
}