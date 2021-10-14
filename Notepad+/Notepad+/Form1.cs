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
    public partial class Form1 : Form
    {
        /// <summary>
        /// Создание формы.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            // Добавление контекстного меню.
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
            // Восстанавливаем настройки, если файл с ними найден.
            if (File.Exists("settings.txt"))
                SetSettings(File.ReadAllLines("settings.txt"));
            // Добавляем события при нажатии на кнопки какого-то из меню.
            toolStripMenuItemSave.Click += SaveClicked;
            toolStripMenuItemOpen.Click += OpenClicked;
            toolStripMenuItemClose.Click += CloseClicked;
            toolStripMenuItemNewInNew.Click += NewInNew;
            // Цветовая схема.
            colorSchemeDefault.Click += DefaultColor;
            colorScheme1.Click += DarkColor;
            colorScheme2.Click += YellowColor;
            // Правка.
            itemCopy.Click += CopyItem_Click;
            copyTextItem.Click += CopyItem_Click;
            itemInsert.Click += InsertItem_Click;
            pasteTextItem.Click += InsertItem_Click;
            itemCut.Click += CutItem_Click;
            cutTextItem.Click += CutItem_Click;
            itemAllText.Click += SelectAllItem_Click;
            // Шрифт.
            itemTextFormat.Click += Font_Change;
            fontItem.Click += Font_Change;
            italicItem.Click += ItalicChoosed;
            boldItem.Click += BoldChoosed;
            stressedItem.Click += StressedChoosed;
            crossedOutItem.Click += CrossedOutChoosed;
            // Информация о горячих клавишах.
            infoMenuItem.Click += Info_Show;
            // Автосохранение по таймеру.
            toolStripSaveFreq.Click += SaveFreq_Change;
            timer1.Tick += Timer1_Tick;
            // Добавление горячих клавиш.
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            // Обработка события закрытия формы.
            this.FormClosing += FClosing;
        }
        /// <summary>
        /// Восстановление ранее выбранных настроек, открываются файлы, которые были открыты в приложении (если они ещё существуют).
        /// </summary>
        /// <param name="settings">Текст файла настроек.</param>
        private void SetSettings(string[] settings)
        {
            if (settings.Length == 0)
                return;
            // Восстанавливаем настройки таймера.
            int timer;
            if (settings.Length > 1 && int.TryParse(settings[1], out timer))
            {
                // Если таймер 0, он не был запущен. Иначе устанавливаем таймер. Если файл настроек некорректен, сообщаем.
                if (timer > 0)
                {
                    timer1.Start();
                    timer1.Interval = timer;
                }
            }
            else
            {
                DialogResult error = MessageBox.Show(
                    "Не получилось воcстановить настройки таймера.",
                    "Некорректный файл настроек.",
                    MessageBoxButtons.OK);
            }
            // Восстанавливаем настройки цветовой схемы. Сообщаем, если не получилось.
            if (settings.Length > 2 && settings[2] == "default")
                SetDefaultColor();
            else if (settings.Length > 2 && settings[2] == "dark")
                SetDarkColor();
            else if (settings.Length > 2 && settings[2] == "yellow")
                SetYellowColor();
            else
            {
                DialogResult error = MessageBox.Show(
                    "Не получилось воcстановить настройки цветовой схемы.",
                    "Некорректный файл настроек.",
                    MessageBoxButtons.OK);
            }
            // Открываем файлы. Сообщаем, если не получилось.
            foreach (string fileName in settings[0].Split("::"))
                if (File.Exists(fileName))
                {
                    if (tabControl1.SelectedTab.Text == "Безымянный")
                        OpenFile(fileName);
                    else
                        NewTabOpen(fileName);
                }
                else if (fileName != "" && fileName != " " && fileName != ":" && fileName != "::")
                {
                    DialogResult error = MessageBox.Show(
                        "Не получилось найти файл " + fileName + ", возможно, он был удалён, или файл настроек оказался некорректным.",
                        "Не получилось открыть файл.",
                        MessageBoxButtons.OK);
                }
        }
        /// <summary>
        /// Сохранение файла с указанием нового имени.
        /// </summary>
        private void SaveClicked(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                // Ищем нужный RichTextBox и сохраняем из него в файл.
                foreach (var t in tabControl1.SelectedTab.Controls)
                    if (t is RichTextBox)
                    {
                        // Определяем тип файла и сохраняем.
                        if (saveFile.FileName.Substring(saveFile.FileName.Length - 3) == "rtf")
                            ((RichTextBox)t).SaveFile(saveFile.FileName, RichTextBoxStreamType.RichText);
                        else
                            File.WriteAllText(saveFile.FileName, ((RichTextBox)t).Text);
                    }
                // Устанавливаем имя файла на соответствующей вкладке.
                tabControl1.SelectedTab.Text = saveFile.FileName;
            }
        }
        /// <summary>
        /// Сохранение файла с указанием нового имени.
        /// </summary>
        private void SaveAll(object sender, EventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
                if (page.Text != "Безымянный" && page.Text != "+")
                {
                    foreach (var t in page.Controls)
                        if (t is RichTextBox)
                        {
                            // Определяем тип файла и сохраняем.
                            if (page.Text.Substring(page.Text.Length - 3) == "rtf")
                                ((RichTextBox)t).SaveFile(page.Text, RichTextBoxStreamType.RichText);
                            else
                                File.WriteAllText(page.Text, ((RichTextBox)t).Text);
                        }
                }
                else if (page.Text != "+")
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
                    {
                        // Ищем нужный RichTextBox и сохраняем из него в файл.
                        foreach (var t in page.Controls)
                            if (t is RichTextBox)
                            {
                                // Определяем тип файла и сохраняем.
                                if (saveFile.FileName.Substring(saveFile.FileName.Length - 3) == "rtf")
                                    ((RichTextBox)t).SaveFile(saveFile.FileName, RichTextBoxStreamType.RichText);
                                else
                                    File.WriteAllText(saveFile.FileName, ((RichTextBox)t).Text);
                            }
                        // Устанавливаем имя файла на соответствующей вкладке.
                        page.Text = saveFile.FileName;
                    }
                }
        }
        /// <summary>
        /// Открываем ранее сохранённый файл.
        /// </summary>
        private void OpenClicked(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Ищем нужный RichTextBox и выводим файл туда.
                foreach (var t in tabControl1.SelectedTab.Controls)
                    if (t is RichTextBox)
                    {
                        // Определяем тип файла и помещаем содержимое в RichTextBox.
                        if (openFile.FileName.Substring(openFile.FileName.Length - 3) == "rtf")
                            ((RichTextBox)t).Rtf = File.ReadAllText(openFile.FileName);
                        else
                            ((RichTextBox)t).Text = File.ReadAllText(openFile.FileName);
                    }
                // Устанавливаем имя файла на соответствующей вкладке.
                tabControl1.SelectedTab.Text = openFile.FileName;
            }
        }
        /// <summary>
        /// Открываем ранее сохранённый файл по его имени.
        /// </summary>
        private void OpenFile(string name)
        {
            if (File.Exists(name))
            {
                // Ищем нужный RichTextBox и выводим файл туда.
                foreach (var t in tabControl1.SelectedTab.Controls)
                    if (t is RichTextBox)
                    {
                        // Определяем тип файла и помещаем содержимое в RichTextBox.
                        if (name.Substring(name.Length - 3) == "rtf")
                            ((RichTextBox)t).Rtf = File.ReadAllText(name);
                        else
                            ((RichTextBox)t).Text = File.ReadAllText(name);
                    }
                // Устанавливаем имя файла на соответствующей вкладке.
                tabControl1.SelectedTab.Text = name;
            }
        }
        /// <summary>
        /// Событие установки базовой цветовой схемы.
        /// </summary>
        private void DefaultColor(object sender, EventArgs e)
        {
            // Устанавливаем базовую цветовую схему.
            SetDefaultColor();
        }
        /// <summary>
        /// Установка базовой цветовой схемы приложения.
        /// </summary>
        private void SetDefaultColor()
        {
            // Меняем основной цвет.
            this.BackColor = Color.White;
            foreach (TabPage page in tabControl1.TabPages)
                // Меняем цвет для RichTextBox и текста в нём.
                foreach (var t in page.Controls)
                    if (t is RichTextBox)
                    {
                        ((RichTextBox)t).BackColor = Color.White;
                        ((RichTextBox)t).ForeColor = Color.Black;
                    }
            // Меняем цвет в меню.
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.Black;
        }
        /// <summary>
        /// Событие установки тёмной цветовой схемы.
        /// </summary>
        private void DarkColor(object sender, EventArgs e)
        {
            // Устанавливаем тёмную цветовую схему.
            SetDarkColor();
        }
        /// <summary>
        /// Установка тёмной цветовой схемы.
        /// </summary>
        private void SetDarkColor()
        {
            // Меняем основной цвет.
            this.BackColor = Color.Black;
            foreach (TabPage page in tabControl1.TabPages)
                // Меняем цвет для RichTextBox и текста в нём.
                foreach (var t in page.Controls)
                    if (t is RichTextBox)
                    {
                        ((RichTextBox)t).BackColor = Color.Black;
                        ((RichTextBox)t).ForeColor = Color.White;
                    }
            // Меняем цвет в меню.
            menuStrip1.BackColor = Color.Black;
            menuStrip1.ForeColor = Color.White;
        }
        /// <summary>
        /// Событие установки жёлтой цветовой схемы.
        /// </summary>
        private void YellowColor(object sender, EventArgs e)
        {
            // Устанавливаем жёлтую цветовую схему.
            SetYellowColor();
        }
        /// <summary>
        /// Установка жёлтой цветовой схемы.
        /// </summary>
        private void SetYellowColor()
        {
            // Меняем основной цвет.
            this.BackColor = Color.Yellow;
            foreach (TabPage page in tabControl1.TabPages)
                // Меняем цвет для RichTextBox и текста в нём.
                foreach (var t in page.Controls)
                    if (t is RichTextBox)
                    {
                        ((RichTextBox)t).BackColor = Color.Yellow;
                        ((RichTextBox)t).ForeColor = Color.Brown;
                    }
            // Меняем цвет в меню.
            menuStrip1.BackColor = Color.Yellow;
            menuStrip1.ForeColor = Color.Brown;
        }

        /// <summary>
        /// Событие закрытия программы, предлагает сохранить файл, сохраняет настройки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FClosing(object sender, CancelEventArgs e)
        {
            // Предложение сохранить файл.
            DialogResult toSave = MessageBox.Show(
                "Сохранить открытые файлы перед выходом?",
                "Выход",
                MessageBoxButtons.YesNoCancel);
            if (toSave == DialogResult.Yes)
                SaveAll(sender, e);
            if (toSave == DialogResult.Cancel)
                e.Cancel = true;
            string settings = "";
            // Oткрытые файлы.
            foreach (TabPage page in tabControl1.TabPages)
                if (page.Text != "Безымянный" && page.Text != "+")
                    settings += page.Text + "::";
            // Частота сохранения.
            if (timer1.Enabled)
                settings += "\n" + timer1.Interval;
            else
                settings += "\n0";
            // Цветовая схема.
            if (this.BackColor == Color.White)
                settings += "\ndefault";
            else if (this.BackColor == Color.Black)
                settings += "\ndark";
            else if (this.BackColor == Color.Yellow)
                settings += "\nyellow";
            else
                settings += "\ndefault";
            File.WriteAllText("settings.txt", settings);
        }
        /// <summary>
        /// Появляется окно с информацией о горячих клавишах.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Show(object sender, EventArgs e)
        {
            DialogResult info = MessageBox.Show(
                "Ctrl + C - копировать,\n" +
                "Ctrl + V - вставить,\n" +
                "Ctrl + X - вырезать,\n" +
                "Ctrl + N - создать документ в новой вкладке,\n" +
                "Ctrl + Shift + N - создать документ в новом окне,\n" +
                "Ctrl + S - сохранить текущий документ,\n" +
                "Ctrl + Shift + S - сохранить все открытые документы,\n" +
                "Alt + F4 - закрытие приложения.\n",
                "Горячие клавиши");
        }
        /// <summary>
        /// Вставка из буфера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void InsertItem_Click(object sender, EventArgs e)
        {
            // Вставляем текст из буфера на правильной вкладке.
            foreach (var t in tabControl1.SelectedTab.Controls)
                if (t is RichTextBox)
                    ((RichTextBox)t).Paste();
        }
        /// <summary>
        /// Копирование текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CopyItem_Click(object sender, EventArgs e)
        {
            // Выделен текст в текстовом поле, ищем на правильной вкладке, копируем его в буфер.
            foreach (var t in tabControl1.SelectedTab.Controls)
                if (t is RichTextBox)
                    ((RichTextBox)t).Copy();
        }
        /// <summary>
        /// Выделение всего текста выбранного окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectAllItem_Click(object sender, EventArgs e)
        {
            // Выделяем текст всего поля, найдя нужную вкладку.
            foreach (var t in tabControl1.SelectedTab.Controls)
                if (t is RichTextBox)
                    ((RichTextBox)t).SelectAll();
        }
        /// <summary>
        /// Вырезать выбранный текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CutItem_Click(object sender, EventArgs e)
        {
            // Выделен текст в текстовом поле, копируем его в буфер и удаляем из поля.
            foreach (var t in tabControl1.SelectedTab.Controls)
                if (t is RichTextBox)
                {
                    ((RichTextBox)t).Copy();
                    ((RichTextBox)t).SelectedText = "";
                }
        }
        /// <summary>
        /// Сделать выбранный текст курсивным.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ItalicChoosed(object sender, EventArgs e)
        {
            foreach (var t in tabControl1.SelectedTab.Controls)
                // Выбираем нужную вкладку.
                if (t is RichTextBox)
                    // Меняем шрифт на курсив.
                    ((RichTextBox)t).SelectionFont = new Font(((RichTextBox)t).SelectionFont, FontStyle.Italic | ((RichTextBox)t).SelectionFont.Style);
        }
        /// <summary>
        /// Сделать выбранный текст полужирным.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BoldChoosed(object sender, EventArgs e)
        {
            foreach (var t in tabControl1.SelectedTab.Controls)
                // Выбираем нужную вкладку.
                if (t is RichTextBox)
                    // Меняем шрифт на полужирный.
                    ((RichTextBox)t).SelectionFont = new Font(((RichTextBox)t).SelectionFont, FontStyle.Bold | ((RichTextBox)t).SelectionFont.Style);
        }
        /// <summary>
        /// Подчеркнуть выбранный текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StressedChoosed(object sender, EventArgs e)
        {
            foreach (var t in tabControl1.SelectedTab.Controls)
                // Выбираем нужную вкладку.
                if (t is RichTextBox)
                    // Меняем шрифт на подчёркнутый.
                    ((RichTextBox)t).SelectionFont = new Font(((RichTextBox)t).SelectionFont, FontStyle.Underline | ((RichTextBox)t).SelectionFont.Style);
        }
        /// <summary>
        /// Зачеркнуть выбранный текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CrossedOutChoosed(object sender, EventArgs e)
        {
            foreach (var t in tabControl1.SelectedTab.Controls)
                // Выбираем нужную вкладку.
                if (t is RichTextBox)
                    // Меняем шрифт на зачёркнутый.
                    ((RichTextBox)t).SelectionFont = new Font(((RichTextBox)t).SelectionFont, FontStyle.Strikeout | ((RichTextBox)t).SelectionFont.Style);
        }
        /// <summary>
        /// Поменять основной шрифт.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Font_Change(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка шрифта
            foreach (var t in tabControl1.SelectedTab.Controls)
                // Выбираем нужную вкладку.
                if (t is RichTextBox)
                    // Меняем шрифт.
                    ((RichTextBox)t).Font = fontDialog1.Font;
        }

        /// <summary>
        /// Создание нового файла в новом окне.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInNew(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }
        /// <summary>
        /// Вызов от горячих клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + Shift + N - создать документ в новом окне.
            if (e.Control && e.Shift && e.KeyCode == Keys.N)
            {
                new Form1().ShowDialog();
                // Не даем другим клавишам перехватить действие.
                e.SuppressKeyPress = true;
            }
            // Ctrl + Shift + S - сохранить все открытые документы.
            else if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                SaveAll(sender, e);
                e.SuppressKeyPress = true;
            }
            // Ctrl-S сохранить.
            else if (e.Control && e.KeyCode == Keys.S)
            {
                SaveClicked(sender, e);
                e.SuppressKeyPress = true;
            }
            // Ctrl + N - создать документ в новой вкладке.
            else if (e.Control && e.KeyCode == Keys.N)
            {
                NewTabAdd(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// Открытие в новой вкладке через OpenFileDialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTabOpen(object sender, EventArgs e)
        {
            TabPage newTabPage = new TabPage();
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
                richTextBox1.Text = File.ReadAllText(openFile.FileName);
            newTabPage.Text = openFile.FileName;
            RichTextBox newRichTextBox = new RichTextBox();
            newRichTextBox.Dock = DockStyle.Fill;
            newTabPage.Controls.Add(newRichTextBox);
            tabControl1.TabPages.Add(newTabPage);
        }
        /// <summary>
        /// Открытие в новой вкладке по названию файла.
        /// </summary>
        /// <param name="fileName"></param>
        private void NewTabOpen(string fileName)
        {
            TabPage newTabPage = new TabPage();
            RichTextBox newRichTextBox = new RichTextBox();
            if (fileName.Substring(fileName.Length - 3) == "rtf")
                newRichTextBox.Rtf = File.ReadAllText(fileName);
            else
                newRichTextBox.Text = File.ReadAllText(fileName);
            newTabPage.Text = fileName;
            newRichTextBox.Dock = DockStyle.Fill;
            newTabPage.Controls.Add(newRichTextBox);
            tabControl1.TabPages.Add(newTabPage);
        }
        /// <summary>
        /// Добавить новую вкладку с новым пусты файлом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTabAdd(object sender, EventArgs e)
        {
            TabPage newTabPage = new TabPage();
            newTabPage.Text = "Безымянный";
            // Создаем RichTextBox для новой страницы.
            RichTextBox newRichTextBox = new RichTextBox();
            newRichTextBox.Dock = DockStyle.Fill;
            // Контекстное меню для новой страницы.
            newRichTextBox.ContextMenuStrip = contextMenuStrip1;
            newTabPage.Controls.Add(newRichTextBox);
            // Добавляем новую страницу к старым.
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
        }
        /// <summary>
        /// Смена вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Создание нового файла, если выбран "+".
            if (tabControl1.SelectedTab == newTab)
                NewTabAdd(sender, e);
            else
            {
                // Вернуть контекстное меню к выбранной вкладке.
                foreach (var t in tabControl1.SelectedTab.Controls)
                    if (t is RichTextBox)
                        ((RichTextBox)t).ContextMenuStrip = contextMenuStrip1;
            }
        }
        /// <summary>
        /// Изменение частоты автосохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFreq_Change(object sender, EventArgs e)
        {
            // Задать новый интервал.
            int newInterval = (int)(new SaveFreqChangeForm(timer1.Interval).ShowAndGetResult());
            // Если новые данные были сохранены, использовать.
            if (newInterval > 0)
            {
                // Включить таймер, если он был выключен.
                if (timer1.Enabled == false)
                    timer1.Start();
                timer1.Interval = newInterval;
            }
        }
        /// <summary>
        /// Автосохранение (по таймеру).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Сохраняем все файлы с именами.
            foreach (TabPage page in tabControl1.TabPages)
                if (page.Text != "Безымянный" && page.Text != "+")
                {
                    foreach (var t in page.Controls)
                        if (t is RichTextBox)
                            File.WriteAllText(page.Text, ((RichTextBox)t).Text);
                }
        }
        /// <summary>
        /// Закрытие одного файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseClicked(object sender, EventArgs e)
        {
            TabPage toClose = tabControl1.SelectedTab;
            // Предложение сохранить файл.
            DialogResult toSave = MessageBox.Show(
                "Сохранить файл перед закрытием?",
                "Выход",
                MessageBoxButtons.YesNo);
            // Сохранение.
            if (toSave == DialogResult.Yes)
                SaveClicked(sender, e);
            // Переход к другому файлу, если есть.
            foreach (TabPage page in tabControl1.TabPages)
                if (page.Text != "Безымянный" && page.Text != "+")
                {
                    tabControl1.SelectedTab = page;
                    break;
                }
            // Удаление.
            tabControl1.TabPages.Remove(toClose);
        }
    }
}
