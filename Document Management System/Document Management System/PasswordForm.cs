using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Document_Management_System
{
    public partial class PasswordForm : Form
    {
        FolderBrowserDialog folderDialog;
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            PasswordForm.ActiveForm.Dispose();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = folderDialog.SelectedPath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                newPasswordTextBox.PasswordChar = char.Parse("\0");
            }
            else
            {
                newPasswordTextBox.PasswordChar = '*';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                rePasswordTextBox.PasswordChar = char.Parse("\0");
            }
            else
            {
                rePasswordTextBox.PasswordChar = '*';
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }
    }
}
