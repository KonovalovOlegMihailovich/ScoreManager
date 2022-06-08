using Microsoft.EntityFrameworkCore;
namespace ScoreManager
{
    public partial class Main : Form
    {
        private Dictionary<object, IEnumerable<object>> EselectTable;
        private Dictionary<object, Form> Adds;
        private delegate void f();
        private Dictionary<object, f> delete;
        public object selected { get; private set; }
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
            SelectedDB(EmpToolStripMenuItem, e);
            Create_Digalogs();
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
        }

        private void addscore(object sender, EventArgs e)
        {

        }

        public void updategridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                EselectTable = new Dictionary<object, IEnumerable<object>>() // Заполняем словарь, нужными значениями для удобного выбора БД
                {
                    [ReasonsToolStripMenuItem] = db.Reasons.ToList(),
                    [DepToolStripMenuItem] = db.Departments.ToList(),
                    [EmpToolStripMenuItem] = db.historyBalanceEmployees.Get(),
                    [TovarsToolStripMenuItem] = db.Tovars.ToList(),
                    [HistoryToolStripMenuItem] = db.historyBalanceEmployees.GetHistories(),
                    [LimitsToolStripMenuItem] =  db.Limits.ToList()
                };
                dataGridView1.DataSource = EselectTable[selected];
                PravkaToolStripMenuItem.Enabled = !(HistoryToolStripMenuItem == selected);
            }
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void SelectedDB(object sender, EventArgs e)
        {
            selected = sender;
            updategridToolStripMenuItem_Click(sender, e);
            удалитьToolStripMenuItem.Enabled = изменитьToolStripMenuItem.Enabled = !(dataGridView1.Rows.Count == 0);
        }

        private void Add(object sender, EventArgs e)
        {
            Adds[selected].Show();
            Create_Digalogs();
        }

        private void Remove(object sender, EventArgs e)
        {
            delete[selected]();
            updategridToolStripMenuItem_Click(selected, e);
        }

        private void Edit(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                uint id = uint.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
                if (selected == EmpToolStripMenuItem)
                    new WindowEmployees(this, db.historyBalanceEmployees.Get().First(s => s.Id == id)).Show();
                else if (selected == DepToolStripMenuItem)
                    new WindowDepartament(this, db.Departments.First(s => s.Id == id)).Show();
                else if (selected == ReasonsToolStripMenuItem)
                    new WindowReasons(this, db.Reasons.First(s => s.Id == id)).Show();
                else if (selected == TovarsToolStripMenuItem)
                    new WindowTovar(this, db.Tovars.First(s => s.Id == id)).Show();
                else if (selected == LimitsToolStripMenuItem)
                    new WindowLimits(this, db.Limits.First(s => s.Id == id)).Show();
                
            }
        }
    }
}