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
    public partial class WindowReasons : Form
    {
        Reason reason;
        public WindowReasons(Main Sender, Reason reason = null)
        {
            Load += (s, e) => Sender.Enabled = false;
            FormClosing += (s, e) => { Sender.Enabled = true; Sender.updategridToolStripMenuItem_Click(Sender.selected, new EventArgs()); };
            InitializeComponent();
            this.reason = reason;

            if (reason != null)
            { 
                textBox1.Text = reason.Name;
                textBox2.Text = reason.Score.ToString();
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar));

        private void button2_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    if (reason != null)
                    {
                        reason.Name = textBox1.Text;
                        reason.Score = uint.Parse(textBox2.Text);
                        db.Reasons.Update(reason);
                    }
                    else
                    {
                        db.Reasons.Add(new Reason() { Name = textBox1.Text, Score = uint.Parse(textBox2.Text) });
                    }
                    db.SaveChanges();
                }catch (Exception)
                {
                    MessageBox.Show("Неудалось добавить причину");
                }
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
