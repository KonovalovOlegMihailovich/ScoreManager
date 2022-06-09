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
    public partial class WindowLimits : Form
    {
        Limits limits;
        public WindowLimits(Main Sender, Limits limits = null)
        {
            this.Load += (s, e) => Sender.Enabled = false;
            this.FormClosing += (s, e) => { Sender.Enabled = true; Sender.updategridToolStripMenuItem_Click(Sender.selected, new EventArgs()); };
            InitializeComponent();
            this.limits = limits;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar));

        private void WindowLimits_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                checkedListBox1.Items.AddRange(db.Departments.ToArray());
                if (limits != null)
                {
                    limits = db.Limits.Include(x => x.departments).First(x => x.Id == limits.Id);
                    textBox1.Text = limits.January.ToString();
                    textBox2.Text = limits.February.ToString();
                    textBox3.Text = limits.March.ToString();
                    textBox4.Text = limits.April.ToString();
                    textBox5.Text = limits.May.ToString();
                    textBox6.Text = limits.June.ToString();
                    textBox7.Text = limits.July.ToString();
                    textBox8.Text = limits.August.ToString();
                    textBox9.Text = limits.September.ToString();
                    textBox10.Text = limits.October.ToString();
                    textBox11.Text = limits.November.ToString();
                    textBox12.Text = limits.December.ToString();
                    foreach (Department department in limits.departments)
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            if (department == checkedListBox1.Items[i]) 
                            {
                                checkedListBox1.SetItemChecked(i, true);
                                break;
                            }
                } 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Department> departments = new List<Department>();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (Department department in checkedListBox1.CheckedItems)
                {
                    departments.Add(db.Departments.First(s=> s.Id == department.Id));
                }
                try
                {
                    if (limits != null)
                    {
                        limits.January = uint.Parse(textBox1.Text);
                        limits.February = uint.Parse(textBox2.Text);
                        limits.April = uint.Parse(textBox3.Text);
                        limits.March = uint.Parse(textBox4.Text);
                        limits.May = uint.Parse(textBox5.Text);
                        limits.June = uint.Parse(textBox6.Text);
                        limits.July = uint.Parse(textBox7.Text);
                        limits.August = uint.Parse(textBox8.Text);
                        limits.September = uint.Parse(textBox9.Text);
                        limits.October = uint.Parse(textBox10.Text);
                        limits.November = uint.Parse(textBox11.Text);
                        limits.December = uint.Parse(textBox12.Text);
                        limits.departments = departments;
                        db.Limits.Update(limits);
                    }
                    else
                    {
                        limits = new Limits()
                        {
                            January = uint.Parse(textBox1.Text),
                            February = uint.Parse(textBox2.Text),
                            April = uint.Parse(textBox3.Text),
                            March = uint.Parse(textBox4.Text),
                            May = uint.Parse(textBox5.Text),
                            June = uint.Parse(textBox6.Text),
                            July = uint.Parse(textBox7.Text),
                            August = uint.Parse(textBox8.Text),
                            September = uint.Parse(textBox9.Text),
                            October = uint.Parse(textBox10.Text),
                            November = uint.Parse(textBox11.Text),
                            December = uint.Parse(textBox12.Text),
                            departments = departments
                        };
                        db.Limits.Add(limits);
                    }
                    db.SaveChanges();
                    Close();
                }
                catch (Exception) 
                {
                    MessageBox.Show("Не удалось сохранить данные.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
