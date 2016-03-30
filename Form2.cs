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
        
        //GERAÇÂO MATRIZ - COM AS VARIÁVEIS ATRIBUÍDAS A PARTIR DO MAINFORM
        private void textbut_Click(object sender, EventArgs e)
        {
            if (vf > 0 && vb > 0)
            {

                DataTable tbDataGridM2 = new DataTable();
                tbDataGridM2 = new DataTable();


               tbDataGridM2.Columns.Add("Base", typeof(string));


                for (int coluna = 1; coluna <= vb; coluna++)
                    tbDataGridM2.Columns.Add("X" + coluna, typeof(float));

                for (int coluna = 1; coluna <= vf; coluna++)
                    tbDataGridM2.Columns.Add("F" + coluna, typeof(float));

                tbDataGridM2.Columns.Add("B", typeof(float));


                object[] Linha = new object[tbDataGridM2.Columns.Count];


                for (int linha = 1; linha <= vf; linha++)
                {
                    Linha[0] = ("F" + linha).ToString();
                    for (int coluna = 1; coluna <= vf + vb + 1; coluna++)
                    {
                        if (tbDataGridM2.Columns[coluna].ColumnName.ToString() == "F" + linha.ToString()) { Linha[coluna] = 1.0; }
                        else { Linha[coluna] = 0.0; }
                    }
                    tbDataGridM2.Rows.Add(Linha);
                }

                for (int linha = vf; linha <= vf; linha++)
                {
                    Linha[0] = ("Z").ToString();
                    for (int coluna = 1; coluna < vf + vb + 1; coluna++) { Linha[coluna] = 0.0; }
                    tbDataGridM2.Rows.Add(Linha);
                }


                dataGridM.AllowUserToAddRows = false;
                dataGridM.AllowUserToOrderColumns = false;
                dataGridM.DataSource = tbDataGridM2;
                dataGridM.Update();
                dataGridM.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
               

                tbDataGridM = tbDataGridM2;

                matrizSimplex = new float[vf + 1, vf + vb + 1];
                MatrizIlimitada = new float[vf + 1, vb + vf + 1];

                for (int linha = 0; linha < matrizSimplex.GetLength(0); linha++)
                {
                    for (int coluna = 0; coluna < matrizSimplex.GetLength(1); coluna++)
                    {
                        matrizSimplex[linha, coluna] = float.Parse(tbDataGridM2.Rows[linha][coluna + 1].ToString());
                    }
                }
            }
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
