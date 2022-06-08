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
            if (limits != null)
            {
                checkedListBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
