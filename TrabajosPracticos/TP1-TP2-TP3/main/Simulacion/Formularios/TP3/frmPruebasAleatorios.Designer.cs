namespace Simulacion.Formularios
{
    partial class frmPruebasAleatorios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpbox_Distribución = new System.Windows.Forms.GroupBox();
            this.lblDistribución = new System.Windows.Forms.Label();
            this.rdbNormalConvolucion = new System.Windows.Forms.RadioButton();
            this.rdbNormalBoxMuller = new System.Windows.Forms.RadioButton();
            this.rdbPoisson = new System.Windows.Forms.RadioButton();
            this.rdbExponencial = new System.Windows.Forms.RadioButton();
            this.rdbUniforme = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxLambda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxDesviacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxMedia = new System.Windows.Forms.TextBox();
            this.txtBoxB = new System.Windows.Forms.TextBox();
            this.txtBoxA = new System.Windows.Forms.TextBox();
            this.txtBox_NrosGenerar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtn5 = new System.Windows.Forms.RadioButton();
            this.rbtn10 = new System.Windows.Forms.RadioButton();
            this.rbtn15 = new System.Windows.Forms.RadioButton();
            this.txtBox_Otro = new System.Windows.Forms.TextBox();
            this.rbtnOtro = new System.Windows.Forms.RadioButton();
            this.btnRealizarPrueba = new System.Windows.Forms.Button();
            this.dgvValoresGenerados = new System.Windows.Forms.DataGridView();
            this.columnIntervalo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMarcaClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnfo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnfe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPruebaChiCuadrado = new System.Windows.Forms.DataGridView();
            this.columnIntervalo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerarHistograma = new System.Windows.Forms.Button();
            this.dgvValor = new System.Windows.Forms.DataGridView();
            this.lblCantNros = new System.Windows.Forms.Label();
            this.grpbox_Distribución.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoresGenerados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPruebaChiCuadrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValor)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbox_Distribución
            // 
            this.grpbox_Distribución.Controls.Add(this.lblDistribución);
            this.grpbox_Distribución.Controls.Add(this.rdbNormalConvolucion);
            this.grpbox_Distribución.Controls.Add(this.rdbNormalBoxMuller);
            this.grpbox_Distribución.Controls.Add(this.rdbPoisson);
            this.grpbox_Distribución.Controls.Add(this.rdbExponencial);
            this.grpbox_Distribución.Controls.Add(this.rdbUniforme);
            this.grpbox_Distribución.Location = new System.Drawing.Point(12, 43);
            this.grpbox_Distribución.Margin = new System.Windows.Forms.Padding(2);
            this.grpbox_Distribución.Name = "grpbox_Distribución";
            this.grpbox_Distribución.Padding = new System.Windows.Forms.Padding(2);
            this.grpbox_Distribución.Size = new System.Drawing.Size(343, 136);
            this.grpbox_Distribución.TabIndex = 2;
            this.grpbox_Distribución.TabStop = false;
            // 
            // lblDistribución
            // 
            this.lblDistribución.AutoSize = true;
            this.lblDistribución.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistribución.Location = new System.Drawing.Point(8, 15);
            this.lblDistribución.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistribución.Name = "lblDistribución";
            this.lblDistribución.Size = new System.Drawing.Size(283, 21);
            this.lblDistribución.TabIndex = 7;
            this.lblDistribución.Text = "Seleccione la distribución deseada:";
            // 
            // rdbNormalConvolucion
            // 
            this.rdbNormalConvolucion.AutoSize = true;
            this.rdbNormalConvolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNormalConvolucion.Location = new System.Drawing.Point(166, 103);
            this.rdbNormalConvolucion.Margin = new System.Windows.Forms.Padding(2);
            this.rdbNormalConvolucion.Name = "rdbNormalConvolucion";
            this.rdbNormalConvolucion.Size = new System.Drawing.Size(171, 24);
            this.rdbNormalConvolucion.TabIndex = 6;
            this.rdbNormalConvolucion.TabStop = true;
            this.rdbNormalConvolucion.Text = "Normal: Convolucion";
            this.rdbNormalConvolucion.UseVisualStyleBackColor = true;
            this.rdbNormalConvolucion.CheckedChanged += new System.EventHandler(this.rdbNormalConvolucion_CheckedChanged);
            // 
            // rdbNormalBoxMuller
            // 
            this.rdbNormalBoxMuller.AutoSize = true;
            this.rdbNormalBoxMuller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNormalBoxMuller.Location = new System.Drawing.Point(166, 75);
            this.rdbNormalBoxMuller.Margin = new System.Windows.Forms.Padding(2);
            this.rdbNormalBoxMuller.Name = "rdbNormalBoxMuller";
            this.rdbNormalBoxMuller.Size = new System.Drawing.Size(154, 24);
            this.rdbNormalBoxMuller.TabIndex = 5;
            this.rdbNormalBoxMuller.TabStop = true;
            this.rdbNormalBoxMuller.Text = "Normal: BoxMuller";
            this.rdbNormalBoxMuller.UseVisualStyleBackColor = true;
            this.rdbNormalBoxMuller.CheckedChanged += new System.EventHandler(this.rdbNormalBoxMuller_CheckedChanged);
            // 
            // rdbPoisson
            // 
            this.rdbPoisson.AutoSize = true;
            this.rdbPoisson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPoisson.Location = new System.Drawing.Point(8, 94);
            this.rdbPoisson.Margin = new System.Windows.Forms.Padding(2);
            this.rdbPoisson.Name = "rdbPoisson";
            this.rdbPoisson.Size = new System.Drawing.Size(83, 24);
            this.rdbPoisson.TabIndex = 4;
            this.rdbPoisson.TabStop = true;
            this.rdbPoisson.Text = "Poisson";
            this.rdbPoisson.UseVisualStyleBackColor = true;
            this.rdbPoisson.CheckedChanged += new System.EventHandler(this.rdbPoisson_CheckedChanged);
            // 
            // rdbExponencial
            // 
            this.rdbExponencial.AutoSize = true;
            this.rdbExponencial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbExponencial.Location = new System.Drawing.Point(166, 47);
            this.rdbExponencial.Margin = new System.Windows.Forms.Padding(2);
            this.rdbExponencial.Name = "rdbExponencial";
            this.rdbExponencial.Size = new System.Drawing.Size(113, 24);
            this.rdbExponencial.TabIndex = 3;
            this.rdbExponencial.TabStop = true;
            this.rdbExponencial.Text = "Exponencial";
            this.rdbExponencial.UseVisualStyleBackColor = true;
            this.rdbExponencial.CheckedChanged += new System.EventHandler(this.rdbExponencial_CheckedChanged);
            // 
            // rdbUniforme
            // 
            this.rdbUniforme.AutoSize = true;
            this.rdbUniforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbUniforme.Location = new System.Drawing.Point(8, 67);
            this.rdbUniforme.Margin = new System.Windows.Forms.Padding(2);
            this.rdbUniforme.Name = "rdbUniforme";
            this.rdbUniforme.Size = new System.Drawing.Size(92, 24);
            this.rdbUniforme.TabIndex = 2;
            this.rdbUniforme.TabStop = true;
            this.rdbUniforme.Text = "Uniforme";
            this.rdbUniforme.UseVisualStyleBackColor = true;
            this.rdbUniforme.CheckedChanged += new System.EventHandler(this.rdbUniforme_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBoxLambda);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBoxDesviacion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBoxMedia);
            this.groupBox1.Controls.Add(this.txtBoxB);
            this.groupBox1.Controls.Add(this.txtBoxA);
            this.groupBox1.Location = new System.Drawing.Point(12, 183);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(343, 138);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "B:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "Intervalo [A;B]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 21);
            this.label8.TabIndex = 22;
            this.label8.Text = "A:";
            // 
            // txtBoxLambda
            // 
            this.txtBoxLambda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxLambda.Location = new System.Drawing.Point(251, 101);
            this.txtBoxLambda.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxLambda.Name = "txtBoxLambda";
            this.txtBoxLambda.Size = new System.Drawing.Size(76, 26);
            this.txtBoxLambda.TabIndex = 9;
            this.txtBoxLambda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(152, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 21);
            this.label4.TabIndex = 26;
            this.label4.Text = "Lambda:";
            // 
            // txtBoxDesviacion
            // 
            this.txtBoxDesviacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDesviacion.Location = new System.Drawing.Point(251, 61);
            this.txtBoxDesviacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxDesviacion.Name = "txtBoxDesviacion";
            this.txtBoxDesviacion.Size = new System.Drawing.Size(76, 26);
            this.txtBoxDesviacion.TabIndex = 8;
            this.txtBoxDesviacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(167, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Media: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(148, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 42);
            this.label5.TabIndex = 25;
            this.label5.Text = "Desviación \r\nEstándar:\r\n";
            // 
            // txtBoxMedia
            // 
            this.txtBoxMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMedia.Location = new System.Drawing.Point(251, 22);
            this.txtBoxMedia.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxMedia.Name = "txtBoxMedia";
            this.txtBoxMedia.Size = new System.Drawing.Size(76, 26);
            this.txtBoxMedia.TabIndex = 7;
            this.txtBoxMedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxB
            // 
            this.txtBoxB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxB.Location = new System.Drawing.Point(63, 82);
            this.txtBoxB.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxB.Name = "txtBoxB";
            this.txtBoxB.Size = new System.Drawing.Size(66, 26);
            this.txtBoxB.TabIndex = 3;
            this.txtBoxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxA
            // 
            this.txtBoxA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxA.Location = new System.Drawing.Point(63, 44);
            this.txtBoxA.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxA.Name = "txtBoxA";
            this.txtBoxA.Size = new System.Drawing.Size(66, 26);
            this.txtBoxA.TabIndex = 2;
            this.txtBoxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBox_NrosGenerar
            // 
            this.txtBox_NrosGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_NrosGenerar.Location = new System.Drawing.Point(294, 9);
            this.txtBox_NrosGenerar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBox_NrosGenerar.Name = "txtBox_NrosGenerar";
            this.txtBox_NrosGenerar.Size = new System.Drawing.Size(76, 26);
            this.txtBox_NrosGenerar.TabIndex = 4;
            this.txtBox_NrosGenerar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBox_NrosGenerar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_NrosGenerar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 334);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cantidad de intervalos:";
            // 
            // rbtn5
            // 
            this.rbtn5.AutoSize = true;
            this.rbtn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn5.Location = new System.Drawing.Point(211, 335);
            this.rbtn5.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn5.Name = "rbtn5";
            this.rbtn5.Size = new System.Drawing.Size(36, 24);
            this.rbtn5.TabIndex = 6;
            this.rbtn5.TabStop = true;
            this.rbtn5.Text = "5";
            this.rbtn5.UseVisualStyleBackColor = true;
            // 
            // rbtn10
            // 
            this.rbtn10.AutoSize = true;
            this.rbtn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn10.Location = new System.Drawing.Point(247, 335);
            this.rbtn10.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn10.Name = "rbtn10";
            this.rbtn10.Size = new System.Drawing.Size(45, 24);
            this.rbtn10.TabIndex = 7;
            this.rbtn10.TabStop = true;
            this.rbtn10.Text = "10";
            this.rbtn10.UseVisualStyleBackColor = true;
            // 
            // rbtn15
            // 
            this.rbtn15.AutoSize = true;
            this.rbtn15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn15.Location = new System.Drawing.Point(296, 335);
            this.rbtn15.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn15.Name = "rbtn15";
            this.rbtn15.Size = new System.Drawing.Size(45, 24);
            this.rbtn15.TabIndex = 8;
            this.rbtn15.TabStop = true;
            this.rbtn15.Text = "15";
            this.rbtn15.UseVisualStyleBackColor = true;
            // 
            // txtBox_Otro
            // 
            this.txtBox_Otro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Otro.Location = new System.Drawing.Point(358, 335);
            this.txtBox_Otro.Margin = new System.Windows.Forms.Padding(2);
            this.txtBox_Otro.Name = "txtBox_Otro";
            this.txtBox_Otro.Size = new System.Drawing.Size(50, 26);
            this.txtBox_Otro.TabIndex = 10;
            this.txtBox_Otro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnOtro
            // 
            this.rbtnOtro.AutoSize = true;
            this.rbtnOtro.Location = new System.Drawing.Point(340, 340);
            this.rbtnOtro.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnOtro.Name = "rbtnOtro";
            this.rbtnOtro.Size = new System.Drawing.Size(14, 13);
            this.rbtnOtro.TabIndex = 11;
            this.rbtnOtro.TabStop = true;
            this.rbtnOtro.UseVisualStyleBackColor = true;
            // 
            // btnRealizarPrueba
            // 
            this.btnRealizarPrueba.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRealizarPrueba.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRealizarPrueba.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRealizarPrueba.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizarPrueba.ForeColor = System.Drawing.Color.White;
            this.btnRealizarPrueba.Location = new System.Drawing.Point(424, 318);
            this.btnRealizarPrueba.Margin = new System.Windows.Forms.Padding(2);
            this.btnRealizarPrueba.Name = "btnRealizarPrueba";
            this.btnRealizarPrueba.Size = new System.Drawing.Size(123, 58);
            this.btnRealizarPrueba.TabIndex = 12;
            this.btnRealizarPrueba.Text = "Realizar Prueba";
            this.btnRealizarPrueba.UseVisualStyleBackColor = false;
            this.btnRealizarPrueba.Click += new System.EventHandler(this.btnRealizarPrueba_Click);
            // 
            // dgvValoresGenerados
            // 
            this.dgvValoresGenerados.AllowUserToAddRows = false;
            this.dgvValoresGenerados.AllowUserToDeleteRows = false;
            this.dgvValoresGenerados.AllowUserToResizeColumns = false;
            this.dgvValoresGenerados.AllowUserToResizeRows = false;
            this.dgvValoresGenerados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvValoresGenerados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvValoresGenerados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValoresGenerados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvValoresGenerados.ColumnHeadersHeight = 29;
            this.dgvValoresGenerados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvValoresGenerados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnIntervalo1,
            this.columnMarcaClase,
            this.columnfo1,
            this.columnP,
            this.columnfe1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvValoresGenerados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvValoresGenerados.EnableHeadersVisualStyles = false;
            this.dgvValoresGenerados.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvValoresGenerados.Location = new System.Drawing.Point(374, 9);
            this.dgvValoresGenerados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvValoresGenerados.Name = "dgvValoresGenerados";
            this.dgvValoresGenerados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValoresGenerados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvValoresGenerados.RowHeadersWidth = 25;
            this.dgvValoresGenerados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvValoresGenerados.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvValoresGenerados.RowTemplate.Height = 24;
            this.dgvValoresGenerados.Size = new System.Drawing.Size(356, 294);
            this.dgvValoresGenerados.TabIndex = 14;
            // 
            // columnIntervalo1
            // 
            this.columnIntervalo1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnIntervalo1.HeaderText = "Intervalo";
            this.columnIntervalo1.MinimumWidth = 6;
            this.columnIntervalo1.Name = "columnIntervalo1";
            this.columnIntervalo1.ReadOnly = true;
            // 
            // columnMarcaClase
            // 
            this.columnMarcaClase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnMarcaClase.HeaderText = "MC";
            this.columnMarcaClase.MinimumWidth = 6;
            this.columnMarcaClase.Name = "columnMarcaClase";
            this.columnMarcaClase.ReadOnly = true;
            // 
            // columnfo1
            // 
            this.columnfo1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnfo1.HeaderText = "fo";
            this.columnfo1.MinimumWidth = 6;
            this.columnfo1.Name = "columnfo1";
            this.columnfo1.ReadOnly = true;
            // 
            // columnP
            // 
            this.columnP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnP.HeaderText = "P()";
            this.columnP.MinimumWidth = 6;
            this.columnP.Name = "columnP";
            this.columnP.ReadOnly = true;
            // 
            // columnfe1
            // 
            this.columnfe1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnfe1.HeaderText = "fe";
            this.columnfe1.MinimumWidth = 6;
            this.columnfe1.Name = "columnfe1";
            this.columnfe1.ReadOnly = true;
            // 
            // dgvPruebaChiCuadrado
            // 
            this.dgvPruebaChiCuadrado.AllowUserToAddRows = false;
            this.dgvPruebaChiCuadrado.AllowUserToDeleteRows = false;
            this.dgvPruebaChiCuadrado.AllowUserToResizeColumns = false;
            this.dgvPruebaChiCuadrado.AllowUserToResizeRows = false;
            this.dgvPruebaChiCuadrado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPruebaChiCuadrado.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvPruebaChiCuadrado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPruebaChiCuadrado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPruebaChiCuadrado.ColumnHeadersHeight = 29;
            this.dgvPruebaChiCuadrado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPruebaChiCuadrado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnIntervalo,
            this.columnFo,
            this.columnFe,
            this.columnC,
            this.columnCac});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPruebaChiCuadrado.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPruebaChiCuadrado.EnableHeadersVisualStyles = false;
            this.dgvPruebaChiCuadrado.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvPruebaChiCuadrado.Location = new System.Drawing.Point(11, 385);
            this.dgvPruebaChiCuadrado.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPruebaChiCuadrado.Name = "dgvPruebaChiCuadrado";
            this.dgvPruebaChiCuadrado.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPruebaChiCuadrado.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPruebaChiCuadrado.RowHeadersWidth = 25;
            this.dgvPruebaChiCuadrado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPruebaChiCuadrado.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPruebaChiCuadrado.RowTemplate.Height = 24;
            this.dgvPruebaChiCuadrado.Size = new System.Drawing.Size(536, 129);
            this.dgvPruebaChiCuadrado.TabIndex = 13;
            // 
            // columnIntervalo
            // 
            this.columnIntervalo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnIntervalo.HeaderText = "Intervalo";
            this.columnIntervalo.MinimumWidth = 6;
            this.columnIntervalo.Name = "columnIntervalo";
            this.columnIntervalo.ReadOnly = true;
            // 
            // columnFo
            // 
            this.columnFo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnFo.HeaderText = "fo";
            this.columnFo.MinimumWidth = 6;
            this.columnFo.Name = "columnFo";
            this.columnFo.ReadOnly = true;
            // 
            // columnFe
            // 
            this.columnFe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnFe.HeaderText = "fe";
            this.columnFe.MinimumWidth = 6;
            this.columnFe.Name = "columnFe";
            this.columnFe.ReadOnly = true;
            // 
            // columnC
            // 
            this.columnC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnC.HeaderText = "C";
            this.columnC.MinimumWidth = 6;
            this.columnC.Name = "columnC";
            this.columnC.ReadOnly = true;
            // 
            // columnCac
            // 
            this.columnCac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnCac.HeaderText = "C(AC)";
            this.columnCac.MinimumWidth = 6;
            this.columnCac.Name = "columnCac";
            this.columnCac.ReadOnly = true;
            // 
            // btnGenerarHistograma
            // 
            this.btnGenerarHistograma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarHistograma.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGenerarHistograma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarHistograma.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerarHistograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarHistograma.ForeColor = System.Drawing.Color.White;
            this.btnGenerarHistograma.Location = new System.Drawing.Point(562, 481);
            this.btnGenerarHistograma.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerarHistograma.Name = "btnGenerarHistograma";
            this.btnGenerarHistograma.Size = new System.Drawing.Size(125, 69);
            this.btnGenerarHistograma.TabIndex = 15;
            this.btnGenerarHistograma.Text = "Generar Histograma";
            this.btnGenerarHistograma.UseVisualStyleBackColor = false;
            this.btnGenerarHistograma.Click += new System.EventHandler(this.btnGenerarHistograma_Click);
            // 
            // dgvValor
            // 
            this.dgvValor.AllowUserToAddRows = false;
            this.dgvValor.AllowUserToDeleteRows = false;
            this.dgvValor.AllowUserToResizeColumns = false;
            this.dgvValor.AllowUserToResizeRows = false;
            this.dgvValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvValor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvValor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvValor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvValor.ColumnHeadersHeight = 29;
            this.dgvValor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvValor.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvValor.EnableHeadersVisualStyles = false;
            this.dgvValor.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvValor.Location = new System.Drawing.Point(562, 317);
            this.dgvValor.Margin = new System.Windows.Forms.Padding(2);
            this.dgvValor.Name = "dgvValor";
            this.dgvValor.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValor.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvValor.RowHeadersVisible = false;
            this.dgvValor.RowHeadersWidth = 51;
            this.dgvValor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgvValor.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvValor.RowTemplate.Height = 24;
            this.dgvValor.Size = new System.Drawing.Size(168, 150);
            this.dgvValor.TabIndex = 16;
            // 
            // lblCantNros
            // 
            this.lblCantNros.AutoSize = true;
            this.lblCantNros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantNros.Location = new System.Drawing.Point(7, 11);
            this.lblCantNros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantNros.Name = "lblCantNros";
            this.lblCantNros.Size = new System.Drawing.Size(283, 21);
            this.lblCantNros.TabIndex = 17;
            this.lblCantNros.Text = "¿Cuántos números desea generar?";
            // 
            // frmPruebasNumerosAleatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 561);
            this.Controls.Add(this.lblCantNros);
            this.Controls.Add(this.dgvValor);
            this.Controls.Add(this.btnGenerarHistograma);
            this.Controls.Add(this.dgvValoresGenerados);
            this.Controls.Add(this.dgvPruebaChiCuadrado);
            this.Controls.Add(this.btnRealizarPrueba);
            this.Controls.Add(this.rbtnOtro);
            this.Controls.Add(this.txtBox_Otro);
            this.Controls.Add(this.rbtn15);
            this.Controls.Add(this.rbtn10);
            this.Controls.Add(this.rbtn5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_NrosGenerar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbox_Distribución);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmPruebasNumerosAleatorios";
            this.Text = "Generador Uniforme";
            this.Load += new System.EventHandler(this.frmGeneradorDistribucion_Load);
            this.grpbox_Distribución.ResumeLayout(false);
            this.grpbox_Distribución.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoresGenerados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPruebaChiCuadrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpbox_Distribución;
        private System.Windows.Forms.RadioButton rdbNormalBoxMuller;
        private System.Windows.Forms.RadioButton rdbPoisson;
        private System.Windows.Forms.RadioButton rdbExponencial;
        private System.Windows.Forms.RadioButton rdbUniforme;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBox_NrosGenerar;
        private System.Windows.Forms.TextBox txtBoxDesviacion;
        private System.Windows.Forms.TextBox txtBoxMedia;
        private System.Windows.Forms.TextBox txtBoxB;
        private System.Windows.Forms.TextBox txtBoxA;
        private System.Windows.Forms.TextBox txtBoxLambda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtn5;
        private System.Windows.Forms.RadioButton rbtn10;
        private System.Windows.Forms.RadioButton rbtn15;
        private System.Windows.Forms.TextBox txtBox_Otro;
        private System.Windows.Forms.RadioButton rbtnOtro;
        private System.Windows.Forms.Button btnRealizarPrueba;
        private System.Windows.Forms.DataGridView dgvValoresGenerados;
        private System.Windows.Forms.DataGridView dgvPruebaChiCuadrado;
        private System.Windows.Forms.Button btnGenerarHistograma;
        private System.Windows.Forms.RadioButton rdbNormalConvolucion;
        private System.Windows.Forms.DataGridView dgvValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIntervalo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnC;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCac;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIntervalo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMarcaClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnfo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnP;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnfe1;
        private System.Windows.Forms.Label lblCantNros;
        private System.Windows.Forms.Label lblDistribución;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}