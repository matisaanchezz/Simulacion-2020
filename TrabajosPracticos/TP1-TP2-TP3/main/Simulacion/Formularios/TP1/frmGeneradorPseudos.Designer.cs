namespace Simulacion.Formularios
{
    partial class frm_generador_numeros
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_generador_numeros));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXo = new System.Windows.Forms.TextBox();
            this.txtK = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtNumerosAGenerar = new System.Windows.Forms.TextBox();
            this.rbtMixto = new System.Windows.Forms.RadioButton();
            this.rbtMultiplicativo = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnGenerar1Mas = new System.Windows.Forms.Button();
            this.dgvNumeros = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAyudaXo = new System.Windows.Forms.Button();
            this.tltAyuda = new System.Windows.Forms.ToolTip(this.components);
            this.btnAyudaK = new System.Windows.Forms.Button();
            this.btnAyudaG = new System.Windows.Forms.Button();
            this.btnAyudaC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumeros)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semilla (Xo):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Entero k:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Entero g:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Constante aditiva c:";
            // 
            // txtXo
            // 
            this.txtXo.Enabled = false;
            this.txtXo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXo.Location = new System.Drawing.Point(274, 84);
            this.txtXo.Name = "txtXo";
            this.txtXo.Size = new System.Drawing.Size(100, 26);
            this.txtXo.TabIndex = 2;
            this.txtXo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtXo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXo_KeyPress);
            // 
            // txtK
            // 
            this.txtK.Enabled = false;
            this.txtK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtK.Location = new System.Drawing.Point(274, 117);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(100, 26);
            this.txtK.TabIndex = 3;
            this.txtK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtK_KeyPress);
            // 
            // txtC
            // 
            this.txtC.Enabled = false;
            this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.Location = new System.Drawing.Point(274, 183);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(100, 26);
            this.txtC.TabIndex = 5;
            this.txtC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtC_KeyPress);
            // 
            // txtG
            // 
            this.txtG.Enabled = false;
            this.txtG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtG.Location = new System.Drawing.Point(274, 150);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(100, 26);
            this.txtG.TabIndex = 4;
            this.txtG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtG_KeyPress);
            // 
            // txtNumerosAGenerar
            // 
            this.txtNumerosAGenerar.Enabled = false;
            this.txtNumerosAGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumerosAGenerar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtNumerosAGenerar.Location = new System.Drawing.Point(535, 120);
            this.txtNumerosAGenerar.Name = "txtNumerosAGenerar";
            this.txtNumerosAGenerar.Size = new System.Drawing.Size(100, 26);
            this.txtNumerosAGenerar.TabIndex = 6;
            this.txtNumerosAGenerar.Text = "20";
            this.txtNumerosAGenerar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumerosAGenerar.Enter += new System.EventHandler(this.txtNumerosAGenerar_Enter);
            this.txtNumerosAGenerar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumerosAGenerar_KeyPress);
            this.txtNumerosAGenerar.Leave += new System.EventHandler(this.txtNumerosAGenerar_Leave);
            // 
            // rbtMixto
            // 
            this.rbtMixto.AutoSize = true;
            this.rbtMixto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMixto.Location = new System.Drawing.Point(66, 46);
            this.rbtMixto.Name = "rbtMixto";
            this.rbtMixto.Size = new System.Drawing.Size(110, 24);
            this.rbtMixto.TabIndex = 0;
            this.rbtMixto.TabStop = true;
            this.rbtMixto.Text = "Mixto/Lineal";
            this.rbtMixto.UseVisualStyleBackColor = true;
            this.rbtMixto.CheckedChanged += new System.EventHandler(this.rbtMixto_CheckedChanged);
            // 
            // rbtMultiplicativo
            // 
            this.rbtMultiplicativo.AutoSize = true;
            this.rbtMultiplicativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMultiplicativo.Location = new System.Drawing.Point(270, 46);
            this.rbtMultiplicativo.Name = "rbtMultiplicativo";
            this.rbtMultiplicativo.Size = new System.Drawing.Size(116, 24);
            this.rbtMultiplicativo.TabIndex = 1;
            this.rbtMultiplicativo.TabStop = true;
            this.rbtMultiplicativo.Text = "Multiplicativo";
            this.rbtMultiplicativo.UseVisualStyleBackColor = true;
            this.rbtMultiplicativo.CheckedChanged += new System.EventHandler(this.rbtMultiplicativo_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(387, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Seleccione el método congruencial que desea utilizar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(436, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cuántos números desea generar?";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(475, 161);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(90, 30);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnGenerar1Mas
            // 
            this.btnGenerar1Mas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerar1Mas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar1Mas.Enabled = false;
            this.btnGenerar1Mas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar1Mas.Location = new System.Drawing.Point(551, 494);
            this.btnGenerar1Mas.Name = "btnGenerar1Mas";
            this.btnGenerar1Mas.Size = new System.Drawing.Size(136, 41);
            this.btnGenerar1Mas.TabIndex = 8;
            this.btnGenerar1Mas.Text = "Ver próximo";
            this.btnGenerar1Mas.UseVisualStyleBackColor = true;
            this.btnGenerar1Mas.Click += new System.EventHandler(this.btnGenerar1Mas_Click);
            // 
            // dgvNumeros
            // 
            this.dgvNumeros.AllowUserToAddRows = false;
            this.dgvNumeros.AllowUserToDeleteRows = false;
            this.dgvNumeros.AllowUserToResizeColumns = false;
            this.dgvNumeros.AllowUserToResizeRows = false;
            this.dgvNumeros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNumeros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvNumeros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNumeros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNumeros.ColumnHeadersHeight = 30;
            this.dgvNumeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNumeros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvNumeros.EnableHeadersVisualStyles = false;
            this.dgvNumeros.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvNumeros.Location = new System.Drawing.Point(74, 237);
            this.dgvNumeros.Name = "dgvNumeros";
            this.dgvNumeros.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNumeros.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNumeros.RowHeadersWidth = 40;
            this.dgvNumeros.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvNumeros.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNumeros.Size = new System.Drawing.Size(454, 295);
            this.dgvNumeros.TabIndex = 15;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Iteración";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "- - - - -";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Xi+1";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Xi+1 / m";
            this.Column4.Name = "Column4";
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(582, 161);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAyudaXo
            // 
            this.btnAyudaXo.BackgroundImage = global::Simulacion.Properties.Resources.blue_exclamation_point_button_henrik_lehnerer;
            this.btnAyudaXo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaXo.Location = new System.Drawing.Point(380, 83);
            this.btnAyudaXo.Name = "btnAyudaXo";
            this.btnAyudaXo.Size = new System.Drawing.Size(30, 30);
            this.btnAyudaXo.TabIndex = 17;
            this.btnAyudaXo.UseVisualStyleBackColor = true;
            this.btnAyudaXo.MouseHover += new System.EventHandler(this.btnAyudaXo_MouseHover);
            // 
            // btnAyudaK
            // 
            this.btnAyudaK.BackgroundImage = global::Simulacion.Properties.Resources.blue_exclamation_point_button_henrik_lehnerer;
            this.btnAyudaK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaK.Location = new System.Drawing.Point(380, 116);
            this.btnAyudaK.Name = "btnAyudaK";
            this.btnAyudaK.Size = new System.Drawing.Size(30, 30);
            this.btnAyudaK.TabIndex = 18;
            this.btnAyudaK.UseVisualStyleBackColor = true;
            this.btnAyudaK.MouseHover += new System.EventHandler(this.btnAyudaK_MouseHover);
            // 
            // btnAyudaG
            // 
            this.btnAyudaG.BackgroundImage = global::Simulacion.Properties.Resources.blue_exclamation_point_button_henrik_lehnerer;
            this.btnAyudaG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaG.Location = new System.Drawing.Point(380, 149);
            this.btnAyudaG.Name = "btnAyudaG";
            this.btnAyudaG.Size = new System.Drawing.Size(30, 30);
            this.btnAyudaG.TabIndex = 19;
            this.btnAyudaG.UseVisualStyleBackColor = true;
            this.btnAyudaG.MouseHover += new System.EventHandler(this.btnAyudaG_MouseHover);
            // 
            // btnAyudaC
            // 
            this.btnAyudaC.BackgroundImage = global::Simulacion.Properties.Resources.blue_exclamation_point_button_henrik_lehnerer;
            this.btnAyudaC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaC.Location = new System.Drawing.Point(380, 182);
            this.btnAyudaC.Name = "btnAyudaC";
            this.btnAyudaC.Size = new System.Drawing.Size(30, 30);
            this.btnAyudaC.TabIndex = 20;
            this.btnAyudaC.UseVisualStyleBackColor = true;
            this.btnAyudaC.MouseHover += new System.EventHandler(this.btnAyudaC_MouseHover);
            // 
            // frm_generador_numeros
            // 
            this.AcceptButton = this.btnGenerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 561);
            this.Controls.Add(this.btnAyudaC);
            this.Controls.Add(this.btnAyudaG);
            this.Controls.Add(this.btnAyudaK);
            this.Controls.Add(this.btnAyudaXo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvNumeros);
            this.Controls.Add(this.btnGenerar1Mas);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbtMultiplicativo);
            this.Controls.Add(this.rbtMixto);
            this.Controls.Add(this.txtNumerosAGenerar);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtK);
            this.Controls.Add(this.txtXo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_generador_numeros";
            this.Text = "Generador de números aleatorios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumeros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtXo;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtNumerosAGenerar;
        private System.Windows.Forms.RadioButton rbtMixto;
        private System.Windows.Forms.RadioButton rbtMultiplicativo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnGenerar1Mas;
        private System.Windows.Forms.DataGridView dgvNumeros;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnAyudaXo;
        private System.Windows.Forms.ToolTip tltAyuda;
        private System.Windows.Forms.Button btnAyudaK;
        private System.Windows.Forms.Button btnAyudaG;
        private System.Windows.Forms.Button btnAyudaC;
    }
}

