using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Formularios
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void abrir_form_en_panel(object form)
        {
            if (this.panel_contenedor.Controls.Count > 0)
            {
                this.panel_contenedor.Controls.RemoveAt(0);
            }
            Form frm = form as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.panel_contenedor.Controls.Add(frm);
            this.panel_contenedor.Tag = frm;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrir_form_en_panel(new Simulacion.Formularios.frmPruebasPseudos());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrir_form_en_panel(new Simulacion.Formularios.frm_generador_numeros());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            abrir_form_en_panel(new Simulacion.Formularios.frmInicio());
        }

        private void frm_principal_Load(object sender, EventArgs e)
        {
            abrir_form_en_panel(new Simulacion.Formularios.frmInicio());
        }

        private void btnDistribución_Click(object sender, EventArgs e)
        {
            abrir_form_en_panel(new Simulacion.Formularios.frmPruebasAleatorios());
        }

        private void btnGeneradorAleatorios_Click(object sender, EventArgs e)
        {
            abrir_form_en_panel(new Simulacion.Formularios.frmGeneradorAleatorios());
        }
    }
}
