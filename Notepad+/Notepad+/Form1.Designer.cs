namespace Notepad_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.italicItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boldItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stressedItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossedOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemColor = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSchemeDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.colorScheme1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorScheme2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSaveFreq = new System.Windows.Forms.ToolStripMenuItem();
            this.infoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemAllText = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.itemInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTextFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.newTab = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItemNewInNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem2.Text = "Открыть";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.changeTextItem,
            this.toolStripMenuFormat,
            this.toolStripMenuItemSettings,
            this.infoMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "Файл";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.toolStripMenuItemSave,
            this.toolStripMenuItemClose,
            this.toolStripMenuItemNewInNew});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem3.Text = "Файл";
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemOpen.Text = "Открыть";
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemSave.Text = "Сохранить как";
            // 
            // toolStripMenuItemClose
            // 
            this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            this.toolStripMenuItemClose.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemClose.Text = "Закрыть выбранный файл";
            // 
            // changeTextItem
            // 
            this.changeTextItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyTextItem,
            this.pasteTextItem,
            this.cutTextItem});
            this.changeTextItem.Name = "changeTextItem";
            this.changeTextItem.Size = new System.Drawing.Size(59, 20);
            this.changeTextItem.Text = "Правка";
            // 
            // copyTextItem
            // 
            this.copyTextItem.Name = "copyTextItem";
            this.copyTextItem.Size = new System.Drawing.Size(257, 22);
            this.copyTextItem.Text = "Копировать выделенный текст";
            // 
            // pasteTextItem
            // 
            this.pasteTextItem.Name = "pasteTextItem";
            this.pasteTextItem.Size = new System.Drawing.Size(257, 22);
            this.pasteTextItem.Text = "Вставить текст из буфера обмена";
            // 
            // cutTextItem
            // 
            this.cutTextItem.Name = "cutTextItem";
            this.cutTextItem.Size = new System.Drawing.Size(257, 22);
            this.cutTextItem.Text = "Вырезать выделенный текст";
            // 
            // toolStripMenuFormat
            // 
            this.toolStripMenuFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.italicItem,
            this.boldItem,
            this.stressedItem,
            this.crossedOutItem,
            this.fontItem});
            this.toolStripMenuFormat.Name = "toolStripMenuFormat";
            this.toolStripMenuFormat.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuFormat.Text = "Формат";
            // 
            // italicItem
            // 
            this.italicItem.Name = "italicItem";
            this.italicItem.Size = new System.Drawing.Size(227, 22);
            this.italicItem.Text = "Курсив";
            // 
            // boldItem
            // 
            this.boldItem.Name = "boldItem";
            this.boldItem.Size = new System.Drawing.Size(227, 22);
            this.boldItem.Text = "Жирный";
            // 
            // stressedItem
            // 
            this.stressedItem.Name = "stressedItem";
            this.stressedItem.Size = new System.Drawing.Size(227, 22);
            this.stressedItem.Text = "Подчёркнутый";
            // 
            // crossedOutItem
            // 
            this.crossedOutItem.Name = "crossedOutItem";
            this.crossedOutItem.Size = new System.Drawing.Size(227, 22);
            this.crossedOutItem.Text = "Зачёркнутый";
            // 
            // fontItem
            // 
            this.fontItem.Name = "fontItem";
            this.fontItem.Size = new System.Drawing.Size(227, 22);
            this.fontItem.Text = "Изменить основной шрифт";
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemColor,
            this.toolStripSaveFreq});
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(79, 20);
            this.toolStripMenuItemSettings.Text = "Настройки";
            // 
            // toolStripMenuItemColor
            // 
            this.toolStripMenuItemColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorSchemeDefault,
            this.colorScheme1,
            this.colorScheme2});
            this.toolStripMenuItemColor.Name = "toolStripMenuItemColor";
            this.toolStripMenuItemColor.Size = new System.Drawing.Size(247, 22);
            this.toolStripMenuItemColor.Text = "Выбор цветовой схемы";
            // 
            // colorSchemeDefault
            // 
            this.colorSchemeDefault.Name = "colorSchemeDefault";
            this.colorSchemeDefault.Size = new System.Drawing.Size(119, 22);
            this.colorSchemeDefault.Text = "Светлая";
            // 
            // colorScheme1
            // 
            this.colorScheme1.Name = "colorScheme1";
            this.colorScheme1.Size = new System.Drawing.Size(119, 22);
            this.colorScheme1.Text = "Темная";
            // 
            // colorScheme2
            // 
            this.colorScheme2.Name = "colorScheme2";
            this.colorScheme2.Size = new System.Drawing.Size(119, 22);
            this.colorScheme2.Text = "Жёлтый";
            // 
            // toolStripSaveFreq
            // 
            this.toolStripSaveFreq.Name = "toolStripSaveFreq";
            this.toolStripSaveFreq.Size = new System.Drawing.Size(247, 22);
            this.toolStripSaveFreq.Text = "Задать частоту автосохранения";
            // 
            // infoMenuItem
            // 
            this.infoMenuItem.Name = "infoMenuItem";
            this.infoMenuItem.Size = new System.Drawing.Size(194, 20);
            this.infoMenuItem.Text = "Справка по горячим клавишам";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAllText,
            this.itemCut,
            this.itemCopy,
            this.itemInsert,
            this.itemTextFormat});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(307, 114);
            this.contextMenuStrip1.Text = "Меню";
            // 
            // itemAllText
            // 
            this.itemAllText.Name = "itemAllText";
            this.itemAllText.Size = new System.Drawing.Size(306, 22);
            this.itemAllText.Text = "Выбрать весь текст";
            // 
            // itemCut
            // 
            this.itemCut.Name = "itemCut";
            this.itemCut.Size = new System.Drawing.Size(306, 22);
            this.itemCut.Text = "Вырезать выделенный фрагмент текста";
            // 
            // itemCopy
            // 
            this.itemCopy.Name = "itemCopy";
            this.itemCopy.Size = new System.Drawing.Size(306, 22);
            this.itemCopy.Text = "Копировать выделенный фрагмент текста";
            // 
            // itemInsert
            // 
            this.itemInsert.Name = "itemInsert";
            this.itemInsert.Size = new System.Drawing.Size(306, 22);
            this.itemInsert.Text = "Вставить текст из буфера обмена";
            // 
            // itemTextFormat
            // 
            this.itemTextFormat.Name = "itemTextFormat";
            this.itemTextFormat.Size = new System.Drawing.Size(306, 22);
            this.itemTextFormat.Text = "Задать формат выделенного текста";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Безымянный";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(786, 392);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.newTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 426);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // newTab
            // 
            this.newTab.Location = new System.Drawing.Point(4, 24);
            this.newTab.Name = "newTab";
            this.newTab.Size = new System.Drawing.Size(792, 398);
            this.newTab.TabIndex = 1;
            this.newTab.Text = "+";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // toolStripMenuItemNewInNew
            // 
            this.toolStripMenuItemNewInNew.Name = "toolStripMenuItemNewInNew";
            this.toolStripMenuItemNewInNew.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemNewInNew.Text = "Создать в новом окне";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Notepad+";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem changeTextItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFormat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemColor;
        private System.Windows.Forms.ToolStripMenuItem colorSchemeDefault;
        private System.Windows.Forms.ToolStripMenuItem colorScheme1;
        private System.Windows.Forms.ToolStripMenuItem colorScheme2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemAllText;
        private System.Windows.Forms.ToolStripMenuItem itemCut;
        private System.Windows.Forms.ToolStripMenuItem itemCopy;
        private System.Windows.Forms.ToolStripMenuItem itemInsert;
        private System.Windows.Forms.ToolStripMenuItem itemTextFormat;
        private System.Windows.Forms.ToolStripMenuItem italicItem;
        private System.Windows.Forms.ToolStripMenuItem boldItem;
        private System.Windows.Forms.ToolStripMenuItem stressedItem;
        private System.Windows.Forms.ToolStripMenuItem crossedOutItem;
        private System.Windows.Forms.ToolStripMenuItem infoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage newTab;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveFreq;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem copyTextItem;
        private System.Windows.Forms.ToolStripMenuItem pasteTextItem;
        private System.Windows.Forms.ToolStripMenuItem cutTextItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewInNew;
    }
}

