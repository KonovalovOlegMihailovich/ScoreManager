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
    public partial class AddEmployees : Form
    {
        public AddEmployees(Main Sender, Employees employees = null)
        {
            this.Load += (s, e) => Sender.Enabled = false;
            this.FormClosing += (s, e) => { Sender.Enabled = true; Sender.updategridToolStripMenuItem_Click(Sender.selected, new EventArgs()); };
            InitializeComponent();
        }

        private void AddEmployees_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                comboBox1.Items.AddRange(db.Departments.ToArray());
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (textBox1.Text.Length == 0) throw new Exception();
                    db.historyBalanceEmployees.Add(new Employees() { FullName = textBox1.Text, Department = db.Departments.Where(s => s == (Department)comboBox1.SelectedItem).First() });
                    db.SaveChanges();
                }
                Close();
            } 
            catch (Exception)
            {
                MessageBox.Show("Не удалось добавить сотрудника");
            }
        }
    }
}
