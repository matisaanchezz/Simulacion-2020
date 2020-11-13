namespace MonteCarlo2020
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_cant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_test = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_stock_inicial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Q = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_R = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Ko = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Ks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Km = new System.Windows.Forms.TextBox();
            this.btn_grafico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_cant
            // 
            this.txt_cant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_cant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cant.Location = new System.Drawing.Point(494, 34);
            this.txt_cant.Name = "txt_cant";
            this.txt_cant.Size = new System.Drawing.Size(100, 26);
            this.txt_cant.TabIndex = 0;
            this.txt_cant.Text = "11";
            this.txt_cant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese cantidad de semanas a simular:";
            // 
            // btn_test
            // 
            this.btn_test.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_test.FlatAppearance.BorderSize = 0;
            this.btn_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_test.Location = new System.Drawing.Point(680, 237);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(117, 57);
            this.btn_test.TabIndex = 7;
            this.btn_test.Text = "Test Montecarlo";
            this.btn_test.UseVisualStyleBackColor = false;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stock inicial:";
            // 
            // txt_stock_inicial
            // 
            this.txt_stock_inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_stock_inicial.Location = new System.Drawing.Point(234, 105);
            this.txt_stock_inicial.Name = "txt_stock_inicial";
            this.txt_stock_inicial.Size = new System.Drawing.Size(100, 26);
            this.txt_stock_inicial.TabIndex = 1;
            this.txt_stock_inicial.Text = "7";
            this.txt_stock_inicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tamaño de lote (Q):";
            // 
            // txt_Q
            // 
            this.txt_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Q.Location = new System.Drawing.Point(234, 178);
            this.txt_Q.Name = "txt_Q";
            this.txt_Q.Size = new System.Drawing.Size(100, 26);
            this.txt_Q.TabIndex = 3;
            this.txt_Q.Text = "6";
            this.txt_Q.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Punto de reposición (R):";
            // 
            // txt_R
            // 
            this.txt_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_R.Location = new System.Drawing.Point(234, 140);
            this.txt_R.Name = "txt_R";
            this.txt_R.Size = new System.Drawing.Size(100, 26);
            this.txt_R.TabIndex = 2;
            this.txt_R.Text = "2";
            this.txt_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(351, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Costo por pedido (Ko):";
            // 
            // txt_Ko
            // 
            this.txt_Ko.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ko.Location = new System.Drawing.Point(698, 175);
            this.txt_Ko.Name = "txt_Ko";
            this.txt_Ko.Size = new System.Drawing.Size(100, 26);
            this.txt_Ko.TabIndex = 6;
            this.txt_Ko.Text = "20";
            this.txt_Ko.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(351, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(292, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Costo de stock out por unidad (Ks):";
            // 
            // txt_Ks
            // 
            this.txt_Ks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ks.Location = new System.Drawing.Point(698, 140);
            this.txt_Ks.Name = "txt_Ks";
            this.txt_Ks.Size = new System.Drawing.Size(100, 26);
            this.txt_Ks.TabIndex = 5;
            this.txt_Ks.Text = "5";
            this.txt_Ks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(351, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(347, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Costo por mantenimiento por unidad (Km):";
            // 
            // txt_Km
            // 
            this.txt_Km.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Km.Location = new System.Drawing.Point(698, 105);
            this.txt_Km.Name = "txt_Km";
            this.txt_Km.Size = new System.Drawing.Size(100, 26);
            this.txt_Km.TabIndex = 4;
            this.txt_Km.Text = "3";
            this.txt_Km.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_grafico
            // 
            this.btn_grafico.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_grafico.FlatAppearance.BorderSize = 0;
            this.btn_grafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_grafico.Location = new System.Drawing.Point(547, 237);
            this.btn_grafico.Name = "btn_grafico";
            this.btn_grafico.Size = new System.Drawing.Size(127, 57);
            this.btn_grafico.TabIndex = 15;
            this.btn_grafico.Text = "Ver Gráfica";
            this.btn_grafico.UseVisualStyleBackColor = false;
            this.btn_grafico.Click += new System.EventHandler(this.btn_grafico_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_test;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(840, 330);
            this.Controls.Add(this.btn_grafico);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Ko);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Ks);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Km);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Q);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_R);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_stock_inicial);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cant);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test de Montecarlo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_cant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_stock_inicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Q;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_R;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Ko;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Ks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Km;
        private System.Windows.Forms.Button btn_grafico;
    }
}

