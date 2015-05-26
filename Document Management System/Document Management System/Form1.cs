using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Document_Management_System
{
    public partial class DocManagement : Form
    {
        string RECENT_FILE_LIST_FILE_PATH = "";                  // holds the recent modified files by DOCUMENTMANAGEMENTSYSTEM
        string RECENT_FOLDER_LIST_FILE_PATH = "";                // holds the recent modified folders by DOCUMENTMANAGEMENTSYSTEM
        string DEFAULT_PATH = "";                                // default path of "DocumentManagement" folder
        List<string> RECENT_DIRECTORIES = new List<string>();    // holds the path of the recent directories
        List<string> RECENT_FILES = new List<string>();          // holds the path of the recent files
        List<PictureBox> picFolders = new List<PictureBox>();    // holds the recent updated folders
        List<Label> fileLabels = new List<Label>();              // holds the recent updated files
        string newDocumentFormat = ".doc";                       // format of the new created document
        string newDocumentPath = "";                             // path of the new created document
        string newDocumentName = "";                             // name of the new created document
        string tempPath = "";                                    // temporary path to hold the browse location
        bool isNewLocation = false;                              // check whether browse button click or not
        bool isFileListOpen = false;
        int docType = 1;                                         //1 for doc, 2 for docx 3 for txt, 4 for odt and 5 for rtf
        FileList fl;

        public DocManagement()
        {
            InitializeComponent();
            
            innerWorkingAreaPanel.Location = new Point(ClientSize.Width/2 - innerWorkingAreaPanel.Width/3, 30);
            comboBox1.Text = "DOC";
            CreateRootFolders(); // creates root folders for the first time
            UpdateRecentFolderAndFileList(); // create files to save the recent file and folder list
            ShowRecentFolders(); // shows recents folders
            ShowRecentFiles();   // show recent modified folders
            //this.MouseMove+=new MouseEventHandler(DocManagement_MouseMove);
            /*existingFoldersRadioButton.CheckedChanged += new EventHandler(existingFoldersRadioButton_Click);
            newFolderRadioButton.CheckedChanged += new EventHandler(newFolderRadioButton_Click);
            newLocationRadioButton.CheckedChanged += new EventHandler(newLocationRadioButton_Click);
            docRadioButton.CheckedChanged+=new EventHandler(docRadioButton_CheckedChanged);
            pdfRadioButton.CheckedChanged+=new EventHandler(pdfRadioButton_CheckedChanged);
            textRadioButton.CheckedChanged+=new EventHandler(textRadioButton_CheckedChanged);*/
            this.Click+=new EventHandler(DocManagement_Click);
            this.innerWorkingAreaPanel.Click += new EventHandler(DocManagement_Click);
        }

        public void UpdateRecentFolderAndFileList()
        {
            string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folderPath = folderPath.Replace("\\", "/") + "/DocumentManagement";
            RECENT_FILE_LIST_FILE_PATH = folderPath + "/recentFileList.txt";
            RECENT_FOLDER_LIST_FILE_PATH = folderPath + "/recentFolderList.txt";

            if (!File.Exists(RECENT_FOLDER_LIST_FILE_PATH))
                File.Create(RECENT_FOLDER_LIST_FILE_PATH);

            if (!File.Exists(RECENT_FILE_LIST_FILE_PATH))
                File.Create(RECENT_FILE_LIST_FILE_PATH);
        }

        public void CreateRootFolders()
        {
            string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folderPath = folderPath.Replace("\\", "/") + "/DocumentManagement";
            DEFAULT_PATH = folderPath;

            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

                string[] foldersName = { folderPath + "/Best Practices", folderPath + "/Finance", folderPath + "/Human Resource", folderPath + "/Legal", folderPath + "/Marketing", folderPath + "/Projects", folderPath + "/Sales" };
                for (int i = 0; i < foldersName.Length; i++)
                {
                    Directory.CreateDirectory(foldersName[i]);
                }
            }
        
        }

        public void DoAllBeforeCreate()
        {

            createOptionsPanel.Visible = true;
            string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folderPath = folderPath.Replace("\\", "/") + "/DocumentManagement";
            string[] directories = Directory.GetDirectories(folderPath);
            string[] foldernames = new string[directories.Length];

            for (int i = 0; i < directories.Length; i++)
            {
                int f = directories[i].LastIndexOf("\\");
                int l = directories[i].Length;
                string folder = directories[i].Substring(f + 1, l - f - 1);
                foldernames[i] = folder;
            }
            //folderComboBox.Items.AddRange(foldernames);
        }

        public void ShowRecentFolders()
        {
            try
            {
                int px = 50, py = 400, lx = 50, ly = 460;
                string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                folderPath = folderPath.Replace("\\", "/") + "/DocumentManagement";
                string[] directorie = Directory.GetDirectories(folderPath);
                List<DateTime> date = new List<DateTime>();

                string[] folderList = File.ReadAllLines(RECENT_FOLDER_LIST_FILE_PATH);

                string[] directories = new string[directorie.Length + folderList.Length];

                directorie.CopyTo(directories, 0);
                folderList.CopyTo(directories, directorie.Length);

                for (int j = 0; j < directories.Length; j++)
                {
                    DirectoryInfo fi1 = new DirectoryInfo(directories[j]);
                    DateTime created = fi1.LastWriteTime;
                    date.Add(created);
                }



                for (int m = 0; m < directories.Length; m++)
                {
                    for (int n = m + 1; n < directories.Length; n++)
                    {
                        DateTime temp = new DateTime();
                        string stemp = "";
                        if (date[m] < date[n])
                        {
                            temp = date[m];
                            date[m] = date[n];
                            date[n] = temp;

                            stemp = directories[m];
                            directories[m] = directories[n];
                            directories[n] = stemp;
                        }
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    RECENT_DIRECTORIES.Add(directories[i]);
                    int f = directories[i].LastIndexOf("\\");
                    int l = directories[i].Length;
                    string folder = directories[i].Substring(f + 1, l - f - 1);
                    PictureBox pic = new PictureBox();
                    pic.Image = global::Document_Management_System.Properties.Resources.folder;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Location = new Point(px, py);
                    pic.Width = 65;
                    pic.Height = 55;
                    pic.MouseEnter += new EventHandler(pic_MouseEnter);
                    pic.MouseLeave += new EventHandler(pic_MouseLeave);
                    pic.Click += new EventHandler(pic_Click);
                    this.innerWorkingAreaPanel.Controls.Add(pic);
                    picFolders.Add(pic);
                    px += 100;
                    Label lbl = new Label();
                    lbl.Location = new Point(lx, ly);
                    lbl.Text = folder;
                    lbl.ForeColor = Color.White;
                    this.innerWorkingAreaPanel.Controls.Add(lbl);
                    lx += 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public List<string> GetFiles(string folderPath)
        {
            List<string> allFiles = new List<string>();

            foreach (string directory in Directory.GetDirectories(folderPath))
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    if (file.ToLower().Contains(".txt") || file.ToLower().Contains(".pdf") || file.ToLower().Contains(".doc"))   // only add header.php file in the list
                    {
                        allFiles.Add(file);
                    }
                }

                GetFiles(directory);
            }

            return allFiles;

        }

        public void ShowRecentFiles()
        {
            try
            {
                int x=10,y=20;
                string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                folderPath = folderPath.Replace("\\", "/") + "/DocumentManagement";
                string[] directories = Directory.GetDirectories(folderPath);

                List<string> allFiles = new List<string>();

                for (int i = 0; i < directories.Length; i++)
                {
                    directories[i] = directories[i].Replace("\\", "/");
                    string[] files = Directory.GetFiles(directories[i]);

                    for (int j = 0; j < files.Length; j++)
                    {
                        if (files[j].Contains(".txt") || files[j].Contains(".doc") || files[j].Contains(".docx") || files[j].Contains(".pdf"))
                        {
                            allFiles.Add(files[j]);
                        }
                    }
                    List<string> list = GetFiles(directories[i]);
                    allFiles.AddRange(list);
                }

                string[] fileList = File.ReadAllLines(RECENT_FILE_LIST_FILE_PATH);

                for (int k = 0; k < fileList.Length; k++)
                {
                    allFiles.Add(fileList[k]);
                }

                List<DateTime> date = new List<DateTime>();

                for (int j = 0; j < allFiles.Count; j++)
                {
                    FileInfo fi1 = new FileInfo(allFiles[j]);
                    DateTime created = fi1.LastWriteTime;
                    date.Add(created);
                }

                for (int m = 0; m < allFiles.Count; m++)
                {
                    for (int n = m + 1; n < allFiles.Count; n++)
                    {
                        DateTime temp = new DateTime();
                        string stemp = "";
                        if (date[m] < date[n])
                        {
                            temp = date[m];
                            date[m] = date[n];
                            date[n] = temp;

                            stemp = allFiles[m];
                            allFiles[m] = allFiles[n];
                            allFiles[n] = stemp;
                        }
                    }
                }

                if (allFiles.Count >= 6)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        RECENT_FILES.Add(allFiles[k]);
                        Label lbl = new Label();
                        string text = allFiles[k].Substring(allFiles[k].Length - 20, 20).Replace("\\", "/");
                        System.Drawing.Font font = new System.Drawing.Font("Calibri", 10.0f);
                        lbl.Font = font;
                        lbl.Text = ".." + text;
                        lbl.Location = new Point(x, y);
                        lbl.Width = 155;
                        lbl.MouseEnter+=new EventHandler(lbl_MouseEnter);
                        lbl.MouseLeave += new EventHandler(lbl_MouseLeave);
                        lbl.Click+=new EventHandler(lbl_Click);
                        y += 45;
                        fileLabels.Add(lbl);
                        this.outerSidePanel.Controls.Add(lbl);
                    }
                }
                else
                {
                    for (int k = 0; k < allFiles.Count; k++)
                    {
                        RECENT_FILES.Add(allFiles[k]);
                        Label lbl = new Label();
                        string text = allFiles[k].Substring(allFiles[k].Length - 20, 20).Replace("\\", "/");
                        System.Drawing.Font font = new System.Drawing.Font("Calibri", 10.0f);
                        lbl.Font = font;
                        lbl.Location = new Point(x, y);
                        lbl.Width = 155;
                        lbl.Text = ".." + text;
                        lbl.MouseEnter += new EventHandler(lbl_MouseEnter);
                        lbl.MouseLeave+=new EventHandler(lbl_MouseLeave);
                        lbl.Click += new EventHandler(lbl_Click);
                        y += 45;
                        fileLabels.Add(lbl);
                        this.outerSidePanel.Controls.Add(lbl);                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public void OpenWordDocument(string path)
        {
            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();

            try
            {
                Document doc = ap.Documents.Open(path, ReadOnly: false, Visible: false);
                doc.Activate();

                Selection sel = ap.Selection;

                if (sel != null)
                {
                    switch (sel.Type)
                    {
                        case WdSelectionType.wdSelectionIP:
                            //sel.TypeText(DateTime.Now.ToString());
                            //sel.TypeParagraph();
                            break;

                        default:
                            MessageBox.Show("Selection type not handled; no writing done");
                            break;

                    }

                    // Remove all meta data.
                    doc.RemoveDocumentInformation(WdRemoveDocInfoType.wdRDIAll);

                    ap.Documents.Save(NoPrompt: true, OriginalFormat: true);

                }
                else
                {
                    Console.WriteLine("Unable to acquire Selection...no writing to document done..");
                }

                ap.Documents.Close(SaveChanges: false, OriginalFormat: false, RouteDocument: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                ((_Application)ap).Quit(SaveChanges: false, OriginalFormat: false, RouteDocument: false);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(ap);
            }


        }

        private void createButton_Click(object sender, EventArgs e)
        {
            DoAllBeforeCreate();
        }

        private void DocManagement_Click(object sender, EventArgs e)
        {
            if (isFileListOpen)
            {
                isFileListOpen = false;
                fl.Dispose();
            }
        }

        private void pic_MouseEnter(object sender, EventArgs e)
        {
            Point mousePosition = this.PointToClient(Cursor.Position);
            //MessageBox.Show("mouse:" + mousePosition.X + " " + mousePosition.Y + " pic:" + picFolders[0].Location.X + " " + picFolders[0].Location.Y + " client:" + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3));
            for (int i = 0; i < picFolders.Count; i++)
            {
                if ((mousePosition.X >= picFolders[i].Location.X + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) - 140 && mousePosition.X <= picFolders[i].Location.X + picFolders[i].Width + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) - 140) && (mousePosition.Y >= picFolders[i].Location.Y +  30 && mousePosition.Y <= picFolders[i].Location.Y + picFolders[i].Height + 30))
                {
                    picFolders[i].Image = global::Document_Management_System.Properties.Resources.open_folder;
                    picFolders[i].Cursor = Cursors.Hand;
                    
                }
                else
                {
                    picFolders[i].Image = global::Document_Management_System.Properties.Resources.folder;
                }
            }
        }

        private void pic_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < picFolders.Count; i++)
            {
                picFolders[i].Image = global::Document_Management_System.Properties.Resources.folder;
            }
        }

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            Point mousePosition = this.PointToClient(Cursor.Position);
            //MessageBox.Show("mouse: " + mousePosition.X + " " + mousePosition.Y + " width: " + (fileLabels[0].Location.X + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) + outerSidePanel.Location.X - 145) + " " + (fileLabels[0].Location.Y + panel2.Height + label11.Height + 20));
            for (int i = 0; i < fileLabels.Count; i++)
            {
                if ((mousePosition.X >= fileLabels[i].Location.X + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) + outerSidePanel.Location.X - 145 && mousePosition.X <= fileLabels[i].Location.X + fileLabels[i].Width + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) + outerSidePanel.Location.X - 145) && (mousePosition.Y >= fileLabels[i].Location.Y + panel2.Height + label11.Height + 90 && mousePosition.Y <= fileLabels[i].Location.Y + fileLabels[i].Height + panel2.Height + label11.Height + 90))
                {
                    fileLabels[i].ForeColor = Color.White;
                    fileLabels[i].Font = new System.Drawing.Font("Calibri", 10.0f, FontStyle.Underline);
                    fileLabels[i].Cursor = Cursors.Hand;
                }
                else
                {
                    fileLabels[i].ForeColor = Color.Black;
                    fileLabels[i].Font = new System.Drawing.Font("Calibri", 10.0f, FontStyle.Regular);
                }
                //MessageBox.Show(fileLabels[i].Location.X + " " + fileLabels[i].Location.Y + " " + fileLabels[i].Width + " " + fileLabels[i].Height);
            }
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < fileLabels.Count; i++)
            {
                fileLabels[i].ForeColor = Color.Black;
                fileLabels[i].Font = new System.Drawing.Font("Calibri", 10.0f, FontStyle.Regular);
            }
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            Point mousePosition = this.PointToClient(Cursor.Position);
            //MessageBox.Show("mouse: " + mousePosition.X + " " + mousePosition.Y + " width: " + (fileLabels[0].Location.X + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) + outerSidePanel.Location.X - 145) + " " + (fileLabels[0].Location.Y + panel2.Height + label11.Height + 100));
            for (int i = 0; i < fileLabels.Count; i++)
            {
                if ((mousePosition.X >= fileLabels[i].Location.X + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) + outerSidePanel.Location.X - 145 && mousePosition.X <= fileLabels[i].Location.X + fileLabels[i].Width + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) + outerSidePanel.Location.X - 145) && (mousePosition.Y >= fileLabels[i].Location.Y + panel2.Height + label11.Height + 90 && mousePosition.Y <= fileLabels[i].Location.Y + fileLabels[i].Height + panel2.Height + label11.Height + 90))
                {
                    System.Diagnostics.Process.Start(RECENT_FILES[i].Replace("\\", "/"));
                    //MessageBox.Show(RECENT_FILES[i]);
                }
            }
        }

        private void newLocationButton_Click(object sender, EventArgs e)
        {
          
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoAllBeforeCreate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogCSV = new OpenFileDialog();

            openFileDialogCSV.InitialDirectory = System.Windows.Forms.Application.ExecutablePath.ToString();
            openFileDialogCSV.Filter = "Text files (*.txt)|*.txt|Document files (*.doc)|*.doc|All files (*.*)|*.*";
            openFileDialogCSV.FilterIndex = 1;
            openFileDialogCSV.RestoreDirectory = true;

            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                //this.filePathTextBox.Text = openFileDialogCSV.FileName.ToString();
                //filePath = openFileDialogCSV.FileName.ToString();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog(); //new file dialog box taken
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|Document files (*.doc)|*.doc|All files (*.*)|*.*";             //to show the csv option
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)            //shows the window to save file 
            {

                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(fs);

                /*int i = 0;
                while (i < fileContent.Count)
                {
                    writer.WriteLine(fileContent[i]);
                    i++;
                }*/
                writer.Close();
                fs.Close();

            }
        }

        /*private void existingFoldersRadioButton_Click(object sender, EventArgs e)
        {
            if (existingFoldersRadioButton.Checked)
                folderComboBox.Enabled = true;
            else
                folderComboBox.Enabled = false;
        }

        private void newFolderRadioButton_Click(object sender, EventArgs e)
        {
            if (newFolderRadioButton.Checked)
                newFolderTextBox.Enabled = true;
            else
                newFolderTextBox.Enabled = false;
        }

        private void newLocationRadioButton_Click(object sender, EventArgs e)
        {
            if (newLocationRadioButton.Checked)
                newLocationButton.Enabled = true;
            else
                newLocationButton.Enabled = false;
        }

        private void docRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (docRadioButton.Checked)
                newDocumentFormat = ".doc";
        }

        private void pdfRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (pdfRadioButton.Checked)
                newDocumentFormat = ".docx";
        }

        private void textRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (textRadioButton.Checked)
                newDocumentFormat = ".txt";
        }

        private void finalCreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (existingFoldersRadioButton.Checked)
                {
                    newDocumentPath = folderComboBox.SelectedItem.ToString();
                }
                else if (newFolderRadioButton.Checked)
                {
                    newDocumentPath = newFolderTextBox.Text;
                    Directory.CreateDirectory(DEFAULT_PATH + "/" + newDocumentPath);
                }
                else
                {
                    newDocumentPath = tempPath;
                }

                newDocumentName = fileNameTextBox.Text;

                if ((newDocumentFormat.Length < 1 || newDocumentName.Length < 1 || newDocumentPath.Length < 1) && !isNewLocation)
                {
                    MessageBox.Show("Please Select file format, file path and file name properly", "Error in Input!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!isNewLocation)
                    {
                        if (newDocumentFormat == ".doc" || newDocumentFormat == ".docx")
                        {
                            System.IO.File.WriteAllText(DEFAULT_PATH + "/" + newDocumentPath + "/" + newDocumentName + newDocumentFormat, "");
                            OpenWordDocument(DEFAULT_PATH + "/" + newDocumentPath + "/" + newDocumentName + newDocumentFormat);
                            System.Diagnostics.Process.Start(DEFAULT_PATH + "/" + newDocumentPath + "/" + newDocumentName + newDocumentFormat);
                        }
                        else
                        {
                            System.IO.File.WriteAllText(DEFAULT_PATH + "/" + newDocumentPath + "/" + newDocumentName + newDocumentFormat, "");
                            System.Diagnostics.Process.Start(DEFAULT_PATH + "/" + newDocumentPath + "/" + newDocumentName + newDocumentFormat);
                        }
                        
                    }
                    else
                    {
                        if (newDocumentPath.Contains(".doc") || newDocumentPath.Contains(".docx"))
                        {
                            System.IO.File.WriteAllText(newDocumentPath, "");
                            OpenWordDocument(newDocumentPath);
                            System.Diagnostics.Process.Start(newDocumentPath);
                        }
                        else
                        {
                            System.IO.File.WriteAllText(newDocumentPath, "");
                            System.Diagnostics.Process.Start(newDocumentPath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void newLocationButton_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog(); //new file dialog box taken
            saveFileDialog1.Filter = "Files (*" + newDocumentFormat + ")|*" + newDocumentFormat + "|All files (*.*)|*.*";            //to show the csv option
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)            //shows the window to save file 
            {
                tempPath = saveFileDialog1.FileName;
                isNewLocation = true;
                fileNameTextBox.Enabled = false;
            }
        }*/

        private void pic_Click(object sender, EventArgs e)
        {
            if (isFileListOpen)
            {
                isFileListOpen = false;
                fl.Dispose();
            }

            Point mousePosition = this.PointToClient(Cursor.Position);

            for (int i = 0; i < picFolders.Count; i++)
            {
                if ((mousePosition.X >= picFolders[i].Location.X + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) - 140 && mousePosition.X <= picFolders[i].Location.X + picFolders[i].Width + (ClientSize.Width / 2 - innerWorkingAreaPanel.Width / 3) - 140) && (mousePosition.Y >= picFolders[i].Location.Y + 30 && mousePosition.Y <= picFolders[i].Location.Y + picFolders[i].Height + 30))
                {
                    List<string> allFiles = new List<string>();
                    RECENT_DIRECTORIES[i] = RECENT_DIRECTORIES[i].Replace("\\", "/");
                    string[] files = Directory.GetFiles(RECENT_DIRECTORIES[i]);

                    for (int j = 0; j < files.Length; j++)
                    {
                        if (files[j].Contains(".txt") || files[j].Contains(".doc") || files[j].Contains(".docx") || files[j].Contains(".pdf"))
                        {
                            allFiles.Add(files[j]);
                        }
                    }
                    List<string> list = GetFiles(RECENT_DIRECTORIES[i]);
                    allFiles.AddRange(list);

                    Point point = new Point(Cursor.Position.X, Cursor.Position.Y);
                    isFileListOpen = true;
                    fl = new FileList(point, allFiles);
                    fl.Show();
                }
                else
                {
                    //picFolders[i].Image = global::Document_Management_System.Properties.Resources.folder;
                }
            }
        }
        
        private void setPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void removePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void setPasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new PasswordForm().Show();
        }

        private void unsetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnsetPasswordForm().Show();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewDocumentForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)  // create files to a choosen format
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

                string filepath = System.IO.Path.Combine(directory.Text, fileName.Text+"."+extension);

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
                            if(!folderList.Contains(directory.Text))
                                writer1.WriteLine(directory.Text);
                            writer1.Close();
                        }

                        string[] fileList = File.ReadAllLines(RECENT_FILE_LIST_FILE_PATH);

                        using (StreamWriter writer2 = File.AppendText(RECENT_FILE_LIST_FILE_PATH))
                        {
                            if(!fileList.Contains(filepath))
                                writer2.WriteLine(filepath);
                            writer2.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Characters in the file name!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

        private void txtRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (txtRadioButton.Checked)
            {
                docType = 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fldrDialog = new FolderBrowserDialog();
            if (fldrDialog.ShowDialog() == DialogResult.OK)
            {
                directory.Text = fldrDialog.SelectedPath;
            }
        }

        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConvertDocument().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filterText = "";
            if (comboBox1.Text == "DOC")
            {
                filterText = "Document files (*.doc)|*.doc";
            }
            else if (comboBox1.Text == "DOCX")
            {
                filterText = "Document files (*.docx)|*.docx";
            }
            else if (comboBox1.Text == "PDF")
            {
                filterText = "Portable Document files (*.pdf)|*.pdf";
            }
            else
            {
                filterText = "Text files (*.txt)|*.txt";
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filterText;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileList.Items.Add(ofd.FileName);
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
