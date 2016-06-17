namespace ProgramacaoDinamica_Mochila_0_1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgItens = new System.Windows.Forms.DataGridView();
            this.tbMochila = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPrint = new System.Windows.Forms.TextBox();
            this.tbPD = new System.Windows.Forms.TextBox();
            this.tbVD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbMochilaD = new System.Windows.Forms.RadioButton();
            this.bRun = new System.Windows.Forms.Button();
            this.dgDebug = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgItens)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDebug)).BeginInit();
            this.SuspendLayout();
            // 
            // dgItens
            // 
            this.dgItens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItens.Location = new System.Drawing.Point(15, 13);
            this.dgItens.Margin = new System.Windows.Forms.Padding(4);
            this.dgItens.Name = "dgItens";
            this.dgItens.Size = new System.Drawing.Size(605, 90);
            this.dgItens.TabIndex = 6;
            this.dgItens.TabStop = false;
            // 
            // tbMochila
            // 
            this.tbMochila.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMochila.Location = new System.Drawing.Point(467, 148);
            this.tbMochila.Margin = new System.Windows.Forms.Padding(4);
            this.tbMochila.MaxLength = 3;
            this.tbMochila.Name = "tbMochila";
            this.tbMochila.Size = new System.Drawing.Size(156, 22);
            this.tbMochila.TabIndex = 2;
            this.tbMochila.Text = "5";
            this.tbMochila.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Peso máximo da mochila";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbPrint);
            this.groupBox1.Controls.Add(this.tbPD);
            this.groupBox1.Controls.Add(this.tbVD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbMochilaD);
            this.groupBox1.Location = new System.Drawing.Point(18, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 89);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleção de algoritmo";
            // 
            // tbPrint
            // 
            this.tbPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPrint.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbPrint.Location = new System.Drawing.Point(180, 67);
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Size = new System.Drawing.Size(252, 22);
            this.tbPrint.TabIndex = 13;
            this.tbPrint.TabStop = false;
            // 
            // tbPD
            // 
            this.tbPD.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbPD.Location = new System.Drawing.Point(264, 26);
            this.tbPD.Name = "tbPD";
            this.tbPD.Size = new System.Drawing.Size(78, 22);
            this.tbPD.TabIndex = 11;
            this.tbPD.TabStop = false;
            // 
            // tbVD
            // 
            this.tbVD.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbVD.Location = new System.Drawing.Point(180, 26);
            this.tbVD.Name = "tbVD";
            this.tbVD.Size = new System.Drawing.Size(78, 22);
            this.tbVD.TabIndex = 11;
            this.tbVD.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Print-Mochila-Itens";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Valor (R$)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Peso (kg)";
            // 
            // rbMochilaD
            // 
            this.rbMochilaD.AutoSize = true;
            this.rbMochilaD.Checked = true;
            this.rbMochilaD.Location = new System.Drawing.Point(3, 26);
            this.rbMochilaD.Name = "rbMochilaD";
            this.rbMochilaD.Size = new System.Drawing.Size(160, 20);
            this.rbMochilaD.TabIndex = 3;
            this.rbMochilaD.TabStop = true;
            this.rbMochilaD.Text = "Mochila 0-1 (dinâmico)";
            this.rbMochilaD.UseVisualStyleBackColor = true;
            // 
            // bRun
            // 
            this.bRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRun.Location = new System.Drawing.Point(468, 177);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(156, 36);
            this.bRun.TabIndex = 3;
            this.bRun.Text = "&Rodar algoritmo";
            this.bRun.UseVisualStyleBackColor = true;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // dgDebug
            // 
            this.dgDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDebug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDebug.Location = new System.Drawing.Point(19, 220);
            this.dgDebug.Margin = new System.Windows.Forms.Padding(4);
            this.dgDebug.Name = "dgDebug";
            this.dgDebug.Size = new System.Drawing.Size(602, 90);
            this.dgDebug.TabIndex = 14;
            this.dgDebug.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 318);
            this.Controls.Add(this.dgDebug);
            this.Controls.Add(this.bRun);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMochila);
            this.Controls.Add(this.dgItens);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programação Dinâmica - Problema: Mochila 0-1 ou 0-1 Knapsack Problem";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItens)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDebug)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgItens;
        private System.Windows.Forms.TextBox tbMochila;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbVD;
        private System.Windows.Forms.RadioButton rbMochilaD;
        private System.Windows.Forms.TextBox tbPrint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgDebug;
    }
}

