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
                // У department нет связи с записями в других таблицами, поэтому поля Employees, Reasons и Limints равны null.
                // Со связями many-to-* надо работать через SelectMany
              
                checkedListBox1.Items.AddRange(db.Reasons.ToArray());
                if (department != null)
                {
                    List<Reason> reasons = db.Departments.Where(s => s.Id == department.Id).SelectMany(s => s.Reasons).ToList();
                    textBox1.Text = department.DepartmentName;
                    foreach (Reason reason in reasons)
                    {
                        department = db.Departments.Where(s => s.Id == department.Id).First();
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            if (checkedListBox1.Items[i] == reason)
                            {
                                checkedListBox1.SetItemChecked(i, true);
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
                List<Limits> limits = new List<Limits>();
                using (ApplicationContext db = new ApplicationContext())
                {
                    foreach (Reason reason in checkedListBox1.CheckedItems)
                    {
                        reasons.Add(db.Reasons.Where(s=>s.Id == reason.Id).First());
                    }
                    if (department != null)
                    {
                        department = db.Departments.Include(x => x.Reasons).Include(x => x.Limits).Include(x => x.Employees).First(x => x.Id == department.Id);
                        department.DepartmentName = textBox1.Text;
                        department.Reasons = reasons;
                        db.SaveChanges();
                    }
                    else
                    {
                        department = new Department()
                        {
                            DepartmentName = textBox1.Text
                        };
                        department.Reasons.AddRange(reasons);
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
    }
}
