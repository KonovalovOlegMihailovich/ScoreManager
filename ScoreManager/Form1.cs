
namespace ScoreManager
{
    public partial class Form1 : Form
    {
        private Dictionary<object, IEnumerable<object>> EselectTable;
        private object selected;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            SelectedDB(ReasonsToolStripMenuItem, e);
        }

        private void addscore(object sender, EventArgs e)
        {

        }

        private void updategridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                EselectTable = new Dictionary<object, IEnumerable<object>>() // Заполняем словарь, нужными значениями для удобного выбора БД
                {
                    [ReasonsToolStripMenuItem] = db.historyBalanceEmployees.Get()
                    //    [DepToolStripMenuItem] = db.Departments.ToList(),
                    //    [EmpToolStripMenuItem] = db.Employees.ToList(),
                    //    [TovarsToolStripMenuItem] = db.Tovars.ToList()
                };
                dataGridView1.DataSource = EselectTable[selected];
            }
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(TimeSpan.Parse(DateTime.Now.ToLongTimeString()).ToString());
            using (ApplicationContext db = new ApplicationContext())
            {
                //db.Reasons.Add(new Reason() { Name = "Переаботал 12 часов", Score = 125});
                //db.SaveChanges();
            }
        }

        private void SelectedDB(object sender, EventArgs e)
        {
            selected = sender;
            updategridToolStripMenuItem_Click(sender, e);
        }
    }
}