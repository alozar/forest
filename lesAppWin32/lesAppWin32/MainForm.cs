using lesAppWin32.Model.Entities;
using lesAppWin32.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lesAppWin32
{
    public partial class MainForm : Form
    {
        FileService fileService;
        ParseService parseService;
        public List<Quarter> quarters { get; set; }

        public MainForm()
        {
            InitializeComponent();

            fileService = new FileService();
            parseService = new ParseService();
            quarters = new List<Quarter>();

            comboBox1.DataSource = quarters;
            comboBox1.DisplayMember = "Number";
        }

        //Открыть
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Forest json files|*.frj";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            textBoxFile.Text = openFileDialog.FileName;
            try
            {
                var quarters = fileService.Open(openFileDialog.FileName);
                quarters.Clear();
                foreach (var q in quarters)
                    quarters.Add(q);
                //SelectedQuarter = quarters.FirstOrDefault();
                //SelectedSection = SelectedQuarter.Sections.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Парсить
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "text files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            textBoxFile.Text = openFileDialog.FileName;
            try
            {
                var quarters = parseService.Open(openFileDialog.FileName);
                quarters.Clear();
                foreach (var p in quarters)
                    quarters.Add(p);
                MessageBox.Show("Файл распарсен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Сохранить
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            textBoxFile.Text = saveFileDialog.FileName;
            try
            {
                fileService.Save(saveFileDialog.FileName, quarters.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Вычислить
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //var result = СalculateService.GetResult(SelectedSection, Square);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
