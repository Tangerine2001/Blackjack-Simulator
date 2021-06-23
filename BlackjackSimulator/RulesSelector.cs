using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackSimulator
{
    public partial class RulesSelector : Form
    {
        public RulesSelector()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SinglePlayer form = new SinglePlayer(int.Parse(deckNumberText.Text), true, 1000);
            form.Show();
            this.Hide();
        }

        private void RulesSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
