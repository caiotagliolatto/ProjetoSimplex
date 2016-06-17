using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProgramacaoDinamica_Mochila_0_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgItens.AllowUserToAddRows = false;                
            dgItens.ColumnCount = 40;
            dgItens.RowCount = 3;
            int[] peso = new int[15];
            int[] valor = new int[15];
            for (int i = 0; i < 15; i++)
            {
                dgItens.Rows[0].Cells[i].Value = i + 1;       
                dgItens.Rows[1].Cells[i].Value = peso[i];      
                dgItens.Rows[2].Cells[i].Value = valor[i];     
            }
            dgItens.Rows[0].HeaderCell.Value = "Item";
            dgItens.Rows[1].HeaderCell.Value = "Peso (kg)";
            dgItens.Rows[2].HeaderCell.Value = "Valor (R$)";
            dgItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;   
            dgItens.ColumnHeadersVisible = false;  
            dgItens.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);   
            
           
            dgDebug.AllowUserToAddRows = false;               
            dgDebug.ColumnCount = 1;
            dgDebug.RowCount = 3;
            dgDebug.Rows[0].HeaderCell.Value = "Peso subsolução";
            dgDebug.Rows[1].HeaderCell.Value = "Item inserido";
            dgDebug.Rows[2].HeaderCell.Value = "Peso subsolução anterior";
            dgDebug.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;   
            dgDebug.ColumnHeadersVisible = false;  
            dgDebug.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);   
        }

        private struct itens
        {
            public int p;  
            public int v;  
        }
        private struct lista
        {
            public int i;  
            public int a;  
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            try
            {
                int w = int.Parse(tbMochila.Text);
                int aux = 0;
                while (dgItens.Rows[1].Cells[aux].Value != null)
                {
                    aux++;
                }
                itens[] n = new itens[aux + 1];
                n[0].p = 0;
                n[0].v = 0;
                for (int i = 1; i < aux + 1; i++)
                {
                    n[i].p = int.Parse(dgItens.Rows[1].Cells[i-1].Value.ToString());
                    n[i].v = int.Parse(dgItens.Rows[2].Cells[i-1].Value.ToString());
                }

                Stopwatch stopwatch = new Stopwatch();

                bRun.Text = "Rodando...";
                bRun.Enabled = false;

                if (rbMochilaD.Checked)
                {
                    tbVD.Text = "";
                    tbPD.Text = "";
                    this.Refresh();
                    lista[] Lista = new lista[1];    
                    Lista[0].i = 0;
                    Lista[0].a = 0;
                    stopwatch.Start();
                    itens q = Mochila_0_1_Dinâmico(n, w, ref Lista);
                    stopwatch.Stop();
                    tbVD.Text = q.v.ToString();
                    tbPD.Text = q.p.ToString();

                    Print_Mochila_Itens(Lista);
                }

                bRun.Enabled = true;
                bRun.Text = "&Rodar algoritmo";
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro");
            }
        }


        private itens Mochila_0_1_Dinâmico(itens[] n, int w, ref lista[] Lista)
        {
            itens resposta;
            resposta.v = 0;
            resposta.p = 0;

            int c = n.Length;

            itens[] mochila = new itens[w + 1];
            mochila[0].p = 0;
            mochila[0].v = 0;

            Lista = new lista[w + 1];
            Lista[0].i = 0;
            Lista[0].a = 0;

            bool[] usado = new bool[c];
            for (int i = 0; i < c; i++)
            {
                usado[i] = false;
            }

            for (int peso = 1; peso <= w; peso++)
            {

                mochila[peso].p = mochila[peso-1].p;
                mochila[peso].v = mochila[peso-1].v;

                Lista[peso].i = 0;
                Lista[peso].a = peso-1;

                for (int item = 1; item < c; item++)
                {

                    if (peso >= n[item].p)
                    {

                        if (peso >= mochila[peso - n[item].p].p + n[item].p)
                        {
                            if (mochila[peso].v < mochila[peso - n[item].p].v + n[item].v)
                            {
                                bool ok = true;
                                int busca = peso - n[item].p;   
                                while(busca > 0)
                                {
                                    int itemAnt = Lista[busca].i;
                                    if (itemAnt == 0)
                                    {
                                    }
                                    if(itemAnt == item)
                                    {
                                        ok = false; 
                                        break;      
                                    }
                                    busca = Lista[busca].a;
                                }
                                if (ok == true)
                                {
                                    mochila[peso].v = mochila[peso - n[item].p].v + n[item].v;
                                    mochila[peso].p = mochila[peso - n[item].p].p + n[item].p;
                                    Lista[peso].i = item;
                                    Lista[peso].a = peso - n[item].p;
                                }
                            }
                        }
                    }
                }
            }
            resposta.v = mochila[w].v;
            resposta.p = mochila[w].p;
            return resposta;
        }
        
        private void Print_Mochila_Itens(lista[] Lista)
        {
            tbPrint.Text = "";
            int c = Lista.Length - 1;
            while (c > 0)
            {
                if (Lista[c].i != 0)
                {
                    tbPrint.Text += Lista[c].i.ToString() + ", ";
                }
                c = Lista[c].a;
             }
            if (tbPrint.Text.Length > 2)
            {
                tbPrint.Text = tbPrint.Text.Substring(0, tbPrint.Text.Length - 2);
            }
            dgDebug.ColumnCount = Lista.Length;
            for (int i = 0; i < dgDebug.ColumnCount; i++)
            {
                dgDebug.Rows[0].Cells[i].Value = null;
                dgDebug.Rows[1].Cells[i].Value = null;
                dgDebug.Rows[2].Cells[i].Value = null;
            }
            for (int i = 0; i < Lista.Length; i++)
            {
                dgDebug.Rows[0].Cells[i].Value = i.ToString();
                dgDebug.Rows[1].Cells[i].Value = Lista[i].i.ToString();
                dgDebug.Rows[2].Cells[i].Value = Lista[i].a.ToString();
            }
            int solução = Lista.Length - 1;
            while(solução > 0)
            {
                dgDebug.Rows[1].Cells[solução].Value = "* " + dgDebug.Rows[1].Cells[solução].Value;
                solução = int.Parse(dgDebug.Rows[2].Cells[solução].Value.ToString());
            }

        }

     
    }
}