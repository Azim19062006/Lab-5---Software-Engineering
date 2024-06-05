namespace lab5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btn_select;
        private TextBox txt_path;
        private ListBox lst_of_folder;
        private DataGridView dataGridViewFiles;
        private Button btn_process;
        private MenuStrip menuStrip;
        private ToolStripMenuItem about_inf;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region

        private void InitializeComponent()
        {
            btn_select = new Button();
            txt_path = new TextBox();
            lst_of_folder = new ListBox();
            dataGridViewFiles = new DataGridView();
            btn_process = new Button();
            menuStrip = new MenuStrip();
            about_inf = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiles).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();


            btn_select.Location = new Point(1150, 75);
            btn_select.Name = "btn_select";
            btn_select.Size = new Size(250, 75);
            btn_select.TabIndex = 0;
            btn_select.Text = "Select";
            btn_select.UseVisualStyleBackColor = true;


            txt_path.BackColor = Color.LightGray;
            txt_path.Location = new Point(12, 80);
            txt_path.Name = "txt_path";
            txt_path.ReadOnly = true;
            txt_path.Size = new Size(1090, 27);
            txt_path.TabIndex = 1;


            lst_of_folder.FormattingEnabled = true;
            lst_of_folder.Location = new Point(12, 120);
            lst_of_folder.Name = "lst_of_folder";
            lst_of_folder.Size = new Size(330, 450);
            lst_of_folder.TabIndex = 2;


            dataGridViewFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiles.Location = new Point(350, 120);
            dataGridViewFiles.Name = "dataGridViewFiles";
            dataGridViewFiles.RowHeadersWidth = 51;
            dataGridViewFiles.Size = new Size(750, 450);
            dataGridViewFiles.TabIndex = 3;


            btn_process.Location = new Point(922, 580);
            btn_process.Name = "btn_process";
            btn_process.Size = new Size(450, 90);
            btn_process.TabIndex = 4;
            btn_process.Text = "Process";
            btn_process.UseVisualStyleBackColor = true;
            btn_process.Visible = false;


            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { about_inf });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";


            about_inf.BackColor = Color.LightBlue;
            about_inf.Name = "about_inf";
            about_inf.Size = new Size(64, 24);
            about_inf.Text = "About";
            about_inf.Click += Click_On_AboutMenuItem;


            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(btn_select);
            Controls.Add(txt_path);
            Controls.Add(lst_of_folder);
            Controls.Add(dataGridViewFiles);
            Controls.Add(btn_process);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "Form1";
            Text = "MyFirstForm";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiles).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
