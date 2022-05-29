
namespace ScoreManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            updategridToolStripMenuItem_Click(sender, e);
        }

        private void addscore(object sender, EventArgs e)
        {

        }

        private void updategridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                dataGridView1.DataSource = db.Reasons.ToList();
            }
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Reasons.Add(new Reason() { Name = "Переаботал 12 часов", Score = 125});
                db.SaveChanges();
            }
        }
    }
}