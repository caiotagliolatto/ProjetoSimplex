namespace WindowsFormsApplication1
{
    partial class sec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridM = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridM)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridM
            // 
            this.dataGridM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridM.Location = new System.Drawing.Point(62, 11);
            this.dataGridM.Name = "dataGridM";
            this.dataGridM.Size = new System.Drawing.Size(793, 205);
            this.dataGridM.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Fazer Iteração";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // resultBox
            // 
            this.resultBox.FormattingEnabled = true;
            this.resultBox.Location = new System.Drawing.Point(43, 280);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(812, 108);
            this.resultBox.TabIndex = 6;
            // 
            // sec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 398);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridM);
            this.Name = "sec";
            this.Text = "SIMPLEX";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox resultBox;
    }
}

