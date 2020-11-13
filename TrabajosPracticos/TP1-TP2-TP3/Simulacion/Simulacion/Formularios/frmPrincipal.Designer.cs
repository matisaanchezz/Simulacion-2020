namespace Simulacion.Formularios
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panel_menu = new System.Windows.Forms.Panel();
            this.btnGeneradorAleatorios = new System.Windows.Forms.Button();
            this.btnDistribución = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_generador_pseudoaleatorios = new System.Windows.Forms.Button();
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.panel_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel_menu.Controls.Add(this.btnGeneradorAleatorios);
            this.panel_menu.Controls.Add(this.btnDistribución);
            this.panel_menu.Controls.Add(this.btnInicio);
            this.panel_menu.Controls.Add(this.button3);
            this.panel_menu.Controls.Add(this.btn_generador_pseudoaleatorios);
            this.panel_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_menu.Location = new System.Drawing.Point(0, 0);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(240, 561);
            this.panel_menu.TabIndex = 0;
            // 
            // btnGeneradorAleatorios
            // 
            this.btnGeneradorAleatorios.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnGeneradorAleatorios.FlatAppearance.BorderSize = 0;
            this.btnGeneradorAleatorios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnGeneradorAleatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneradorAleatorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneradorAleatorios.ForeColor = System.Drawing.Color.White;
            this.btnGeneradorAleatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneradorAleatorios.Location = new System.Drawing.Point(0, 251);
            this.btnGeneradorAleatorios.Name = "btnGeneradorAleatorios";
            this.btnGeneradorAleatorios.Size = new System.Drawing.Size(240, 65);
            this.btnGeneradorAleatorios.TabIndex = 13;
            this.btnGeneradorAleatorios.Text = "Generador de aleatorios";
            this.btnGeneradorAleatorios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneradorAleatorios.UseVisualStyleBackColor = false;
            this.btnGeneradorAleatorios.Click += new System.EventHandler(this.btnGeneradorAleatorios_Click);
            // 
            // btnDistribución
            // 
            this.btnDistribución.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnDistribución.FlatAppearance.BorderSize = 0;
            this.btnDistribución.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDistribución.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDistribución.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistribución.ForeColor = System.Drawing.Color.White;
            this.btnDistribución.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDistribución.Location = new System.Drawing.Point(0, 312);
            this.btnDistribución.Name = "btnDistribución";
            this.btnDistribución.Size = new System.Drawing.Size(240, 65);
            this.btnDistribución.TabIndex = 12;
            this.btnDistribución.Text = "Prueba de bondad de ajuste para aleatorios";
            this.btnDistribución.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDistribución.UseVisualStyleBackColor = false;
            this.btnDistribución.Click += new System.EventHandler(this.btnDistribución_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInicio.BackgroundImage")));
            this.btnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInicio.Location = new System.Drawing.Point(0, 0);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(240, 106);
            this.btnInicio.TabIndex = 10;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(240, 65);
            this.button3.TabIndex = 9;
            this.button3.Text = "Prueba de bondad de ajuste para pseudoaleatorios";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_generador_pseudoaleatorios
            // 
            this.btn_generador_pseudoaleatorios.FlatAppearance.BorderSize = 0;
            this.btn_generador_pseudoaleatorios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_generador_pseudoaleatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generador_pseudoaleatorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generador_pseudoaleatorios.ForeColor = System.Drawing.Color.White;
            this.btn_generador_pseudoaleatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_generador_pseudoaleatorios.Location = new System.Drawing.Point(0, 112);
            this.btn_generador_pseudoaleatorios.Name = "btn_generador_pseudoaleatorios";
            this.btn_generador_pseudoaleatorios.Size = new System.Drawing.Size(240, 65);
            this.btn_generador_pseudoaleatorios.TabIndex = 8;
            this.btn_generador_pseudoaleatorios.Text = "Generador de pseudoaleatorios";
            this.btn_generador_pseudoaleatorios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_generador_pseudoaleatorios.UseVisualStyleBackColor = true;
            this.btn_generador_pseudoaleatorios.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenedor.Location = new System.Drawing.Point(240, 0);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(744, 561);
            this.panel_contenedor.TabIndex = 3;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel_contenedor);
            this.Controls.Add(this.panel_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Text = "TP1 Simulación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_principal_Load);
            this.panel_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_generador_pseudoaleatorios;
        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnDistribución;
        private System.Windows.Forms.Button btnGeneradorAleatorios;
    }
}