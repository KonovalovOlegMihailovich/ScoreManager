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
    public partial class WindowTovar : Form
    {
        Tovar tovar;
        public WindowTovar(Main Sender, Tovar tovar = null)
        {
            this.Load += (s, e) => Sender.Enabled = false;
            this.FormClosing += (s, e) => { Sender.Enabled = true; Sender.updategridToolStripMenuItem_Click(Sender.selected, new EventArgs()); };
            InitializeComponent();
            this.tovar = tovar;
        }

        private void WindowTovar_Load(object sender, EventArgs e)
        {
            if (tovar != null)
            {
                textBox1.Text = tovar.Name;
                textBox2.Text = tovar.Quantity.ToString();
                textBox3.Text = tovar.Price.ToString();
            }
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar));


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (textBox2.Text == "" || textBox1.Text == "" ||textBox3.Text == "")
                {
                    MessageBox.Show("Заполните поля");
                    return;
                }
                try
                {
                    if (tovar != null)
                    {
                        tovar.Name = textBox1.Text;
                        tovar.Quantity = uint.Parse(textBox2.Text);
                        tovar.Price = uint.Parse(textBox3.Text);
                        db.Tovars.Update(tovar);
                    }
                    else
                    {
                        db.Tovars.Add(new Tovar()
                        {
                            Name = textBox1.Text,
                            Quantity = uint.Parse(textBox2.Text),
                            Price = uint.Parse(textBox3.Text)
                        });
                    }
                    db.SaveChanges();
                }
                catch(Exception)
                {
                    MessageBox.Show("Невозможно сохранить данные");
                }
            }
            Close();
        }
    }
}
