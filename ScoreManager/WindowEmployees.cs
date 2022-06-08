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
    public partial class WindowEmployees : Form
    {
        private Employees emp;
        public WindowEmployees(Main Sender, Employees employees = null)
        {
            this.Load += (s, e) => Sender.Enabled = false;
            this.FormClosing += (s, e) => { Sender.Enabled = true; Sender.updategridToolStripMenuItem_Click(Sender.selected, new EventArgs()); };
            InitializeComponent();
            List<Department> list;
            using (ApplicationContext db = new ApplicationContext())
            {
                list = db.Departments.ToList();
                comboBox1.Items.AddRange(list.ToArray());

            }
            emp = null;
            if (employees != null)
            {
                // В связи с тем, что у employees свойство Departament равно null, приходится использовать хитрость с поиском
                // записи сотрудника и последующем поиском idшника отдела.

                textBox1.Text = employees.FullName;
                using (ApplicationContext db = new ApplicationContext())
                { 
                    //comboBox1.DataSource = departments;
                    emp = db.historyBalanceEmployees.Get().Where(s => s.Id == employees.Id).First();
                    comboBox1.SelectedIndex = list.IndexOf(emp.Department);
                }
            }
        }

        private void AddEmployees_Load(object sender, EventArgs e)
        {
            
                
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
                    if (emp != null)
                    {
                        emp.FullName = textBox1.Text;
                        emp.Department = db.Departments.FirstOrDefault(s => s == (Department)comboBox1.SelectedItem);
                        db.historyBalanceEmployees.Update(emp);
                    }
                    else
                    {
                        db.historyBalanceEmployees.Add(new Employees() { FullName = textBox1.Text, Department = db.Departments.FirstOrDefault(s => s == (Department)comboBox1.SelectedItem) });
                    }
                    db.SaveChanges();
                }
                Close();
            } 
            catch (Exception)
            {
                MessageBox.Show("Не удалось сохранить данные");
            }
        }
    }
}
