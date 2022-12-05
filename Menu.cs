using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadanie1;
using Zadanie2;
using Zadanie3;
using Zadanie4;
using Zadanie5;

namespace IS_2_20_HajievAA_Uchebka
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form x1 = new Ex1();
            x1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form x2 = new Ex2();
            x2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form x3 = new Ex3();
            x3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form x4 = new Ex4();
            x4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form x5 = new Ex5();
            x5.ShowDialog();
        }
    }
}
