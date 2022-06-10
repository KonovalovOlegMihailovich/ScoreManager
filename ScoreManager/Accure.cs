using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace ScoreManager
{
    public partial class Accure : Form
    {
        private Employees employees;
        private bool save = false;
        public Accure(Main Sender, Employees employees)
        {
            Load += (s, e) => Sender.Enabled = false;
            FormClosing += (s, e) => { Sender.Enabled = true; Sender.updategridToolStripMenuItem_Click(Sender.Selected, new EventArgs()); };
            this.employees = employees;
            InitializeComponent();
        }

        private void Accure_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                employees = db.historyBalanceEmployees.Get().First(x => x.Id == employees.Id);
                Department dep = db.Departments.Include(x => x.Employees).Include(x => x.Reasons).First(x => x.Id == employees.Department.Id);
                label3.Text = dep.DepartmentName;
                toolStripStatusLabel2.Text = dep.Balance.ToString();
                checkedListBox1.Items.AddRange(dep.Reasons.ToArray());
                checkedListBox2.Items.AddRange(dep.Employees.ToArray());
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                    if (((Employees)checkedListBox2.Items[i]).Id == employees.Id)
                    {
                        checkedListBox2.SetItemChecked(i, true);
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Внимание", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                save = true;
                checkedListBox_ItemCheck(this, new ItemCheckEventArgs(0, CheckState.Checked, CheckState.Checked));
                Close();
            }
        }
            // Вне зависимости от изменений делаем полный перерасчёт всего
        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Reason> checkedItems = new List<Reason>();
                foreach (Reason item in checkedListBox1.CheckedItems)
                    checkedItems.Add(item);
                if (sender == checkedListBox1)
                    if (e.NewValue == CheckState.Checked)
                        checkedItems.Add((Reason)checkedListBox1.Items[e.Index]);
                    else
                        checkedItems.Remove((Reason)checkedListBox1.Items[e.Index]);

                List<Employees> checkedItems2 = new List<Employees>();
                foreach (Employees item in checkedListBox2.CheckedItems)
                    checkedItems2.Add(item);
                if (sender == checkedListBox2)
                    if (e.NewValue == CheckState.Checked)
                        checkedItems2.Add((Employees)checkedListBox2.Items[e.Index]);
                    else
                        checkedItems2.Remove((Employees)checkedListBox2.Items[e.Index]);

                employees = db.historyBalanceEmployees.Get().First(x => x.Id == employees.Id);
                Department dep = db.Departments.Include(x => x.Employees).Include(x => x.Reasons).First(x => x.Id == employees.Department.Id);
                uint sum = 0;
                foreach (Reason reason in checkedItems)
                    sum += reason.Score;
                foreach (Employees emp in checkedItems2)
                    db.historyBalanceEmployees.Enrollment(db.historyBalanceEmployees.Get().First(x => x.Id == emp.Id), sum);
                toolStripStatusLabel2.Text = dep.Balance.ToString();

                if (save)
                { 
                    db.Departments.Update(dep);
                    db.SaveChanges();
                }
             }
        }
    }
}
