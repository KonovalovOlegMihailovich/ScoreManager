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
    public partial class WindowDepartament : Form
    {
        Department department;
        public WindowDepartament(Main Sender, Department department = null)
        {
            Load += (s, e) => Sender.Enabled = false;
            FormClosing += (s, e) => { Sender.Enabled = true; Sender.updategridToolStripMenuItem_Click(Sender.selected, new EventArgs()); };
            InitializeComponent();
            this.department = department;
        }

        private void WindowDepartament_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            { 
                checkedListBox1.Items.AddRange(db.Reasons.ToArray());
                checkedListBox2.Items.AddRange(db.historyBalanceEmployees.Get().ToArray());
                comboBox1.Items.AddRange(db.Limits.ToArray());
                checkBox2.Visible = false;
                if (department != null)
                {
                    checkBox2.Visible = true;
                    department = db.Departments.Include(x => x.Reasons).Include(x => x.Limits).Include(x => x.Employees).First(x => x.Id == department.Id);
                    comboBox1.SelectedIndex = db.Limits.ToList().IndexOf(department.Limits);
                    List<Reason> reasons = department.Reasons;
                    List<Employees> employees = department.Employees;
                    textBox1.Text = department.DepartmentName;
                    foreach (Reason reason in reasons)
                    {
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            if (checkedListBox1.Items[i] == reason)
                            {
                                checkedListBox1.SetItemChecked(i, true);
                                break; // Если элемент найден, нет смысл перебирать список дальше.
                            }
                        }
                    }
                    foreach (Employees emp in employees)
                    {
                        for (int i = 0; i < checkedListBox2.Items.Count; i++)
                        {
                            if (checkedListBox2.Items[i] == emp)
                            {
                                checkedListBox2.SetItemChecked(i, true);
                                break; // Если элемент найден, нет смысл перебирать список дальше.
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "") throw new Exception();
                List<Reason> reasons = new List<Reason>();
                List<Employees> employees = new List<Employees>();
                using (ApplicationContext db = new ApplicationContext())
                {
                    foreach (Reason reason in checkedListBox1.CheckedItems)
                    {
                        reasons.Add(db.Reasons.First(s=>s.Id == reason.Id));
                    }
                    foreach (Employees emp  in checkedListBox2.CheckedItems)
                    {
                        employees.Add(db.historyBalanceEmployees.Get().First(s => s.Id == emp.Id));
                    }
                    if (department != null)
                    {
                        department = db.Departments.Include(x => x.Reasons).Include(x => x.Limits).Include(x => x.Employees).First(x => x.Id == department.Id);
                        department.DepartmentName = textBox1.Text;
                        department.Reasons = reasons;
                        if (checkBox1.Checked)
                            department.Employees.AddRange(employees);
                        else
                            department.Employees = employees;
                        department.Limits = db.Limits.FirstOrDefault(s => s == ((Limits)comboBox1.SelectedItem));
                        db.SaveChanges();
                    }
                    else
                    {
                        department = new Department()
                        {
                            DepartmentName = textBox1.Text,
                            Limits = db.Limits.FirstOrDefault(s => s == ((Limits)comboBox1.SelectedItem))
                        };
                        department.Reasons.AddRange(reasons);
                        department.Employees.AddRange(employees);
//                        department.Limits = db.Limits.FirstOrDefault(s => s.Id == ((Limits)comboBox1.SelectedItem).Id);
                        db.Departments.Add(department);
                    }
                    db.SaveChanges();
                }
                Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Не возможно сохранить изменения");
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (checkBox1.Checked)
                {
                    checkBox2.Enabled = false;
                    foreach (Department dep in db.Departments.Include(x => x.Employees).ToArray())
                        foreach (Employees emp in dep.Employees)
                            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                                if (emp.Id == ((Employees)checkedListBox2.Items[i]).Id)
                                {
                                    checkedListBox2.Items.Remove(checkedListBox2.Items[i]);
                                    break;
                                }
                }
                else
                {
                    checkBox2.Enabled = true;
                    checkedListBox2.Items.Clear();
                    checkedListBox2.Items.AddRange(db.historyBalanceEmployees.Get().ToArray());
                    if (department != null)
                        foreach (Employees emp in department.Employees)
                            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                                if (((Employees)checkedListBox2.Items[i]).Id == emp.Id)
                                {
                                    checkedListBox2.SetItemChecked(i, true);
                                    break; // Если элемент найден, нет смысл перебирать список дальше.
                                }
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (checkBox2.Checked)
                {
                    checkBox1.Enabled = false;
                    checkedListBox2.Items.Clear();
                    checkedListBox2.Items.AddRange(department.Employees.ToArray());
                    for (int i = 0; i < checkedListBox2.Items.Count; i++)
                        checkedListBox2.SetItemChecked(i, true);
                }
                else
                {
                    checkBox1.Enabled = true;
                    checkedListBox2.Items.Clear();
                    checkedListBox2.Items.AddRange(db.historyBalanceEmployees.Get().ToArray());
                    if (department != null)
                        foreach (Employees emp in department.Employees)
                            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                                if (((Employees)checkedListBox2.Items[i]).Id == emp.Id)
                                {
                                    checkedListBox2.SetItemChecked(i, true);
                                    break; // Если элемент найден, нет смысл перебирать список дальше.
                                }
                }
            }
        }
    }
}
