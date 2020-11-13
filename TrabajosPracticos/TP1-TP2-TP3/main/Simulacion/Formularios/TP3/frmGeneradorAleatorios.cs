using Simulacion.Clases;
using Simulacion.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Simulacion.Formularios
{
    public partial class frmGeneradorAleatorios : Form
    {
        IGeneradorAleatorio generador_aleatorio;
        IGeneradorPseudo generadorPseudo;

        public frmGeneradorAleatorios()
        {
            InitializeComponent();
        }

        private void soloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int cantidadNumeros;

            try
            {
                cantidadNumeros = int.Parse(txtBox_NrosGenerar.Text);
            }
            catch
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBox_NrosGenerar.Focus();
                return;
            }
            if (cantidadNumeros == 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBox_NrosGenerar.Focus();
                return;
            }


            generadorPseudo = new GeneradorLenguaje();

            float[] numerosPseudo;
            float[] numerosAleatorios;

            if (rdbUniforme.Checked)
            {
                float a;
                float b;

                try
                {
                    a = float.Parse(txtInterA.Text);
                    b = float.Parse(txtInterB.Text);
                }
                catch
                {
                    MessageBox.Show("Complete las casillas correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInterA.Focus();
                    return;
                }

                //tener en cuenta que no estamos validando que A sea menor a B, pero anda lo mismo
                generador_aleatorio = new GeneradorUniforme(a, b);

                //tener en cuenta q esto entrega pseudoaleatorios SOLO de 4 decimales (aviso por las dudas)
                numerosPseudo = generadorPseudo.generarPseudoaleatorios(cantidadNumeros);

                numerosAleatorios = generador_aleatorio.generarNumeros(numerosPseudo);
                generador_aleatorio.llenar_dgv(dgvNumeros, numerosAleatorios);
            } 

            else if (rdbExponencial.Checked)
            {
                float media;

                try
                {
                    media = float.Parse(txtMedia.Text);
                }
                catch
                {
                    MessageBox.Show("Complete las casillas correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMedia.Focus();
                    return;
                }

                generador_aleatorio = new GeneradorExponencial(media);

                //tener en cuenta q esto entrega pseudoaleatorios SOLO de 4 decimales (aviso por las dudas)
                numerosPseudo = generadorPseudo.generarPseudoaleatorios(cantidadNumeros);

                numerosAleatorios = generador_aleatorio.generarNumeros(numerosPseudo);
                generador_aleatorio.llenar_dgv(dgvNumeros, numerosAleatorios);

            } 

            else if (rdbNormalBoxMuller.Checked)
            {
                float media;
                float desviacion;

                try
                {
                    media = float.Parse(txtMedia.Text);
                    desviacion = float.Parse(txtDesviacion.Text);
                }
                catch
                {
                    MessageBox.Show("Complete las casillas correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMedia.Focus();
                    return;
                }

                generador_aleatorio = new GeneradorNormal(media, desviacion,"box_muller");

                numerosPseudo = generadorPseudo.generarPseudoaleatorios(cantidadNumeros * 2);

                numerosAleatorios = generador_aleatorio.generarNumeros(numerosPseudo);

                generador_aleatorio.llenar_dgv(dgvNumeros, numerosAleatorios);

            } 

            else if (rdbNormalConvolucion.Checked)
            {
                float media;
                float desviacion;

                try
                {
                    media = float.Parse(txtMedia.Text);
                    desviacion = float.Parse(txtDesviacion.Text);
                }
                catch
                {
                    MessageBox.Show("Complete las casillas correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMedia.Focus();
                    return;
                }

                generador_aleatorio = new GeneradorNormal(media, desviacion, "convolucion");

                numerosPseudo = generadorPseudo.generarPseudoaleatorios(cantidadNumeros * 12);

                numerosAleatorios = generador_aleatorio.generarNumeros(numerosPseudo);

                generador_aleatorio.llenar_dgv(dgvNumeros, numerosAleatorios);

            } 

            else if (rdbPoisson.Checked)
            {
                float lambda;

                try
                {
                    lambda = float.Parse(txtLambda.Text);
                }
                catch
                {
                    MessageBox.Show("Complete las casillas correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLambda.Focus();
                    return;
                }

                GeneradorPoisson generador = new GeneradorPoisson();
                int[] numerosPoisson = generador.generarNumerosPoisson(cantidadNumeros, lambda);
                generador.llenar_dgv(dgvNumeros, numerosPoisson);

            } 
        }

        private void borrar_cajas_texto()
        {
            txtInterA.Text = "";
            txtInterB.Text = "";
            txtMedia.Text = "";
            txtLambda.Text = "";
            txtDesviacion.Text = "";
        }

        private void rdbUniforme_CheckedChanged(object sender, EventArgs e)
        {
            borrar_cajas_texto();
            txtInterA.Enabled = true;
            txtInterB.Enabled = true;
            txtMedia.Enabled = false;
            txtLambda.Enabled = false;
            txtDesviacion.Enabled = false;
            txtInterA.Focus();
        }

        private void rdbExponencial_CheckedChanged(object sender, EventArgs e)
        {
            borrar_cajas_texto();
            txtInterA.Enabled = false;
            txtInterB.Enabled = false;
            txtMedia.Enabled = true;
            txtLambda.Enabled = false;
            txtDesviacion.Enabled = false;
            txtMedia.Focus();
        }

        private void rdbNormalBoxMuller_CheckedChanged(object sender, EventArgs e)
        {
            borrar_cajas_texto();
            txtInterA.Enabled = false;
            txtInterB.Enabled = false;
            txtMedia.Enabled = true;
            txtLambda.Enabled = false;
            txtDesviacion.Enabled = true;
            txtMedia.Focus();
        }

        private void rdbNormalConvolucion_CheckedChanged(object sender, EventArgs e)
        {
            borrar_cajas_texto();
            txtInterA.Enabled = false;
            txtInterB.Enabled = false;
            txtMedia.Enabled = true;
            txtLambda.Enabled = false;
            txtDesviacion.Enabled = true;
            txtMedia.Focus();
        }

        private void rdbPoisson_CheckedChanged(object sender, EventArgs e)
        {
            borrar_cajas_texto();
            txtInterA.Enabled = false;
            txtInterB.Enabled = false;
            txtMedia.Enabled = false;
            txtLambda.Enabled = true;
            txtDesviacion.Enabled = false;
            txtLambda.Focus();
        }

        private void frmGeneradorAleatorios_Load(object sender, EventArgs e)
        {
            txtBox_NrosGenerar.Focus();
        }

        private void txtBox_NrosGenerar_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtInterA_KeyPress(object sender, KeyPressEventArgs e)
        {
            //soloNumeros(e);
        }

        private void txtInterB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //soloNumeros(e);
        }

        private void txtLambda_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtDesviacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

    }
}
