using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Simulacion.Clases;
using Simulacion.Interfaces;
using System.Timers;
using Simulacion.Clases.PruebasBondadAjuste;

namespace Simulacion.Formularios
{
    public partial class frmPruebasAleatorios : Form
    {
        IGeneradorPseudo generadorPseudo;
        IGeneradorAleatorio generadorAleatorio;
        IPruebaBondadAjuste prueba;
        Histograma histograma1;

        public frmPruebasAleatorios()
        {
            InitializeComponent();

        }

        private void rdbUniforme_CheckedChanged(object sender, EventArgs e)
        {
            // text boxs a ser deshabilitados y/o habilitados...
            txtBoxA.Enabled = true;
            txtBoxB.Enabled = true;
            txtBoxMedia.Enabled = false;
            txtBoxLambda.Enabled = false;
            txtBoxDesviacion.Enabled = false;
            txtBoxA.Focus();
        }

        private void rdbPoisson_CheckedChanged(object sender, EventArgs e)
        {
            // text boxs a ser deshabilitados y/o habilitados... Puede ser lambda o media
            //tiene q tomar un valor entero
            txtBoxA.Enabled = false;
            txtBoxB.Enabled = false;
            txtBoxDesviacion.Enabled = false;
            txtBoxMedia.Enabled = false;
            txtBoxLambda.Enabled = true;
            txtBoxLambda.Focus();
        }

        private void rdbExponencial_CheckedChanged(object sender, EventArgs e)
        {
            // text boxs a ser deshabilitados y/o habilitados...
            txtBoxA.Enabled = false;
            txtBoxB.Enabled = false;
            txtBoxDesviacion.Enabled = false;
            txtBoxLambda.Enabled = false;
            txtBoxMedia.Enabled = true;
            txtBoxMedia.Focus();
        }

        private void rdbNormalBoxMuller_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxA.Enabled = false;
            txtBoxB.Enabled = false;
            txtBoxLambda.Enabled = false;
            txtBoxDesviacion.Enabled = true;
            txtBoxMedia.Enabled = true;
            txtBoxMedia.Focus();
        }

        private void rdbNormalConvolucion_CheckedChanged(object sender, EventArgs e)
        {
            // text boxs a ser deshabilitados y/o habilitados...
            txtBoxA.Enabled = false;
            txtBoxB.Enabled = false;
            txtBoxDesviacion.Enabled = true;
            txtBoxLambda.Enabled = false;
            txtBoxMedia.Enabled = true;
            txtBoxMedia.Focus();
        }

        private void frmGeneradorDistribucion_Load(object sender, EventArgs e)
        {
            txtBoxLambda.Enabled = false;
            txtBoxDesviacion.Enabled = false;
            txtBoxMedia.Enabled = false;
            txtBoxA.Enabled = false;
            txtBoxB.Enabled = false;
            txtBox_NrosGenerar.Focus();
        }

        private void btnRealizarPrueba_Click(object sender, EventArgs e)
        {
            try
            {
                txtBox_NrosGenerar.Focus();
                int cant_numeros = Convert.ToInt32(txtBox_NrosGenerar.Text);
                int nroIntervalos;
                int cant_minima;

                if (rbtn5.Checked)
                {
                    cant_minima = 30;
                    nroIntervalos = 5;
                }
                else if (rbtn10.Checked)
                {
                    cant_minima = 5 * 10;
                    nroIntervalos = 10;
                }
                else if (rbtn15.Checked)
                {
                    cant_minima = 5 * 15;
                    nroIntervalos = 15;
                }
                else if (rbtnOtro.Checked)
                {
                    int otroNum = int.Parse(txtBox_Otro.Text);
                    cant_minima = 5 * otroNum;
                    nroIntervalos = otroNum;
                }
                else return;

                // ------------------------ Distribuciones ------------------------                

                if (cant_numeros >= cant_minima)
                {
                    dgvPruebaChiCuadrado.Rows.Clear();
                    dgvValoresGenerados.Rows.Clear();
                    float[] lista_pseudos = new float[cant_numeros];
                    float[] lista_aleatorios = new float[cant_numeros];

                    // variables para el histograma (para todas las distribuciones)
                    int[,] matrizFrecuencias = new int[2, nroIntervalos];

                    // DISTRIBUCIÓN UNIFORME --> LISTO
                    if (rdbUniforme.Checked)
                    {
                        float a;
                        float b;

                        try
                        {
                            a = float.Parse(txtBoxA.Text);
                            b = float.Parse(txtBoxB.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Complete las casillas correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtBoxA.Focus();
                            return;
                        }
                        if (a >= b)
                        {
                            MessageBox.Show("El límite inferior A no puede ser mayor o igual al límite superior B. Ingrese nuevamente los valores", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        //PASO 1 --> SE PROCEDE A LLENAR TABLA DE ALEATORIOS

                        // pseudoaleatorios
                        generadorPseudo = new GeneradorLenguaje();
                        lista_pseudos = generadorPseudo.generarPseudoaleatorios(cant_numeros);
                        // aleatorios
                        generadorAleatorio = new GeneradorUniforme(a, b);
                        lista_aleatorios = generadorAleatorio.generarNumeros(lista_pseudos);

                        generadorAleatorio.llenar_dgv(dgvValor, lista_aleatorios);

                        //PASO 2 --> SE PROCEDE A LLENAR TABLA DE FRECUENCIAS ESPERADAS

                        float tamañoIntervalo_Uniforme = (b - a) / nroIntervalos;

                        float[] fo_array = new float[nroIntervalos];
                        float fe_uniforme = (float)cant_numeros / (float)nroIntervalos;
                        float[] desde = new float[nroIntervalos];
                        float[] hasta = new float[nroIntervalos];

                        //determinación de intervalos
                        desde[0] = a;
                        hasta[0] = a + tamañoIntervalo_Uniforme;
                        for (int i = 1; i < nroIntervalos; i++)
                        {
                            desde[i] = hasta[i - 1];
                            hasta[i] = hasta[i - 1] + tamañoIntervalo_Uniforme;
                        }
                        //determinación de frecuencia observada
                        for (int i = 0; i < cant_numeros; i++)
                        {
                            for (int j = 0; j < nroIntervalos; j++)
                            {
                                if (lista_aleatorios[i] < hasta[j])
                                {
                                    fo_array[j] += 1;
                                    break;
                                }
                            }
                        }

                        // ------ Carga matriz y Array de frecuencias esperadas ------

                        float[] fe_array = new float[nroIntervalos];
                        for (int i = 0; i < nroIntervalos; i++)
                        {
                            fe_array[i] = fe_uniforme;
                            matrizFrecuencias[1, i] = Convert.ToInt32(fo_array[i]);
                            matrizFrecuencias[0, i] = Convert.ToInt32(fe_uniforme);
                        }

                        // ------ Tabla ji-Cuadrada  ------

                        prueba = new JICuadrada();
                        prueba.realizar_prueba_en_dgv(dgvPruebaChiCuadrado, desde, hasta, fo_array, fe_array);

                    }

                    // DISTRIBUCIÓN NORMAL: BOX MULLER
                    else if (rdbNormalBoxMuller.Checked)
                    {
                        float media = float.Parse(txtBoxMedia.Text);
                        float desvacionEstandar = float.Parse(txtBoxDesviacion.Text);
                        if (cant_numeros >= 0)
                        {
                            //PASO 1 --> SE PROCEDE A LLENAR TABLA DE ALEATORIOS

                            // pseudoaleatorios
                            generadorPseudo = new GeneradorLenguaje();
                            lista_pseudos = generadorPseudo.generarPseudoaleatorios(cant_numeros * 2);
                            // aleatorios
                            generadorAleatorio = new GeneradorNormal(media, desvacionEstandar, "box_muller");
                            lista_aleatorios = generadorAleatorio.generarNumeros(lista_pseudos);

                            generadorAleatorio.llenar_dgv(dgvValor, lista_aleatorios);
                            // aleatorios BoxMuller 1
                            float[] aleatorios_BM1 = new float[cant_numeros];
                            Array.Copy(lista_aleatorios, 0, aleatorios_BM1, 0, cant_numeros);


                            //PASO 2 Determinación de intervalos, marcas de clases y P()s
                            float[] desde = new float[nroIntervalos];
                            float[] hasta = new float[nroIntervalos];
                            float[] marca_clase = new float[nroIntervalos];
                            float[] p_ = new float[nroIntervalos];

                            float menor_aleatorio = aleatorios_BM1.Min();
                            float mayor_aleatorio = aleatorios_BM1.Max();

                            desde[0] = menor_aleatorio;
                            float tamaño_intervalo = (1 + mayor_aleatorio - menor_aleatorio) / nroIntervalos;
                            hasta[0] = menor_aleatorio + tamaño_intervalo;

                            marca_clase[0] = (desde[0] + hasta[0]) / 2;

                            p_[0] = Math.Abs(calcularDensidadNormal(media, desvacionEstandar, marca_clase[0], hasta[0], desde[0]));

                            for (int i = 1; i < nroIntervalos; i++)
                            {
                                desde[i] = hasta[i - 1];
                                hasta[i] = hasta[i - 1] + tamaño_intervalo;
                                marca_clase[i] = (desde[i] + hasta[i]) / 2;
                                p_[i] = Math.Abs(calcularDensidadNormal(media, desvacionEstandar, marca_clase[i], hasta[i], desde[i]));
                            }

                            // PASO 3 Frecuencias observadas y esperadas
                            float[] fo_array = new float[nroIntervalos];
                            float[] fe_array = new float[nroIntervalos];
                            for (int k = 0; k < nroIntervalos; k++)
                            {
                                // fe
                                fe_array[k] = p_[k] * (float)cant_numeros;
                            }
                            for (int i = 0; i < cant_numeros; i++)
                            {
                                for (int j = 0; j < nroIntervalos; j++)
                                {
                                    // fo
                                    if (aleatorios_BM1[i] < hasta[j])
                                    {
                                        fo_array[j] += 1;

                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < nroIntervalos; i++)
                            {
                                dgvValoresGenerados.Rows.Add(string.Format("[ " + "{0:N2}", desde[i]) + " ; " + string.Format("{0:N2}", hasta[i]) + " )", string.Format("{0:N2}", marca_clase[i]), fo_array[i], string.Format("{0:N4}", p_[i]), string.Format("{0:N4}", fe_array[i]));
                            }


                            // ------ Carga de matriz para histograma ------

                            for (int i = 0; i < nroIntervalos; i++)
                            {
                                matrizFrecuencias[1, i] = Convert.ToInt32(fo_array[i]);
                                matrizFrecuencias[0, i] = Convert.ToInt32(fe_array[i]);
                            }

                            // ----- Juntando intervalos adyacentes necesarios -----

                            vector_fe_mayor_5(desde, hasta, fe_array, fo_array);

                            // ------ Tabla ji-Cuadrada  ------

                            prueba = new JICuadrada();
                            prueba.realizar_prueba_en_dgv(dgvPruebaChiCuadrado, desde, hasta, fo_array, fe_array);

                        }
                    }

                    // DISTRIBUCIÓN NORMAL: CONVOLUCIÓN
                    else if (rdbNormalConvolucion.Checked)
                    {

                        //PASO 1 --> SE PROCEDE A LLENAR TABLA DE ALEATORIOS

                        float media = float.Parse(txtBoxMedia.Text);
                        float desviacion = float.Parse(txtBoxDesviacion.Text);

                        // pseudoaleatorios
                        generadorPseudo = new GeneradorLenguaje();
                        lista_pseudos = generadorPseudo.generarPseudoaleatorios(cant_numeros * 12);

                        // aleatorios
                        generadorAleatorio = new GeneradorNormal(media, desviacion, "convolucion");
                        lista_aleatorios = generadorAleatorio.generarNumeros(lista_pseudos);

                        generadorAleatorio.llenar_dgv(dgvValor, lista_aleatorios);


                        //PASO 2 Determinación de intervalos, marcas de clases y P()s
                        float[] desde = new float[nroIntervalos];
                        float[] hasta = new float[nroIntervalos];
                        float[] marca_clase = new float[nroIntervalos];
                        float[] p_ = new float[nroIntervalos];

                        float menor_aleatorio = lista_aleatorios.Min();
                        float mayor_aleatorio = lista_aleatorios.Max();
                        desde[0] = menor_aleatorio;
                        float tamaño_intervalo = (1 + mayor_aleatorio - menor_aleatorio) / nroIntervalos;
                        hasta[0] = menor_aleatorio + tamaño_intervalo;
                        marca_clase[0] = (desde[0] + hasta[0]) / 2;
                        p_[0] = Math.Abs(calcularDensidadNormal(media, desviacion, marca_clase[0], desde[0], hasta[0]));

                        for (int i = 1; i < nroIntervalos; i++)
                        {
                            desde[i] = hasta[i - 1];
                            hasta[i] = hasta[i - 1] + tamaño_intervalo;
                            marca_clase[i] = (desde[i] + hasta[i]) / 2;
                            p_[i] = Math.Abs(calcularDensidadNormal(media, desviacion, marca_clase[i], desde[i], hasta[i]));
                        }

                        // PASO 2 Frecuencias observadas y esperadas
                        float[] fo_array = new float[nroIntervalos];
                        float[] fe_array = new float[nroIntervalos];
                        for (int k = 0; k < nroIntervalos; k++)
                        {
                            // fe
                            fe_array[k] = p_[k] * (float)cant_numeros;
                        }
                        for (int i = 0; i < cant_numeros; i++)
                        {
                            for (int j = 0; j < nroIntervalos; j++)
                            {
                                // fo
                                if (lista_aleatorios[i] < hasta[j])
                                {
                                    fo_array[j] += 1;

                                    break;
                                }
                            }
                        }
                        for (int i = 0; i < nroIntervalos; i++)
                        {
                            dgvValoresGenerados.Rows.Add(string.Format("[ " + "{0:N2}", desde[i]) + " ; " + string.Format("{0:N2}", hasta[i]) + " )", string.Format("{0:N2}", marca_clase[i]), fo_array[i], string.Format("{0:N4}", p_[i]), string.Format("{0:N4}", fe_array[i]));
                        }


                        // ------ Histograma ------

                        for (int i = 0; i < nroIntervalos; i++)
                        {
                            matrizFrecuencias[1, i] = Convert.ToInt32(fo_array[i]);
                            matrizFrecuencias[0, i] = Convert.ToInt32(fe_array[i]);
                        }

                        // ----- Juntando intervalos adyacentes necesarios -----

                        vector_fe_mayor_5(desde, hasta, fe_array, fo_array);

                        // ------ Tabla ji-Cuadrada  ------

                        prueba = new JICuadrada();
                        prueba.realizar_prueba_en_dgv(dgvPruebaChiCuadrado, desde, hasta, fo_array, fe_array);
                    }

                    // DISTRIBUCIÓN POISSON
                    else if (rdbPoisson.Checked)
                    {

                        dgvValor.Rows.Clear();
                        int[] variablesPoisson = new int[cant_numeros];
                        int cantidadVar = variablesPoisson.Length;
                        double lambda = double.Parse(txtBoxLambda.Text);
                        GeneradorPoisson generadorPoisson = new GeneradorPoisson();
                        variablesPoisson = generadorPoisson.generarNumerosPoisson(cant_numeros, lambda);

                        int[] numerosPoisson = generadorPoisson.generarNumerosPoisson(cant_numeros, lambda);
                        generadorPoisson.llenar_dgv(dgvValor, numerosPoisson);

                        int minimo = variablesPoisson.Min();
                        int maximo = variablesPoisson.Max();
                        int h = 0;

                        // -------------- Histograma --------------
                        matrizFrecuencias = new int[2, cant_numeros];
                        for (int i = minimo; i < maximo + 1; i++)
                        {
                            int fo = 0;
                            double pPoisson = 0;
                            int fe = 0;

                            for (int j = 0; j < variablesPoisson.Length; j++)
                            {
                                if (variablesPoisson[j] == minimo)
                                {
                                    fo = fo + 1;
                                }
                            }

                            pPoisson = calcularDensidadPoisson(minimo, lambda);
                            fe = (int)Math.Round(Convert.ToDouble(variablesPoisson.Length * pPoisson), 0, MidpointRounding.ToEven);

                            dgvValoresGenerados.Rows.Add(minimo, " - ", fo, string.Format("{0:N4}", pPoisson), fe);


                            matrizFrecuencias[0, h] = Convert.ToInt32(fe);
                            matrizFrecuencias[1, h] = fo;
                            fo = 0;
                            fe = 0;
                            pPoisson = 0;
                            minimo = minimo + 1;
                            h++;
                        }

                        nroIntervalos = dgvValoresGenerados.Rows.Count;
                        // -------------- \ Histograma --------------

                        string intJiCuadrado = "";
                        int foJiCuadrado = 0;
                        int feJiCuadrado = 0;
                        float estadisticoAC = 0;
                        int contador = -1;
                        float[] estadisticos = new float[100];

                        for (int i = 0; i < dgvValoresGenerados.Rows.Count; i++)
                        {

                            intJiCuadrado = intJiCuadrado.ToString() + " " + Convert.ToInt32(dgvValoresGenerados.Rows[i].Cells[0].Value).ToString();
                            foJiCuadrado = foJiCuadrado + Convert.ToInt32(dgvValoresGenerados.Rows[i].Cells[2].Value);
                            feJiCuadrado = feJiCuadrado + Convert.ToInt32(dgvValoresGenerados.Rows[i].Cells[4].Value);


                            if (feJiCuadrado >= 5)
                            {
                                contador = contador + 1;
                                float estadistico = (float)Math.Pow((feJiCuadrado - foJiCuadrado), 2) / feJiCuadrado;
                                estadisticoAC = estadisticoAC + estadistico;
                                estadisticos[contador] = estadistico;
                                dgvPruebaChiCuadrado.Rows.Add(intJiCuadrado, foJiCuadrado, feJiCuadrado, string.Format("{0:N4}", estadistico), string.Format("{0:N4}", estadisticoAC));

                                intJiCuadrado = "";
                                foJiCuadrado = 0;
                                feJiCuadrado = 0;
                            }
                            else
                            {
                                if (i == dgvValoresGenerados.Rows.Count - 1)
                                {
                                    float estAc = 0;
                                    for (int j = 0; j < contador; j++)
                                    {
                                        estAc = estAc + estadisticos[j];
                                    }
                                    float estadistico =
                                        (float)Math.Pow(((Convert.ToInt32(dgvPruebaChiCuadrado.Rows[contador].Cells[2].Value) + feJiCuadrado) - (Convert.ToInt32(dgvPruebaChiCuadrado.Rows[contador].Cells[1].Value) + foJiCuadrado)), 2) / (Convert.ToInt32(dgvPruebaChiCuadrado.Rows[contador].Cells[2].Value) + feJiCuadrado);
                                    dgvPruebaChiCuadrado.Rows[contador].Cells[0].Value = dgvPruebaChiCuadrado.Rows[contador].Cells[0].Value.ToString() + "" + intJiCuadrado.ToString();
                                    dgvPruebaChiCuadrado.Rows[contador].Cells[1].Value = Convert.ToInt32(dgvPruebaChiCuadrado.Rows[contador].Cells[1].Value) + foJiCuadrado;
                                    dgvPruebaChiCuadrado.Rows[contador].Cells[2].Value = Convert.ToInt32(dgvPruebaChiCuadrado.Rows[contador].Cells[2].Value) + feJiCuadrado;
                                    dgvPruebaChiCuadrado.Rows[contador].Cells[3].Value = string.Format("{0:N4}", estadistico);
                                    estAc = estAc + estadistico;
                                    dgvPruebaChiCuadrado.Rows[contador].Cells[4].Value = string.Format("{0:N4}", estAc);


                                }

                            }

                        }
                        dgvPruebaChiCuadrado.Rows[dgvPruebaChiCuadrado.Rows.Count - 1].Cells[4].Style.BackColor = Color.Orange;

                    }

                    // DISTRIBUCIÓN EXPONENCIAL
                    else if (rdbExponencial.Checked)
                    {
                        float media = float.Parse(txtBoxMedia.Text);


                        //PASO 1 --> SE PROCEDE A LLENAR TABLA DE ALEATORIOS

                        // pseudoaleatorios
                        generadorPseudo = new GeneradorLenguaje();
                        lista_pseudos = generadorPseudo.generarPseudoaleatorios(cant_numeros);
                        // aleatorios
                        generadorAleatorio = new GeneradorExponencial(media);
                        lista_aleatorios = generadorAleatorio.generarNumeros(lista_pseudos);

                        generadorAleatorio.llenar_dgv(dgvValor, lista_aleatorios);


                        //PASO 2 Determinación de intervalos, marcas de clases y P()s
                        float lambda = 1 / media;
                        float[] desde = new float[nroIntervalos];
                        float[] hasta = new float[nroIntervalos];
                        float[] marca_clase = new float[nroIntervalos];
                        float[] p_ = new float[nroIntervalos];

                        float menor_aleatorio = lista_aleatorios.Min();
                        float mayor_aleatorio = lista_aleatorios.Max();

                        desde[0] = menor_aleatorio;
                        float tamaño_intervalo = (1 + mayor_aleatorio - menor_aleatorio) / nroIntervalos;
                        hasta[0] = menor_aleatorio + tamaño_intervalo;

                        marca_clase[0] = (desde[0] + hasta[0]) / 2;

                        p_[0] = Math.Abs(calcularDensidadExponencial(marca_clase[0], hasta[0], desde[0], lambda));

                        for (int i = 1; i < nroIntervalos; i++)
                        {
                            desde[i] = hasta[i - 1];
                            hasta[i] = hasta[i - 1] + tamaño_intervalo;
                            marca_clase[i] = (desde[i] + hasta[i]) / 2;
                            p_[i] = Math.Abs(calcularDensidadExponencial(marca_clase[i], hasta[i], desde[i], lambda));
                        }

                        // PASO 3 Frecuencias observadas y esperadas
                        float[] fo_array = new float[nroIntervalos];
                        float[] fe_array = new float[nroIntervalos];
                        for (int k = 0; k < nroIntervalos; k++)
                        {
                            // fe
                            fe_array[k] = p_[k] * (float)cant_numeros;
                        }
                        for (int i = 0; i < cant_numeros; i++)
                        {
                            for (int j = 0; j < nroIntervalos; j++)
                            {
                                // fo
                                if (lista_aleatorios[i] < hasta[j])
                                {
                                    fo_array[j] += 1;

                                    break;
                                }
                            }
                        }
                        for (int i = 0; i < nroIntervalos; i++)
                        {
                            dgvValoresGenerados.Rows.Add(string.Format("[ " + "{0:N2}", desde[i]) + " ; " + string.Format("{0:N2}", hasta[i]) + " )", string.Format("{0:N2}", marca_clase[i]), fo_array[i], string.Format("{0:N4}", p_[i]), string.Format("{0:N4}", fe_array[i]));
                        }


                        // ------ Carga de matriz para histograma ------

                        for (int i = 0; i < nroIntervalos; i++)
                        {
                            matrizFrecuencias[1, i] = Convert.ToInt32(fo_array[i]);
                            matrizFrecuencias[0, i] = Convert.ToInt32(fe_array[i]);
                        }

                        // ----- Juntando intervalos adyacentes necesarios -----

                        vector_fe_mayor_5(desde, hasta, fe_array, fo_array);

                        // ------ Tabla ji-Cuadrada  ------

                        prueba = new JICuadrada();
                        prueba.realizar_prueba_en_dgv(dgvPruebaChiCuadrado, desde, hasta, fo_array, fe_array);

                    }

                    // Histograma para todas las distribuciones
                    histograma1 = new Histograma();
                    histograma1.cargarHistograma(nroIntervalos, matrizFrecuencias, cant_numeros);

                }
                else
                {
                    MessageBox.Show("Debe solicitar al menos " + cant_minima.ToString() + " números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBox_NrosGenerar.Clear();
                    txtBox_NrosGenerar.Focus();
                }
            }
            catch
            {
                Clases.IOException exception = new Clases.IOException();
            }
        }

        private void vector_fe_mayor_5(float[] desde, float[] hasta, float[] fe, float[] fo)
        {
            int cant = fe.Length;
            int ultima_pos = cant - 1;

            // de derecha a izquierda
            for (int i = ultima_pos; i > 0; i--)
            {
                if (fe[i] < (float)5)
                {
                    fe[i - 1] += fe[i];
                    fe[i] = 0;
                    desde[i] = 0;
                    hasta[i - 1] = hasta[i];
                    hasta[i] = 0;
                    fo[i - 1] += fo[i];
                    fo[i] = 0;
                }
            }

            // de izquierda a derecha
            for (int i2 = 0; i2 < cant - 1; i2++)
            {
                if (fe[i2] < 5)
                {
                    fe[i2 + 1] += fe[i2];
                    fe[i2] = 0;
                    desde[i2 + 1] = desde[i2];
                    desde[i2] = 0;
                    hasta[i2] = 0;
                    fo[i2 + 1] += fo[i2];
                    fo[i2] = 0;
                }
            }
        }

        // Cálculo de las densidades respectivas...
        private float calcularDensidadNormal(float media, float desviacion, float marcaClase, float limSup, float limInf)
        {
            float pMuller = (limSup - limInf) * (1 / (desviacion * ((float)Math.Sqrt(2 * (float)Math.PI)))) * (float)(Math.Exp(-0.5 * (float)Math.Pow(((marcaClase - media) / desviacion), 2)));

            return pMuller;
        }

        private double calcularDensidadPoisson(int minimo, double lambda)
        {
            double pPoisson = (double)(((double)Math.Pow(lambda, minimo) * (double)Math.Exp(-lambda)) / (factorial(minimo)));
            return pPoisson;
        }

        private float calcularDensidadExponencial(float marcaClase, float hasta, float desde, float lambda)
        {
            float pExponencial = (hasta - desde) * (lambda * ((float)Math.Exp(-lambda * marcaClase))); ;
            return pExponencial;
        }

        // Factorial para Poisson
        public double factorial(int num)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }
            return num * factorial(num - 1);

        }

        private void btnGenerarHistograma_Click(object sender, EventArgs e)
        {
            histograma1.Show();

        }

        private void txtBox_NrosGenerar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

    }
}
