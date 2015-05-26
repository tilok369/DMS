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
    public partial class FileList : Form
    {
        List<string> allFiles = new List<string>();
        List<Label> labels = new List<Label>();

        public FileList(Point point, List<string> allFiles)
        {
            InitializeComponent();
            this.allFiles = allFiles;
            SetLabels();
            this.Location = new Point(point.X, point.Y - this.Height);
            fileListPanel.Click+=new EventHandler(fileListPanel_Click);
        }

        public void SetLabels()
        {
            int x = 5, y = 25;

            try
            {
                this.Height = allFiles.Count * 60;
                fileListPanel.Height = this.Height;
                fileListPanel.Width = this.Width;

                for (int k = 0; k < allFiles.Count; k++)
                {
                    Label lbl = new Label();
                    string text = allFiles[k].Replace("\\", "/");
                    System.Drawing.Font font = new System.Drawing.Font("Calibri", 10.0f);
                    lbl.Font = font;
                    lbl.Location = new Point(x, y);
                    lbl.Width = 550;
                    lbl.Text = ".." + text;
                    lbl.MouseEnter += new EventHandler(lbl_MouseEnter);
                    lbl.MouseLeave += new EventHandler(lbl_MouseLeave);
                    lbl.Click+=new EventHandler(lbl_Click);
                    y += 45;
                    labels.Add(lbl);
                    this.fileListPanel.Controls.Add(lbl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void fileListPanel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            Point mousePosition = this.PointToClient(Cursor.Position);
            //MessageBox.Show(mousePosition.X + " " + mousePosition.Y);
            for (int i = 0; i < labels.Count; i++)
            {
                if ((mousePosition.X >= labels[i].Location.X && mousePosition.X <= labels[i].Location.X + labels[i].Width) && (mousePosition.Y >= labels[i].Location.Y && mousePosition.Y <= labels[i].Location.Y + labels[i].Height))
                {
                    this.Hide();
                    System.Diagnostics.Process.Start(allFiles[i].Replace("\\","/"));
                    this.Dispose();
                }
            }
        }

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            Point mousePosition = this.PointToClient(Cursor.Position);
            //MessageBox.Show(mousePosition.X + " " + mousePosition.Y);
            for (int i = 0; i < labels.Count; i++)
            {
                if ((mousePosition.X>=labels[i].Location.X && mousePosition.X<=labels[i].Location.X+labels[i].Width) && (mousePosition.Y>=labels[i].Location.Y && mousePosition.Y<=labels[i].Location.Y+labels[i].Height))
                {
                    labels[i].ForeColor = Color.Blue;
                    labels[i].Font = new System.Drawing.Font("Calibri", 10.0f, FontStyle.Underline);
                    labels[i].Cursor = Cursors.Hand;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                    labels[i].Font = new System.Drawing.Font("Calibri", 10.0f, FontStyle.Regular);
                }
                //MessageBox.Show(fileLabels[i].Location.X + " " + fileLabels[i].Location.Y + " " + fileLabels[i].Width + " " + fileLabels[i].Height);
            }
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].ForeColor = Color.Black;
                labels[i].Font = new System.Drawing.Font("Calibri", 10.0f, FontStyle.Regular);
            }
        }
    }
}
