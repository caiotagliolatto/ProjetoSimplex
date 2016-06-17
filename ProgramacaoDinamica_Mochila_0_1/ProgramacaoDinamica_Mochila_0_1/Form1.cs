using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Incluido manualmente
using System.Diagnostics;   //para uso do Stopwatch

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
            //Define as caracteristicas do DataGridView dgItens (tabela) 
            dgItens.AllowUserToAddRows = false;                //Bolqueia adição de linhas pelo usuário
            dgItens.ColumnCount = 40;
            dgItens.RowCount = 3;
            //Define um vetor de preços
            //int[] peso = new int[15] { 1, 1, 2, 5, 6, 6, 7, 8, 10, 12, 12, 15, 20, 30, 50 };
            //int[] valor = new int[15] { 50, 1000, 1200, 100, 222, 1000, 333, 100, 150, 5, 5000, 17, 20, 240, 2000 };
            int[] peso = new int[15];// { 1, 1, 1, 1, 1, 1, 7, 8, 10, 12, 12, 15, 20, 30, 50 };
            int[] valor = new int[15];// { 50, 100, 200, 300, 400, 500, 333, 100, 150, 5, 5000, 17, 20, 240, 2000 };
            for (int i = 0; i < 15; i++)
            {
                dgItens.Rows[0].Cells[i].Value = i + 1;        //Preenche os números dos itens
                dgItens.Rows[1].Cells[i].Value = peso[i];      //Preenche os peso de cada item
                dgItens.Rows[2].Cells[i].Value = valor[i];     //Preenche os valor de cada item
            }
            dgItens.Rows[0].HeaderCell.Value = "Item";
            dgItens.Rows[1].HeaderCell.Value = "Peso (kg)";
            dgItens.Rows[2].HeaderCell.Value = "Valor (R$)";
            dgItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;   //Ajusta a largura das colunas
            dgItens.ColumnHeadersVisible = false;  //Oculta o cabeçalho das colunas
            dgItens.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);   //Ajusta a largura dos cabeçalhos das colunas    
            
            //Debug solução usando programação dinâmica
            //Define as caracteristicas do DataGridView dgDebug (tabela) 
            dgDebug.AllowUserToAddRows = false;                //Bolqueia adição de linhas pelo usuário
            dgDebug.ColumnCount = 1;
            dgDebug.RowCount = 3;
            dgDebug.Rows[0].HeaderCell.Value = "Peso subsolução";
            dgDebug.Rows[1].HeaderCell.Value = "Item inserido";
            dgDebug.Rows[2].HeaderCell.Value = "Peso subsolução anterior";
            dgDebug.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;   //Ajusta a largura das colunas
            dgDebug.ColumnHeadersVisible = false;  //Oculta o cabeçalho das colunas
            dgDebug.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);   //Ajusta a largura dos cabeçalhos das colunas    
        }

        private struct itens
        {
            public int p;  //peso
            public int v;  //valor
        }
        private struct lista
        {
            public int i;  //item
            public int a;  //anterior
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            try
            {
                //Lê o peso máximo da mochila
                int w = int.Parse(tbMochila.Text);
                //Descobre a quantidade de itens
                int aux = 0;
                while (dgItens.Rows[1].Cells[aux].Value != null)
                {
                    aux++;
                }
                //Cria vetor de estrutura com itens
                itens[] n = new itens[aux + 1];
                //Preenche o vetor com os pesos e valores de 0 a n
                n[0].p = 0;
                n[0].v = 0;
                for (int i = 1; i < aux + 1; i++)
                {
                    n[i].p = int.Parse(dgItens.Rows[1].Cells[i-1].Value.ToString());
                    n[i].v = int.Parse(dgItens.Rows[2].Cells[i-1].Value.ToString());
                }
                //Cria um Stopwatch para medir o tempo
                Stopwatch stopwatch = new Stopwatch();
                //Desabilita o botão Run e troca o texto
                bRun.Text = "Rodando...";
                bRun.Enabled = false;
                //Se selecionou algoritmo Extended-Botton-Up-Cut-Rod
                if (rbMochilaD.Checked)
                {
                    tbVD.Text = "";
                    tbPD.Text = "";
                    this.Refresh();
                    lista[] Lista = new lista[1];    //Cria uma nova lista para receber os itens
                    Lista[0].i = 0;
                    Lista[0].a = 0;
                    stopwatch.Start();
                    itens q = Mochila_0_1_Dinâmico(n, w, ref Lista);
                    stopwatch.Stop();
                    tbVD.Text = q.v.ToString();
                    tbPD.Text = q.p.ToString();
                    //Escrever o método para o print dos itens da lista
                    Print_Mochila_Itens(Lista);
                }
                //Habilita o botão Run e troca o texto
                bRun.Enabled = true;
                bRun.Text = "&Rodar algoritmo";
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro");
            }
        }

        /// <summary>
        /// Coloca na mochila o maior valor possível
        /// usando programação dinâmica
        /// </summary>
        /// <param name="n">lista de itens com valor e peso começa no item 0 nulo</param>
        /// <param name="w">peso máximo da mochila</param>
        /// <param name="Lista">lista com itens selecionados e anterior saída por referência</param>
        /// <returns>peso e valor final da mochila</returns>
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

            //Para cada um dos pesos
            for (int peso = 1; peso <= w; peso++)
            {
                //Mochila começa com as características da mochila de peso uma unidade inferior
                mochila[peso].p = mochila[peso-1].p;
                mochila[peso].v = mochila[peso-1].v;
                //Lista começa com item 0 e peso uma unidade inferior
                Lista[peso].i = 0;
                Lista[peso].a = peso-1;

                //Para cada um dos itens
                for (int item = 1; item < c; item++)
                {
                    //Se o peso atual é maior que o peso do item
                    if (peso >= n[item].p)
                    {
                        //Se o peso atual é >= que o peso de uma solução ótima anterior + o peso do item atual
                        if (peso >= mochila[peso - n[item].p].p + n[item].p)
                        {
                            //Se o valor para o peso atual é < que o valor de uma solução ótima anterior + o valor do item atual
                            if (mochila[peso].v < mochila[peso - n[item].p].v + n[item].v)
                            {
                                //Busca em profundidade nos itens da subsolução ótima
                                bool ok = true;
                                int busca = peso - n[item].p;   //Item anterior
                                while(busca > 0)
                                {
                                    int itemAnt = Lista[busca].i;
                                    //Se o item anterior á nulo
                                    if (itemAnt == 0)
                                    {
                                        //busca--;    //Decrementa o peso da busca
                                        //continue;   //Pula para próxima iteração
                                    }
                                    //Se o item anterior é igual ao item atual
                                    if(itemAnt == item)
                                    {
                                        ok = false; //Não pode usar este item
                                        break;      //Quebra o laço
                                    }
                                    //busca -= n[itemAnt].p;  //Aprofunda a busca decrementado do  peso do item anterior
                                    busca = Lista[busca].a;
                                }
                                //Se o item atual é diferente dos itens das subsoluções ótimas anteriores
                                if (ok == true)
                                {
                                    //Atualiza a solução ótima atual
                                    mochila[peso].v = mochila[peso - n[item].p].v + n[item].v;
                                    mochila[peso].p = mochila[peso - n[item].p].p + n[item].p;
                                    //Grava o item e anterior selecionado para solução ótima com peso atual
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
            //Somente para bebug
            //Limpa a tabela de debug
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