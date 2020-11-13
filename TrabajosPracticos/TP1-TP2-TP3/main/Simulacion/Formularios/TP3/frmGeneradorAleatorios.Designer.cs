namespace Simulacion.Formularios
{
    partial class frmGeneradorAleatorios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneradorAleatorios));
            this.txtBox_NrosGenerar = new System.Windows.Forms.TextBox();
            this.lblCantNros = new System.Windows.Forms.Label();
            this.grpbox_Distribución = new System.Windows.Forms.GroupBox();
            this.rdbNormalConvolucion = new System.Windows.Forms.RadioButton();
            this.rdbNormalBoxMuller = new System.Windows.Forms.RadioButton();
            this.rdbPoisson = new System.Windows.Forms.RadioButton();
            this.rdbExponencial = new System.Windows.Forms.RadioButton();
            this.rdbUniforme = new System.Windows.Forms.RadioButton();
            this.lblDistribución = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLambda = new System.Windows.Forms.TextBox();
            this.txtDesviacion = new System.Windows.Forms.TextBox();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDesvEstandar = new System.Windows.Forms.Label();
            this.lblMedia = new System.Windows.Forms.Label();
            this.txtInterB = new System.Windows.Forms.TextBox();
            this.txtInterA = new System.Windows.Forms.TextBox();
            this.lblIntervaloB = new System.Windows.Forms.Label();
            this.lblIntervaloA = new System.Windows.Forms.Label();
            this.dgvNumeros = new System.Windows.Forms.DataGridView();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.grpbox_Distribución.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumeros)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox_NrosGenerar
            // 
            this.txtBox_NrosGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_NrosGenerar.Location = new System.Drawing.Point(324, 31);
            this.txtBox_NrosGenerar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBox_NrosGenerar.Name = "txtBox_NrosGenerar";
            this.txtBox_NrosGenerar.Size = new System.Drawing.Size(67, 26);
            this.txtBox_NrosGenerar.TabIndex = 6;
            this.txtBox_NrosGenerar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBox_NrosGenerar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_NrosGenerar_KeyPress);
            // 
            // lblCantNros
            // 
            this.lblCantNros.AutoSize = true;
            this.lblCantNros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantNros.Location = new System.Drawing.Point(26, 33);
            this.lblCantNros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantNros.Name = "lblCantNros";
            this.lblCantNros.Size = new System.Drawing.Size(283, 21);
            this.lblCantNros.TabIndex = 5;
            this.lblCantNros.Text = "¿Cuántos números desea generar?";
            // 
            // grpbox_Distribución
            // 
            this.grpbox_Distribución.Controls.Add(this.rdbNormalConvolucion);
            this.grpbox_Distribución.Controls.Add(this.rdbNormalBoxMuller);
            this.grpbox_Distribución.Controls.Add(this.rdbPoisson);
            this.grpbox_Distribución.Controls.Add(this.rdbExponencial);
            this.grpbox_Distribución.Controls.Add(this.rdbUniforme);
            this.grpbox_Distribución.Controls.Add(this.lblDistribución);
            this.grpbox_Distribución.Location = new System.Drawing.Point(22, 71);
            this.grpbox_Distribución.Margin = new System.Windows.Forms.Padding(2);
            this.grpbox_Distribución.Name = "grpbox_Distribución";
            this.grpbox_Distribución.Padding = new System.Windows.Forms.Padding(2);
            this.grpbox_Distribución.Size = new System.Drawing.Size(399, 136);
            this.grpbox_Distribución.TabIndex = 7;
            this.grpbox_Distribución.TabStop = false;
            // 
            // rdbNormalConvolucion
            // 
            this.rdbNormalConvolucion.AutoSize = true;
            this.rdbNormalConvolucion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNormalConvolucion.Location = new System.Drawing.Point(166, 103);
            this.rdbNormalConvolucion.Margin = new System.Windows.Forms.Padding(2);
            this.rdbNormalConvolucion.Name = "rdbNormalConvolucion";
            this.rdbNormalConvolucion.Size = new System.Drawing.Size(191, 25);
            this.rdbNormalConvolucion.TabIndex = 6;
            this.rdbNormalConvolucion.TabStop = true;
            this.rdbNormalConvolucion.Text = "Normal: Convolucion";
            this.rdbNormalConvolucion.UseVisualStyleBackColor = true;
            this.rdbNormalConvolucion.CheckedChanged += new System.EventHandler(this.rdbNormalConvolucion_CheckedChanged);
            // 
            // rdbNormalBoxMuller
            // 
            this.rdbNormalBoxMuller.AutoSize = true;
            this.rdbNormalBoxMuller.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNormalBoxMuller.Location = new System.Drawing.Point(166, 75);
            this.rdbNormalBoxMuller.Margin = new System.Windows.Forms.Padding(2);
            this.rdbNormalBoxMuller.Name = "rdbNormalBoxMuller";
            this.rdbNormalBoxMuller.Size = new System.Drawing.Size(165, 25);
            this.rdbNormalBoxMuller.TabIndex = 5;
            this.rdbNormalBoxMuller.TabStop = true;
            this.rdbNormalBoxMuller.Text = "Normal: BoxMuller";
            this.rdbNormalBoxMuller.UseVisualStyleBackColor = true;
            this.rdbNormalBoxMuller.CheckedChanged += new System.EventHandler(this.rdbNormalBoxMuller_CheckedChanged);
            // 
            // rdbPoisson
            // 
            this.rdbPoisson.AutoSize = true;
            this.rdbPoisson.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPoisson.Location = new System.Drawing.Point(18, 74);
            this.rdbPoisson.Margin = new System.Windows.Forms.Padding(2);
            this.rdbPoisson.Name = "rdbPoisson";
            this.rdbPoisson.Size = new System.Drawing.Size(82, 25);
            this.rdbPoisson.TabIndex = 4;
            this.rdbPoisson.TabStop = true;
            this.rdbPoisson.Text = "Poisson";
            this.rdbPoisson.UseVisualStyleBackColor = true;
            this.rdbPoisson.CheckedChanged += new System.EventHandler(this.rdbPoisson_CheckedChanged);
            // 
            // rdbExponencial
            // 
            this.rdbExponencial.AutoSize = true;
            this.rdbExponencial.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbExponencial.Location = new System.Drawing.Point(166, 47);
            this.rdbExponencial.Margin = new System.Windows.Forms.Padding(2);
            this.rdbExponencial.Name = "rdbExponencial";
            this.rdbExponencial.Size = new System.Drawing.Size(123, 25);
            this.rdbExponencial.TabIndex = 3;
            this.rdbExponencial.TabStop = true;
            this.rdbExponencial.Text = "Exponencial";
            this.rdbExponencial.UseVisualStyleBackColor = true;
            this.rdbExponencial.CheckedChanged += new System.EventHandler(this.rdbExponencial_CheckedChanged);
            // 
            // rdbUniforme
            // 
            this.rdbUniforme.AutoSize = true;
            this.rdbUniforme.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbUniforme.Location = new System.Drawing.Point(18, 47);
            this.rdbUniforme.Margin = new System.Windows.Forms.Padding(2);
            this.rdbUniforme.Name = "rdbUniforme";
            this.rdbUniforme.Size = new System.Drawing.Size(97, 25);
            this.rdbUniforme.TabIndex = 2;
            this.rdbUniforme.TabStop = true;
            this.rdbUniforme.Text = "Uniforme";
            this.rdbUniforme.UseVisualStyleBackColor = true;
            this.rdbUniforme.CheckedChanged += new System.EventHandler(this.rdbUniforme_CheckedChanged);
            // 
            // lblDistribución
            // 
            this.lblDistribución.AutoSize = true;
            this.lblDistribución.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistribución.Location = new System.Drawing.Point(4, 15);
            this.lblDistribución.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistribución.Name = "lblDistribución";
            this.lblDistribución.Size = new System.Drawing.Size(283, 21);
            this.lblDistribución.TabIndex = 1;
            this.lblDistribución.Text = "Seleccione la distribución deseada:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLambda);
            this.groupBox1.Controls.Add(this.txtDesviacion);
            this.groupBox1.Controls.Add(this.txtMedia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblDesvEstandar);
            this.groupBox1.Controls.Add(this.lblMedia);
            this.groupBox1.Controls.Add(this.txtInterB);
            this.groupBox1.Controls.Add(this.txtInterA);
            this.groupBox1.Controls.Add(this.lblIntervaloB);
            this.groupBox1.Controls.Add(this.lblIntervaloA);
            this.groupBox1.Location = new System.Drawing.Point(22, 236);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(399, 176);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // txtLambda
            // 
            this.txtLambda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLambda.Location = new System.Drawing.Point(293, 129);
            this.txtLambda.Margin = new System.Windows.Forms.Padding(2);
            this.txtLambda.Name = "txtLambda";
            this.txtLambda.Size = new System.Drawing.Size(76, 26);
            this.txtLambda.TabIndex = 9;
            this.txtLambda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLambda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLambda_KeyPress);
            // 
            // txtDesviacion
            // 
            this.txtDesviacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesviacion.Location = new System.Drawing.Point(293, 81);
            this.txtDesviacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesviacion.Name = "txtDesviacion";
            this.txtDesviacion.Size = new System.Drawing.Size(76, 26);
            this.txtDesviacion.TabIndex = 8;
            this.txtDesviacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesviacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesviacion_KeyPress);
            // 
            // txtMedia
            // 
            this.txtMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedia.Location = new System.Drawing.Point(293, 33);
            this.txtMedia.Margin = new System.Windows.Forms.Padding(2);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(76, 26);
            this.txtMedia.TabIndex = 7;
            this.txtMedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMedia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMedia_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lambda:";
            // 
            // lblDesvEstandar
            // 
            this.lblDesvEstandar.AutoSize = true;
            this.lblDesvEstandar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesvEstandar.Location = new System.Drawing.Point(199, 73);
            this.lblDesvEstandar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesvEstandar.Name = "lblDesvEstandar";
            this.lblDesvEstandar.Size = new System.Drawing.Size(99, 42);
            this.lblDesvEstandar.TabIndex = 5;
            this.lblDesvEstandar.Text = "Desviación \r\nEstándar:\r\n";
            // 
            // lblMedia
            // 
            this.lblMedia.AutoSize = true;
            this.lblMedia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedia.Location = new System.Drawing.Point(218, 36);
            this.lblMedia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(68, 21);
            this.lblMedia.TabIndex = 4;
            this.lblMedia.Text = "Media: ";
            // 
            // txtInterB
            // 
            this.txtInterB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterB.Location = new System.Drawing.Point(78, 99);
            this.txtInterB.Margin = new System.Windows.Forms.Padding(2);
            this.txtInterB.Name = "txtInterB";
            this.txtInterB.Size = new System.Drawing.Size(66, 26);
            this.txtInterB.TabIndex = 3;
            this.txtInterB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInterB_KeyPress);
            // 
            // txtInterA
            // 
            this.txtInterA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterA.Location = new System.Drawing.Point(78, 61);
            this.txtInterA.Margin = new System.Windows.Forms.Padding(2);
            this.txtInterA.Name = "txtInterA";
            this.txtInterA.Size = new System.Drawing.Size(66, 26);
            this.txtInterA.TabIndex = 2;
            this.txtInterA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInterA_KeyPress);
            // 
            // lblIntervaloB
            // 
            this.lblIntervaloB.AutoSize = true;
            this.lblIntervaloB.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntervaloB.Location = new System.Drawing.Point(50, 102);
            this.lblIntervaloB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIntervaloB.Name = "lblIntervaloB";
            this.lblIntervaloB.Size = new System.Drawing.Size(23, 21);
            this.lblIntervaloB.TabIndex = 1;
            this.lblIntervaloB.Text = "B:";
            // 
            // lblIntervaloA
            // 
            this.lblIntervaloA.AutoSize = true;
            this.lblIntervaloA.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntervaloA.Location = new System.Drawing.Point(45, 64);
            this.lblIntervaloA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIntervaloA.Name = "lblIntervaloA";
            this.lblIntervaloA.Size = new System.Drawing.Size(27, 21);
            this.lblIntervaloA.TabIndex = 0;
            this.lblIntervaloA.Text = "A:";
            // 
            // dgvNumeros
            // 
            this.dgvNumeros.AllowUserToAddRows = false;
            this.dgvNumeros.AllowUserToDeleteRows = false;
            this.dgvNumeros.AllowUserToResizeColumns = false;
            this.dgvNumeros.AllowUserToResizeRows = false;
            this.dgvNumeros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNumeros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNumeros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvNumeros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNumeros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNumeros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNumeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNumeros.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNumeros.EnableHeadersVisualStyles = false;
            this.dgvNumeros.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvNumeros.Location = new System.Drawing.Point(451, 31);
            this.dgvNumeros.MaximumSize = new System.Drawing.Size(360, 470);
            this.dgvNumeros.Name = "dgvNumeros";
            this.dgvNumeros.ReadOnly = true;
            this.dgvNumeros.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNumeros.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvNumeros.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNumeros.Size = new System.Drawing.Size(240, 470);
            this.dgvNumeros.TabIndex = 18;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(330, 433);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(90, 36);
            this.btnGenerar.TabIndex = 20;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 21);
            this.label3.TabIndex = 21;
            this.label3.Text = "Intervalo [A;B]";
            // 
            // frmGeneradorAleatorios
            // 
            this.AcceptButton = this.btnGenerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 522);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgvNumeros);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbox_Distribución);
            this.Controls.Add(this.txtBox_NrosGenerar);
            this.Controls.Add(this.lblCantNros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGeneradorAleatorios";
            this.Text = "Generación de Números Aleatorios";
            this.Load += new System.EventHandler(this.frmGeneradorAleatorios_Load);
            this.grpbox_Distribución.ResumeLayout(false);
            this.grpbox_Distribución.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumeros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_NrosGenerar;
        private System.Windows.Forms.Label lblCantNros;
        private System.Windows.Forms.GroupBox grpbox_Distribución;
        private System.Windows.Forms.RadioButton rdbNormalConvolucion;
        private System.Windows.Forms.RadioButton rdbNormalBoxMuller;
        private System.Windows.Forms.RadioButton rdbPoisson;
        private System.Windows.Forms.RadioButton rdbExponencial;
        private System.Windows.Forms.RadioButton rdbUniforme;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLambda;
        private System.Windows.Forms.TextBox txtDesviacion;
        private System.Windows.Forms.TextBox txtMedia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDesvEstandar;
        private System.Windows.Forms.Label lblMedia;
        private System.Windows.Forms.TextBox txtInterB;
        private System.Windows.Forms.TextBox txtInterA;
        private System.Windows.Forms.Label lblIntervaloB;
        private System.Windows.Forms.Label lblIntervaloA;
        private System.Windows.Forms.DataGridView dgvNumeros;
        private System.Windows.Forms.Label lblDistribución;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label3;
    }
}