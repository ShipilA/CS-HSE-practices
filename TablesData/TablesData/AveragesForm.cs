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
    /// <summary>
    /// Форма со средними значениями по колонке.
    /// </summary>
    class AveragesForm : Form
    {
        // Храним колонки и данные.
        DataGridViewColumnCollection columns;
        DataGridView grid;
        // Храним текст, который надо менять при нажатии на некоторые кнопки, чтобы не искать его долго.
        Label averageText, medianText, rmsText, dispersionText;
        // Храним номер выбранного столбца.
        int curNum;
        /// <summary>
        /// Запуск формы.
        /// </summary>
        /// <param name="grid">DataGridView с данными.</param>
        public AveragesForm(DataGridView grid)
        {
            // Сохраняем нужную информацию, задаем текст и размер формы.
            this.Text = "Выберите столбец";
            this.Width = 800;
            this.columns = grid.Columns;
            this.grid = grid;
            // Добавляем лейблы для текса о посчитанных средних значениях.
            averageText = new Label();
            medianText = new Label();
            rmsText = new Label();
            dispersionText = new Label();
            averageText.Width = 600;
            medianText.Width = 600;
            rmsText.Width = 600;
            dispersionText.Width = 600;
            averageText.Location = new Point(250, 10);
            medianText.Location = new Point(250, 30);
            rmsText.Location = new Point(250, 50);
            dispersionText.Location = new Point(250, 70);
            this.Controls.Add(averageText);
            this.Controls.Add(medianText);
            this.Controls.Add(rmsText);
            this.Controls.Add(dispersionText);
            // Создаем кнопки для всех колонок.
            int i = 10;
            foreach (DataGridViewColumn column in columns)
            {
                Button chooseColumn = new Button();
                chooseColumn.Width = 200;
                chooseColumn.Text = column.Name;
                chooseColumn.Location = new Point(10, i);
                this.Controls.Add(chooseColumn);
                // При нажатии выбираем колонку
                chooseColumn.Click += Choose;
                i += 20;
            }
        }
        /// <summary>
        /// Выбор столбца.
        /// </summary>
        private void Choose(object sender, EventArgs e)
        {
            curNum = 0;
            // Считаем номер в массиве.
            while (columns[curNum].Name != ((Button)sender).Text)
                ++curNum;
            // Меняем текст: пересчитываем среднее для нового столбца.
            ResetText(columns[curNum].Name);
        }
        /// <summary>
        /// Обновляем текст со значениями средних.
        /// </summary>
        /// <param name="columnName">Имя колонки.</param>
        private void ResetText(string columnName)
        {
            int rowsCnt = grid.Rows.Count - 1;
            double sum = 0, value, dispersion = 0, rms = 0;
            List<double> values = new List<double>();
            // Преобразуем наши данные в числа, если можем.
            for (int i = 0; i < rowsCnt; ++i)
            {
                string[] curNumber = grid[curNum, i].Value.ToString().Split('\"');
                // Проверяем, численное ли значение.
                if (curNumber.Length >= 2 && (double.TryParse(curNumber[1], out value) || double.TryParse(curNumber[1].Replace('.', ','), out value)) ||
                     curNumber.Length == 1 && (double.TryParse(curNumber[0], out value) || double.TryParse(curNumber[0].Replace('.', ','), out value)))

                {
                    sum += value;
                    values.Add(value);
                }
                else
                {
                    MessageBox.Show("Нечисленное значение в выбранном столбце", "Ошибка", MessageBoxButtons.OK);
                    averageText.Text = "";
                    rmsText.Text = "";
                    medianText.Text = "";
                    dispersionText.Text = "";
                    return;
                }
            }
            // Считаем средние и выводим их в форму.
            double average = sum / rowsCnt;
            averageText.Text = "Среднее значение по столбцу " + columnName + ": " + average.ToString();
            values.Sort();
            if (rowsCnt % 2 == 0)
                medianText.Text = $"Медиана по столбцу {columnName}: {((values[rowsCnt / 2] + values[rowsCnt / 2 - 1]) / 2).ToString()}";
            else
                medianText.Text = "Медиана по столбцу " + columnName + ": " + (values[rowsCnt / 2]).ToString();
            for (int i = 0; i < values.Count; ++i)
            {
                dispersion += Math.Pow(values[i] - average, 2);
                rms += Math.Pow(values[i] - average, 2);
            }
            rms = Math.Sqrt(rms / values.Count);
            dispersion /= values.Count;
            rmsText.Text = "Среднеквадратическое отклонение по столбцу " + columnName + ": " + rms.ToString();
            dispersionText.Text = "Дисперсия по столбцу " + columnName + ": " + dispersion.ToString();
        }

        /// <summary>
        /// Открыть форму.
        /// </summary>
        public void ShowAverageForm()
        {
            // Запускаем форму, не блокируя остальные.
            this.Show();
        }
    }
}
