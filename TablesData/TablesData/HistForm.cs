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
using System.Windows.Forms.DataVisualization.Charting;

namespace TablesData
{
    /// <summary>
    /// Форма для построения гистограммы.
    /// </summary>
    class HistForm : Form
    {
        // Сохраняем таблицу и колонки, чтобы удобно к ним обращаться.
        DataGridViewColumnCollection columns;
        DataGridView grid;
        // Номер выбранной колонки.
        int curNum = -1;
        Control.ControlCollection controls;
        // Гистограмма, сохраняем, чтобы менять.
        Chart hist;
        // Данные для гистограммы, сохраняем, чтобы менять.
        Series seriesFromGrid;
        // Числа для построения гистограммы.
        List<double> sortedNumbers;
        // Регулятор ширины колонок гистограммы.
        NumericUpDown columnWidth;
        /// <summary>
        /// Создание формы.
        /// </summary>
        /// <param name="grid">Таблица</param>
        public HistForm(DataGridView grid)
        {
            this.Text = "Выберите столбeц, нажав на кнопки с ними";
            this.Width = 1200;
            int i = 10;
            // Сохраняем всё нужное.
            this.columns = grid.Columns;
            this.grid = grid;
            // Создаем кнопки для выбора колонки.
            foreach (DataGridViewColumn column in columns)
            {
                Button chooseColumn = new Button();
                chooseColumn.Width = 200;
                chooseColumn.Text = column.Name;
                chooseColumn.Location = new Point(10, i);
                this.Controls.Add(chooseColumn);
                // При нажатии выбираем колонку
                chooseColumn.Click += Choose;
                // Делаем расстояние между кнопками.
                i += 20;
            }
            // Сохраняем кнпки, чтобы их убирать.
            controls = this.Controls;
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
            // Прячем кнопки.
            foreach (var control in controls)
                if (control is Button)
                {
                    ((Button)control).Visible = false;
                }
            this.Text = $"Гистограмма столбца {columns[curNum].Name}";
            // Рисуем гистограмму.
            DrawHist();
        }
        /// <summary>
        /// Проверяем, численная ли колонка.
        /// </summary>
        /// <param name="grid">Таблица</param>
        /// <param name="colNum">Ноер столбца</param>
        /// <param name="sortedNumbers">Отсортированный массив чисел, если все числа, иначе мусор или пустой</param>
        /// <returns></returns>
        public bool IsNumericColumn(DataGridView grid, int colNum, out List<double> sortedNumbers)
        {
            int rowsCnt = grid.Rows.Count - 1;
            sortedNumbers = new List<double>();
            // Проходимся по столбцу.
            for (int i = 0; i < rowsCnt; ++i)
            {
                double value;
                string[] curNumber = grid[colNum, i].Value.ToString().Split('\"');
                // Если число, добавляем в массив, иначе сообщаем, что колонка не числовая.
                if (curNumber.Length >= 2 && (double.TryParse(curNumber[1], out value) || double.TryParse(curNumber[1].Replace('.', ','), out value)) ||
                     curNumber.Length == 1 && (double.TryParse(curNumber[0], out value) || double.TryParse(curNumber[0].Replace('.', ','), out value)))
                {
                    sortedNumbers.Add(value);
                }
                else
                    return false;
            }
            // Если всё хорошо, сортируем массив.
            sortedNumbers.Sort();
            return true;
        }
        /// <summary>
        /// Создает словарь из значений столбца и их количества.
        /// </summary>
        /// <param name="grid">Таблица</param>
        /// <param name="colNum">Номер столбца</param>
        /// <returns>Словарь: значение - количество</returns>
        Dictionary<string, int> GetDict(DataGridView grid, int colNum)
        {
            Dictionary<string, int> ans = new Dictionary<string, int>();
            int rowsCnt = grid.Rows.Count - 1;
            // Проходим по колонке.
            for (int i = 0; i < rowsCnt; ++i)
            {
                // Добавляем новое значение или увеличиваем количество элементов со старым значением.
                if (ans.ContainsKey(grid[curNum, i].Value.ToString()))
                    ans[grid[curNum, i].Value.ToString()]++;
                else
                    ans.Add(grid[curNum, i].Value.ToString(), 1);
            }
            return ans;
        }
        /// <summary>
        /// Рисуем гистограмму.
        /// </summary>
        private void DrawHist()
        {
            // Создаем график.
            hist = new Chart();
            hist.Parent = this;
            // Свойство, чтобы гистограмма перерисовывалась по размеру формы.
            hist.Dock = DockStyle.Fill;
            hist.ChartAreas.Add(new ChartArea());
            seriesFromGrid = new Series(columns[curNum].Name);
            seriesFromGrid.ChartType = SeriesChartType.Column;
            // Добавляем оси.
            Axis ax = new Axis();
            ax.Title = columns[curNum].Name;
            hist.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Количество";
            hist.ChartAreas[0].AxisY = ay;
            // Если числовой столбец, делаем гистограмму с возможностью редактирования ширины столбца гистограммы.
            if (IsNumericColumn(grid, curNum, out sortedNumbers))
            {
                // Создаем и настраиваем NumericUpDown
                columnWidth = new NumericUpDown();
                columnWidth.Location = new Point(20, 20);
                columnWidth.Visible = true;
                columnWidth.Minimum = 1;
                this.Controls.Add(columnWidth);
                int widthCol = (sortedNumbers.Count + 99) / 100;
                columnWidth.Value = widthCol;
                // Рисуем гистограмму.
                this.DrawNumHist();
                ax.Interval = widthCol;
                // Перерисовываем при изменеии ширины.
                columnWidth.ValueChanged += RedrawNumHist;
            }
            else
            {
                // Создаем словарь и рисуем диаграмму по нему.
                Dictionary<string, int> gridCount = GetDict(grid, curNum);
                foreach (var forSeries in gridCount)
                {
                    seriesFromGrid.Points.AddXY(forSeries.Key, forSeries.Value);
                }
                // Чтобы были видны все значения.
                ax.Interval = 1;
                hist.Series.Clear();
                hist.Series.Add(seriesFromGrid);
            }
        }
        /// <summary>
        /// Перерисовка гистограммы.
        /// </summary>
        private void RedrawNumHist(object sender, EventArgs e)
        {
            DrawNumHist();
        }
        /// <summary>
        /// Рисование гистограммы для численного столбца.
        /// </summary>
        private void DrawNumHist()
        {
            // Задаем ширину колонки.
            int widthCol = (int)columnWidth.Value;
            seriesFromGrid = new Series(columns[curNum].Name);
            // Заполняем данные.
            for (int i = 0; i < sortedNumbers.Count; ++i)
            {
                int j = i, cnt = 0;
                // Создаем столбцы нужной блины.
                while (j < sortedNumbers.Count && sortedNumbers[j] < sortedNumbers[i] + widthCol)
                    ++j;
                cnt = j - i + 1;
                seriesFromGrid.Points.AddXY((sortedNumbers[i] + sortedNumbers[j - 1]) / 2, cnt);
                i = j;
            }
            // Рисуем, стерев старое.
            hist.Series.Clear();
            hist.Series.Add(seriesFromGrid);
            columnWidth.BringToFront();
        }

        /// <summary>
        /// Открыть форму.
        /// </summary>
        public void ShowHist()
        {
            // Запускаем форму, не блокируя остальные.
            this.Show();
        }
    }
}
