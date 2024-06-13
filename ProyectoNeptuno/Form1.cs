using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoNeptuno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 VEN2 = new Form2();
            this.Hide();
            VEN2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 VEN3 = new Form3();
            this.Hide();
            VEN3.Show();

        }
    }
}
