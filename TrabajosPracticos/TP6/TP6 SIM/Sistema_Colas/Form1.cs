using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Colas
{

    public partial class Form1 : Form
    {
        // Atributos 
        private static Random rand;
        frmTabla frm;
        ArrayList estado_ANTERIOR;
        ArrayList estado_actual;
        //-------------------------------------------------------
        //PARA TP6
        ArrayList estado_actual_PURGA;
        ArrayList estado_ANTERIOR_PURGA;
        //----------------------------------------
        float tiempo_atención;
        float media;
        float mostrar_desde;
        float mostrar_hasta;
        int numero_colum = 0;
        string comparacion;
        int posiciones;
        // UNIFORME --> para la escucha en cabina
        float A;
        float B;

        //lo necesito para el cálculo del reloj
        private int cant_obj;

        // Constructor
        public Form1()
        {
            InitializeComponent();
            rand = new Random();

            txt_min.Enabled = true;
            txt_hs.Enabled = false;
        }

        // Métodos
        private void btn_test_Click(object sender, EventArgs e)
        {
            // seteo de variables de simulación

            A = Convert.ToInt32(txt_unif_medio.Text) - Convert.ToInt32(txt_unifr_mas_menos.Text);
            B = Convert.ToInt32(txt_unif_medio.Text) + Convert.ToInt32(txt_unifr_mas_menos.Text);
            tiempo_atención = float.Parse(txt_t_atencion.Text);
            media = float.Parse(txt_media.Text);

            // seteo variables de tiempo para visualizacion
            mostrar_desde = float.Parse(txt_desde.Text);
            mostrar_hasta = float.Parse(txt_hasta.Text);

            //---------------- Tiempo de simulación ----------------
            // va a servir para el ciclo while

            float tiempo_simulacion_min;
            if (rdb_hs.Checked) tiempo_simulacion_min = 60 * Convert.ToInt32(txt_hs.Text);
            else if (rdb_min.Checked) tiempo_simulacion_min = Convert.ToInt32(txt_min.Text);
            else return;


            //---------------- Inicialización ----------------       
            frm = new frmTabla();
            inicializar();
            
            // El estado actual en la posicion 1 pasa a tomar el valor de vector Purga en 85.1', 116.6',  y demas valores calculados con runge kutta
            // SOLO OCURRE CON SIMULACIONES DE 117 EN ADELANTE
            while ((float)estado_actual[1] < tiempo_simulacion_min)
            {

                if ((string)estado_actual[0] == "Llegada cliente")
                {
                    evento_llegada_cliente();
                    
                }

                else if ((string)estado_actual[0] == "Fin atención C1")
                {
                    evento_fin_atencion_cajero1();
                }

                else if ((string)estado_actual[0] == "Fin atención C2")
                {
                    evento_fin_atencion_cajero2();
                }

                else if ((string)estado_actual[0] == "Fin escucha cabina")
                {
                    evento_fin_escucha_cabina();
                }

                //-----Para la purga del servidor----------------------
                else if ((string)estado_actual[0] == "Fin Purga")
                {
                    evento_fin_purga();
                    
                }

                //------------Inicio de inestabilidad-----------------
                else if ((string)estado_actual[0] == "Inicio inestabilidad")
                {
                    evento_inicio_inestabilidad();

                }
                calcular_tiempos_ociosos();
                calcular_promedio_clientes_que_compraron();
                calcular_promedio_tiempo_en_cola();

                //visualización en dgv
                if ((float)estado_actual[1] >= mostrar_desde && (float)estado_actual[1] < mostrar_hasta)
                {
                    frm.dgv_resultado.Rows.Add();
                    int posiciones = estado_actual.Count - 1;
                    visualizar_vector_estado(0,12,0,0, estado_actual);
                    visualizar_vector_estado(1, 3, 1, 12, estado_actual_PURGA);
                    visualizar_vector_estado(13,13,13,3, estado_actual);
                    visualizar_vector_estado(0, 0, 0, 17, estado_actual_PURGA);
                    visualizar_vector_estado(14, posiciones,14,4, estado_actual);
                }
                estado_ANTERIOR = (ArrayList)estado_actual.Clone();
                estado_ANTERIOR_PURGA = (ArrayList)estado_actual_PURGA.Clone();

                // setear próximo estado
                determinar_proximo_estado_y_reloj();
            }
            visualizar_vector_estado(0, 12, 0, 0, estado_actual);
            visualizar_vector_estado(1, 3, 1, 12, estado_actual_PURGA);
            visualizar_vector_estado(13, 13, 13, 3, estado_actual);
            visualizar_vector_estado(0, 0, 0, 17, estado_actual_PURGA);
            visualizar_vector_estado(14, posiciones, 14, 4, estado_actual);
            frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Orange;
            frm.ShowDialog();
        }


        private void visualizar_vector_estado(int desde, int hasta, int num, int dezpl, ArrayList vector)
        {
            for (int j = num; desde <= j && j <= hasta; j++)
            {
                comparacion = Convert.ToString(vector[j]);
                if (comparacion != "-1" && comparacion != "BORRADO")
                {
                    frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].Cells[j + dezpl].Value = vector[j];

                }
                if (comparacion == "True")
                {
                    if ((frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].Cells[j - 3 + dezpl].Value) != null)
                    {
                        frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].Cells[j + dezpl].Value = "SI";
                        continue;
                    }
                    else
                    {
                        frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].Cells[j + dezpl].Value = " ";
                    }

                }
                if (comparacion == "False")
                {
                    if ((frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].Cells[j - 3 + dezpl].Value) != null)
                    {
                        frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].Cells[j + dezpl].Value = "NO";
                        continue;
                    }
                    else
                    {
                        frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].Cells[j + dezpl].Value = " ";
                    }
                }
            }
        }

        private void determinar_proximo_estado_y_reloj()
        {
            float tiempo_menor;

            // t menor será la próxima llegada
            tiempo_menor = (float)estado_ANTERIOR[4];
            estado_actual[0] = "Llegada cliente";

            if ((float)estado_ANTERIOR[7] != -1 && tiempo_menor > (float)estado_ANTERIOR[7])
            {
                tiempo_menor = (float)estado_ANTERIOR[7];
                estado_actual[0] = "Fin atención C1";
            }
            if ((float)estado_ANTERIOR[8] != -1 && tiempo_menor > (float)estado_ANTERIOR[8])
            {
                tiempo_menor = (float)estado_ANTERIOR[8];
                estado_actual[0] = "Fin atención C2";
            }

            //---------------------------------------------------------------------------------
            // Se agrega para actualizar el proximo estado de inestabilidad y fin de purga
            if ((float)estado_ANTERIOR_PURGA[2] != -1 && tiempo_menor > (float)estado_ANTERIOR_PURGA[2])
            {
                tiempo_menor = (float)estado_ANTERIOR_PURGA[2];
                estado_actual[0] = "Inicio inestabilidad";
            }


            if ((float)estado_ANTERIOR_PURGA[3] != -1 && tiempo_menor > (float)estado_ANTERIOR_PURGA[3])
            {
                tiempo_menor = (float)estado_ANTERIOR_PURGA[3];
                estado_actual[0] = "Fin Purga";
            }
            //---------------------------------------------------------------------------------
            this.cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                if ((float)estado_ANTERIOR[26 + 4 * i] != -1 && tiempo_menor > (float)estado_ANTERIOR[26 + 4 * i])
                {
                    tiempo_menor = (float)estado_ANTERIOR[26 + 4 * i];
                    estado_actual[0] = "Fin escucha cabina";
                }
            }
            estado_actual[1] = tiempo_menor;
        }

        private void calcular_promedio_tiempo_en_cola()
        {
            if ((float)estado_actual[22] == 0)
            {
                estado_actual[23] = 0;
                return;
            }
            estado_actual[23] = (float)estado_actual[21] / (float)estado_actual[22];
        }

        private void calcular_promedio_clientes_que_compraron()
        {
            if (((float)estado_actual[18] + (float)estado_actual[19]) == 0)
            {
                estado_actual[20] = (float)0;
                return;
            }
            estado_actual[20] = (float)estado_actual[19] / ((float)estado_actual[18] + (float)estado_actual[19]);
        }

        //INICIO EVENTOS
        private void evento_llegada_cliente()
        {
            int nroCliente = 1;

            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND
            estado_actual[2] = obtener_random();
            // 3) t entre llegadas
            estado_actual[3] = (float)((-this.media) * Math.Log(1 - (float)estado_actual[2]));
            // 4) calculo próxima llegada
            estado_actual[4] = (float)estado_actual[1] + (float)estado_actual[3];
            // 5) RND
            estado_actual[5] = obtener_random();
            // 6) accion al entrar
            estado_actual[6] = accion_cliente_entrar((float)estado_actual[5]);
            // 7)
            // determinada más abajo según corresponda
            // 8)
            // determinada más abajo según corresponda
            // 9)
            estado_actual[9] = (float)-1;
            // 10)
            estado_actual[10] = Convert.ToString(-1);
            // 11)
            estado_actual[11] = (float)-1;
            // 12)
            estado_actual[12] = Convert.ToString(-1);
            // 13)
            // determinada más abajo según corresponda
            // 14)
            // determinada más abajo según corresponda
            // 15)
            // determinada más abajo según corresponda
            // 16)
            // esta posición la determina otro método
            // 17)
            // esta posición la determina otro método
            // 18) al entrar cliente, suma en 1 el contador
            // más abajo
            // 19)
            // más abajo
            // 20)
            // esta posición la determina otro método
            // 21)
            estado_actual[21] = (float)estado_ANTERIOR[21];
            // 22)
            estado_actual[22] = (float)estado_ANTERIOR[22];
            // 23)
            // esta posición la determina otro método
            this.cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                nroCliente = nroCliente + 1;
                estado_actual[24 + 4 * i] = (string)estado_ANTERIOR[24 + 4 * i];
                estado_actual[25 + 4 * i] = (float)estado_ANTERIOR[25 + 4 * i];
                estado_actual[26 + 4 * i] = (float)estado_ANTERIOR[26 + 4 * i];
                estado_actual[27 + 4 * i] = estado_ANTERIOR[27 + 4 * i];
            }
            //si entra a ver
            if ((string)estado_actual[6] == "Mirar")
            {
                estado_actual[7] = (float)estado_ANTERIOR[7];
                estado_actual[8] = (float)estado_ANTERIOR[8];

                estado_actual[13] = (string)estado_ANTERIOR[13];
                estado_actual[14] = (string)estado_ANTERIOR[14];
                estado_actual[15] = (float)estado_ANTERIOR[15];

                //18) sumo 1 al contador clientes que no compraron
                estado_actual[18] = (float)estado_ANTERIOR[18] + 1;
            }
            //entra a comprar
            else
            {
                int clienteAReutilizar = -1;
                //buscamos si hay cliente BORRADO
                this.cant_obj = (estado_ANTERIOR.Count - 24) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[24 + 4 * i] == (string)"BORRADO")
                    {
                        clienteAReutilizar = i;
                        break;
                    }
                }

                //ambos cajeros ocupados, irá a la cola, asi tambien si el cajero 2 esta ocupado y el 1 esta purgando
                if ((string)estado_ANTERIOR[13] == "Ocupado" && (string)estado_ANTERIOR[14] == "Ocupado" || (string)estado_ANTERIOR[13] == "Purgando" && (string)estado_ANTERIOR[14] == "Ocupado")
                {
                    estado_actual[7] = (float)estado_ANTERIOR[7];
                    estado_actual[8] = (float)estado_ANTERIOR[8];

                    estado_actual[13] = (string)estado_ANTERIOR[13];
                    estado_actual[14] = (string)estado_ANTERIOR[14];
                    estado_actual[15] = (float)estado_ANTERIOR[15] + 1;
                    if (clienteAReutilizar != -1)
                    {
                        estado_actual[24 + 4 * clienteAReutilizar] = (string)"EC";
                        estado_actual[25 + 4 * clienteAReutilizar] = (float)estado_actual[1];
                        estado_actual[26 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //estado
                        estado_actual.Add("EC");
                        //tiempo de llegada a la cola
                        estado_actual.Add((float)estado_actual[1]);
                        //tiempo fin-escucha_cabina --> no corresponde
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }
                }

                //ambos cajeros libres, irá al cajero randomly
                if ((string)estado_ANTERIOR[13] == "Libre" && (string)estado_ANTERIOR[14] == "Libre")
                {
                    float rnd = obtener_random();
                    // irá al cajero 1
                    if (rnd < 0.5)
                    {
                        estado_actual[7] = calcular_fin_atencion();
                        estado_actual[8] = (float)estado_ANTERIOR[8];

                        estado_actual[13] = "Ocupado";
                        estado_actual[14] = (string)estado_ANTERIOR[14];
                        estado_actual[15] = (float)estado_ANTERIOR[15];

                        if (clienteAReutilizar != -1)
                        {
                            estado_actual[24 + 4 * clienteAReutilizar] = (string)"SA C1";
                        }
                        else
                        {
                            //estado
                            estado_actual.Add("SA C1");
                        }
                    }
                    // irá al cajero 2
                    else
                    {
                        estado_actual[7] = (float)estado_ANTERIOR[7];
                        estado_actual[8] = calcular_fin_atencion();

                        estado_actual[13] = (string)estado_ANTERIOR[13];
                        estado_actual[14] = "Ocupado";
                        estado_actual[15] = (float)estado_ANTERIOR[15];

                        if (clienteAReutilizar != -1)
                        {
                            estado_actual[24 + 4 * clienteAReutilizar] = (string)"SA C2";
                        }
                        else
                        {
                            //estado
                            estado_actual.Add("SA C2");
                        }

                    }



                    if (clienteAReutilizar != -1)
                    {
                        estado_actual[25 + 4 * clienteAReutilizar] = (float)-1;
                        estado_actual[26 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //tiempo de llegada a la cola
                        estado_actual.Add((float)-1);
                        //tiempo fin-escucha_cabina --> no corresponde
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }


                }

                // cajero 1 libre cajero 2 ocupado
                if ((string)estado_ANTERIOR[13] == "Libre" && (string)estado_ANTERIOR[14] == "Ocupado")
                {
                    estado_actual[7] = calcular_fin_atencion();
                    estado_actual[8] = (float)estado_ANTERIOR[8];

                    estado_actual[13] = "Ocupado";
                    estado_actual[14] = (string)estado_ANTERIOR[14];
                    estado_actual[15] = (float)estado_ANTERIOR[15];

                    if (clienteAReutilizar != -1)
                    {
                        estado_actual[24 + 4 * clienteAReutilizar] = (string)"SA C1";
                        estado_actual[25 + 4 * clienteAReutilizar] = (float)-1;
                        estado_actual[26 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //estado
                        estado_actual.Add("SA C1");
                        //tiempo de llegada a la cola
                        estado_actual.Add((float)-1);
                        //tiempo fin-escucha_cabina
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }


                }

                // cajero 2 libre cajero 1 ocupado, o si cajero 2 libre y cajero 1 purgando
                if ((string)estado_ANTERIOR[14] == "Libre" && (string)estado_ANTERIOR[13] == "Ocupado" || (string)estado_ANTERIOR[13] == "Purgando" && (string)estado_ANTERIOR[14] == "Libre")
                {
                    estado_actual[7] = (float)estado_ANTERIOR[7];
                    estado_actual[8] = calcular_fin_atencion();


                    estado_actual[13] = (string)estado_ANTERIOR[13];
                    estado_actual[14] = "Ocupado";
                    estado_actual[15] = (float)estado_ANTERIOR[15];

                    if (clienteAReutilizar != -1)
                    {
                        estado_actual[24 + 4 * clienteAReutilizar] = (string)"SA C2";
                        estado_actual[25 + 4 * clienteAReutilizar] = (float)-1;
                        estado_actual[26 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //estado
                        estado_actual.Add("SA C2");
                        //tiempo de llegada a la cola
                        estado_actual.Add((float)-1);
                        //tiempo fin-escucha_cabina --> no corresponde
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }

                }

                //18) mantengo contador clientes que no compraron
                estado_actual[18] = (float)estado_ANTERIOR[18];

                if (clienteAReutilizar != -1)
                {
                    estado_actual[27 + 4 * clienteAReutilizar] = false;
                }
                else
                {
                    //boolean fue a cabina
                    estado_actual.Add(false);
                }
            }


            //19) mantengo el contador clientes que compraron, ya sea si vino a mirar o al cajero
            estado_actual[19] = (float)estado_ANTERIOR[19];

            //seteo vector purga
            setear_vector_purga_eventos();
            
        }

        private void evento_fin_atencion_cajero1()
        {
            // mantengo los objetos si o si deben ir primero, NO mover
            cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                estado_actual[24 + 4 * i] = (string)estado_ANTERIOR[24 + 4 * i];
                estado_actual[25 + 4 * i] = (float)estado_ANTERIOR[25 + 4 * i];
                estado_actual[26 + 4 * i] = (float)estado_ANTERIOR[26 + 4 * i];
                estado_actual[27 + 4 * i] = estado_ANTERIOR[27 + 4 * i];
            }

            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND
            estado_actual[2] = (float)-1;
            // 3) t entre llegadas
            estado_actual[3] = (float)-1;
            // 4) no calculo próxima llegada; mantengo
            estado_actual[4] = (float)estado_ANTERIOR[4];
            // 5) RND
            estado_actual[5] = (float)-1;
            // 6) no calculo accion al entrar --> -1
            estado_actual[6] = Convert.ToString(-1);
            // 7)
            // más abajo
            // 8) mantengo fin de atención de cajero 2
            estado_actual[8] = (float)estado_ANTERIOR[8];
            // 9) RND
            estado_actual[9] = obtener_random();
            // 10) calculo la consulta de esta atención
            // más abajo
            // 11) RND
            estado_actual[11] = (float)-1;
            // 12) no corresponde acción después de cabina
            estado_actual[12] = Convert.ToString(-1);
            // 13)
            // más abajo
            // 14) mantengo estado del cajero 2
            estado_actual[14] = (string)estado_ANTERIOR[14];
            // 15) 
            // más abajo
            // 16)
            // esta posición la determina otro método
            // 17)
            // esta posición la determina otro método
            // 18) mantengo el contador de clientes que no compraron
            estado_actual[18] = (float)estado_ANTERIOR[18];
            // 19) 
            // más abajo
            // 20)
            // esta posición la determina otro método
            // 21)
            // más abajo
            // 22) sumo 1 al contador clientes con atención finalizada
            estado_actual[22] = (float)estado_ANTERIOR[22] + 1;
            // 23)
            // esta posición la determina otro método


            // 10) si el objeto recién atendido pasó por la cabina, si o si comprará, sino, calculo
            cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                if ((string)estado_ANTERIOR[24 + 4 * i] == "SA C1")
                {
                    if ((Boolean)estado_ANTERIOR[27 + 4 * i])
                    {
                        estado_actual[9] = (float)-1;
                        estado_actual[10] = "Compra";
                    }
                    else
                    {
                        estado_actual[10] = calcular_consulta_fin_atencion((float)estado_actual[9]);
                    }
                }
            }

            // dependiendo si hay cola o no, hago lo siguiente:
            // NO HAY COLA
            if ((float)estado_ANTERIOR[15] == 0)
            {
                // no calculo fin_atención
                estado_actual[7] = (float)-1;
                // pasa a libre
                estado_actual[13] = "Libre";
                // cola DEBERÍA seguir en cero
                estado_actual[15] = (float)estado_ANTERIOR[15];

            }
            // HAY COLA
            else
            {
                // calculo fin de atención de la nueva persona que empieza a atender
                estado_actual[7] = calcular_fin_atencion();
                // mantengo, que DEBERÍA ser Ocupado
                estado_actual[13] = (string)estado_ANTERIOR[13];
                // cola disminuye en 1
                estado_actual[15] = (float)estado_ANTERIOR[15] - 1;
                // Cambio el estado del objeto de EC a SA C1
                cant_obj = (estado_ANTERIOR.Count - 24) / 4;
                float min = 0;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((float)estado_ANTERIOR[25 + 4 * i] != -1)
                    {
                        min = (float)estado_ANTERIOR[25 + 4 * i];

                        for (int j = 1; j < cant_obj; j++)
                        {
                            if ((float)estado_ANTERIOR[25 + 4 * j] <= min &&
                            (float)estado_ANTERIOR[25 + 4 * j] != -1)
                            {
                                min = (float)estado_ANTERIOR[25 + 4 * j];
                            }
                        }
                    }
                }

                for (int i = 0; i < cant_obj; i++)
                {
                    if (min == (float)estado_ANTERIOR[25 + 4 * i])
                    {
                        estado_actual[24 + 4 * i] = "SA C1";
                        estado_actual[25 + 4 * i] = (float)-1;
                        //acumulo el tiempo en cola
                        estado_actual[21] = ((float)estado_ANTERIOR[21] + ((float)estado_actual[1] - (float)estado_ANTERIOR[25 + 4 * i]));
                        break;
                    }
                }


            }


            // 19) contador clientes que compraron
            if ((string)estado_actual[10] == "Compra")
            {
                // si compró, sumo 1 en contador
                estado_actual[19] = (float)estado_ANTERIOR[19] + 1;
            }
            else
            {
                // si va a la cabina, mantengo
                estado_actual[19] = (float)estado_ANTERIOR[19];
            }


            // calculo ac tiempo en cola, y la muerte del objeto (si corresponde)
            cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                if ((string)estado_ANTERIOR[24 + 4 * i] == "SA C1")
                {
                    // borro lógicamente el objeto atendido (si corresponde, sino no)
                    if ((string)estado_actual[10] == "Compra")
                    {
                        // se va
                        estado_actual[24 + 4 * i] = "BORRADO";
                        estado_actual[26 + 4 * i] = (float)-1;
                        estado_actual[27 + 4 * i] = false;
                    }
                    else
                    {
                        // va a cabina
                        estado_actual[24 + 4 * i] = "EE";
                        estado_actual[26 + 4 * i] = calcular_tiempo_en_cabina() + (float)estado_actual[1];
                        estado_actual[27 + 4 * i] = true;

                    }

                    estado_actual[25 + 4 * i] = (float)-1;

                    break;

                }
            }
            setear_vector_purga_eventos();
        }

        private void evento_fin_atencion_cajero2()
        {

            // mantengo los objetos, No mover, va primero
            cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                estado_actual[24 + 4 * i] = (string)estado_ANTERIOR[24 + 4 * i];
                estado_actual[25 + 4 * i] = (float)estado_ANTERIOR[25 + 4 * i];
                estado_actual[26 + 4 * i] = (float)estado_ANTERIOR[26 + 4 * i];
                estado_actual[27 + 4 * i] = estado_ANTERIOR[27 + 4 * i];
            }

            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND
            estado_actual[2] = (float)-1;
            // 3) t entre llegadas
            estado_actual[3] = (float)-1;
            // 4) no calculo próxima llegada; mantengo
            estado_actual[4] = (float)estado_ANTERIOR[4];
            // 5) RND
            estado_actual[5] = (float)-1;
            // 6) no calculo accion al entrar --> -1
            estado_actual[6] = Convert.ToString(-1);
            // 7) mantengo fin de atención de cajero 1
            estado_actual[7] = (float)estado_ANTERIOR[7];
            // 8)
            // más abajo
            // 9) RND
            estado_actual[9] = obtener_random();
            // 10) calculo la consulta de esta atención
            // más abajo
            // 11) RND
            estado_actual[11] = (float)-1;
            // 12) no corresponde acción después de cabina
            estado_actual[12] = Convert.ToString(-1);
            // 13) mantengo estado del cajero 1
            estado_actual[13] = (string)estado_ANTERIOR[13];
            // 14)
            // más abajo
            // 15)
            // más abajo
            // 16)
            // esta posición la determina otro método
            // 17)
            // esta posición la determina otro método
            // 18) mantengo el contador de clientes que no compraron
            estado_actual[18] = (float)estado_ANTERIOR[18];
            // 19)
            // más abajo
            // 20)
            // esta posición la determina otro método
            // 21)
            // más abajo
            // 22)sumo 1 al contador clientes con atención finalizada
            estado_actual[22] = (float)estado_ANTERIOR[22] + 1;
            // 23)
            // esta posición la determina otro método

            // 10) si el objeto recién atendido pasó por la cabina, si o si comprará, sino, calculo
            cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                if ((string)estado_ANTERIOR[24 + 4 * i] == "SA C2")
                {
                    if ((Boolean)estado_ANTERIOR[27 + 4 * i])
                    {
                        estado_actual[10] = "Compra";
                    }
                    else
                    {
                        estado_actual[10] = calcular_consulta_fin_atencion((float)estado_actual[9]);
                    }
                }
            }

            // dependiendo si hay cola o no, hago lo siguiente:
            // NO HAY COLA
            if ((float)estado_ANTERIOR[15] == 0)
            {
                // no calculo fin_atención
                estado_actual[8] = (float)-1;
                // pasa a libre
                estado_actual[14] = "Libre";
                // cola DEBERÍA seguir en cero
                estado_actual[15] = (float)estado_ANTERIOR[15];
            }

            // HAY COLA

            else
            {
                // calculo fin de atención de la nueva persona que empieza a atender
                estado_actual[8] = calcular_fin_atencion();
                // mantengo, que DEBERÍA ser Ocupado
                estado_actual[14] = (string)estado_ANTERIOR[14];
                // cola disminuye en 1
                estado_actual[15] = (float)estado_ANTERIOR[15] - 1;
                // Cambio el estado del objeto de EC a SA C2
                cant_obj = (estado_ANTERIOR.Count - 24) / 4;
                float min = 0;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((float)estado_ANTERIOR[25 + 4 * i] != -1)
                    {
                        min = (float)estado_ANTERIOR[25 + 4 * i];

                        for (int j = 1; j < cant_obj; j++)
                        {
                            if ((float)estado_ANTERIOR[25 + 4 * j] <= min &&
                            (float)estado_ANTERIOR[25 + 4 * j] != -1)
                            {
                                min = (float)estado_ANTERIOR[25 + 4 * j];
                            }
                        }
                    }
                }

                for (int i = 0; i < cant_obj; i++)
                {
                    if (min == (float)estado_ANTERIOR[25 + 4 * i])
                    {
                        estado_actual[24 + 4 * i] = "SA C2";
                        estado_actual[25 + 4 * i] = (float)-1;
                        //acumulo el tiempo en cola
                        estado_actual[21] = ((float)estado_ANTERIOR[21] + ((float)estado_actual[1] - (float)estado_ANTERIOR[25 + 4 * i]));
                        break;
                    }
                }

            }

            // contador clientes que compraron
            if ((string)estado_actual[10] == "Compra")
            {
                // si compró, sumo 1 en contador
                estado_actual[19] = (float)estado_ANTERIOR[19] + 1;
            }
            else
            {
                // si va a la cabina, mantengo
                estado_actual[19] = (float)estado_ANTERIOR[19];
            }


            // calculo ac tiempo en cola, y la muerte del objeto (si corresponde)
            cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                if ((string)estado_ANTERIOR[24 + 4 * i] == "SA C2")
                {
                    // borro lógicamente el objeto atendido (si corresponde, sino no)
                    if ((string)estado_actual[10] == "Compra")
                    {
                        // se fue
                        estado_actual[24 + 4 * i] = "BORRADO";
                        estado_actual[26 + 4 * i] = (float)-1;
                        estado_actual[27 + 4 * i] = false;
                    }
                    else
                    {
                        // en cabina
                        estado_actual[24 + 4 * i] = "EE";
                        estado_actual[26 + 4 * i] = calcular_tiempo_en_cabina() + (float)estado_actual[1];
                        estado_actual[27 + 4 * i] = true;

                    }

                    estado_actual[25 + 4 * i] = (float)-1;

                    break;

                }
            }
            setear_vector_purga_eventos();
        }

        private void evento_fin_escucha_cabina()
        {
            // mantengo los objetos
            cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                estado_actual[24 + 4 * i] = (string)estado_ANTERIOR[24 + 4 * i];
                estado_actual[25 + 4 * i] = (float)estado_ANTERIOR[25 + 4 * i];
                estado_actual[26 + 4 * i] = (float)estado_ANTERIOR[26 + 4 * i];
                estado_actual[27 + 4 * i] = estado_ANTERIOR[27 + 4 * i];
            }
            // 2) RND
            estado_actual[2] = (float)-1;
            // 3) t entre llegadas
            estado_actual[3] = (float)-1;
            // no calculo próxima llegada; mantengo
            estado_actual[4] = (float)estado_ANTERIOR[4];

            //RND accion
            estado_actual[5] = (float)-1;
            // no calculo accion al entrar --> -1
            estado_actual[6] = (float)-1;

            // mantengo consulta
            estado_actual[9] = (float)-1;
            estado_actual[10] = Convert.ToString(-1);

            // 18) mantengo el contador de clientes que entraron
            // más abajo
            // 19) mantengo contador clientes q compraron
            estado_actual[19] = (float)estado_ANTERIOR[19];
            // mantengo ac de tiempo en cola
            estado_actual[21] = (float)estado_ANTERIOR[21];
            // mantengo contador cliente fin de atencion
            estado_actual[22] = (float)estado_ANTERIOR[22];


            //RND Cabina
            estado_actual[11] = obtener_random();

            // Validamos RND
            if ((float)estado_actual[11] < (float)0.3)
            {
                // modificamos Accion despues de cabina
                estado_actual[12] = "A pagar en cajero";

                //ambos cajeros ocupados, irá a la cola, o  cajero 1 purgando y cajero 2 ocupado
                if ((string)estado_ANTERIOR[13] == "Ocupado" && (string)estado_ANTERIOR[14] == "Ocupado" || (string)estado_ANTERIOR[13] == "Purgando" && (string)estado_ANTERIOR[14] == "Ocupado")
                {
                    //fin atencion cajeros 1 y 2, se mantienen
                    estado_actual[7] = (float)estado_ANTERIOR[7];
                    estado_actual[8] = (float)estado_ANTERIOR[8];

                    //estados cajeros 1 y 2
                    estado_actual[13] = (string)estado_ANTERIOR[13];
                    estado_actual[14] = (string)estado_ANTERIOR[14];
                    //cola
                    estado_actual[15] = (float)estado_ANTERIOR[15] + 1;

                    //modificamos objeto temporal en escucha
                    cant_obj = (estado_ANTERIOR.Count - 24) / 4;
                    for (int i = 0; i < cant_obj; i++)
                    {
                        if ((float)estado_ANTERIOR[26 + 4 * i] == (float)estado_actual[1])
                        {
                            estado_actual[24 + 4 * i] = "EC";
                            estado_actual[25 + 4 * i] = (float)estado_actual[1];
                            estado_actual[26 + 4 * i] = (float)-1;
                            estado_actual[27 + 4 * i] = true;
                            break;
                        }
                    }
                }
                //ambos cajeros libres, irá al cajero randomly
                if ((string)estado_ANTERIOR[13] == "Libre" && (string)estado_ANTERIOR[14] == "Libre")
                {
                    float rnd = obtener_random();
                    // irá al cajero 1
                    if (rnd < 0.5)
                    {
                        //fin atencion cajeros 1 y 2
                        estado_actual[7] = calcular_fin_atencion();
                        estado_actual[8] = (float)estado_ANTERIOR[8];

                        //estados cajeros 1 y 2
                        estado_actual[13] = "Ocupado";
                        estado_actual[14] = (string)estado_ANTERIOR[14];
                        //cola
                        estado_actual[15] = (float)estado_ANTERIOR[15];

                        //modificamos objeto temporal en escucha
                        cant_obj = (estado_ANTERIOR.Count - 24) / 4;
                        for (int i = 0; i < cant_obj; i++)
                        {
                            if ((float)estado_ANTERIOR[26 + 4 * i] == (float)estado_actual[1])
                            {
                                estado_actual[24 + 4 * i] = "SA C1";
                                estado_actual[25 + 4 * i] = (float)-1;
                                estado_actual[26 + 4 * i] = (float)-1;
                                estado_actual[27 + 4 * i] = true;
                                break;
                            }
                        }
                    }
                    // irá al cajero 2
                    else
                    {
                        //fin atencion cajeros 1 y 2
                        estado_actual[7] = (float)estado_ANTERIOR[7];
                        estado_actual[8] = calcular_fin_atencion();

                        //estados cajeros 1 y 2
                        estado_actual[13] = (string)estado_ANTERIOR[13];
                        estado_actual[14] = "Ocupado";
                        //cola
                        estado_actual[15] = (float)estado_ANTERIOR[15];

                        //modificamos objeto temporal en escucha
                        cant_obj = (estado_ANTERIOR.Count - 24) / 4;
                        for (int i = 0; i < cant_obj; i++)
                        {
                            if ((float)estado_ANTERIOR[26 + 4 * i] == (float)estado_actual[1])
                            {
                                estado_actual[24 + 4 * i] = "SA C2";
                                estado_actual[25 + 4 * i] = (float)-1;
                                estado_actual[26 + 4 * i] = (float)-1;
                                estado_actual[27 + 4 * i] = true;
                                break;
                            }
                        }
                    }
                }
                // cajero 1 libre cajero 2 ocupado
                if ((string)estado_ANTERIOR[13] == "Libre" && (string)estado_ANTERIOR[14] == "Ocupado")
                {
                    //fin atencion cajeros 1 y 2
                    estado_actual[7] = calcular_fin_atencion();
                    estado_actual[8] = (float)estado_ANTERIOR[8];

                    //estados cajeros 1 y 2
                    estado_actual[13] = "Ocupado";
                    estado_actual[14] = (string)estado_ANTERIOR[14];
                    //cola
                    estado_actual[15] = (float)estado_ANTERIOR[15];

                    //modificamos objeto temporal en escucha
                    cant_obj = (estado_ANTERIOR.Count - 24) / 4;
                    for (int i = 0; i < cant_obj; i++)
                    {
                        if ((float)estado_ANTERIOR[26 + 4 * i] == (float)estado_actual[1])
                        {
                            estado_actual[24 + 4 * i] = "SA C1";
                            estado_actual[25 + 4 * i] = (float)-1;
                            estado_actual[26 + 4 * i] = (float)-1;
                            estado_actual[27 + 4 * i] = true;
                            break;
                        }
                    }
                }

                // cajero 2 libre cajero 1 ocupado, o cajero 2 libre cajero 1 purgando
                if ((string)estado_ANTERIOR[14] == "Libre" && (string)estado_ANTERIOR[13] == "Ocupado" || (string)estado_ANTERIOR[13] == "Purgando" && (string)estado_ANTERIOR[14] == "Libre")
                {
                    //fin atencion cajeros 1 y 2
                    estado_actual[8] = calcular_fin_atencion();
                    estado_actual[7] = (float)estado_ANTERIOR[7];

                    //estados cajeros 1 y 2
                    estado_actual[14] = "Ocupado";
                    estado_actual[13] = (string)estado_ANTERIOR[13];
                    //cola
                    estado_actual[15] = (float)estado_ANTERIOR[15];

                    //modificamos objeto temporal en escucha
                    cant_obj = (estado_ANTERIOR.Count - 24) / 4;
                    for (int i = 0; i < cant_obj; i++)
                    {
                        if ((float)estado_ANTERIOR[26 + 4 * i] == (float)estado_actual[1])
                        {
                            estado_actual[24 + 4 * i] = "SA C2";
                            estado_actual[25 + 4 * i] = (float)-1;
                            estado_actual[26 + 4 * i] = (float)-1;
                            estado_actual[27 + 4 * i] = true;
                            break;
                        }
                    }
                }
                // mantengo contador clientes que no compraron
                estado_actual[18] = (float)estado_ANTERIOR[18];
            }
            else
            {
                // muerte del objeto
                cant_obj = (estado_ANTERIOR.Count - 24) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((float)estado_ANTERIOR[26 + 4 * i] == (float)estado_actual[1])
                    {
                        estado_actual[24 + 4 * i] = "BORRADO";
                        estado_actual[25 + 4 * i] = (float)-1;
                        estado_actual[26 + 4 * i] = (float)-1;
                        estado_actual[27 + 4 * i] = true;

                        break;
                    }
                }
                // se mantine igual a la iteracion anterior
                estado_actual[7] = (float)estado_ANTERIOR[7];
                estado_actual[8] = (float)estado_ANTERIOR[8];
                estado_actual[12] = "Se va";
                estado_actual[13] = (string)estado_ANTERIOR[13];
                estado_actual[14] = (string)estado_ANTERIOR[14];
                estado_actual[15] = (float)estado_ANTERIOR[15];

                // al irse, sumo 1 en contador de clientes que no compraron
                estado_actual[18] = (float)estado_ANTERIOR[18] + 1;
            }
            setear_vector_purga_eventos();
        }

        //----Eventos TP 6----
        private void evento_fin_purga()
        {
            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND
            estado_actual[2] = -1;
            // 3) t entre llegadas
            estado_actual[3] = -1;
            // 4) calculo próxima llegada
            estado_actual[4] = (float)estado_ANTERIOR[4];
            // 5) RND
            estado_actual[5] = -1;
            // 6) accion al entrar
            estado_actual[6] = -1;
            // 7) Fin atencion cajero 1
            // Definido en el for de abajo
            // 8) Fin atencion cajero 2
            estado_actual[8] = (float)estado_ANTERIOR[8];
            // 9) RND Consulta
            estado_actual[9] = (float)-1;
            // 10) Consulta
            estado_actual[10] = Convert.ToString(-1);
            // 11) RND Cabina
            estado_actual[11] = (float)-1;
            // 12) Cabina
            estado_actual[12] = Convert.ToString(-1);
            // 13) Estado cajero 1
            // Definido en el for de abajo
            // 14) Estado cajero 2
            estado_actual[14] = (string)estado_ANTERIOR[14];
            // 15) Cola
            estado_actual[15] = (float)estado_ANTERIOR[15];
            // 16)
            estado_actual[16] = (float)estado_ANTERIOR[16];
            // 17)
            estado_actual[17] = (float)estado_ANTERIOR[17];
            // 18) 
            estado_actual[18] = (float)estado_ANTERIOR[18];
            // 19)
            estado_actual[19] = (float)estado_ANTERIOR[19];
            // 20)
            estado_actual[20] = (float)estado_ANTERIOR[20];
            // 21)
            estado_actual[21] = (float)estado_ANTERIOR[21];
            // 22)
            estado_actual[22] = (float)estado_ANTERIOR[22];
            // 23)
            estado_actual[23] = (float)estado_ANTERIOR[23];

            //CONTROL DE OBJETOS TEMPORALES y definicion de 7) fin atencion de cajero 1 y de 13) estado cajero 1
            this.cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                estado_actual[24 + 4 * i] = (string)estado_ANTERIOR[24 + 4 * i];
                estado_actual[25 + 4 * i] = (float)estado_ANTERIOR[25 + 4 * i];
                estado_actual[26 + 4 * i] = (float)estado_ANTERIOR[26 + 4 * i];
                estado_actual[27 + 4 * i] = estado_ANTERIOR[27 + 4 * i];

            }
            // Para ver el 1er objeto que esta en ER
            for (int i = 0; i < cant_obj; i++)
            {
                //Se verfica si hay un cliente esperando reanudación por el cajero 1, entonces pasa al estado "Siendo atendido por cajero 1" SA C1
                if ((string)estado_actual[24 + 4 * i] == "ER")
                {
                    estado_actual[24 + 4 * i] = (string)"SA C1";
                    estado_actual[7] = (float)estado_actual[1] + (float)estado_ANTERIOR_PURGA[0];
                    estado_actual[13] = "Ocupado";
                    break;
                }
                else
                {
                    estado_actual[7] = (float)-1;
                    estado_actual[13] = "Libre";
                }

            }

            //---------------------------------Seteo del vector Purga---------------------------------------------------------
            // 0) Tiempo restante
            estado_actual_PURGA[0] = (float)-1;
            // 1) RND
            estado_actual_PURGA[1] = obtener_random();
            // 2) Inicio inestabilidad
            estado_actual_PURGA[2] = calculo_inestabilidad((float)estado_actual_PURGA[1]) + (float)estado_actual[1];
            // 3) Fin de purga
            estado_actual_PURGA[3] = (float)-1;
        }

        private void evento_inicio_inestabilidad()
        {
            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND
            estado_actual[2] = (float)-1;
            // 3) t entre llegadas
            estado_actual[3] = (float)-1;
            // 4) calculo próxima llegada
            estado_actual[4] = (float)estado_ANTERIOR[4];
            // 5) RND
            estado_actual[5] = (float)-1;
            // 6) accion al entrar
            estado_actual[6] = (float)-1;
            // 7) Fin atencion cajero 1. Lo ponemos en -1 porque se esta purgando
            estado_actual[7] = (float)-1;
            // 8) Fin atencion cajero 2
            estado_actual[8] = (float)estado_ANTERIOR[8];
            // 9)
            estado_actual[9] = (float)-1;
            // 10)
            estado_actual[10] = Convert.ToString(-1);
            // 11)
            estado_actual[11] = (float)-1;
            // 12)
            estado_actual[12] = Convert.ToString(-1);
            // 13) Estado cajero 1
            estado_actual[13] = "Purgando";
            // 14) Estado cajero 2
            estado_actual[14] = estado_ANTERIOR[14];
            // 15) Cola
            estado_actual[15] = (float)estado_ANTERIOR[15];
            // 16)
            estado_actual[16] = (float)estado_ANTERIOR[16];
            // 17)
            estado_actual[17] = (float)estado_ANTERIOR[17];
            // 18)
            estado_actual[18] = (float)estado_ANTERIOR[18];
            // 19)
            estado_actual[19] = (float)estado_ANTERIOR[19];
            // 20)
            estado_actual[20] = (float)estado_ANTERIOR[20];
            // 21)
            estado_actual[21] = (float)estado_ANTERIOR[21];
            // 22)
            estado_actual[22] = (float)estado_ANTERIOR[22];
            // 23)
            estado_actual[23] = (float)estado_ANTERIOR[23];

            //CONTROL DE OBJETOS TEMPORALES
            this.cant_obj = (estado_ANTERIOR.Count - 24) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                estado_actual[24 + 4 * i] = (string)estado_ANTERIOR[24 + 4 * i];
                estado_actual[25 + 4 * i] = (float)estado_ANTERIOR[25 + 4 * i];
                estado_actual[26 + 4 * i] = (float)estado_ANTERIOR[26 + 4 * i];
                estado_actual[27 + 4 * i] = estado_ANTERIOR[27 + 4 * i];

                //Se verfica si hay un cliente siendo atendido por el cajero 1, entonces pasa al estado "Esperando Reanudacion" ER
                if ((string)estado_actual[24 + 4 * i] == "SA C1")
                {
                    estado_actual[24 + 4 * i] = (string)"ER";
                }

            }

            //---------------------------------Seteo del vector Purga---------------------------------------------------------
            // 0) Tiempo restante
            if ((string)estado_ANTERIOR[13] == "Ocupado")
            {
                estado_actual_PURGA[0] = (float)estado_ANTERIOR[7] - (float)estado_actual[1];
            }

            else
            {
                estado_actual_PURGA[0] = (float)-1;
            }
            // 1) RND
            estado_actual_PURGA[1] = (float)-1;
            // 2) Inicio inestabilidad
            estado_actual_PURGA[2] = (float)-1;
            // 3) Fin de purga
            estado_actual_PURGA[3] = (float)(estado_actual[1]) + 20;
        }

        //FIN EVENTOS
        //Calculo de inestabilidad (se pasa el rnd por parametro para poder usar el metodo para calcular el primer momento de inestabilidad y el resto que se calcula con el vector actual
        private float calculo_inestabilidad(float rnd)
        {

            float[,] matriz_Inestabilidad = new float[3, 2];
            matriz_Inestabilidad[0, 0] = (float)74.2;
            matriz_Inestabilidad[0, 1] = (float)0.20;
            matriz_Inestabilidad[1, 0] = (float)85.1;
            matriz_Inestabilidad[1, 1] = (float)0.50;
            matriz_Inestabilidad[2, 0] = (float)96.6;
            matriz_Inestabilidad[2, 1] = (float)1;
            float valor = 0;
            int cantidad_filas = matriz_Inestabilidad.GetLength(0);
            for (int i = 0; i < cantidad_filas; i++)
            {
                if (rnd < matriz_Inestabilidad[i, 1])
                {
                    valor = matriz_Inestabilidad[i, 0];
                    break;
                }
            }
            return valor;
        }

        private void agregarColumnas()
        {
            numero_colum += 1;
            string columna_con_fondo;
            //if ((string)estado_actual[6] == "Ir a cajero")
            //{
                //estado
                frm.dgv_resultado.Columns.Add("estadoCliente" + Convert.ToString(numero_colum) , "Estado Cliente ");

                //legada a cola
                frm.dgv_resultado.Columns.Add("TiempoLLegadaCliente" + Convert.ToString(numero_colum) , "Tiempo Llegada Cola Cliente " );

                columna_con_fondo = "TiempoEscuchaCliente" + Convert.ToString(numero_colum);

                //t escucha cabina
                frm.dgv_resultado.Columns.Add(columna_con_fondo, "Fin Escucha Cliente " );

                frm.dgv_resultado.Columns[columna_con_fondo].DefaultCellStyle.BackColor = Color.Lavender;
                frm.dgv_resultado.Columns[columna_con_fondo].DefaultCellStyle.SelectionBackColor = Color.Black;
                frm.dgv_resultado.Columns[columna_con_fondo].HeaderCell.Style.BackColor = Color.Black;

                //flag cabina
                frm.dgv_resultado.Columns.Add("CabinaFlag" + Convert.ToString(numero_colum), "Fue a cabina " );
            //}
        }

        private void calcular_tiempos_ociosos()
        {
            // cajero 1
            if ((string)estado_ANTERIOR[13] == "Libre")
            {
                //acumula
                estado_actual[16] = (float)estado_actual[1] - (float)estado_ANTERIOR[1] + (float)estado_ANTERIOR[16];
            }
            else
            {
                //mantiene
                estado_actual[16] = (float)estado_ANTERIOR[16];
            }

            // cajero 2
            if ((string)estado_ANTERIOR[14] == "Libre")
            {
                //acumula
                estado_actual[17] = (float)estado_actual[1] - (float)estado_ANTERIOR[1] + (float)estado_ANTERIOR[17];
            }
            else
            {
                //mantiene
                estado_actual[17] = (float)estado_ANTERIOR[17];
            }
        }

        private string calcular_consulta_fin_atencion(float rnd)
        {
            if (rnd < 0.4) return "Compra";
            return "Cabina";
        }

        private string accion_cliente_entrar(float rnd)
        {
            if (rnd < 0.1) return "Mirar";
            if (rnd < 1) return "Ir a cajero";
            else return "ERROR";
        }

        private float calcular_fin_atencion()
        {
            return (float)estado_actual[1] + tiempo_atención;
        }

        private float calcular_tiempo_en_cabina()
        {
            return A + obtener_random() * (B - A);
        }

        private void inicializar()
        {
            frm.dgv_resultado.Rows.Clear();

            estado_ANTERIOR = new ArrayList();

            estado_ANTERIOR_PURGA = new ArrayList();

            // 0) evento
            estado_ANTERIOR.Add("Inicialización");
            // 1) reloj
            estado_ANTERIOR.Add((float)0.00);
            // 2) RND t entre llegadas
            estado_ANTERIOR.Add(obtener_random());
            // 3) t entre llegadas
            estado_ANTERIOR.Add((float)((-this.media) * Math.Log(1 - (float)estado_ANTERIOR[2])));
            // 4) próxima llegada
            estado_ANTERIOR.Add((float)estado_ANTERIOR[1] + (float)estado_ANTERIOR[3]);
            // 5) RND acción 
            estado_ANTERIOR.Add((float)-1);
            // 6) acción al entrar
            estado_ANTERIOR.Add("---");
            // 7) fin atención cajero 1
            estado_ANTERIOR.Add((float)-1);
            // 8) fin atención cajero 2
            estado_ANTERIOR.Add((float)-1);
            // 9) RND consulta 
            estado_ANTERIOR.Add((float)-1);
            // 10) consulta al entrar
            estado_ANTERIOR.Add("---");
            // 11) RND cabina
            estado_ANTERIOR.Add((float)-1);
            // 12) acción después de escuchar
            estado_ANTERIOR.Add("---");
            // 13) estado cajero 1
            estado_ANTERIOR.Add("Libre");
            // 14) estado cajero 2
            estado_ANTERIOR.Add("Libre");
            // 15) cola
            estado_ANTERIOR.Add((float)0);
            // 16) ac t ocio cajero 1
            estado_ANTERIOR.Add((float)0);
            // 17) ac t ocio cajero 2
            estado_ANTERIOR.Add((float)0);
            // 18) contador clientes que entraron
            estado_ANTERIOR.Add((float)0);
            // 19) contador clientes que compraron
            estado_ANTERIOR.Add((float)0);
            // 20) promedio clientes que compraron
            estado_ANTERIOR.Add((float)0);
            // 21) ac tiempo en cola
            estado_ANTERIOR.Add((float)0);
            // 22) contador clientes fin atención
            estado_ANTERIOR.Add((float)0);
            // 23) tiempo promedio en cola
            estado_ANTERIOR.Add((float)0);


            //---------------TP 6----------------------------
            //Nuevo vector
            //Inicialización Lista...
            //0) Tiempo restante de atencion de cajero 1
            estado_ANTERIOR_PURGA.Add((float)-1);
            //1) RND
            estado_ANTERIOR_PURGA.Add((float)obtener_random());

            //2) Inicio de inestabilidad
            estado_ANTERIOR_PURGA.Add((float)calculo_inestabilidad((float)estado_ANTERIOR_PURGA[1]));

            //3) Fin de purga
            estado_ANTERIOR_PURGA.Add((float)-1);

            // Inicialización de la primera fila y visualización
            frm.dgv_resultado.Rows.Add();
            int posiciones = estado_ANTERIOR.Count - 1;
            visualizar_vector_estado(0, 12, 0, 0, estado_ANTERIOR);
            visualizar_vector_estado(1, 3, 1, 12, estado_ANTERIOR_PURGA);
            visualizar_vector_estado(13, 13, 13, 3, estado_ANTERIOR);
            visualizar_vector_estado(0, 0, 0, 17, estado_ANTERIOR_PURGA);
            visualizar_vector_estado(14, posiciones, 14, 4, estado_ANTERIOR);
            frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Orange;
            frm.dgv_resultado.Columns[1].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[4].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[7].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[8].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[20].HeaderCell.Style.BackColor = Color.Red;
            frm.dgv_resultado.Columns[21].HeaderCell.Style.BackColor = Color.Red;
            frm.dgv_resultado.Columns[24].HeaderCell.Style.BackColor = Color.Red;
            frm.dgv_resultado.Columns[27].HeaderCell.Style.BackColor = Color.Red;

            estado_actual = new ArrayList(estado_ANTERIOR);
            estado_actual[0] = "Llegada cliente";
            estado_actual[1] = (float)estado_ANTERIOR[4];

            estado_actual_PURGA = new ArrayList(estado_ANTERIOR_PURGA);

        }

        private static float obtener_random()
        {
            float random = 0;
            random =  (float)(Math.Truncate(rand.NextDouble() * 100) / 100);
            while(random == 0)
            {
                random = (float)(Math.Truncate(rand.NextDouble() * 100) / 100);
            }

            return random;

        }

        private void setear_vector_purga_eventos()
        {
            //si el servidor esta purgando, se mantiene el tiempo restante y el fin de purga, sino, se mantiene el proximo comienzo de inestabilidad unicamente
            this.cant_obj = (estado_ANTERIOR.Count - 24) / 4;

            if ((string)estado_actual[13] == "Purgando")
            {
                // 1) RND
                estado_actual_PURGA[1] = (float)-1;
                // 2) Inicio inestabilidad
                estado_actual_PURGA[2] = (float)-1;
                // 3) Fin de purga
                estado_actual_PURGA[3] = estado_ANTERIOR_PURGA[3];
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_actual[24 + 4 * i] == "ER")
                    {
                        // 0) Tiempo restante
                        estado_actual_PURGA[0] = estado_ANTERIOR_PURGA[0];
                        break;
                    }
                    else
                    {
                        // 0) Tiempo restante
                        estado_actual_PURGA[0] = (float)-1;
                    }
                }
            }
            else
            {
                // 0) Tiempo restante
                estado_actual_PURGA[0] = (float)-1;
                // 1) RND
                estado_actual_PURGA[1] = (float)-1;
                // 2) Inicio inestabilidad
                estado_actual_PURGA[2] = estado_ANTERIOR_PURGA[2];
                // 3) Fin de purga
                estado_actual_PURGA[3] = (float)-1;
            }

        }

        // Métodos interfaz visual
        private void txt_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_hs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_desde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rdb_min_CheckedChanged(object sender, EventArgs e)
        {
            txt_min.Enabled = true;
            txt_hs.Enabled = false;
        }

        private void rdb_hs_CheckedChanged(object sender, EventArgs e)
        {
            txt_min.Enabled = false;
            txt_hs.Enabled = true;
        }
    }
}
