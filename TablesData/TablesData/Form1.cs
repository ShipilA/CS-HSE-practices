using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace TablesData
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Инициализация главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            // Открытие файла по нажатию на кнопку в меню.
            toolStripMenuOpen.Click += OpenClicked;
            // Открытие формы со средними значениями при нажатии на кнопку в меню.
            toolStripMenuAverages.Click += AveragesFormOpen;
            // Открытие формы с графиком при нажатии на кнопку в меню.
            toolStripMenuPlot.Click += PlotFormOpen;
            // Открытие формы гистограммой при нажатии на кнопку в меню.
            toolStripMenuHist.Click += HistFormOpen;
        }

        /// <summary>
        /// Открываем ранее сохранённый файл по его имени.
        /// </summary>
        private void OpenFile(string name)
        {
            // Могут быть ошибка не только из-за несуществования.
            try
            {
                // Проверяем формат файла.
                if (name.Substring(name.Length - 3) == "csv")
                {
                    // Считываем по строкам-столбцам
                    string[][] data = Array.ConvertAll(File.ReadAllLines(name), x => Array.ConvertAll(x.Replace(", ", "; ").Split(","), x => x.Replace("; ", ", ")));
                    if (data.Length == 0)
                    {
                        MessageBox.Show("Выбраный файл пуст", "Ошибка", MessageBoxButtons.OK);
                        return;
                    }
                    // Преобразуе данные в dataGridView-вид.
                    dataGridView.Rows.Clear();
                    dataGridView.ColumnCount = data[0].Length;
                    for (int i = 0; i < data[0].Length; ++i)
                    {
                        dataGridView.Columns[i].Name = data[0][i];
                    }
                    for (int i = 1; i < data.Length; ++i)
                    {
                        dataGridView.Rows.Add(data[i]);
                    }
                }
                else
                    MessageBox.Show("Выбраный файл не является файлом в формате scv", "Ошибка", MessageBoxButtons.OK);
                this.Text = name;
            }
            catch (Exception)
            {
                MessageBox.Show("Не получилось открыть файл.", "Ошибка", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Открываем ранее сохранённый файл.
        /// </summary>
        private void OpenClicked(object sender, EventArgs e)
        {
            // Выбираем файл и пытаемся открыть, если можем.
            OpenFileDialog openFile = new OpenFileDialog();
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    OpenFile(openFile.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не получилось открыть файл.", "Ошибка", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Открываем форму со средними значениями.
        /// </summary>
        private void AveragesFormOpen(object sender, EventArgs e)
        {
            // Проверяем, что всё успешно, иначе обрабатыем исключение.
            try
            {
                // Запускаем форму.
                if (dataGridView.Rows.Count == 0)
                    MessageBox.Show("Не выбран файл с данными или был выбран пустой файл", "Ошибка", MessageBoxButtons.OK);
                else
                    (new AveragesForm(dataGridView)).ShowAverageForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Не получилось открыть форму, проверьте данные на корректность.", "Ошибка", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Открываем форму с графиком.
        /// </summary>
        private void PlotFormOpen(object sender, EventArgs e)
        {
            // Проверяем, что всё успешно, иначе обрабатыем исключение.
            try
            {
                // Запускаем форму.
                if (dataGridView.Rows.Count == 0)
                    MessageBox.Show("Не выбран файл с данными или был выбран пустой файл", "Ошибка", MessageBoxButtons.OK);
                else
                    (new PlotForm(dataGridView)).ShowPlot();
            }
            catch (Exception)
            {
                MessageBox.Show("Не получилось открыть форму, проверьте данные на корректность.", "Ошибка", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Открываем форму с гистограммой.
        /// </summary>
        private void HistFormOpen(object sender, EventArgs e)
        {
            // Проверяем, что всё успешно, иначе обрабатыем исключение.
            try
            {
                // Запускаем форму.
                if (dataGridView.Rows.Count == 0)
                    MessageBox.Show("Не выбран файл с данными или был выбран пустой файл", "Ошибка", MessageBoxButtons.OK);
                else
                    (new HistForm(dataGridView)).ShowHist();
            }
            catch (Exception)
            {
                MessageBox.Show("Не получилось открыть форму, проверьте данные на корректность.", "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}
