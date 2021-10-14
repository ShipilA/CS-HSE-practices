namespace TablesData
{
    partial class MainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuHist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuPlot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAverages = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuOpen,
            this.toolStripMenuAnalysis});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "Меню";
            // 
            // toolStripMenuOpen
            // 
            this.toolStripMenuOpen.Name = "toolStripMenuOpen";
            this.toolStripMenuOpen.Size = new System.Drawing.Size(118, 20);
            this.toolStripMenuOpen.Text = "Открыть файл csv";
            // 
            // toolStripMenuAnalysis
            // 
            this.toolStripMenuAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuHist,
            this.toolStripMenuPlot,
            this.toolStripMenuAverages});
            this.toolStripMenuAnalysis.Name = "toolStripMenuAnalysis";
            this.toolStripMenuAnalysis.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuAnalysis.Text = "Анализ";
            // 
            // toolStripMenuHist
            // 
            this.toolStripMenuHist.Name = "toolStripMenuHist";
            this.toolStripMenuHist.Size = new System.Drawing.Size(490, 22);
            this.toolStripMenuHist.Text = "Гистограмма";
            // 
            // toolStripMenuPlot
            // 
            this.toolStripMenuPlot.Name = "toolStripMenuPlot";
            this.toolStripMenuPlot.Size = new System.Drawing.Size(490, 22);
            this.toolStripMenuPlot.Text = "Двумерный график зависимости";
            // 
            // toolStripMenuAverages
            // 
            this.toolStripMenuAverages.Name = "toolStripMenuAverages";
            this.toolStripMenuAverages.Size = new System.Drawing.Size(490, 22);
            this.toolStripMenuAverages.Text = "Среднее, медиана, дисперсия, среднеквадратичное отклонение по столбцу";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(710, 449);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.Text = "dataGridView1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 489);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Анализ табличных данных";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOpen;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAnalysis;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuHist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuPlot;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAverages;
    }
}

