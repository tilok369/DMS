using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Document_Management_System
{
    public partial class NewDocumentForm : Form
    {
        string RECENT_FILE_LIST_FILE_PATH = "";                  // holds the recent modified files by DOCUMENTMANAGEMENTSYSTEM
        string RECENT_FOLDER_LIST_FILE_PATH = "";                // holds the recent modified folders by DOCUMENTMANAGEMENTSYSTEM
        int docType = 1;                                         //1 for doc, 2 for docx 3 for txt, 4 for odt and 5 for rtf

        public NewDocumentForm()
        {
            InitializeComponent();
            UpdateRecentFolderAndFileList();
        }

        public void UpdateRecentFolderAndFileList()
        {
            string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folderPath = folderPath.Replace("\\", "/") + "/DocumentManagement";
            RECENT_FILE_LIST_FILE_PATH = folderPath + "/recentFileList.txt";
            RECENT_FOLDER_LIST_FILE_PATH = folderPath + "/recentFolderList.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fldrDialog = new FolderBrowserDialog();
            if (fldrDialog.ShowDialog() == DialogResult.OK)
            {
                directory.Text = fldrDialog.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (directory.Text != "" && fileName.Text != "")
            {
                string extension = "";
                if (docType == 1)
                {
                    extension = "doc";
                }
                else if (docType == 2)
                {
                    extension = "docx";
                }
                else if (docType == 3)
                {
                    extension = "txt";
                }
                else if (docType == 4)
                {
                    extension = "odt";
                }
                else if (docType == 5)
                {
                    extension = "rtf";
                }

                string filepath = System.IO.Path.Combine(directory.Text, fileName.Text + "." + extension);

                if (filepath.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1)
                {
                    if (!System.IO.File.Exists(filepath))
                    {
                        try
                        {
                            TextWriter tw = new StreamWriter(filepath);
                            tw.Close();

                            if (checkBox1.Checked)
                            {
                                System.Diagnostics.Process.Start(filepath);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }

                        string[] folderList = File.ReadAllLines(RECENT_FOLDER_LIST_FILE_PATH);

                        using (StreamWriter writer1 = File.AppendText(RECENT_FOLDER_LIST_FILE_PATH))
                        {
                            if (!folderList.Contains(directory.Text))
                                writer1.WriteLine(directory.Text);
                            writer1.Close();
                        }

                        string[] fileList = File.ReadAllLines(RECENT_FILE_LIST_FILE_PATH);

                        using (StreamWriter writer2 = File.AppendText(RECENT_FILE_LIST_FILE_PATH))
                        {
                            if (!fileList.Contains(filepath))
                                writer2.WriteLine(filepath);
                            writer2.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Characters in the file name!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void docRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (docRadioButton.Checked)
            {
                docType = 1;
            }
        }

        private void docxRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (docxRadioButton.Checked)
            {
                docType = 2;
            }
        }

        private void textRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (textRadioButton.Checked)
            {
                docType = 3;
            }
        }

        private void odtRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (odtRadioButton.Checked)
            {
                docType = 4;
            }
        }

        private void rtfRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rtfRadioButton.Checked)
            {
                docType = 5;
            }
        }
    }
}
