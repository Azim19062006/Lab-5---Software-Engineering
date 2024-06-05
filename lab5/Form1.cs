using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.MidnightBlue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size((int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8), (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8));

            btn_select.Click += Click_On_BtnSelectFolder;
            lst_of_folder.DoubleClick += DoubleClick;
            dataGridViewFiles.CellDoubleClick += DataGridViewFiles_CellDoubleClick;
            btn_process.Click += Click_On_BtnProcessFiles;
        }

        private void Click_On_AboutMenuItem(object sender, EventArgs e)
        {
            MessageBox.Show("Developer: Mamatbaev Azim\nE-mail: mamatbaev_a@auca.kg\nGitHub: https://github.com", "Information about Developer");
        }

        private void Click_On_BtnSelectFolder(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_path.Text = folderBrowserDialog.SelectedPath;
                    LoadFolder(folderBrowserDialog.SelectedPath);
                    btn_process.Visible = true;
                }
            }
        }

        private void LoadFolder(string folderPath)
        {
            lst_of_folder.Items.Clear();
            dataGridViewFiles.Rows.Clear();
            dataGridViewFiles.Columns.Clear();

            dataGridViewFiles.Columns.Add("Name", "Name");
            dataGridViewFiles.Columns.Add("LastModified", "Last Modified");
            dataGridViewFiles.Columns.Add("Size", "Size (bytes)");
            dataGridViewFiles.Columns.Add("ProcessingTime", "Processing Time");

            try
            {
                string[] directories = Directory.GetDirectories(folderPath);
                foreach (var directory in directories)
                {
                    lst_of_folder.Items.Add(Path.GetFileName(directory));
                }

                string[] files = Directory.GetFiles(folderPath);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    dataGridViewFiles.Rows.Add(fileInfo.Name, fileInfo.LastWriteTime, fileInfo.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading folder contents: " + ex.Message);
            }
        }

        private void DoubleClick(object sender, EventArgs e)
        {
            if (lst_of_folder.SelectedItem != null)
            {
                string selectedFolderName = lst_of_folder.SelectedItem.ToString();
                string selectedFolderPath = Path.Combine(txt_path.Text, selectedFolderName);

                DirectoryInfo directoryInfo = new DirectoryInfo(selectedFolderPath);

                Form folderInfoForm = new Form
                {
                    Text = "Folder Info",
                    Size = new Size(300, 200)
                };

                Label lblFolderName = new Label
                {
                    Text = "Name: " + directoryInfo.Name,
                    AutoSize = true,
                    Location = new Point(10, 10)
                };

                Label lblLastModified = new Label
                {
                    Text = "Last Modified: " + directoryInfo.LastWriteTime.ToString(),
                    AutoSize = true,
                    Location = new Point(10, 40)
                };

                folderInfoForm.Controls.Add(lblFolderName);
                folderInfoForm.Controls.Add(lblLastModified);

                folderInfoForm.ShowDialog();
            }
        }

        private void DataGridViewFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewFiles.Rows.Count)
            {
                var row = dataGridViewFiles.Rows[e.RowIndex];
                string fileName = row.Cells["Name"].Value.ToString();
                string filePath = Path.Combine(txt_path.Text, fileName);

                var result = MessageBox.Show($"Хотите продублировать файл '{fileName}'?", "Дублировать", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string newFilePath = Path.Combine(txt_path.Text, Path.GetFileNameWithoutExtension(fileName) + "_copy" + Path.GetExtension(fileName));
                        File.Copy(filePath, newFilePath);
                        LoadFolder(txt_path.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }

        private async void Click_On_BtnProcessFiles(object sender, EventArgs e)
        {
            var random = new Random();
            var tasks = dataGridViewFiles.Rows.Cast<DataGridViewRow>().Select(async row =>
            {
                int delay = random.Next(1, dataGridViewFiles.Rows.Count + 1);
                await Task.Delay(delay * 1000);
                row.Cells["ProcessingTime"].Value = delay;
            }).ToArray();

            await Task.WhenAll(tasks);
        }
    }
}
