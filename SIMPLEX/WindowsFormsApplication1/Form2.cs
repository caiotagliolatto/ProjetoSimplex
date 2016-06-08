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
        static int vf, vb, deci = 0, helpVar2 = 0, helpVar = 0;
        DataTable tbDataGridM = new DataTable();
        float[,] matrizSimplex = new float[0, 0];
        float[,] MatrizIlimitada = new float[0, 0];
        public sec(int f, int b, int d)
        {
            vf = f;
            vb = b;
            deci = d;
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            main variaveis = new main();
            variaveis.Show();
        }

        private void textbut_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

           resultBox.Items.Clear();
            if (tbDataGridM.Rows.Count > 0)
            {
                for (int linha = 0; linha < tbDataGridM.Rows.Count; linha++)
                {
                    resultBox.Items.Add(tbDataGridM.Rows[linha][0].ToString() + " = " + float.Parse(tbDataGridM.Rows[linha][vf + vb + 1].ToString()).ToString("N1"));
                }
            }
            else
                MessageBox.Show("Nao existe matriz", "Erro de matriz", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    private void button1_Click_1(object sender, EventArgs e)
        {

            if (deci==1)
            {
                itMax(matrizSimplex);
            }
            else if (deci==2)
            {

               // itMin(matrizSimplex);
            }
            else
            {
                MessageBox.Show("Selecione um tipo!", "Erro");
            }
        }

        private void Simplex_Load(object sender, EventArgs e)
        {

        }

        public float[,] itMax(float[,] Matriz)
        {
            int Xpivo = 0, Ypivo = 0, X = 0, Y = 0;
            float pivo = 0, menorZ = 0, Aux = 0, primeiraDiv = 0;
            int contador = 0;
            bool flag = true;

            for (X = 0; X < Matriz.GetLength(0); X++)
            {
                for (Y = 0; Y < Matriz.GetLength(1); Y++)
                {
                    Matriz[X, Y] = float.Parse(tbDataGridM.Rows[X][Y + 1].ToString());
                }
            }

            float[,] MatrizAux = new float[vf + 1, vb + vf + 1];

            for (X = 0; X < Matriz.GetLength(0); X++)
            {
                for (Y = 0; Y < Matriz.GetLength(1); Y++)
                {
                    MatrizAux[X, Y] = Matriz[X, Y];
                }
            }

            for (Y = 0; Y < Matriz.GetLength(1); Y++)
            {
                if (Matriz[(Matriz.GetLength(0) - 1), Y] < 0) { contador = 1; }
            }

            if (contador != 1)
            {
                MessageBox.Show("Fim das iterações, Resultado Impresso Abaixo.", "Resultado");

                resultBox.Items.Clear();
                if (tbDataGridM.Rows.Count > 0)
                {
                    for (int linha = 0; linha < tbDataGridM.Rows.Count; linha++)
                    {
                        resultBox.Items.Add(tbDataGridM.Rows[linha][0].ToString() + " = " + float.Parse(tbDataGridM.Rows[linha][vf + vb + 1].ToString()).ToString("N1"));
                    }
                }
                else
                    MessageBox.Show("Nao existe matriz", "Erro de matriz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (contador == 1)
            {

                for (X = (Matriz.GetLength(0) - 1); X < Matriz.GetLength(0); X++)
                {
                    for (Y = 0; Y < Matriz.GetLength(1) - 1; Y++)
                    {
                        if ((Matriz[X, Y] < 0) && (Matriz[X, Y] < menorZ))
                        {
                            menorZ = Matriz[X, Y]; Ypivo = Y;
                        }
                    }
                }

                primeiraDiv = Matriz[0, (Matriz.GetLength(1) - 1)] / Matriz[0, Ypivo];
                for (X = 0; X < (Matriz.GetLength(0) - 1); X++)
                {
                    for (Y = Matriz.GetLength(1) - 1; Y < Matriz.GetLength(1); Y++)
                    {
                        if (Matriz[X, Y] / Matriz[X, Ypivo] < primeiraDiv && Matriz[X, Y] / Matriz[X, Ypivo] > 0)
                        {
                            Aux = Matriz[X, Y]; Xpivo = X;
                        }
                    }
                }

                pivo = Matriz[Xpivo, Ypivo];

                for (X = Xpivo; X <= Xpivo; X++)
                {
                    for (Y = 0; Y < Matriz.GetLength(1); Y++)
                    {
                        Matriz[X, Y] /= pivo; MatrizAux[X, Y] = Matriz[X, Y];
                    }
                }

                for (X = 0; X < Matriz.GetLength(0); X++)
                {
                    for (Y = 0; Y < Matriz.GetLength(1); Y++)
                    {
                        if (X != Xpivo)
                        {
                            MatrizAux[X, Y] = Matriz[Xpivo, Y] * (-1 * Matriz[X, Ypivo]) + Matriz[X, Y];
                        }
                    }
                }

                for (X = 0; X < Matriz.GetLength(0); X++)
                {
                    for (Y = 0; Y < Matriz.GetLength(1); Y++)
                    {
                        Matriz[X, Y] = MatrizAux[X, Y];
                    }
                }

                for (X = 0; X < Matriz.GetLength(0); X++)
                {
                    for (Y = 0; Y < Matriz.GetLength(1); Y++)
                    {
                        tbDataGridM.Rows[X][Y + 1] = (Matriz[X, Y].ToString());
                    }
                }

                tbDataGridM.Rows[Xpivo][0] = (tbDataGridM.Columns[Ypivo + 1].ColumnName.ToString());

                for (X = 0; X < Matriz.GetLength(0); X++)
                {
                    if (flag != true)
                    {
                        break;
                    }

                    for (Y = 0; Y < Matriz.GetLength(1); Y++)
                    {
                        if (MatrizIlimitada[X, Y] != Matriz[X, Y])
                        {
                            flag = false;
                            break;
                        }
                        else { helpVar = 2; }
                    }
                }

                if (helpVar2 == 0)
                {
                    for (X = 0; X < Matriz.GetLength(0); X++)
                    {
                        for (Y = 0; Y < Matriz.GetLength(1); Y++)
                        {
                            MatrizIlimitada[X, Y] = Matriz[X, Y];
                        }
                    }
                    helpVar2 = 1;
                }


            }
            return (Matriz);
        }

    private void main_Load(object sender, EventArgs e)
        {

        }
    }
}
