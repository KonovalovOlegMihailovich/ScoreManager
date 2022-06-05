namespace ScoreManager
{
    partial class Main
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.начислитьБаллыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.историяСписанийИНачисленийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PravkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReasonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TovarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updategridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(800, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начислитьБаллыToolStripMenuItem,
            this.списатьToolStripMenuItem,
            this.историяСписанийИНачисленийToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 70);
            // 
            // начислитьБаллыToolStripMenuItem
            // 
            this.начислитьБаллыToolStripMenuItem.Name = "начислитьБаллыToolStripMenuItem";
            this.начислитьБаллыToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.начислитьБаллыToolStripMenuItem.Text = "Начислить";
            this.начислитьБаллыToolStripMenuItem.Click += new System.EventHandler(this.addscore);
            // 
            // списатьToolStripMenuItem
            // 
            this.списатьToolStripMenuItem.Name = "списатьToolStripMenuItem";
            this.списатьToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.списатьToolStripMenuItem.Text = "Списать";
            // 
            // историяСписанийИНачисленийToolStripMenuItem
            // 
            this.историяСписанийИНачисленийToolStripMenuItem.Name = "историяСписанийИНачисленийToolStripMenuItem";
            this.историяСписанийИНачисленийToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.историяСписанийИНачисленийToolStripMenuItem.Text = "Сведенье";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PravkaToolStripMenuItem,
            this.показатьToolStripMenuItem,
            this.updategridToolStripMenuItem,
            this.loadDataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PravkaToolStripMenuItem
            // 
            this.PravkaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.PravkaToolStripMenuItem.Name = "PravkaToolStripMenuItem";
            this.PravkaToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.PravkaToolStripMenuItem.Text = "Правка";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.Add);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.Remove);
            // 
            // показатьToolStripMenuItem
            // 
            this.показатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReasonsToolStripMenuItem,
            this.EmpToolStripMenuItem,
            this.DepToolStripMenuItem,
            this.TovarsToolStripMenuItem,
            this.HistoryToolStripMenuItem});
            this.показатьToolStripMenuItem.Name = "показатьToolStripMenuItem";
            this.показатьToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.показатьToolStripMenuItem.Text = "Показать";
            // 
            // ReasonsToolStripMenuItem
            // 
            this.ReasonsToolStripMenuItem.Name = "ReasonsToolStripMenuItem";
            this.ReasonsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ReasonsToolStripMenuItem.Text = "Причины";
            this.ReasonsToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // EmpToolStripMenuItem
            // 
            this.EmpToolStripMenuItem.Name = "EmpToolStripMenuItem";
            this.EmpToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.EmpToolStripMenuItem.Text = "Персонал";
            this.EmpToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // DepToolStripMenuItem
            // 
            this.DepToolStripMenuItem.Name = "DepToolStripMenuItem";
            this.DepToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.DepToolStripMenuItem.Text = "Отделы";
            this.DepToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // TovarsToolStripMenuItem
            // 
            this.TovarsToolStripMenuItem.Name = "TovarsToolStripMenuItem";
            this.TovarsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.TovarsToolStripMenuItem.Text = "Товары";
            this.TovarsToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // HistoryToolStripMenuItem
            // 
            this.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem";
            this.HistoryToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.HistoryToolStripMenuItem.Text = "История";
            this.HistoryToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // updategridToolStripMenuItem
            // 
            this.updategridToolStripMenuItem.Name = "updategridToolStripMenuItem";
            this.updategridToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.updategridToolStripMenuItem.Text = "_updateGrid";
            this.updategridToolStripMenuItem.Click += new System.EventHandler(this.updategridToolStripMenuItem_Click);
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.loadDataToolStripMenuItem.Text = "_loadData";
            this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Персонал";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem PravkaToolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem изменитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem показатьToolStripMenuItem;
        private ToolStripMenuItem ReasonsToolStripMenuItem;
        private ToolStripMenuItem EmpToolStripMenuItem;
        private ToolStripMenuItem DepToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem начислитьБаллыToolStripMenuItem;
        private ToolStripMenuItem списатьToolStripMenuItem;
        private ToolStripMenuItem историяСписанийИНачисленийToolStripMenuItem;
        private ToolStripMenuItem updategridToolStripMenuItem;
        private ToolStripMenuItem loadDataToolStripMenuItem;
        private ToolStripMenuItem TovarsToolStripMenuItem;
        private ToolStripMenuItem HistoryToolStripMenuItem;
    }
}