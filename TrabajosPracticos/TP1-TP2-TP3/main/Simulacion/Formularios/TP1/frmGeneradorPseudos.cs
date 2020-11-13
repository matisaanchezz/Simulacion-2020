using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulacion.Interfaces;
using Simulacion.Clases;


namespace Simulacion.Formularios
{
    public partial class frm_generador_numeros : Form
    {
        IGeneradorPseudo generador;

        public frm_generador_numeros()
        {
            InitializeComponent();
        }

        private void rbtMixto_CheckedChanged(object sender, EventArgs e)
        {
            txtXo.Enabled = true;
            txtK.Enabled = true;
            txtG.Enabled = true;
            txtC.Enabled = true;
            txtNumerosAGenerar.Enabled = true;
            btnGenerar1Mas.Enabled = false;
            dgvNumeros.Rows.Clear();
            txtXo.Focus();
        }

        private void rbtMultiplicativo_CheckedChanged(object sender, EventArgs e)
        {
            txtXo.Enabled = true;
            txtK.Enabled = true;
            txtG.Enabled = true;
            txtNumerosAGenerar.Enabled = true;
            txtC.Enabled = false;
            btnGenerar1Mas.Enabled = false;
            dgvNumeros.Rows.Clear();
            txtXo.Focus();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGenerar1Mas.Enabled = false;
                btnGenerar1Mas.Enabled = true;

                //X0
                float Xo = float.Parse(txtXo.Text);

                float k = float.Parse(txtK.Text);
                //m periodo
                float g = float.Parse(txtG.Text);
                //Cantidad de n° a generar
                int cant = Convert.ToInt32(txtNumerosAGenerar.Text);


                // este if asegura que si o si un solo radiobutton esté seleccionado
                if ((rbtMixto.Checked && !rbtMultiplicativo.Checked) || (!rbtMixto.Checked && rbtMultiplicativo.Checked))
                {

                    if (rbtMixto.Checked)
                    {
                        //c cte aditiva                    
                        float c = float.Parse(txtC.Text);
                        dgvNumeros.Columns[1].HeaderText = "a.Xi + c";
                        generador = new GeneradorLineal(Xo, k, c, g);
                    }
                    else
                    {
                        dgvNumeros.Columns[1].HeaderText = "a.Xi";
                        generador = new GeneradorMultiplicativo(Xo, k, g);
                    }

                    // llena la datagriedview con los n° pseudoaleatorios
                    generador.llenar_dgv(dgvNumeros, cant);
                }
            }
            catch
            {
                IOException ex = new IOException();
                ex.validar_Carga(txtC, txtG, txtK, txtXo, txtNumerosAGenerar, null, btnGenerar1Mas);
            }
        }

        private void btnGenerar1Mas_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnGenerar.Enabled) generador.agregar_fila_dgv(dgvNumeros);
                dgvNumeros.FirstDisplayedScrollingRowIndex = dgvNumeros.RowCount - 1;

            }
            catch
            {
                IOException ex = new IOException();
                ex.validar_Carga(txtC, txtG, txtK, txtXo, txtNumerosAGenerar, null, btnGenerar1Mas);
            }
        }

        private void soloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtXo_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtK_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtG_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtNumerosAGenerar_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                btnGenerar1Mas.Enabled = false;
                txtC.Text = "";
                txtG.Text = "";
                txtK.Text = "";
                txtXo.Text = "";
                txtNumerosAGenerar.Text = "20";
                dgvNumeros.Rows.Clear();
                txtXo.Focus();
            }
            catch
            {
                IOException ex = new IOException();
                ex.otroError();
            }
        }

        private void txtNumerosAGenerar_Enter(object sender, EventArgs e)
        {
            if (txtNumerosAGenerar.Text == "20")
            {
                txtNumerosAGenerar.Text = "";
                txtNumerosAGenerar.ForeColor = Color.Black;
            }
        }

        private void txtNumerosAGenerar_Leave(object sender, EventArgs e)
        {
            if (txtNumerosAGenerar.Text == "")
            {
                txtNumerosAGenerar.Text = "20";
                txtNumerosAGenerar.ForeColor = Color.Silver;
            }
        }

        private void btnAyudaXo_MouseHover(object sender, EventArgs e)
        {
            if (rbtMixto.Checked)
            {
                tltAyuda.SetToolTip(btnAyudaXo, "Ingrese un número entero.");
            }
            else if (rbtMultiplicativo.Checked)
            {
                tltAyuda.SetToolTip(btnAyudaXo, "Ingrese un número entero. Recomendado: impar.");
            }
        }

        private void btnAyudaK_MouseHover(object sender, EventArgs e)
        {
            tltAyuda.SetToolTip(btnAyudaK, "Ingrese un número entero.");
        }

        private void btnAyudaG_MouseHover(object sender, EventArgs e)
        {
            tltAyuda.SetToolTip(btnAyudaG, "Ingrese un número entero.");
        }

        private void btnAyudaC_MouseHover(object sender, EventArgs e)
        {
            if (rbtMixto.Checked)
            {
                tltAyuda.SetToolTip(btnAyudaC, "Recomendado: entero y primo al módulo (2^g).");
            }
            else
            {
                tltAyuda.SetToolTip(btnAyudaC, "");
            }
        }
    }
}
