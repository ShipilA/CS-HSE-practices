using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;

namespace Notepad_
{
    /// <summary>
    /// Всплывающее окно для изменения частоты автосохранения.
    /// </summary>
    public partial class SaveFreqChangeForm : Form
    {
        // Частота.
        int newFreq = -1;
        /// <summary>
        /// Создание формы.
        /// </summary>
        public SaveFreqChangeForm(int oldFreq = 1)
        {
            // Добавляем NumericUpDown для выбора числа секунд и кнопку для сохранения.
            NumericUpDown freq = new NumericUpDown();
            Button getFreq = new Button();
            getFreq.Location = new Point(10, 25);
            freq.Location = new Point(10, 0);
            getFreq.Text = "Сохранить значение";
            // Ограничения.
            freq.Minimum = 1;
            freq.Maximum = 200;
            // Старое значение, по умолчанию 1.
            freq.Value = oldFreq;
            this.Text = "Выберите частоту автосохранения (раз в сколько секунд)";
            // Размер окна.
            this.Height = 100;
            this.Width = 500;
            this.Controls.Add(getFreq);
            this.Controls.Add(freq);
            // Сохранение результата.
            getFreq.Click += SaveFreq;
        }
        /// <summary>
        /// Сохранение выбранного значения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFreq(object sender, EventArgs e)
        {
            // Находим и сохраняем значение.
            foreach (var t in this.Controls)
                if (t is NumericUpDown)
                    newFreq = (int)((NumericUpDown)t).Value;
            // Закрытие формы.
            this.Close();
        }
        /// <summary>
        /// Запуск окна и выдача результата в основную программу.
        /// </summary>
        /// <returns></returns>
        public int ShowAndGetResult()
        {
            this.ShowDialog();
            return newFreq;
        }
    }
}
