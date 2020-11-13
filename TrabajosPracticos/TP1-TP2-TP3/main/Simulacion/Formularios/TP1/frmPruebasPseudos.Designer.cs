namespace Simulacion.Formularios
{
    partial class frmPruebasPseudos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPruebasPseudos));
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtMetMixto = new System.Windows.Forms.RadioButton();
            this.rbtMetLeng = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOtro = new System.Windows.Forms.TextBox();
            this.rbtOtro = new System.Windows.Forms.RadioButton();
            this.rdb_Intervalo15 = new System.Windows.Forms.RadioButton();
            this.rdb_Intervalo10 = new System.Windows.Forms.RadioButton();
            this.rdb_Intervalo5 = new System.Windows.Forms.RadioButton();
            this.lbl_Intervalos = new System.Windows.Forms.Label();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtK = new System.Windows.Forms.TextBox();
            this.txtXo = new System.Windows.Forms.TextBox();
            this.txtNumerosAGenerar = new System.Windows.Forms.TextBox();
            this.btnRealizarPrueba = new System.Windows.Forms.Button();
            this.dgvTablaChi = new System.Windows.Forms.DataGridView();
            this.intervalo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frecuenciaObservada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frecuenciaEsperada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadPrueba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadPruebaAcum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generar_Histograma = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaChi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTabla
            // 
            this.dgvTabla.AllowUserToAddRows = false;
            this.dgvTabla.AllowUserToDeleteRows = false;
            this.dgvTabla.AllowUserToResizeColumns = false;
            this.dgvTabla.AllowUserToResizeRows = false;
            this.dgvTabla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTabla.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvTabla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabla.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabla.EnableHeadersVisualStyles = false;
            this.dgvTabla.Location = new System.Drawing.Point(693, 15);
            this.dgvTabla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTabla.MaximumSize = new System.Drawing.Size(400, 351);
            this.dgvTabla.Name = "dgvTabla";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTabla.RowHeadersVisible = false;
            this.dgvTabla.RowHeadersWidth = 51;
            this.dgvTabla.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTabla.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTabla.Size = new System.Drawing.Size(279, 351);
            this.dgvTabla.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 78.17259F;
            this.Column1.HeaderText = "Iteración";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 121.8274F;
            this.Column2.HeaderText = "Valor pseudoaleatorio";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtMetMixto);
            this.groupBox1.Controls.Add(this.rbtMetLeng);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(16, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(596, 133);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // rbtMetMixto
            // 
            this.rbtMetMixto.AutoSize = true;
            this.rbtMetMixto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMetMixto.Location = new System.Drawing.Point(256, 95);
            this.rbtMetMixto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtMetMixto.Name = "rbtMetMixto";
            this.rbtMetMixto.Size = new System.Drawing.Size(302, 27);
            this.rbtMetMixto.TabIndex = 1;
            this.rbtMetMixto.Text = "Método Congruencial Mixto";
            this.rbtMetMixto.UseVisualStyleBackColor = true;
            this.rbtMetMixto.CheckedChanged += new System.EventHandler(this.rbtMetMixto_CheckedChanged);
            // 
            // rbtMetLeng
            // 
            this.rbtMetLeng.AutoSize = true;
            this.rbtMetLeng.Checked = true;
            this.rbtMetLeng.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMetLeng.Location = new System.Drawing.Point(256, 57);
            this.rbtMetLeng.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtMetLeng.Name = "rbtMetLeng";
            this.rbtMetLeng.Size = new System.Drawing.Size(237, 27);
            this.rbtMetLeng.TabIndex = 0;
            this.rbtMetLeng.TabStop = true;
            this.rbtMetLeng.Text = "Método del lenguaje";
            this.rbtMetLeng.UseVisualStyleBackColor = true;
            this.rbtMetLeng.CheckedChanged += new System.EventHandler(this.rbtMetLeng_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(580, 59);
            this.label3.TabIndex = 16;
            this.label3.Text = "Seleccione el método de generación de números pseudoaleatorios: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOtro);
            this.groupBox2.Controls.Add(this.rbtOtro);
            this.groupBox2.Controls.Add(this.rdb_Intervalo15);
            this.groupBox2.Controls.Add(this.rdb_Intervalo10);
            this.groupBox2.Controls.Add(this.rdb_Intervalo5);
            this.groupBox2.Controls.Add(this.lbl_Intervalos);
            this.groupBox2.Location = new System.Drawing.Point(16, 388);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(653, 54);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // txtOtro
            // 
            this.txtOtro.Enabled = false;
            this.txtOtro.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtro.Location = new System.Drawing.Point(519, 16);
            this.txtOtro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.Size = new System.Drawing.Size(76, 32);
            this.txtOtro.TabIndex = 4;
            this.txtOtro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOtro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOtro_KeyPress);
            // 
            // rbtOtro
            // 
            this.rbtOtro.AutoSize = true;
            this.rbtOtro.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtOtro.Location = new System.Drawing.Point(477, 22);
            this.rbtOtro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtOtro.Name = "rbtOtro";
            this.rbtOtro.Size = new System.Drawing.Size(17, 16);
            this.rbtOtro.TabIndex = 3;
            this.rbtOtro.TabStop = true;
            this.rbtOtro.UseVisualStyleBackColor = true;
            this.rbtOtro.CheckedChanged += new System.EventHandler(this.rbtOtro_CheckedChanged);
            // 
            // rdb_Intervalo15
            // 
            this.rdb_Intervalo15.AutoSize = true;
            this.rdb_Intervalo15.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_Intervalo15.Location = new System.Drawing.Point(408, 17);
            this.rdb_Intervalo15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdb_Intervalo15.Name = "rdb_Intervalo15";
            this.rdb_Intervalo15.Size = new System.Drawing.Size(53, 27);
            this.rdb_Intervalo15.TabIndex = 2;
            this.rdb_Intervalo15.Text = "15";
            this.rdb_Intervalo15.UseVisualStyleBackColor = true;
            this.rdb_Intervalo15.CheckedChanged += new System.EventHandler(this.rdb_Intervalo15_CheckedChanged);
            // 
            // rdb_Intervalo10
            // 
            this.rdb_Intervalo10.AutoSize = true;
            this.rdb_Intervalo10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_Intervalo10.Location = new System.Drawing.Point(328, 15);
            this.rdb_Intervalo10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdb_Intervalo10.Name = "rdb_Intervalo10";
            this.rdb_Intervalo10.Size = new System.Drawing.Size(53, 27);
            this.rdb_Intervalo10.TabIndex = 1;
            this.rdb_Intervalo10.Text = "10";
            this.rdb_Intervalo10.UseVisualStyleBackColor = true;
            this.rdb_Intervalo10.CheckedChanged += new System.EventHandler(this.rdb_Intervalo10_CheckedChanged);
            // 
            // rdb_Intervalo5
            // 
            this.rdb_Intervalo5.AutoSize = true;
            this.rdb_Intervalo5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_Intervalo5.Location = new System.Drawing.Point(267, 15);
            this.rdb_Intervalo5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdb_Intervalo5.Name = "rdb_Intervalo5";
            this.rdb_Intervalo5.Size = new System.Drawing.Size(42, 27);
            this.rdb_Intervalo5.TabIndex = 0;
            this.rdb_Intervalo5.Text = "5";
            this.rdb_Intervalo5.UseVisualStyleBackColor = true;
            this.rdb_Intervalo5.CheckedChanged += new System.EventHandler(this.rdb_Intervalo5_CheckedChanged);
            // 
            // lbl_Intervalos
            // 
            this.lbl_Intervalos.AutoSize = true;
            this.lbl_Intervalos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Intervalos.Location = new System.Drawing.Point(8, 17);
            this.lbl_Intervalos.Name = "lbl_Intervalos";
            this.lbl_Intervalos.Size = new System.Drawing.Size(242, 23);
            this.lbl_Intervalos.TabIndex = 23;
            this.lbl_Intervalos.Text = "Cantidad de intervalos:";
            // 
            // txtG
            // 
            this.txtG.Enabled = false;
            this.txtG.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtG.Location = new System.Drawing.Point(379, 294);
            this.txtG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(132, 32);
            this.txtG.TabIndex = 3;
            this.txtG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtG_KeyPress);
            // 
            // txtC
            // 
            this.txtC.Enabled = false;
            this.txtC.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.Location = new System.Drawing.Point(379, 335);
            this.txtC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(132, 32);
            this.txtC.TabIndex = 4;
            this.txtC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtC_KeyPress);
            // 
            // txtK
            // 
            this.txtK.Enabled = false;
            this.txtK.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtK.Location = new System.Drawing.Point(379, 254);
            this.txtK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(132, 32);
            this.txtK.TabIndex = 2;
            this.txtK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtK_KeyPress);
            // 
            // txtXo
            // 
            this.txtXo.Enabled = false;
            this.txtXo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXo.Location = new System.Drawing.Point(379, 213);
            this.txtXo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtXo.Name = "txtXo";
            this.txtXo.Size = new System.Drawing.Size(132, 32);
            this.txtXo.TabIndex = 1;
            this.txtXo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtXo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXo_KeyPress);
            // 
            // txtNumerosAGenerar
            // 
            this.txtNumerosAGenerar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumerosAGenerar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtNumerosAGenerar.Location = new System.Drawing.Point(393, 18);
            this.txtNumerosAGenerar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumerosAGenerar.Name = "txtNumerosAGenerar";
            this.txtNumerosAGenerar.Size = new System.Drawing.Size(132, 32);
            this.txtNumerosAGenerar.TabIndex = 0;
            this.txtNumerosAGenerar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumerosAGenerar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumerosAGenerar_KeyPress);
            // 
            // btnRealizarPrueba
            // 
            this.btnRealizarPrueba.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRealizarPrueba.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRealizarPrueba.Enabled = false;
            this.btnRealizarPrueba.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRealizarPrueba.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizarPrueba.ForeColor = System.Drawing.Color.White;
            this.btnRealizarPrueba.Location = new System.Drawing.Point(709, 398);
            this.btnRealizarPrueba.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRealizarPrueba.Name = "btnRealizarPrueba";
            this.btnRealizarPrueba.Size = new System.Drawing.Size(185, 43);
            this.btnRealizarPrueba.TabIndex = 5;
            this.btnRealizarPrueba.Text = "Realizar Prueba";
            this.btnRealizarPrueba.UseVisualStyleBackColor = false;
            this.btnRealizarPrueba.Click += new System.EventHandler(this.btnRealizarPrueba_Click);
            // 
            // dgvTablaChi
            // 
            this.dgvTablaChi.AllowUserToAddRows = false;
            this.dgvTablaChi.AllowUserToDeleteRows = false;
            this.dgvTablaChi.AllowUserToResizeColumns = false;
            this.dgvTablaChi.AllowUserToResizeRows = false;
            this.dgvTablaChi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTablaChi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvTablaChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaChi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTablaChi.ColumnHeadersHeight = 35;
            this.dgvTablaChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTablaChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.intervalo,
            this.frecuenciaObservada,
            this.frecuenciaEsperada,
            this.estadPrueba,
            this.estadPruebaAcum});
            this.dgvTablaChi.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTablaChi.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTablaChi.EnableHeadersVisualStyles = false;
            this.dgvTablaChi.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvTablaChi.Location = new System.Drawing.Point(29, 496);
            this.dgvTablaChi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTablaChi.Name = "dgvTablaChi";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaChi.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTablaChi.RowHeadersWidth = 30;
            this.dgvTablaChi.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTablaChi.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTablaChi.Size = new System.Drawing.Size(761, 210);
            this.dgvTablaChi.TabIndex = 38;
            // 
            // intervalo
            // 
            this.intervalo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.intervalo.HeaderText = "Intervalo";
            this.intervalo.MinimumWidth = 6;
            this.intervalo.Name = "intervalo";
            // 
            // frecuenciaObservada
            // 
            this.frecuenciaObservada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.frecuenciaObservada.HeaderText = "fo";
            this.frecuenciaObservada.MinimumWidth = 6;
            this.frecuenciaObservada.Name = "frecuenciaObservada";
            // 
            // frecuenciaEsperada
            // 
            this.frecuenciaEsperada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.frecuenciaEsperada.HeaderText = "fe";
            this.frecuenciaEsperada.MinimumWidth = 6;
            this.frecuenciaEsperada.Name = "frecuenciaEsperada";
            // 
            // estadPrueba
            // 
            this.estadPrueba.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estadPrueba.HeaderText = "C";
            this.estadPrueba.MinimumWidth = 6;
            this.estadPrueba.Name = "estadPrueba";
            // 
            // estadPruebaAcum
            // 
            this.estadPruebaAcum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estadPruebaAcum.HeaderText = "C(AC)";
            this.estadPruebaAcum.MinimumWidth = 6;
            this.estadPruebaAcum.Name = "estadPruebaAcum";
            // 
            // generar_Histograma
            // 
            this.generar_Histograma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generar_Histograma.BackColor = System.Drawing.SystemColors.Highlight;
            this.generar_Histograma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generar_Histograma.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generar_Histograma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generar_Histograma.ForeColor = System.Drawing.Color.White;
            this.generar_Histograma.Location = new System.Drawing.Point(817, 631);
            this.generar_Histograma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generar_Histograma.Name = "generar_Histograma";
            this.generar_Histograma.Size = new System.Drawing.Size(147, 75);
            this.generar_Histograma.TabIndex = 6;
            this.generar_Histograma.Text = "Generar histograma";
            this.generar_Histograma.UseVisualStyleBackColor = false;
            this.generar_Histograma.Click += new System.EventHandler(this.generar_Histograma_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(344, 23);
            this.label6.TabIndex = 40;
            this.label6.Text = "Cuántos números desea generar?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 342);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 23);
            this.label4.TabIndex = 44;
            this.label4.Text = "Constante aditiva c:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 302);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 43;
            this.label1.Text = "Entero g:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(121, 261);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 42;
            this.label2.Text = "Entero k:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(121, 220);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 23);
            this.label5.TabIndex = 41;
            this.label5.Text = "Semilla (Xo):";
            // 
            // frmJiCuadrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 764);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.generar_Histograma);
            this.Controls.Add(this.dgvTablaChi);
            this.Controls.Add(this.btnRealizarPrueba);
            this.Controls.Add(this.txtNumerosAGenerar);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtK);
            this.Controls.Add(this.txtXo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmJiCuadrado";
            this.Text = " Prueba de bondad de ajuste";
            this.Load += new System.EventHandler(this.frmJiCuadrado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaChi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTabla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtMetMixto;
        private System.Windows.Forms.RadioButton rbtMetLeng;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdb_Intervalo15;
        private System.Windows.Forms.RadioButton rdb_Intervalo10;
        private System.Windows.Forms.RadioButton rdb_Intervalo5;
        private System.Windows.Forms.Label lbl_Intervalos;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.TextBox txtXo;
        private System.Windows.Forms.TextBox txtNumerosAGenerar;
        private System.Windows.Forms.Button btnRealizarPrueba;
        private System.Windows.Forms.TextBox txtOtro;
        private System.Windows.Forms.RadioButton rbtOtro;
        private System.Windows.Forms.DataGridView dgvTablaChi;
        private System.Windows.Forms.Button generar_Histograma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn intervalo;
        private System.Windows.Forms.DataGridViewTextBoxColumn frecuenciaObservada;
        private System.Windows.Forms.DataGridViewTextBoxColumn frecuenciaEsperada;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadPrueba;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadPruebaAcum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}