using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreManager
{
    public partial class History : Form
    {
        Employees employees;
        public History(Main Sender, Employees employees)
        {
            Load += (s, e) => Sender.Enabled = false;
            FormClosing += (s, e) => { Sender.Enabled = true; Sender.updategridToolStripMenuItem_Click(Sender.Selected, new EventArgs()); };
            InitializeComponent();
            this.employees = employees;
        }

        private void History_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //employees = db.historyBalanceEmployees.Get().First(x => x.Id == employees.Id);
                dataGridView1.DataSource = db.historyBalanceEmployees.GetHistories().Where(x => x.Entity.Id == employees.Id).ToList();
            }
        }
    }
}
