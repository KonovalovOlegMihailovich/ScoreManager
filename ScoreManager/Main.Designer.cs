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
            this.EmpMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.начислитьБаллыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.историяСписанийИНачисленийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PravkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReasonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TovarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LimitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryDepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmpMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.начислитьБаллыToolStripMenuItem.Click += new System.EventHandler(this.Accure);
            // 
            // списатьToolStripMenuItem
            // 
            this.списатьToolStripMenuItem.Name = "списатьToolStripMenuItem";
            this.списатьToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.списатьToolStripMenuItem.Text = "Списать";
            this.списатьToolStripMenuItem.Click += new System.EventHandler(this.Writeoff);
            // 
            // историяСписанийИНачисленийToolStripMenuItem
            // 
            this.историяСписанийИНачисленийToolStripMenuItem.Name = "историяСписанийИНачисленийToolStripMenuItem";
            this.историяСписанийИНачисленийToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.историяСписанийИНачисленийToolStripMenuItem.Text = "Сведенья";
            this.историяСписанийИНачисленийToolStripMenuItem.Click += new System.EventHandler(this.History);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PravkaToolStripMenuItem,
            this.показатьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PravkaToolStripMenuItem
            // 
            this.PravkaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.editToolStripMenuItem.Text = "Изменить";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.Edit);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.Remove);
            // 
            // показатьToolStripMenuItem
            // 
            this.показатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReasonsToolStripMenuItem,
            this.EmpToolStripMenuItem,
            this.DepToolStripMenuItem,
            this.TovarsToolStripMenuItem,
            this.LimitsToolStripMenuItem,
            this.HistoryToolStripMenuItem,
            this.HistoryDepToolStripMenuItem});
            this.показатьToolStripMenuItem.Name = "показатьToolStripMenuItem";
            this.показатьToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.показатьToolStripMenuItem.Text = "Показать";
            // 
            // ReasonsToolStripMenuItem
            // 
            this.ReasonsToolStripMenuItem.Name = "ReasonsToolStripMenuItem";
            this.ReasonsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.ReasonsToolStripMenuItem.Text = "Причины";
            this.ReasonsToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // EmpToolStripMenuItem
            // 
            this.EmpToolStripMenuItem.Name = "EmpToolStripMenuItem";
            this.EmpToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.EmpToolStripMenuItem.Text = "Персонал";
            this.EmpToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // DepToolStripMenuItem
            // 
            this.DepToolStripMenuItem.Name = "DepToolStripMenuItem";
            this.DepToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.DepToolStripMenuItem.Text = "Отделы";
            this.DepToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // TovarsToolStripMenuItem
            // 
            this.TovarsToolStripMenuItem.Name = "TovarsToolStripMenuItem";
            this.TovarsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.TovarsToolStripMenuItem.Text = "Товары";
            this.TovarsToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // LimitsToolStripMenuItem
            // 
            this.LimitsToolStripMenuItem.Name = "LimitsToolStripMenuItem";
            this.LimitsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.LimitsToolStripMenuItem.Text = "Лимиты";
            this.LimitsToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // HistoryToolStripMenuItem
            // 
            this.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem";
            this.HistoryToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.HistoryToolStripMenuItem.Text = "История сотрудников";
            this.HistoryToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // HistoryDepToolStripMenuItem
            // 
            this.HistoryDepToolStripMenuItem.Name = "HistoryDepToolStripMenuItem";
            this.HistoryDepToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.HistoryDepToolStripMenuItem.Text = "История отделов";
            this.HistoryDepToolStripMenuItem.Click += new System.EventHandler(this.SelectedDB);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(967, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabel3.Text = "Время входа: ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel4.Text = "-";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel1.Text = "Баланс";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel2.Text = "-";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.EmpMenuStrip;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(967, 404);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Основное окно";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.EmpMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem PravkaToolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
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
        private ToolStripMenuItem LimitsToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private DataGridView dataGridView1;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripMenuItem HistoryDepToolStripMenuItem;
    }
}