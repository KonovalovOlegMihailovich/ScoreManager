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
    public partial class WriteOff : Form
    {
        private Employees employees;
        public WriteOff(Main Sender, Employees employees)
        {
            Load += (s, e) => Sender.Enabled = false;
            FormClosing += (s, e) => 
            { 
                Sender.Enabled = true; 
                Sender.updategridToolStripMenuItem_Click(Sender.Selected, new EventArgs()); 
            };
            InitializeComponent();
            this.employees = employees;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint sum = uint.Parse(textBox1.Text);
            if (sum > employees.Balance)
            {
                MessageBox.Show("Нельзя списать больше, чем баланс сотрудника!");
                return;
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                employees = db.historyBalanceEmployees.Get().First(x => x.Id == employees.Id);
                employees.Department.Balance += sum;
                db.historyBalanceEmployees.Writeoff(employees, sum);
                db.SaveChanges();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void textBox_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar));

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //MessageBox.Show(comboBox1.SelectedIndex.ToString());
                try
                {
                    employees = db.historyBalanceEmployees.Get().First(x => x.Id == ((Employees)comboBox1.SelectedItem).Id);
                }
                catch (Exception) { }
                toolStripStatusLabel2.Text = employees.Balance.ToString();
            }
        }

        private void WriteOff_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                employees = db.historyBalanceEmployees.Get().First(x => x.Id == employees.Id);
                if (employees.Department == null || employees.Balance == 0) Close();
                List<Employees> emp = db.historyBalanceEmployees.Get().Where(x => x.Balance > 0).ToList();
                comboBox1.Items.AddRange(emp.ToArray());
                comboBox1.SelectedIndex = emp.IndexOf(employees);
            }
        }
    }
}
