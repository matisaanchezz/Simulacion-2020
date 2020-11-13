using Simulacion.Interfaces;
using Simulacion.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Simulacion.Clases.PruebasBondadAjuste;

namespace Simulacion.Formularios
{
    public partial class frmPruebasPseudos : Form
    {
        IGeneradorPseudo generador;
        IPruebaBondadAjuste prueba;
        Histograma histograma1;

        public frmPruebasPseudos()
        {
            InitializeComponent();
        }

        private void frmJiCuadrado_Load(object sender, EventArgs e)
        {
            txtNumerosAGenerar.Focus();
            generar_Histograma.Enabled = false;
        }

        private void rbtMetMixto_CheckedChanged(object sender, EventArgs e)
        {
            txtXo.Enabled = true;
            txtK.Enabled = true;
            txtG.Enabled = true;
            txtC.Enabled = true;
            txtXo.Focus();
        }

        private void rbtMetLeng_CheckedChanged(object sender, EventArgs e)
        {
            txtXo.Enabled = false;
            txtK.Enabled = false;
            txtG.Enabled = false;
            txtC.Enabled = false;
        }

        private void rdb_Intervalo5_CheckedChanged(object sender, EventArgs e)
        {
            btnRealizarPrueba.Enabled = true;
            txtOtro.Enabled = false;
        }

        private void rdb_Intervalo10_CheckedChanged(object sender, EventArgs e)
        {
            btnRealizarPrueba.Enabled = true;
            txtOtro.Enabled = false;
        }

        private void rdb_Intervalo15_CheckedChanged(object sender, EventArgs e)
        {
            btnRealizarPrueba.Enabled = true;
            txtOtro.Enabled = false;
        }

        private void rbtOtro_CheckedChanged(object sender, EventArgs e)
        {
            btnRealizarPrueba.Enabled = true;
            txtOtro.Enabled = true;
        }

        private void btnRealizarPrueba_Click(object sender, EventArgs e)
        {
            try
            {
                generar_Histograma.Enabled = true;
                txtNumerosAGenerar.Focus();
                int nroIntervalos;
                int cant_numeros = Convert.ToInt32(txtNumerosAGenerar.Text);
                int cant_minima;

                if (rdb_Intervalo5.Checked)
                {
                    cant_minima = 30;
                    nroIntervalos = 5;
                }
                else if (rdb_Intervalo10.Checked)
                {
                    cant_minima = 5 * 10;
                    nroIntervalos = 10;
                }
                else if (rdb_Intervalo15.Checked)
                {
                    cant_minima = 5 * 15;
                    nroIntervalos = 15;
                }
                else if (rbtOtro.Checked)
                {
                    int otroNum = int.Parse(txtOtro.Text);
                    cant_minima = 5 * otroNum;
                    nroIntervalos = otroNum;
                }
                else return;

                float[] listaNumeros;
                if (cant_numeros >= cant_minima)
                {
                    if (rbtMetLeng.Checked)
                    {
                        generador = new GeneradorLenguaje();
                        listaNumeros = generador.generarPseudoaleatorios(cant_numeros);
                    }
                    else if (rbtMetMixto.Checked)
                    {
                        float k = float.Parse(txtK.Text);
                        float g = float.Parse(txtG.Text);
                        float Xo = float.Parse(txtXo.Text);
                        float c = float.Parse(txtC.Text);
                        generador = new GeneradorLineal(Xo, k, c, g);
                        listaNumeros = generador.generarPseudoaleatorios(cant_numeros);
                    }
                    else return;

                    dgvTabla.Rows.Clear();
                    for (int i = 0; i < cant_numeros; i++)
                    {
                        dgvTabla.Rows.Add(i + 1, string.Format("{0:N4}", listaNumeros[i]));
                    }

                    //determinación de intervalos y de frecuencias esperadas
                    float fe = cant_numeros / nroIntervalos;
                    float[] fe_array = new float[nroIntervalos];
                    fe_array[0] = fe;
                    float tamañoIntervalo = (float)1 / nroIntervalos;
                    float[] desde = new float[nroIntervalos];
                    float[] hasta = new float[nroIntervalos];
                    desde[0] = 0;
                    hasta[0] = tamañoIntervalo;
                    for (int i = 1; i < nroIntervalos; i++)
                    {
                        fe_array[i] = fe;
                        desde[i] = hasta[i - 1];
                        hasta[i] = hasta[i - 1] + tamañoIntervalo;
                    }

                    //determinación de frecuencias observadas
                    float[] fo_array = new float[nroIntervalos];
                    for (int i = 0; i < cant_numeros; i++)
                    {
                        for (int j = 0; j < nroIntervalos; j++)
                        {
                            if (listaNumeros[i] < hasta[j])
                            {
                                fo_array[j] += 1;
                                break;
                            }
                        }
                    }

                    //prueba de bondad de ajuste
                    prueba = new JICuadrada();
                    prueba.realizar_prueba_en_dgv(dgvTablaChi, desde, hasta, fo_array, fe_array);

                    // Cargamos el histograma
                    int[,] matrizFrecuencias = new int[2, nroIntervalos];
                    for (int i = 0; i < nroIntervalos; i++)
                    {
                        matrizFrecuencias[1, i] = Convert.ToInt32(fo_array[i]);
                        matrizFrecuencias[0, i] = Convert.ToInt32(fe_array[i]);
                    }
                    histograma1 = new Histograma();
                    histograma1.cargarHistograma(nroIntervalos, matrizFrecuencias, cant_numeros);
                }
                else
                {
                    MessageBox.Show("Debe solicitar al menos " + cant_minima.ToString() + " números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumerosAGenerar.Clear();
                    txtNumerosAGenerar.Focus();
                }
            }
            catch
            {
                IOException ex = new IOException();
                if (rbtMetLeng.Checked)
                {
                    if (txtNumerosAGenerar.Text == "")
                    {
                        MessageBox.Show("Cargue todos los casilleros por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (rbtOtro.Checked && txtOtro.Text == "")
                    {
                        MessageBox.Show("Cargue todos los casilleros por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (rbtMetMixto.Checked)
                {
                    if (rbtOtro.Checked && txtOtro.Text == "")
                    {
                        MessageBox.Show("Cargue todos los casilleros por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        ex.validar_Carga(txtNumerosAGenerar, txtXo, txtK, txtG, txtC, txtOtro, null);
                }
            }
        }

        private void soloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNumerosAGenerar_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtXo_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtK_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtG_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtOtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void generar_Histograma_Click(object sender, EventArgs e)
        {
            histograma1.Show();
        }
    }
}
