using Microsoft.EntityFrameworkCore;
namespace ScoreManager
{
    public partial class Main : Form
    {
        private Dictionary<object, IEnumerable<object>> EselectTable;
        private Dictionary<object, Form> Adds;
        private delegate void f();
        private Dictionary<object, f> delete;
        private Dictionary<object, ContextMenuStrip> menus;
        private Dictionary<object, ContextMenuStrip> Multimenus;
        public object Selected { get; private set; }
        public Main()
        {
            InitializeComponent();
        }
        private void Create_Digalogs()
        {
            Adds = new Dictionary<object, Form>()
            {
                [EmpToolStripMenuItem] = new WindowEmployees(this),
                [ReasonsToolStripMenuItem] = new WindowReasons(this),
                [DepToolStripMenuItem] = new WindowDepartament(this),
                [TovarsToolStripMenuItem] = new WindowTovar(this),
                [LimitsToolStripMenuItem] = new WindowLimits(this),
            };
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Create_Digalogs();
            var r = () => { };
            delete = new Dictionary<object, f>()
            {
                [EmpToolStripMenuItem] = () =>
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                            db.historyBalanceEmployees.Remove(uint.Parse(row.Cells["Id"].Value.ToString()));
                        db.SaveChanges();
                    }
                },
                [ReasonsToolStripMenuItem] = () =>
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                            db.Reasons.Remove(db.Reasons.First(s => s.Id == uint.Parse(row.Cells["Id"].Value.ToString())));
                        db.SaveChanges();
                    }
                },
                [DepToolStripMenuItem] = () =>
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            Department dep = db.Departments.Include(x => x.Employees).First(s => s.Id == uint.Parse(row.Cells["Id"].Value.ToString()));
                            foreach (Employees emp in dep.Employees)
                                emp.Department = null;
                            db.Departments.Remove(dep);
                        }
                        db.SaveChanges();
                    }
                },
                [TovarsToolStripMenuItem] = () =>
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                            db.Tovars.Remove(db.Tovars.First(s => s.Id == uint.Parse(row.Cells["Id"].Value.ToString())));
                        db.SaveChanges();
                    }
                },
                [LimitsToolStripMenuItem] = () =>
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            Limits limits = db.Limits.Include(x => x.departments).First(s => s.Id == uint.Parse(row.Cells["Id"].Value.ToString()));
                            foreach (Department dep in limits.departments)
                                dep.Limits = null;
                            db.Limits.Remove(limits);
                        }
                        db.SaveChanges();
                    }
                }
                // Историю нет смысла удалять, она нужна для подсчётов.
            };
            menus = new Dictionary<object, ContextMenuStrip>()
            {
                [EmpToolStripMenuItem] = EmpMenuStrip,
                [ReasonsToolStripMenuItem] = ReasMenuStrip,
                [DepToolStripMenuItem] = DepMenuStrip,
                [TovarsToolStripMenuItem] = new ContextMenuStrip(),// Для товара нет смысла делать менюшку
                [HistoryToolStripMenuItem] = new ContextMenuStrip(),// Для истории так же
                [LimitsToolStripMenuItem] = limitsMenuStrip
            };
            Multimenus = new Dictionary<object, ContextMenuStrip>()
            {
                [EmpToolStripMenuItem] = MultiEmpcontextMenuStrip,
                [ReasonsToolStripMenuItem] = new ContextMenuStrip(),
                [DepToolStripMenuItem] = new ContextMenuStrip(),
                [TovarsToolStripMenuItem] = new ContextMenuStrip(),// Для товара нет смысла делать менюшку
                [HistoryToolStripMenuItem] = new ContextMenuStrip(),// Для истории так же
                [LimitsToolStripMenuItem] = new ContextMenuStrip()
            };
            SelectedDB(EmpToolStripMenuItem, e);
            using (ApplicationContext db = new ApplicationContext())
            {
                Company company = db.GetCompany();
                Login l = new Login();
                db.Logins.Add(l); // Фиксируем вход
                toolStripStatusLabel4.Text = l.Date.ToString();
                db.SaveChanges();
                if (db.Logins.First().Date.Month < db.Logins.OrderBy(x => x.Id).Last().Date.Month) // 
                {
                    db.Logins.RemoveRange(db.Logins.Where(x => x.Date.Month < db.Logins.Last().Date.Month));
                    uint sum = 0;
                    foreach (Department dep in db.Departments.Include(x => x.Limits).ToList())
                    {
                        sum += dep.Balance;
                        if (dep.Limits != null)
                            dep.Balance = dep.Limits.ToArray()[db.Logins.OrderBy(x => x.Id).Last().Date.Month - 1];
                        else
                            dep.Balance = 0; // Для безлимитных отделов баланс 0.
                    }
                    db.UpBalance(sum);
                    db.SaveChanges();
                }
                toolStripStatusLabel2.Text = company.Balance.ToString();
            }
        }

        public void updategridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Company company = db.GetCompany();
                toolStripStatusLabel2.Text = company.Balance.ToString();
                EselectTable = new Dictionary<object, IEnumerable<object>>() // Заполняем словарь, нужными значениями для удобного выбора БД
                {
                    [ReasonsToolStripMenuItem] = db.Reasons.ToList(),
                    [DepToolStripMenuItem] = db.Departments.ToList(),
                    [EmpToolStripMenuItem] = db.historyBalanceEmployees.Get(),
                    [TovarsToolStripMenuItem] = db.Tovars.ToList(),
                    [HistoryToolStripMenuItem] = db.historyBalanceEmployees.GetHistories(),
                    [LimitsToolStripMenuItem] =  db.Limits.ToList()
                };
                dataGridView1.DataSource = EselectTable[Selected];
                dataGridView1.ContextMenuStrip = menus[Selected];
                PravkaToolStripMenuItem.Enabled = !(HistoryToolStripMenuItem == Selected); // Блокируем кнопку правки на таблице с историей.
                deleteToolStripMenuItem.Enabled = editToolStripMenuItem.Enabled = !(dataGridView1.Rows.Count == 0); // Блокируем кнопки удаления и изменения, если таблица пустая
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void SelectedDB(object sender, EventArgs e)
        {
            Selected = sender;
            updategridToolStripMenuItem_Click(sender, e);
        }

        private void Add(object sender, EventArgs e)
        {
            Adds[Selected].Show();
            Create_Digalogs();
        }

        private void Remove(object sender, EventArgs e)
        {
            delete[Selected]();
            updategridToolStripMenuItem_Click(Selected, e);
        }

        private void Edit(object sender, EventArgs e)
        {
            uint id = uint.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            using (ApplicationContext db = new ApplicationContext())
                if (Selected == EmpToolStripMenuItem)
                    new WindowEmployees(this, db.historyBalanceEmployees.Get().First(s => s.Id == id)).Show();
                else if (Selected == DepToolStripMenuItem)
                    new WindowDepartament(this, db.Departments.First(s => s.Id == id)).Show();
                else if (Selected == ReasonsToolStripMenuItem)
                    new WindowReasons(this, db.Reasons.First(s => s.Id == id)).Show();
                else if (Selected == TovarsToolStripMenuItem)
                    new WindowTovar(this, db.Tovars.First(s => s.Id == id)).Show();
                else if (Selected == LimitsToolStripMenuItem)
                    new WindowLimits(this, db.Limits.First(s => s.Id == id)).Show();
        }

        private void dataGridView1_SelectChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
                dataGridView1.ContextMenuStrip = Multimenus[Selected];
            else
                dataGridView1.ContextMenuStrip = menus[Selected]; 
        }

        private void Accure(object sender, EventArgs e)
        {
            uint id = uint.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            using (ApplicationContext db = new ApplicationContext())
                if (db.historyBalanceEmployees.Get().First(s => s.Id == id) != null)
                    new Accure(this, db.historyBalanceEmployees.Get().First(s => s.Id == id)).Show();
        }

        private void Writeoff(object sender, EventArgs e)
        {

        }

        private void History(object sender, EventArgs e)
        {

        }
    }
}