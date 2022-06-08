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
            this.EmpMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.LimitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DepMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ReasMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TovarMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.EmpMenuStrip.SuspendLayout();
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
            this.dataGridView1.ContextMenuStrip = this.EmpMenuStrip;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(800, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // EmpMenuStrip
            // 
            this.EmpMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начислитьБаллыToolStripMenuItem,
            this.списатьToolStripMenuItem,
            this.историяСписанийИНачисленийToolStripMenuItem});
            this.EmpMenuStrip.Name = "contextMenuStrip1";
            this.EmpMenuStrip.Size = new System.Drawing.Size(135, 70);
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
            this.историяСписанийИНачисленийToolStripMenuItem.Text = "Сведенья";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PravkaToolStripMenuItem,
            this.показатьToolStripMenuItem});
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
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.Add);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.Edit);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
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
            this.LimitsToolStripMenuItem,
            this.HistoryToolStripMenuItem});
            this.показатьToolStripMenuItem.Name = "показатьToolStripMenuItem";
            this.показатьToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.показатьToolStripMenuItem.Text = "Показать";
            // 
            // ReasonsToolStripMenuItem
            // 
            this.ReasonsToolStripMenuItem.Name = "ReasonsToolStripMenuItem";
            this.ReasonsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ReasonsToolStripMenuItem.Text = "Причины";
            this.ReasonsToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // EmpToolStripMenuItem
            // 
            this.EmpToolStripMenuItem.Name = "EmpToolStripMenuItem";
            this.EmpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EmpToolStripMenuItem.Text = "Персонал";
            this.EmpToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // DepToolStripMenuItem
            // 
            this.DepToolStripMenuItem.Name = "DepToolStripMenuItem";
            this.DepToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DepToolStripMenuItem.Text = "Отделы";
            this.DepToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // TovarsToolStripMenuItem
            // 
            this.TovarsToolStripMenuItem.Name = "TovarsToolStripMenuItem";
            this.TovarsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TovarsToolStripMenuItem.Text = "Товары";
            this.TovarsToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // LimitsToolStripMenuItem
            // 
            this.LimitsToolStripMenuItem.Name = "LimitsToolStripMenuItem";
            this.LimitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LimitsToolStripMenuItem.Text = "Лимиты";
            this.LimitsToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // HistoryToolStripMenuItem
            // 
            this.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem";
            this.HistoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.HistoryToolStripMenuItem.Text = "История";
            this.HistoryToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // DepMenuStrip
            // 
            this.DepMenuStrip.Name = "DepMenuStrip";
            this.DepMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // ReasMenuStrip
            // 
            this.ReasMenuStrip.Name = "contextMenuStrip2";
            this.ReasMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // TovarMenuStrip
            // 
            this.TovarMenuStrip.Name = "contextMenuStrip2";
            this.TovarMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Основное окно";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.EmpMenuStrip.ResumeLayout(false);
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
        private ContextMenuStrip EmpMenuStrip;
        private ToolStripMenuItem начислитьБаллыToolStripMenuItem;
        private ToolStripMenuItem списатьToolStripMenuItem;
        private ToolStripMenuItem историяСписанийИНачисленийToolStripMenuItem;
        private ToolStripMenuItem TovarsToolStripMenuItem;
        private ToolStripMenuItem HistoryToolStripMenuItem;
        private ContextMenuStrip DepMenuStrip;
        private ContextMenuStrip ReasMenuStrip;
        private ContextMenuStrip TovarMenuStrip;
        private ToolStripMenuItem LimitsToolStripMenuItem;
    }
}