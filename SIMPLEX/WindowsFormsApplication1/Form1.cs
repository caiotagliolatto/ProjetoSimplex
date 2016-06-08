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
    public partial class main : Form
    {
        static int varFolg, varBasic, dec = 0;
        
        public main()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maxbut.Checked)
            {
                maxbut.Enabled = false;
                dec = 1;
            }
            else if (minbut.Checked)
            {
                minbut.Enabled = false;
                dec = 2;
            }
            else { MessageBox.Show("Selecione um tipo!", "Erro"); }


            if (maxbut.Checked)
            {

                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    varFolg = Convert.ToInt32(textBox2.Text);
                    varBasic = Convert.ToInt32(textBox1.Text);
                    sec form2 = new sec(varBasic, varFolg, dec);
                    form2.Show();
                    Hide();
                    

                }
                else { MessageBox.Show("Variáveis inválidas !", "Erro de criação"); minbut.Enabled = true; maxbut.Enabled = true; }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
