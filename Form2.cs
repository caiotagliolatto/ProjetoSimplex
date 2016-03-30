using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class sec : Form
    {
        static int vf, vb, deci = 0;
        public sec(int f, int b, int d)
        {
            vf = f;
            vb = b;
            d = deci;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main variaveis = new main();
            variaveis.Show();
        }

        private void textbut_Click(object sender, EventArgs e)
        {
            doit();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
        private void doit()
        {
            MessageBox.Show("variaveis :" + vf + vb + deci, "vars");
        }
    }
}
