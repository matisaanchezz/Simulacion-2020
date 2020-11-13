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

namespace MonteCarlo2020
{
    public partial class Form1 : Form
    {
        Grafica_MonteCarlo grafica = new Grafica_MonteCarlo();
        public Form1()
        {
            InitializeComponent();
            btn_grafico.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txt_cant.Focus();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            try
            {
                grafica.grafico.Series[0].Points.Clear();
                frm_Test_Montecarlo frm = new frm_Test_Montecarlo();
                frm.dgv.Rows.Clear();
                float stock_inicial = float.Parse(txt_stock_inicial.Text);
                float r_ = float.Parse(txt_R.Text);
                float q_ = float.Parse(txt_Q.Text);
                float km_ = float.Parse(txt_Km.Text);
                float ks_ = float.Parse(txt_Ks.Text);
                float ko_ = float.Parse(txt_Ko.Text);
                int cantidad = Convert.ToInt32(txt_cant.Text);

                float[] estado_anterior = new float[17];
                float[] estado_actual = new float[17];

                estado_anterior[0] = 0;
                estado_anterior[10] = stock_inicial;
                estado_anterior[14] = 0;
                estado_anterior[15] = 0;
                estado_anterior[16] = 0;

                frm.dgv.Rows.Add(estado_anterior[0], "", "", "", "", "", "", "", "", "", estado_anterior[10], "", "", "", estado_anterior[14], estado_anterior[15], estado_anterior[16]);

                string randomDemora;
                string demora;
                string orden;
                string llegadaPedido;
                string rndDañada;

                for (int i = 1; i < cantidad; i++)
                {
                    // ----------------------------- listo -----------------------------
                    //reloj [semanas]
                    estado_actual[0] = i;
                    //RND demanda
                    estado_actual[1] = obtener_random();
                    //Demanda // error
                    estado_actual[2] = calcular_demanda(estado_actual[1]);
                    //RND demora solo se genera un random de demora si es que efectivamente hay una orden/pedido
                    //estado_actual[3] = obtener_random();
                    //Demora
                    //estado_actual[4] = calcular_demora(estado_actual[3]);
                    //Orden / Pedido // primero debo determinar el stock actual para recien determinar si hago una orden/pedido o no
                    //estado_actual[5] = determinarOrden(r_, estado_anterior[6], estado_actual[10], estado_actual[0]);

                    //RND Bici dañada
                    //estado_actual[7] = obtener_random();
                    estado_actual[7] = obtener_random_dañada(estado_anterior[6], estado_actual[0]);
                    rndDañada = es_string(estado_actual[7]);

                    //Bicicleta dañada
                    estado_actual[8] = calcular_bici_dañada(estado_actual[7]);

                    //Disponible
                    estado_actual[9] = determinar_disponibilidad(q_, estado_actual[0], estado_anterior[6], estado_actual[8]);

                    //Ks
                    estado_actual[13] = calcular_ks(ks_, estado_actual[2], estado_actual[9], estado_anterior[10]);

                    //Stock Actual // corregido
                    estado_actual[10] = determinarStock(estado_anterior[10], estado_actual[9], estado_actual[2]);

                    //Orden / Pedido // primero debo determinar el stock actual para recien determinar si hago una orden/pedido o no
                    estado_actual[5] = determinarOrden(r_, estado_anterior[6], estado_actual[10], estado_actual[0]);
                    orden = sino_string(estado_actual[5]);

                    //RND demora
                    estado_actual[3] = rndDemora(estado_actual[5]);
                    randomDemora = es_string(estado_actual[3]);

                    //Demora. Dentro de calcular demora, se hace un if para establecer si el random es -1 no recorre la matriz
                    estado_actual[4] = calcular_demora(estado_actual[3]);
                    demora = es_string(estado_actual[4]);

                    //Llegada pedido
                    estado_actual[6] = determinarLlegadaPedido(estado_actual[5], estado_actual[0], estado_actual[4], estado_anterior[6], estado_actual[9]);
                    llegadaPedido = llegada_string(estado_actual[6]);

                    //Ko
                    estado_actual[11] = calcular_costo_ordenamiento(ko_, estado_actual[5]);

                    //Km
                    estado_actual[12] = km_ * estado_actual[10];

                    //Costo total
                    estado_actual[14] = estado_actual[11] + estado_actual[12] + estado_actual[13];

                    //Costo acumulado                
                    estado_actual[15] = estado_actual[14] + estado_anterior[15];

                    //Costo acumulado promedio 
                    estado_actual[16] = estado_actual[15] / estado_actual[0];
                    estado_actual[16] = (float)(Math.Truncate(estado_actual[16] * 100) / 100);
                    // mostrar fila estado actual iteración
                    //frm.dgv.Rows.Add(estado_actual[0], estado_actual[1], estado_actual[2], estado_actual[3], estado_actual[4], estado_actual[5], estado_actual[6], estado_actual[7], estado_actual[8], estado_actual[9], estado_actual[10], estado_actual[11], estado_actual[12], estado_actual[13], estado_actual[14], estado_actual[15], estado_actual[16]);
                    frm.dgv.Rows.Add(estado_actual[0], estado_actual[1], estado_actual[2], randomDemora, demora, orden, llegadaPedido, rndDañada, estado_actual[8], estado_actual[9], estado_actual[10], estado_actual[11], estado_actual[12], estado_actual[13], estado_actual[14], estado_actual[15], estado_actual[16]);
                    grafica.grafico.Series[0].Points.AddXY(estado_actual[0], estado_actual[16]);
                    estado_anterior = estado_actual;

                }
                frm.ShowDialog();
                btn_grafico.Enabled = true;

            }
            catch
            {
                MessageBox.Show("Debe cargar todos los datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private float calcular_costo_ordenamiento(float ko, float llega_orden)
        {
            float costo;
            if (llega_orden == 1)
            {
                costo = ko;
            }
            else
            {
                costo = 0;
            }
            return costo;
        }

        public float determinarStock(float stockAnterior, float disponible, float demanda)
        {
            if ((stockAnterior + disponible) - demanda > 0)
            {
                return (stockAnterior + disponible) - demanda;
            }
            else
            {
                return 0;
            }
        }

        private float calcular_ks(float ks_, float demanda, float disponible, float stock)
        {
            if (demanda > (disponible + stock)) return ks_ * (demanda - (disponible + stock));
            return 0;
        }

        private float determinar_disponibilidad(float q_, float reloj, float llegada_pedido, float bici_dañada)
        {
            if (reloj == llegada_pedido) return q_ - bici_dañada;
            return 0;
        }

        public float determinarLlegadaPedido(float orden, float reloj, float demora, float llegadaPedido, float disponible)
        {
            if (orden == 1)
            {
                return reloj + demora;
            }
            else
            {
                if (llegadaPedido == 0)
                {
                    return 0;
                }
                else
                {
                    if (disponible > 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return llegadaPedido;
                    }
                }
            }
        }

        private float calcular_bici_dañada(float random)
        {
            if (random == -1)
            {
                return 0;
            }
            else
            {
                float dañada_semana;

                float[,] matriz_dañada = new float[2, 2];
                matriz_dañada[0, 0] = (float)0;
                matriz_dañada[0, 1] = (float)0.70;
                matriz_dañada[1, 0] = (float)1;
                matriz_dañada[1, 1] = (float)1.00;

                dañada_semana = recorrer_matriz(matriz_dañada, random);
                return dañada_semana;
            }
        }

        public float determinarOrden(float r, float llegadaPedido, float stock, float reloj)
        {
            if (stock <= r && (llegadaPedido == 0 || llegadaPedido == reloj))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }


        private static Random rand = new Random();

        private static float obtener_random()
        {
            return (float)(Math.Truncate(rand.NextDouble() * 100) / 100);
        }

        private float calcular_demanda(float random)
        {
            float demanda_semana;

            float[,] matriz_demanda = new float[4, 2];
            matriz_demanda[0, 0] = (float)0;
            matriz_demanda[0, 1] = (float)0.50;
            matriz_demanda[1, 0] = (float)1;
            matriz_demanda[1, 1] = (float)0.65;
            matriz_demanda[2, 0] = (float)2;
            matriz_demanda[2, 1] = (float)0.90;
            matriz_demanda[3, 0] = (float)3;
            matriz_demanda[3, 1] = (float)1.00;

            demanda_semana = recorrer_matriz(matriz_demanda, random);
            return demanda_semana;
        }

        private float recorrer_matriz(float[,] matriz, float random)
        {
            float valor = 0;
            int cantidad_filas = matriz.GetLength(0);
            for (int i = 0; i < cantidad_filas; i++)
            {
                if (random < matriz[i, 1])
                {
                    valor = matriz[i, 0];
                    break;
                }
            }
            return valor;
        }

        private float calcular_demora(float random)
        {
            if (random == -1)
            {
                return random;
            }
            else
            {
                float demora_semana;

                float[,] matriz_demora = new float[3, 2];
                matriz_demora[0, 0] = (float)1;
                matriz_demora[0, 1] = (float)0.30;
                matriz_demora[1, 0] = (float)2;
                matriz_demora[1, 1] = (float)0.70;
                matriz_demora[2, 0] = (float)3;
                matriz_demora[2, 1] = (float)1.00;


                demora_semana = recorrer_matriz(matriz_demora, random);
                return demora_semana;
            }
        }

        // Establezco para saber si invoco o no a la función random según exista o no un pedido
        private float rndDemora(float estadoactual)
        {
            if (estadoactual == 1)
            {
                return obtener_random();
            }
            else
            {
                return -1;
            }
        }

        // Obtiene el random para la bici dañada
        public float obtener_random_dañada(float llegadaPedido, float reloj)
        {
            if (llegadaPedido == reloj)
            {
                return obtener_random();
            }
            else
            {
                return -1;
            }
        }

        // Funcion para printear valores en string
        public string es_string(float estado_actual)
        {
            if (estado_actual == -1)
            {
                return "";
            }
            else
            {
                return estado_actual.ToString();
            }

        }

        // Retorna SI/NO
        public string sino_string(float estado_actual)
        {
            if (estado_actual == 1)
            {
                return "SI";
            }
            else
            {
                return "NO";
            }

        }

        // Para mostrar la llegada de pedido
        public string llegada_string(float estado_actual)
        {
            if (estado_actual == 0)
            {
                return "";
            }
            else
            {
                return estado_actual.ToString();
            }
        }

        private void btn_grafico_Click(object sender, EventArgs e)
        {
            grafica.ShowDialog();

        }

    }
}
