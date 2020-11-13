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

namespace Trabajo_Practico_7
{
    public partial class Form1 : Form
    {
        // Constructor
        public Form1()
        {
            InitializeComponent();
            rand = new Random();

            txt_min.Enabled = true;
            txt_hs.Enabled = false;
        }

        // Atributos 
        private static Random rand;
        frm_Tabla frm;
        ArrayList estado_ANTERIOR;
        ArrayList estado_actual;
        float media;
        float mostrar_desde;
        float mostrar_hasta;
        int numero_colum = 0;
        string comparacion;
        // UNIFORME --> para despensa
        float A_desp;
        float B_desp;
        // UNIFORME --> para panaderia
        float A_panaderia;
        float B_panaderia;
        // NORMAL --> para caja
        float media_caja;
        float desv_caja;

        //lo necesito para el cálculo del reloj
        private int cant_obj;
                        
        // Métodos
        //Simulacion
        private void btn_test_Click(object sender, EventArgs e)
        {
            // seteo de variables de simulación           
            media = float.Parse(txt_media.Text);
            A_desp = float.Parse(txt_A_despensa.Text);
            B_desp = float.Parse(txt_B_despensa.Text);
            A_panaderia = float.Parse(txt_A_panaderia.Text);
            B_panaderia = float.Parse(txt_B_panaderia.Text);
            media_caja =float.Parse(txt_med_medio.Text) - float.Parse(txt_med_mas_menos.Text);
            desv_caja = float.Parse(txt_med_medio.Text) + float.Parse(txt_med_mas_menos.Text);                     

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
            frm = new frm_Tabla();
            inicializar();

            //(float)estado_actual[1] < tiempo_simulacion_min
            //int cont = 0;whilr(cont <= 20)
            while ((float)estado_actual[1] < tiempo_simulacion_min)
            {
                //cont += 1;
                if ((string)estado_actual[0] == "Llegada cliente")
                {
                    evento_llegada_cliente();                    
                }
                
                else if ((string)estado_actual[0] == "Fin despensa")
                {
                    evento_fin_atencion_despensa();
                }

                else if ((string)estado_actual[0] == "Fin atención P1")
                {
                    evento_fin_atencion_panadero1();
                }

                else if ((string)estado_actual[0] == "Fin atención P2")
                {
                    evento_fin_atencion_panadero2();
                }
                else if ((string)estado_actual[0] == "Fin caja")
                {
                    evento_fin_caja();
                }

                // METRICAS
                calcular_tiempos_ociosos();
                calcular_porcentaje();
                calcular_cola_max();
                calcular_promedio_tiempo_en_cola();
                calcular_promedio_permanencia();

                //visualización en dgv
                
                if ((float)estado_actual[1] >= mostrar_desde && (float)estado_actual[1] < mostrar_hasta)
                {
                    frm.dgv_resultado.Rows.Add();
                    int posiciones = estado_actual.Count - 1;
                    for (int j = 0; j <= posiciones; j++)
                    {
                        comparacion = Convert.ToString(estado_actual[j]);
                        if (comparacion != "-1" && comparacion != "BORRADO")
                        {
                            frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].Cells[j].Value = estado_actual[j];
                        }         
                    }
                }

                estado_ANTERIOR = (ArrayList)estado_actual.Clone();

                // setear próximo estado
                determinar_proximo_estado_y_reloj();

            }
            estado_actual = (ArrayList)estado_ANTERIOR.Clone();
            // ultima fila
            frm.dgv_resultado.Rows.Add();
            int posiciones1 = estado_actual.Count - 1;
            for (int j = 0; j <= posiciones1; j++)
            {
                comparacion = Convert.ToString(estado_actual[j]);
                if (comparacion != "-1" && comparacion != "BORRADO")
                {
                    frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].Cells[j].Value = estado_actual[j];
                }                
            }
            frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Orange;
            frm.ShowDialog();

        }
         
        private void determinar_proximo_estado_y_reloj()
        {
            float tiempo_menor;

            // t menor será la próxima llegada
            tiempo_menor = (float)estado_ANTERIOR[4];
            estado_actual[0] = "Llegada cliente";

            if ((float)estado_ANTERIOR[9] != -1 && tiempo_menor > (float)estado_ANTERIOR[9])
            {
                tiempo_menor = (float)estado_ANTERIOR[9];
                estado_actual[0] = "Fin despensa";
            }
            if ((float)estado_ANTERIOR[12] != -1 && tiempo_menor > (float)estado_ANTERIOR[12])
            {
                tiempo_menor = (float)estado_ANTERIOR[12];
                estado_actual[0] = "Fin atención P1";
            }
            if ((float)estado_ANTERIOR[13] != -1 && tiempo_menor > (float)estado_ANTERIOR[13])
            {
                tiempo_menor = (float)estado_ANTERIOR[13];
                estado_actual[0] = "Fin atención P2";
            }
            if ((float)estado_ANTERIOR[30] != -1 && tiempo_menor > (float)estado_ANTERIOR[30])
            {
                tiempo_menor = (float)estado_ANTERIOR[30];
                estado_actual[0] = "Fin caja";
            }
            
            estado_actual[1] = tiempo_menor;
        }
                
        //INICIO EVENTOS
        
        private void evento_llegada_cliente()
        {
            int nroCliente = 1;
            
            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND llegada cliente
            estado_actual[2] = obtener_random();
            // 3) t entre llegadas clientes
            estado_actual[3] = (float)((-this.media) * Math.Log(1 - (float)estado_actual[2]));
            // 4) calculo próxima llegada cliente 
            estado_actual[4] = (float)estado_actual[1] + (float)estado_actual[3];
            // 5) RND Accion, va a despensa o panaderia
            estado_actual[5] = obtener_random();
            // 6) accion al entrar
            estado_actual[6] = accion_cliente_entrar((float)estado_actual[5]);
            // 7),8),9) fin at desp. 
            //Determinado mas abajo segun corresponda
            // 10),11),12),13) fin at panaderia(i). 
            //Determinado mas abajo segun corresponda
            // del 14 al 30 fin caja no se calcula
            estado_actual[14] = (float)-1;
            estado_actual[15] = (float)-1;
            estado_actual[16] = (float)-1;
            estado_actual[17] = (float)-1;
            estado_actual[18] = (float)-1;
            estado_actual[19] = (float)estado_ANTERIOR[19];
            estado_actual[20] = (float)-1;
            estado_actual[21] = (float)-1;
            estado_actual[22] = (float)-1;
            estado_actual[23] = (float)estado_ANTERIOR[23];
            estado_actual[24] = (float)-1;
            estado_actual[25] = (float)-1;
            estado_actual[26] = (float)-1;
            estado_actual[27] = (float)estado_ANTERIOR[27];
            estado_actual[28] = (float)-1;
            estado_actual[29] = (float)-1;
            // 30) se verifica si se mantiene o se setea -1
            //mas abajo

            //OBJETOS TEMPORALES
            // 31 y 32 Despensa. 
            //Se determina mas abajo
            // 33 34 y 35 Panaderia. 
            //Se determina mas abajo
            // 36) estado caja
            estado_actual[36] = (string)estado_ANTERIOR[36];
            // 37) cola caja
            estado_actual[37] = (float)estado_ANTERIOR[37];

            // METRICAS
            // 38) 
            estado_actual[38] = (float)estado_ANTERIOR[38];
            // 39) 
            // Lo determina otro metodo
            // 40) 
            // Lo determina otro metodo
            // 41) cola max
            // Lo determina otro metodo
            // 42) cola max
            // Lo determina otro metodo
            // 43)
            estado_actual[43] = (float)estado_ANTERIOR[43];
            // 44)
            estado_actual[44] = (float)estado_ANTERIOR[44];
            // 45) 
            // Lo determina otro metodo
            // 46) 
            // Lo determina otro metodo
            // 47) 
            // Lo determina otro metodo
            // 48)
            estado_actual[48] = (float)estado_ANTERIOR[48];
            // 49)
            estado_actual[49] = (float)estado_ANTERIOR[49];
            // 50) 
            // Lo determina otro metodo

            //mantengo objetos
            this.cant_obj = (estado_ANTERIOR.Count - 51) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                nroCliente = nroCliente + 1;
                estado_actual[51 + 4 * i] = (string)estado_ANTERIOR[51 + 4 * i];
                estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
            }                                 

            //Accion al entrar
            //si entra a Despensa 
            if ((string)estado_actual[6] == "Despensa")
            {
                int clienteAReutilizar = -1;
                //buscamos si hay cliente BORRADO
                this.cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "BORRADO")
                    {
                        clienteAReutilizar = i;
                        break;
                    }
                }
                //Despensa ocupado, irá a la cola
                if ((string)estado_ANTERIOR[31] == "Ocupado")
                {
                    // mantengo despensa
                    estado_actual[7] = (float)-1;
                    estado_actual[8] = (float)-1;
                    estado_actual[9] = (float)estado_ANTERIOR[9];
                    //mantengo panaderia
                    estado_actual[10] = (float)-1;
                    estado_actual[11] = (float)-1;
                    estado_actual[12] = (float)estado_ANTERIOR[12];
                    estado_actual[13] = (float)estado_ANTERIOR[13];
                    // OBJETOS despensa
                    estado_actual[31] = (string)estado_ANTERIOR[31];
                    // aumento cola despensa
                    estado_actual[32] = (float)estado_ANTERIOR[32] + 1;
                    // OBJETOS panaderia mantengo
                    estado_actual[33] = (string)estado_ANTERIOR[33];
                    estado_actual[34] = (string)estado_ANTERIOR[34];
                    estado_actual[35] = (float)estado_ANTERIOR[35];
                    
                    if (clienteAReutilizar != -1)
                    {
                        estado_actual[51 + 4 * clienteAReutilizar] = "EAD";
                        estado_actual[52 + 4 * clienteAReutilizar] = (float)estado_actual[1];
                        estado_actual[53 + 4 * clienteAReutilizar] = (float)-1;
                        estado_actual[54 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //estado
                        estado_actual.Add("EAD");
                        //tiempo de llegada 
                        estado_actual.Add((float)estado_actual[1]);
                        //tiempo de llegada cola panaderia
                        estado_actual.Add((float)-1);
                        //tiempo de llegada cola Caja
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }
                }

                //Despensa libre
                if ((string)estado_ANTERIOR[31] == "Libre")
                {
                    // Calculo despensa
                    estado_actual[7] = obtener_random();
                    estado_actual[8] = calcular_tiempo_despensa((float)estado_actual[7]);
                    estado_actual[9] = (float)estado_actual[8] + (float)estado_actual[1];
                    //mantengo panaderia
                    estado_actual[10] = (float)-1;
                    estado_actual[11] = (float)-1;
                    estado_actual[12] = (float)estado_ANTERIOR[12];
                    estado_actual[13] = (float)estado_ANTERIOR[13];
                    // OBJETOS despensa
                    estado_actual[31] = "Ocupado";
                    estado_actual[32] = (float)estado_ANTERIOR[32];
                    // OBJETOS panaderia mantengo
                    estado_actual[33] = (string)estado_ANTERIOR[33];
                    estado_actual[34] = (string)estado_ANTERIOR[34];
                    estado_actual[35] = (float)estado_ANTERIOR[35];

                    if (clienteAReutilizar != -1)
                    {
                        estado_actual[51 + 4 * clienteAReutilizar] = "SAD";
                        estado_actual[52 + 4 * clienteAReutilizar] = (float)estado_actual[1];
                        estado_actual[53 + 4 * clienteAReutilizar] = (float)-1;
                        estado_actual[54 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //estado
                        estado_actual.Add("SAD");
                        //tiempo de llegada 
                        estado_actual.Add((float)estado_actual[1]);
                        //tiempo de llegada cola panaderia
                        estado_actual.Add((float)-1);
                        //tiempo de llegada cola Caja
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }
                }
            }
            //entra a Panaderia
            else
            {
                int clienteAReutilizar = -1;
                //buscamos si hay cliente BORRADO
                this.cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "BORRADO")
                    {
                        clienteAReutilizar = i;
                        break;
                    }
                }

                //ambos panaderos ocupados, irá a la cola
                if ((string)estado_ANTERIOR[33] == "Ocupado" && (string)estado_ANTERIOR[34] == "Ocupado")
                {
                    // mantengo despensa
                    estado_actual[7] = (float)-1;
                    estado_actual[8] = (float)-1;
                    estado_actual[9] = (float)estado_ANTERIOR[9];
                    //mantengo panaderia
                    estado_actual[10] = (float)-1;
                    estado_actual[11] = (float)-1;
                    estado_actual[12] = (float)estado_ANTERIOR[12];
                    estado_actual[13] = (float)estado_ANTERIOR[13];
                    // OBJETOS despensa
                    estado_actual[31] = (string)estado_ANTERIOR[31];
                    estado_actual[32] = (float)estado_ANTERIOR[32];
                    // OBJETOS panaderia 
                    estado_actual[33] = (string)estado_ANTERIOR[33];
                    estado_actual[34] = (string)estado_ANTERIOR[34];
                    estado_actual[35] = (float)estado_ANTERIOR[35] + 1;

                    if (clienteAReutilizar != -1)
                    {
                        estado_actual[51 + 4 * clienteAReutilizar] = "EAP";
                        estado_actual[52 + 4 * clienteAReutilizar] = (float)estado_actual[1];
                        estado_actual[53 + 4 * clienteAReutilizar] = (float)estado_actual[1];
                        estado_actual[54 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //estado
                        estado_actual.Add("EAP");
                        //tiempo de llegada 
                        estado_actual.Add((float)estado_actual[1]);
                        //tiempo de llegada cola panaderia
                        estado_actual.Add((float)estado_actual[1]);
                        //tiempo de llegada cola Caja
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }
                }

                //ambos panaderos libres, irá al panadero randomly
                if ((string)estado_ANTERIOR[33] == "Libre" && (string)estado_ANTERIOR[34] == "Libre")
                {
                    float rnd = obtener_random();
                    // irá al panadero 1
                    if (rnd < 0.5)
                    {
                        // mantengo despensa
                        estado_actual[7] = (float)-1;
                        estado_actual[8] = (float)-1;
                        estado_actual[9] = (float)estado_ANTERIOR[9];
                        //calculo panaderia
                        estado_actual[10] = obtener_random();
                        estado_actual[11] = calcular_tiempo_panaderia((float)estado_actual[10]);
                        estado_actual[12] = (float)estado_actual[11] + (float)estado_actual[1];
                        estado_actual[13] = (float)-1;
                        // OBJETOS despensa
                        estado_actual[31] = (string)estado_ANTERIOR[31];
                        estado_actual[32] = (float)estado_ANTERIOR[32];
                        // OBJETOS panaderia 
                        estado_actual[33] = "Ocupado";
                        estado_actual[34] = "Libre";
                        estado_actual[35] = (float)estado_ANTERIOR[32];
                        
                        if (clienteAReutilizar != -1)
                        {                        
                            estado_actual[51 + 4 * clienteAReutilizar] = "SAP(1)";
                        }
                        else
                        {
                            //estado
                            estado_actual.Add("SAP(1)");
                        }
                    }
                    // irá al panadero 2
                    else
                    {
                        // mantengo despensa
                        estado_actual[7] = (float)-1;
                        estado_actual[8] = (float)-1;
                        estado_actual[9] = (float)estado_ANTERIOR[9];
                        //calculo panaderia
                        estado_actual[10] = obtener_random();
                        estado_actual[11] = calcular_tiempo_panaderia((float)estado_actual[10]);
                        estado_actual[12] = (float)-1;
                        estado_actual[13] = (float)estado_actual[11] + (float)estado_actual[1];
                        // OBJETOS despensa
                        estado_actual[31] = (string)estado_ANTERIOR[31];
                        estado_actual[32] = (float)estado_ANTERIOR[32];
                        // OBJETOS panaderia 
                        estado_actual[33] = "Libre";
                        estado_actual[34] = "Ocupado";
                        estado_actual[35] = (float)estado_ANTERIOR[35];

                        if (clienteAReutilizar != -1)
                        {
                            estado_actual[51 + 4 * clienteAReutilizar] = "SAP(2)";
                        }
                        else
                        {
                            //estado
                            estado_actual.Add("SAP(2)");
                        }

                    }
                    if (clienteAReutilizar != -1)
                    {                        
                        estado_actual[52 + 4 * clienteAReutilizar] = (float)estado_actual[1];
                        estado_actual[53 + 4 * clienteAReutilizar] = (float)-1;
                        estado_actual[54 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //tiempo de llegada 
                        estado_actual.Add((float)estado_actual[1]);
                        //tiempo de llegada cola panaderia
                        estado_actual.Add((float)-1);
                        //tiempo de llegada cola Caja
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }
                }

                // panadero 1 libre panadero 2 ocupado
                if ((string)estado_ANTERIOR[33] == "Libre" && (string)estado_ANTERIOR[34] == "Ocupado")
                {
                    // mantengo despensa
                    estado_actual[7] = (float)-1;
                    estado_actual[8] = (float)-1;
                    estado_actual[9] = (float)estado_ANTERIOR[9];
                    //calculo panaderia
                    estado_actual[10] = obtener_random();
                    estado_actual[11] = calcular_tiempo_panaderia((float)estado_actual[10]);
                    estado_actual[12] = (float)estado_actual[11] + (float)estado_actual[1];
                    estado_actual[13] = (float)estado_ANTERIOR[13];
                    // OBJETOS despensa
                    estado_actual[31] = (string)estado_ANTERIOR[31];
                    estado_actual[32] = (float)estado_ANTERIOR[32];
                    // OBJETOS panaderia 
                    estado_actual[33] = "Ocupado";
                    estado_actual[34] = (string)estado_ANTERIOR[34];
                    estado_actual[35] = (float)estado_ANTERIOR[35];

                    if (clienteAReutilizar != -1)
                    {
                        estado_actual[51 + 4 * clienteAReutilizar] = "SAP(1)";
                        estado_actual[52 + 4 * clienteAReutilizar] = (float)estado_actual[1];
                        estado_actual[53 + 4 * clienteAReutilizar] = (float)-1;
                        estado_actual[54 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //estado
                        estado_actual.Add("SAP(1)");
                        //tiempo de llegada 
                        estado_actual.Add((float)estado_actual[1]);
                        //tiempo de llegada cola panaderia
                        estado_actual.Add((float)-1);
                        //tiempo de llegada cola Caja
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }
                }

                // panadero 1 ocupado panadero 2 libre 
                if ((string)estado_ANTERIOR[33] == "Ocupado" && (string)estado_ANTERIOR[34] == "Libre")
                {
                    // mantengo despensa
                    estado_actual[7] = (float)-1;
                    estado_actual[8] = (float)-1;
                    estado_actual[9] = (float)estado_ANTERIOR[9];
                    //calculo panaderia
                    estado_actual[10] = obtener_random();
                    estado_actual[11] = calcular_tiempo_panaderia((float)estado_actual[10]);
                    estado_actual[12] = (float)estado_ANTERIOR[12];
                    estado_actual[13] = (float)estado_actual[11] + (float)estado_actual[1];
                    // OBJETOS despensa
                    estado_actual[31] = (string)estado_ANTERIOR[31];
                    estado_actual[32] = (float)estado_ANTERIOR[32];
                    // OBJETOS panaderia 
                    estado_actual[33] = (string)estado_ANTERIOR[33];
                    estado_actual[34] = "Ocupado";
                    estado_actual[35] = (float)estado_ANTERIOR[35];

                    if (clienteAReutilizar != -1)
                    {
                        estado_actual[51 + 4 * clienteAReutilizar] = "SAP(2)";
                        estado_actual[52 + 4 * clienteAReutilizar] = (float)estado_actual[1];
                        estado_actual[53 + 4 * clienteAReutilizar] = (float)-1;
                        estado_actual[54 + 4 * clienteAReutilizar] = (float)-1;
                    }
                    else
                    {
                        //estado
                        estado_actual.Add("SAP(2)");
                        //tiempo de llegada 
                        estado_actual.Add((float)estado_actual[1]);
                        //tiempo de llegada cola panaderia
                        estado_actual.Add((float)-1);
                        //tiempo de llegada cola Caja
                        estado_actual.Add((float)-1);
                        agregarColumnas();
                    }
                }

            }           
            
            //30) verificamos si mantenemos o seteamos -1
            if ((string)estado_ANTERIOR[36] == "Ocupado")
            {
                estado_actual[30] = (float)estado_ANTERIOR[30];
            }
            else
            {
                estado_actual[30] = (float)-1;
            }
        }                
        
        private void evento_fin_atencion_despensa()
        {
            //mantengo objetos
            cant_obj = (estado_ANTERIOR.Count - 51) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                estado_actual[51 + 4 * i] = (string)estado_ANTERIOR[51 + 4 * i];
                estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
            }

            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND llegada cliente
            estado_actual[2] = (float)-1;
            // 3) t entre llegadas clientes
            estado_actual[3] = (float)-1;
            // 4) llegada cliente 
            estado_actual[4] = (float)estado_ANTERIOR[4];
            // 5) RND Accion, va a despensa o panaderia
            estado_actual[5] = (float)-1;
            // 6) accion al entrar
            estado_actual[6] = Convert.ToString(-1);
            // 7),8),9) fin at desp. 
            //Determinado mas abajo segun corresponda
            // 10) RND
            estado_actual[10] = (float)-1;
            //11) t atencion
            estado_actual[11] = (float)-1;
            //12) fin 1
            estado_actual[12] = (float)estado_ANTERIOR[12];
            //13) fin 2
            estado_actual[13] = (float)estado_ANTERIOR[13];
            // del 14 al 30 fin caja             
            //Determinado mas abajo segun corresponda

            //OBJETOS TEMPORALES
            // 31 y 32 Despensa. 
            //Se determina mas abajo
            // 33) estado pan
            estado_actual[33] = (string)estado_ANTERIOR[33];
            //34) estado pan
            estado_actual[34] = (string)estado_ANTERIOR[34];
            //35) cola pan
            estado_actual[35] = (float)estado_ANTERIOR[35];
            // 36) estado caja
            //Se determina mas abajo
            // 37) cola caja
            //Se determina mas abajo

            // METRICAS
            // 38) 
            // se determina mas abajo 
            // 39) 
            // Lo determina otro metodo
            // 40) 
            // Lo determina otro metodo
            // 41) cola max
            // Lo determina otro metodo
            // 42) cola max
            // Lo determina otro metodo
            // 43)
            estado_actual[43] = (float)estado_ANTERIOR[43];
            // 44)
            estado_actual[44] = (float)estado_ANTERIOR[44];
            // 45) 
            // Lo determina otro metodo
            // 46) 
            // Lo determina otro metodo
            // 47) 
            // Lo determina otro metodo
            // 48)
            estado_actual[48] = (float)estado_ANTERIOR[48];
            // 49)
            estado_actual[49] = (float)estado_ANTERIOR[49];
            // 50) 
            // Lo determina otro metodo
                        
            
            // 7),8),9) El servidor termina con un cliente, ahora mira la cola para saber q hacer
            // NO HAY COLA EN DESPENSA
            if ((float)estado_ANTERIOR[32] == 0)
            {
                // no calculo fin despensa
                estado_actual[7] = (float)-1;
                estado_actual[8] = (float)-1;
                estado_actual[9] = (float)-1;
                // pasa a libre
                estado_actual[31] = "Libre";
                // cola DEBERÍA seguir en cero
                estado_actual[32] = (float)estado_ANTERIOR[32];                
            }
            // HAY COLA
            else
            {
                // calculo fin despensa de la nueva persona que empieza a atender
                estado_actual[7] = obtener_random();
                estado_actual[8] = calcular_tiempo_despensa((float)estado_actual[7]);
                estado_actual[9] = (float)estado_actual[8] + (float)estado_actual[1];
                // mantengo, que DEBERÍA ser Ocupado
                estado_actual[31] = (string)estado_ANTERIOR[31];
                // cola disminuye en 1
                estado_actual[32] = (float)estado_ANTERIOR[32] - 1;

                // Cambio el estado del objeto de EAD a SAD
                /*
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "EAD")
                    {
                        estado_actual[51 + 4 * i] = "SAD";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                        estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
                        break;
                    }
                }*/

                //--------------------------------
                float min = 0;
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                //Busco el primer objeto que ingreso a cola
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "EAD")
                    {
                        min = (float)estado_ANTERIOR[52 + 4 * i]; // hs ingreso al sistema
                        for (int j = 1; j < cant_obj; j++)
                        {
                            if ((float)estado_ANTERIOR[52 + 4 * j] < min && (string)estado_ANTERIOR[51 + 4 * j] == "EAD")
                            {
                                min = (float)estado_ANTERIOR[52 + 4 * j];
                            }
                        }
                        break;
                    }
                }
                // cambio de estado al primer objeto EAD que ingreso a cola
                for (int i = 0; i < cant_obj; i++)
                {
                    if (min == (float)estado_ANTERIOR[52 + 4 * i])
                    {
                        estado_actual[51 + 4 * i] = "SAD";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                        estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
                        break;
                    }
                }

                //------------------------
            }

            // Del 14 al 30 Fin caja. cliente mira estado servidor
            // Dependiendo si esta ocupada la CAJA
            // CAJA OCUPADA --> va a cola 
            if ((string)estado_ANTERIOR[36] == "Ocupado")
            {
                // no calculo fin caja
                estado_actual[14] = (float)-1;
                estado_actual[15] = (float)-1;
                estado_actual[16] = (float)-1;
                estado_actual[17] = (float)-1;
                estado_actual[18] = (float)-1;
                estado_actual[19] = (float)estado_ANTERIOR[19];
                estado_actual[20] = (float)-1;
                estado_actual[21] = (float)-1;
                estado_actual[22] = (float)-1;
                estado_actual[23] = (float)estado_ANTERIOR[23];
                estado_actual[24] = (float)-1;
                estado_actual[25] = (float)-1;
                estado_actual[26] = (float)-1;
                estado_actual[27] = (float)estado_ANTERIOR[27];
                estado_actual[28] = (float)-1;
                estado_actual[29] = (float)-1;
                estado_actual[30] = (float)estado_ANTERIOR[30];
                // servidor caja sigue Ocupado
                estado_actual[36] = (string)estado_ANTERIOR[36];
                // cola aumenta
                estado_actual[37] = (float)estado_ANTERIOR[37] + 1;

                //38) AC sigue igual
                estado_actual[38] = (float)estado_ANTERIOR[38];

                // Cambio el estado del objeto de SAD a EAC, seteo hs ingreso a cola
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "SAD")
                    {
                        estado_actual[51 + 4 * i] = "EAC";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                        // seteo hora de ingreso a cola caja
                        estado_actual[54 + 4 * i] = (float)estado_actual[1];
                        break;
                    }
                }
            }
            // CAJA DESOCUPADA --> calculamos fin caja
            else
            {
                // calculamos fin caja
                estado_actual[14] = obtener_random();
                estado_actual[15] = calcular_articulos((float)estado_actual[14]);
                // del 16 al 28
                calcular_tiempo_articulo((float)estado_actual[15]);
                //29)
                calcular_tiempo_embolsado((float)estado_actual[15]);
                //30)
                estado_actual[30] = (float)estado_actual[28] + (float)estado_actual[29] + (float)estado_actual[1];
                // Servidor caja
                estado_actual[36] = "Ocupado";
                estado_actual[37] = (float)estado_ANTERIOR[37];

                //38) aumenta AC
                estado_actual[38] = (float)estado_actual[15] + (float)estado_ANTERIOR[38];

                // Cambio el estado del objeto de SAD a SAC
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "SAD")
                    {
                        estado_actual[51 + 4 * i] = "SAC";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                        estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
                        break;
                    }
                }
            }
                        
        }
        
        private void evento_fin_atencion_panadero1()
        {
            //mantengo objetos
            cant_obj = (estado_ANTERIOR.Count - 51) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                estado_actual[51 + 4 * i] = (string)estado_ANTERIOR[51 + 4 * i];
                estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
            }

            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND llegada cliente
            estado_actual[2] = (float)-1;
            // 3) t entre llegadas clientes
            estado_actual[3] = (float)-1;
            // 4) llegada cliente 
            estado_actual[4] = (float)estado_ANTERIOR[4];
            // 5) RND Accion, va a despensa o panaderia
            estado_actual[5] = (float)-1;
            // 6) accion al entrar
            estado_actual[6] = Convert.ToString(-1);
            // 7) RND
            estado_actual[7] = (float)-1;
            // 8) t atencion
            estado_actual[8] = (float)-1;
            // 9) fin despensa
            estado_actual[9] = (float)estado_ANTERIOR[9];
            // 10), 11), 12) fin Panaderia 1
            estado_actual[13] = (float)estado_ANTERIOR[13];
            //Determinado mas abajo segun corresponda
            // del 14 al 30 fin caja             
            //Determinado mas abajo segun corresponda

            //OBJETOS TEMPORALES
            // 31) estado desp
            estado_actual[31] = (string)estado_ANTERIOR[31];
            // 32) cola Despensa. 
            estado_actual[32] = (float)estado_ANTERIOR[32];
            // 33), 35 Panaderia
            // 34) Estado Panaderia 2 (mantiene, no se usa)
            estado_actual[34] = (string)estado_ANTERIOR[34];
            //Se determina mas abajo            
            // 36) 37) caja
            //Se determina mas abajo

            // METRICAS
            // 38) 
            // se determina mas abajo 
            // 39) 
            // Lo determina otro metodo
            // 40) 
            // Lo determina otro metodo
            // 41) cola max
            // Lo determina otro metodo
            // 42) cola max
            // Lo determina otro metodo
            // 43)
            //Se determina mas abajo
            // 44)
            estado_actual[44] = (float)estado_ANTERIOR[44] + 1;
            // 45) 
            // Lo determina otro metodo
            // 46) 
            // Lo determina otro metodo
            // 47) 
            // Lo determina otro metodo
            // 48)
            estado_actual[48] = (float)estado_ANTERIOR[48];
            // 49)
            estado_actual[49] = (float)estado_ANTERIOR[49];
            // 50) 
            // Lo determina otro metodo
            

            // 10, 11, 12 dependiendo si hay cola o no en PANADERIA xq termino con un cliente, mira cola
            // NO HAY COLA EN PANADERIA 
            if ((float)estado_ANTERIOR[35] == 0)
            {
                // no calculo fin panaderia 1
                estado_actual[10] = (float)-1;
                estado_actual[11] = (float)-1;
                estado_actual[12] = (float)-1;
                // pasa a libre P1 
                estado_actual[33] = "Libre";
                // cola DEBERÍA seguir en cero
                estado_actual[35] = (float)estado_ANTERIOR[35];

                //43
                estado_actual[43] = (float)estado_ANTERIOR[43];
                
            }
            // HAY COLA EN PANADERIA --> calculamos fin panaderia 1
            else
            {
                // calculo fin panaderia 1 de la nueva persona que empieza a atender
                estado_actual[10] = obtener_random();
                estado_actual[11] = calcular_tiempo_panaderia((float)estado_actual[10]);
                estado_actual[12] = (float)estado_actual[11] + (float)estado_actual[1];
                // mantengo estado Panaderia 1, que DEBERÍA ser Ocupado
                estado_actual[33] = (string)estado_ANTERIOR[33];
                // cola disminuye en 1
                estado_actual[35] = (float)estado_ANTERIOR[35] - 1;
                
                // Cambio el estado del objeto de EAP a SAP(1)
                /*
                cant_obj = (estado_ANTERIOR.Count - 51) / 3;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 3 * i] == "EAP")
                    {
                        estado_actual[51 + 3 * i] = "SAP(1)";
                        estado_actual[52 + 3 * i] = (float)estado_ANTERIOR[52 + 3 * i];
                        estado_actual[53 + 3 * i] = (float)-1;
                        // Acumulo tiempo de espera en cola panaderia 43)
                        estado_actual[43] = (((float)estado_actual[1] - (float)estado_ANTERIOR[53 + 3 * i]) + (float)estado_ANTERIOR[43]);
                        break;
                    }
                }*/
                //------------------------------
                float min = 0;
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                //Busco el primer objeto que ingreso a cola
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "EAP")
                    {
                        min = (float)estado_ANTERIOR[52 + 4 * i]; // hs ingreso al sistema
                        for (int j = 1; j < cant_obj; j++)
                        {
                            if ((float)estado_ANTERIOR[52 + 4 * j] < min && (string)estado_ANTERIOR[51 + 4 * j] == "EAP")
                            {
                                min = (float)estado_ANTERIOR[52 + 4 * j];
                            }
                        }
                        break;
                    }
                }
                // cambio de estado al primer objeto EAP que ingreso a cola
                for (int i = 0; i < cant_obj; i++)
                {
                    if (min == (float)estado_ANTERIOR[52 + 4 * i])
                    {
                        estado_actual[51 + 4 * i] = "SAP(1)";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)-1;
                        estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
                        // Acumulo tiempo de espera en cola panaderia 43)
                        estado_actual[43] = (((float)estado_actual[1] - (float)estado_ANTERIOR[53 + 4 * i]) + (float)estado_ANTERIOR[43]);
                        break;
                    }
                }
                //---------------------------------------
            }

            // Del 14 al 30 Fin caja. cliente mira estado servidor
            // Dependiendo si esta ocupada la CAJA
            // CAJA OCUPADA --> va a cola 
            if ((string)estado_ANTERIOR[36] == "Ocupado")
            {
                // no calculo fin caja
                estado_actual[14] = (float)-1;
                estado_actual[15] = (float)-1;
                estado_actual[16] = (float)-1;
                estado_actual[17] = (float)-1;
                estado_actual[18] = (float)-1;
                estado_actual[19] = (float)estado_ANTERIOR[19];
                estado_actual[20] = (float)-1;
                estado_actual[21] = (float)-1;
                estado_actual[22] = (float)-1;
                estado_actual[23] = (float)estado_ANTERIOR[23];
                estado_actual[24] = (float)-1;
                estado_actual[25] = (float)-1;
                estado_actual[26] = (float)-1;
                estado_actual[27] = (float)estado_ANTERIOR[27];
                estado_actual[28] = (float)-1;
                estado_actual[29] = (float)-1;
                estado_actual[30] = (float)estado_ANTERIOR[30];
                // servidor caja sigue Ocupado
                estado_actual[36] = (string)estado_ANTERIOR[36];
                // cola aumenta
                estado_actual[37] = (float)estado_ANTERIOR[37] + 1;

                //38) AC sigue igual
                estado_actual[38] = (float)estado_ANTERIOR[38];

                // Cambio el estado del objeto de SAP(1) a EAC
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "SAP(1)")
                    {
                        estado_actual[51 + 4 * i] = "EAC";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                        estado_actual[54 + 4 * i] = (float)estado_actual[1];
                        break;
                    }
                }
            }
            // CAJA DESOCUPADA --> calculamos fin caja
            else
            {
                // calculamos fin caja
                estado_actual[14] = obtener_random();
                estado_actual[15] = calcular_articulos((float)estado_actual[14]);
                // del 16 al 28
                calcular_tiempo_articulo((float)estado_actual[15]);
                //29)
                calcular_tiempo_embolsado((float)estado_actual[15]);
                //30)
                estado_actual[30] = (float)estado_actual[28] + (float)estado_actual[29] + (float)estado_actual[1];
                // Servidor caja
                estado_actual[36] = "Ocupado";
                estado_actual[37] = (float)estado_ANTERIOR[37];

                //38) aumenta AC
                estado_actual[38] = (float)estado_actual[15] + (float)estado_ANTERIOR[38];

                // Cambio el estado del objeto de SAP(1) a SAC
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "SAP(1)")
                    {
                        estado_actual[51 + 4 * i] = "SAC";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                        estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
                        break;
                    }
                }
            }

        }
        
        private void evento_fin_atencion_panadero2()
        {
            //mantengo objetos
            cant_obj = (estado_ANTERIOR.Count - 51) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                estado_actual[51 + 4 * i] = (string)estado_ANTERIOR[51 + 4 * i];
                estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
            }

            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND llegada cliente
            estado_actual[2] = (float)-1;
            // 3) t entre llegadas clientes
            estado_actual[3] = (float)-1;
            // 4) llegada cliente 
            estado_actual[4] = (float)estado_ANTERIOR[4];
            // 5) RND Accion, va a despensa o panaderia
            estado_actual[5] = (float)-1;
            // 6) accion al entrar
            estado_actual[6] = Convert.ToString(-1);
            // 7) RND
            estado_actual[7] = (float)-1;
            // 8) t atencion
            estado_actual[8] = (float)-1;
            // 9) fin despensa
            estado_actual[9] = (float)estado_ANTERIOR[9];
            // 10), 11), 13) fin Panaderia 2
            // 12) fin panaderia 1
            estado_actual[12] = (float)estado_ANTERIOR[12];
            //Determinado mas abajo segun corresponda
            // del 14 al 30 fin caja             
            //Determinado mas abajo segun corresponda

            //OBJETOS TEMPORALES
            // 31) estado desp
            estado_actual[31] = (string)estado_ANTERIOR[31];
            // 32) cola Despensa. 
            estado_actual[32] = (float)estado_ANTERIOR[32];
            // 34), 35 Panaderia
            // 33) Estado Panaderia 1 (mantiene, no se usa)
            estado_actual[33] = (string)estado_ANTERIOR[33];
            //Se determina mas abajo            
            // 36) 37) caja
            //Se determina mas abajo

            // METRICAS
            // 38) 
            // se determina mas abajo 
            // 39) 
            // Lo determina otro metodo
            // 40) 
            // Lo determina otro metodo
            // 41) cola max
            // Lo determina otro metodo
            // 42) cola max
            // Lo determina otro metodo
            // 43)
            //Se determina mas abajo
            // 44)
            estado_actual[44] = (float)estado_ANTERIOR[44] + 1;
            // 45) 
            // Lo determina otro metodo
            // 46) 
            // Lo determina otro metodo
            // 47) 
            // Lo determina otro metodo
            // 48)
            estado_actual[48] = (float)estado_ANTERIOR[48];
            // 49)
            estado_actual[49] = (float)estado_ANTERIOR[49];
            // 50) 
            // Lo determina otro metodo


            // 10, 11, 13 dependiendo si hay cola o no en PANADERIA xq termino con un cliente, mira cola
            // NO HAY COLA EN PANADERIA 
            if ((float)estado_ANTERIOR[35] == 0)
            {
                // no calculo fin panaderia 2
                estado_actual[10] = (float)-1;
                estado_actual[11] = (float)-1;
                estado_actual[13] = (float)-1;
                // pasa a libre P2
                estado_actual[34] = "Libre";
                // cola DEBERÍA seguir en cero
                estado_actual[35] = (float)estado_ANTERIOR[35];

                //43
                estado_actual[43] = (float)estado_ANTERIOR[43];

            }
            // HAY COLA EN PANADERIA --> calculamos fin panaderia 2
            else
            {
                // calculo fin panaderia 2 de la nueva persona que empieza a atender
                estado_actual[10] = obtener_random();
                estado_actual[11] = calcular_tiempo_panaderia((float)estado_actual[10]);
                estado_actual[13] = (float)estado_actual[11] + (float)estado_actual[1];
                // mantengo estado Panaderia 2, que DEBERÍA ser Ocupado
                estado_actual[34] = (string)estado_ANTERIOR[34];
                // cola disminuye en 1
                estado_actual[35] = (float)estado_ANTERIOR[35] - 1;

                // Cambio el estado del objeto de EAP a SAP(2)
                /*
                cant_obj = (estado_ANTERIOR.Count - 51) / 3;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 3 * i] == "EAP")
                    {
                        estado_actual[51 + 3 * i] = "SAP(2)";
                        estado_actual[52 + 3 * i] = (float)estado_ANTERIOR[52 + 3 * i];
                        estado_actual[53 + 3 * i] = (float)-1;
                        // Acumulo tiempo de espera en cola panaderia 43)
                        estado_actual[43] = (((float)estado_actual[1] - (float)estado_ANTERIOR[53 + 3 * i]) + (float)estado_ANTERIOR[43]);
                        break;
                    }
                }*/
                //------------------------------------------
                float min = 0;
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                //Busco el primer objeto que ingreso a cola
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "EAP")
                    {
                        min = (float)estado_ANTERIOR[52 + 4 * i]; // hs ingreso al sistema
                        for (int j = 1; j < cant_obj; j++)
                        {
                            if ((float)estado_ANTERIOR[52 + 4 * j] < min && (string)estado_ANTERIOR[51 + 4 * j] == "EAP")
                            {
                                min = (float)estado_ANTERIOR[52 + 4 * j];
                            }
                        }
                        break;
                    }
                }
                // cambio de estado al primer objeto EAP que ingreso a cola
                for (int i = 0; i < cant_obj; i++)
                {
                    if (min == (float)estado_ANTERIOR[52 + 4 * i])
                    {
                        estado_actual[51 + 4 * i] = "SAP(2)";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)-1;
                        estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
                        // Acumulo tiempo de espera en cola panaderia 43)
                        estado_actual[43] = (((float)estado_actual[1] - (float)estado_ANTERIOR[53 + 4 * i]) + (float)estado_ANTERIOR[43]);
                        break;
                    }
                }
                //---------------------------------------
            }

            // Del 14 al 30 Fin caja. cliente mira estado servidor
            // Dependiendo si esta ocupada la CAJA
            // CAJA OCUPADA --> va a cola 
            if ((string)estado_ANTERIOR[36] == "Ocupado")
            {
                // no calculo fin caja
                estado_actual[14] = (float)-1;
                estado_actual[15] = (float)-1;
                estado_actual[16] = (float)-1;
                estado_actual[17] = (float)-1;
                estado_actual[18] = (float)-1;
                estado_actual[19] = (float)estado_ANTERIOR[19];
                estado_actual[20] = (float)-1;
                estado_actual[21] = (float)-1;
                estado_actual[22] = (float)-1;
                estado_actual[23] = (float)estado_ANTERIOR[23];
                estado_actual[24] = (float)-1;
                estado_actual[25] = (float)-1;
                estado_actual[26] = (float)-1;
                estado_actual[27] = (float)estado_ANTERIOR[27];
                estado_actual[28] = (float)-1;
                estado_actual[29] = (float)-1;
                estado_actual[30] = (float)estado_ANTERIOR[30];
                // servidor caja sigue Ocupado
                estado_actual[36] = (string)estado_ANTERIOR[36];
                // cola aumenta
                estado_actual[37] = (float)estado_ANTERIOR[37] + 1;

                //38) AC sigue igual
                estado_actual[38] = (float)estado_ANTERIOR[38];

                // Cambio el estado del objeto de SAP(2) a EAC
                
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "SAP(2)")
                    {
                        estado_actual[51 + 4 * i] = "EAC";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                        estado_actual[54 + 4 * i] = (float)estado_actual[1];
                        break;
                    }
                }
            }
            // CAJA DESOCUPADA --> calculamos fin caja
            else
            {
                // calculamos fin caja
                estado_actual[14] = obtener_random();
                estado_actual[15] = calcular_articulos((float)estado_actual[14]);
                // del 16 al 28
                calcular_tiempo_articulo((float)estado_actual[15]);
                //29)
                calcular_tiempo_embolsado((float)estado_actual[15]);
                //30)
                estado_actual[30] = ((float)estado_actual[28] + (float)estado_actual[29] + (float)estado_actual[1]);
                // Servidor caja
                estado_actual[36] = "Ocupado";
                estado_actual[37] = (float)estado_ANTERIOR[37];

                //38) aumenta AC
                estado_actual[38] = (float)estado_actual[15] + (float)estado_ANTERIOR[38];

                // Cambio el estado del objeto de SAP(2) a SAC
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "SAP(2)")
                    {
                        estado_actual[51 + 4 * i] = "SAC";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                        estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
                        break;
                    }
                }
            }

        }
        
        private void evento_fin_caja()
        {
            //mantengo objetos
            cant_obj = (estado_ANTERIOR.Count - 51) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                estado_actual[51 + 4 * i] = (string)estado_ANTERIOR[51 + 4 * i];
                estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                estado_actual[53 + 4 * i] = (float)estado_ANTERIOR[53 + 4 * i];
                estado_actual[54 + 4 * i] = (float)estado_ANTERIOR[54 + 4 * i];
            }

            // 0) evento
            // esta posición la determina otro método
            // 1) reloj
            // esta posición la determina otro método
            // 2) RND llegada cliente
            estado_actual[2] = (float)-1;
            // 3) t entre llegadas clientes
            estado_actual[3] = (float)-1;
            // 4) llegada cliente 
            estado_actual[4] = (float)estado_ANTERIOR[4];
            // 5) RND Accion, va a despensa o panaderia
            estado_actual[5] = (float)-1;
            // 6) accion al entrar
            estado_actual[6] = Convert.ToString(-1);
            // 7) RND
            estado_actual[7] = (float)-1;
            // 8) t atencion
            estado_actual[8] = (float)-1;
            // 9) fin despensa
            estado_actual[9] = (float)estado_ANTERIOR[9];
            // 10) RND
            estado_actual[10] = (float)-1;
            // 11) t atencion
            estado_actual[11] = (float)-1;
            // 12) fin P1
            estado_actual[12] = (float)estado_ANTERIOR[12];
            // 13) fin p2
            estado_actual[13] = (float)estado_ANTERIOR[13];            
            // del 14 al 30 fin caja             
            //Determinado mas abajo segun corresponda

            //OBJETOS TEMPORALES
            // 31) estado desp
            estado_actual[31] = (string)estado_ANTERIOR[31];
            // 32) cola Despensa. 
            estado_actual[32] = (float)estado_ANTERIOR[32];
            // 33) Estado Panaderia 1
            estado_actual[33] = (string)estado_ANTERIOR[33];
            // 34) Estado Panaderia 2
            estado_actual[34] = (string)estado_ANTERIOR[34];
            // 35) estado Panaderia
            estado_actual[35] = (float)estado_ANTERIOR[35];
            //Se determina mas abajo            
            // 36) 37) caja
            //Se determina mas abajo

            // METRICAS
            // 38) 
            // se determina mas abajo por si hay objetos en cola
            // 39) 
            // Lo determina otro metodo
            // 40) 
            // Lo determina otro metodo
            // 41) cola max
            // Lo determina otro metodo
            // 42) cola max
            // Lo determina otro metodo
            // 43)
            estado_actual[43] = (float)estado_ANTERIOR[43];
            // 44)
            estado_actual[44] = (float)estado_ANTERIOR[44];
            // 45) 
            // Lo determina otro metodo
            // 46) 
            // Lo determina otro metodo
            // 47) 
            // Lo determina otro metodo
            // 48)
            // se determina mas abajo
            // 49)
            estado_actual[49] = (float)estado_ANTERIOR[49] + 1;
            // 50) 
            // Lo determina otro metodo

                        
            // Del 14 al 30 Fin caja. Servidor mira la cola
            // NO HAY COLA EN CAJA
            if ((float)estado_ANTERIOR[37] == 0)
            {
                // no calculo fin caja
                estado_actual[14] = (float)-1;
                estado_actual[15] = (float)-1;
                estado_actual[16] = (float)-1;
                estado_actual[17] = (float)-1;
                estado_actual[18] = (float)-1;
                estado_actual[19] = (float)estado_ANTERIOR[19];
                estado_actual[20] = (float)-1;
                estado_actual[21] = (float)-1;
                estado_actual[22] = (float)-1;
                estado_actual[23] = (float)estado_ANTERIOR[23];
                estado_actual[24] = (float)-1;
                estado_actual[25] = (float)-1;
                estado_actual[26] = (float)-1;
                estado_actual[27] = (float)estado_ANTERIOR[27];
                estado_actual[28] = (float)-1;
                estado_actual[29] = (float)-1;
                estado_actual[30] = (float)-1;
                // servidor caja pasa a libre
                estado_actual[36] = "Libre";
                // cola se mantiene en cero
                estado_actual[37] = (float)estado_ANTERIOR[37];

                //38) AC sigue igual
                estado_actual[38] = (float)estado_ANTERIOR[38];
                
            }
            // HAY COLA EN CAJA
            else
            {
                // calculamos fin caja
                estado_actual[14] = obtener_random();
                estado_actual[15] = calcular_articulos((float)estado_actual[14]);
                // del 16 al 28
                calcular_tiempo_articulo((float)estado_actual[15]);
                //29)
                calcular_tiempo_embolsado((float)estado_actual[15]);
                //30)
                estado_actual[30] = (float)estado_actual[28] + (float)estado_actual[29] + (float)estado_actual[1];
                // Servidor caja mantiene estado
                estado_actual[36] = (string)estado_ANTERIOR[36];
                // disminuye cola
                estado_actual[37] = (float)estado_ANTERIOR[37] - 1;

                //38) aumenta AC
                estado_actual[38] = (float)estado_actual[15] + (float)estado_ANTERIOR[38];

                // Cambio el estado del objeto de EAC a SAC
                /*
                cant_obj = (estado_ANTERIOR.Count - 51) / 3;
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 3 * i] == "EAC")
                    {
                        estado_actual[51 + 3 * i] = "SAC";
                        estado_actual[52 + 3 * i] = (float)estado_ANTERIOR[52 + 3 * i];
                        estado_actual[53 + 3 * i] = (float)estado_ANTERIOR[53 + 3 * i];
                        break;
                    }
                }*/
                //-----------------------------
                float min = 0;
                cant_obj = (estado_ANTERIOR.Count - 51) / 4;
                //Busco el primer objeto que ingreso a cola
                for (int i = 0; i < cant_obj; i++)
                {
                    if ((string)estado_ANTERIOR[51 + 4 * i] == "EAC")
                    {
                        min = (float)estado_ANTERIOR[54 + 4 * i]; // hs ingreso a cola caja
                        for (int j = 1; j < cant_obj; j++)
                        {
                            if ((float)estado_ANTERIOR[54 + 4 * j] < min && (string)estado_ANTERIOR[51 + 4 * j] == "EAC")
                            {
                                min = (float)estado_ANTERIOR[54 + 4 * j];
                            }
                        }
                        break;
                    }
                }
                // cambio de estado al primer objeto EAC que ingreso a cola
                for (int i = 0; i < cant_obj; i++)
                {
                    if (min == (float)estado_ANTERIOR[54 + 4 * i])
                    {
                        estado_actual[51 + 4 * i] = "SAC";
                        estado_actual[52 + 4 * i] = (float)estado_ANTERIOR[52 + 4 * i];
                        estado_actual[53 + 4 * i] = (float)-1;
                        estado_actual[54 + 4 * i] = (float)-1;
                        break;
                    }
                }
                //---------------------------------------------


            }
            //------------------------------------------------
            // calculo ac tiempo permanencia, y la muerte del objeto
            cant_obj = (estado_ANTERIOR.Count - 51) / 4;
            for (int i = 0; i < cant_obj; i++)
            {
                if ((string)estado_ANTERIOR[51 + 4 * i] == "SAC")
                {
                    estado_actual[51 + 4 * i] = "BORRADO";
                    estado_actual[52 + 4 * i] = (float)-1;
                    estado_actual[53 + 4 * i] = (float)-1;
                    estado_actual[54 + 4 * i] = (float)-1;
                    // calculo AC tiempo permanencia
                    estado_actual[48] = ((float)estado_actual[1] - (float)estado_ANTERIOR[52 + 4 * i] + (float)estado_ANTERIOR[48]);
                    break;
                }
            }

        }

        //FIN EVENTOS
        private void agregarColumnas()
        {
            numero_colum += 1;
            string columna_con_fondo;

            //estado
            columna_con_fondo = "estadoCliente" + Convert.ToString(numero_colum);
            frm.dgv_resultado.Columns.Add(columna_con_fondo, "Estado Cliente ");
            frm.dgv_resultado.Columns[columna_con_fondo].DefaultCellStyle.BackColor = Color.Lavender;
            frm.dgv_resultado.Columns[columna_con_fondo].DefaultCellStyle.SelectionBackColor = Color.Coral;
            frm.dgv_resultado.Columns[columna_con_fondo].HeaderCell.Style.BackColor = Color.Coral;

            //legada a sistema
            frm.dgv_resultado.Columns.Add("TiempoLLegadaCliente" + Convert.ToString(numero_colum), "HS Ingreso ");

            //legada a cola panaderia
            frm.dgv_resultado.Columns.Add("TiempoLLegadaClienteColaP" + Convert.ToString(numero_colum), "T Llegada Cola Cliente Panaderia");

            //legada a cola Caja
            frm.dgv_resultado.Columns.Add("TiempoLLegadaClienteColaC" + Convert.ToString(numero_colum), "T Llegada Cola Cliente Caja");                  

        }
        
        private string accion_cliente_entrar(float rnd)
        {
            if (rnd < 0.7) return "Panaderia";
            if (rnd < 1) return "Despensa";
            else return "ERROR";
        }         
        
        private float calcular_tiempo_despensa(float rnd1)
        {
            return (A_desp + (rnd1 * (B_desp - A_desp)));
        }
       
        private float calcular_tiempo_panaderia( float rnd)
        {
            return A_panaderia + rnd * (B_panaderia - A_panaderia);
        }
       
        private float calcular_articulos(float rnd)
        {
            if (rnd < 0.4) return 1;
            if (rnd < 0.75) return 2;
            return 3;
        }
        //se calcula con un fin desp, fin pan o fin caja
        private void calcular_tiempo_articulo(float cant_art)
        {
            estado_actual[28] = (float)0;
            if(cant_art == 1)
            {
                // ARTICULO 1 controlo por T2
                if ((float)estado_ANTERIOR[19] == -1)
                {
                    estado_actual[16] = obtener_random();
                    estado_actual[17] = obtener_random();
                    estado_actual[18] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[16]))))
                        *
                        ((float)Math.Cos(2 * ((float)Math.PI) * ((float)estado_actual[17]))))));

                    estado_actual[19] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[16]))))
                        *
                        ((float)Math.Sin(2 * ((float)Math.PI) * ((float)estado_actual[17]))))));
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[18];
                }
                else
                {
                    estado_actual[16] = (float)-1;
                    estado_actual[17] = (float)-1;
                    estado_actual[18] = (float)-1;
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[19];
                    estado_actual[19] = (float)-1;
                }
                // mantengo los otros
                //ART 2
                estado_actual[20] = (float)estado_ANTERIOR[20];
                estado_actual[21] = (float)estado_ANTERIOR[21];
                estado_actual[22] = (float)estado_ANTERIOR[22];
                estado_actual[23] = (float)estado_ANTERIOR[23];
                //ART 3
                estado_actual[24] = (float)estado_ANTERIOR[24];
                estado_actual[25] = (float)estado_ANTERIOR[25];
                estado_actual[26] = (float)estado_ANTERIOR[26];
                estado_actual[27] = (float)estado_ANTERIOR[27];
            }
            else if(cant_art == 2)
            {
                // ARTICULO 1 controlo por T2
                if ((float)estado_ANTERIOR[19] == -1)
                {
                    estado_actual[16] = obtener_random();
                    estado_actual[17] = obtener_random();
                    estado_actual[18] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[16]))))
                        *
                        ((float)Math.Cos(2 * ((float)Math.PI) * ((float)estado_actual[17]))))));

                    estado_actual[19] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[16]))))
                        *
                        ((float)Math.Sin(2 * ((float)Math.PI) * ((float)estado_actual[17]))))));
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[18];
                }
                if ((float)estado_ANTERIOR[19] != -1)
                {
                    estado_actual[16] = (float)-1;
                    estado_actual[17] = (float)-1;
                    estado_actual[18] = (float)-1;
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[19];
                    estado_actual[19] = (float)-1;
                }
                // ARTUCULO 2 controlo por T2
                if ((float)estado_ANTERIOR[23] == -1)
                {
                    estado_actual[20] = obtener_random();
                    estado_actual[21] = obtener_random();
                    estado_actual[22] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[20]))))
                        *
                        ((float)Math.Cos(2 * ((float)Math.PI) * ((float)estado_actual[21]))))));

                    estado_actual[23] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[20]))))
                        *
                        ((float)Math.Sin(2 * ((float)Math.PI) * ((float)estado_actual[21]))))));
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[22];
                }
                if ((float)estado_ANTERIOR[23] != -1)
                {
                    estado_actual[20] = (float)-1;
                    estado_actual[21] = (float)-1;
                    estado_actual[22] = (float)-1;
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[23];
                    estado_actual[23] = (float)-1;
                }
                // Mantengo ART 3
                estado_actual[24] = (float)estado_ANTERIOR[24];
                estado_actual[25] = (float)estado_ANTERIOR[25];
                estado_actual[26] = (float)estado_ANTERIOR[26];
                estado_actual[27] = (float)estado_ANTERIOR[27];
            }
            else
            {
                // ARTICULO 1 controlo por T2
                if ((float)estado_ANTERIOR[19] == -1)
                {
                    estado_actual[16] = obtener_random();
                    estado_actual[17] = obtener_random();
                    estado_actual[18] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[16]))))
                        *
                        ((float)Math.Cos(2 * ((float)Math.PI) * ((float)estado_actual[17]))))));

                    estado_actual[19] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[16]))))
                        *
                        ((float)Math.Sin(2 * ((float)Math.PI) * ((float)estado_actual[17]))))));
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[18];
                }
                if ((float)estado_ANTERIOR[19] != -1)
                {
                    estado_actual[16] = (float)-1;
                    estado_actual[17] = (float)-1;
                    estado_actual[18] = (float)-1;
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[19];
                    estado_actual[19] = (float)-1;
                }
                // ARTUCULO 2 controlo por T2
                if ((float)estado_ANTERIOR[23] == -1)
                {
                    estado_actual[20] = obtener_random();
                    estado_actual[21] = obtener_random();
                    estado_actual[22] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[20]))))
                        *
                        ((float)Math.Cos(2 * ((float)Math.PI) * ((float)estado_actual[21]))))));

                    estado_actual[23] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[20]))))
                        *
                        ((float)Math.Sin(2 * ((float)Math.PI) * ((float)estado_actual[21]))))));
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[22];
                }
                if ((float)estado_ANTERIOR[23] != -1)
                {
                    estado_actual[20] = (float)-1;
                    estado_actual[21] = (float)-1;
                    estado_actual[22] = (float)-1;
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[23];
                    estado_actual[23] = (float)-1;
                }
                // ARTICULO 3 controlo por T2
                if ((float)estado_ANTERIOR[27] == -1)
                {
                    estado_actual[24] = obtener_random();
                    estado_actual[25] = obtener_random();
                    estado_actual[26] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[24]))))
                        *
                        ((float)Math.Cos(2 * ((float)Math.PI) * ((float)estado_actual[25]))))));

                    estado_actual[27] = Math.Abs(media_caja + (desv_caja * (
                        ((float)Math.Sqrt((-2) * ((float)Math.Log((float)estado_actual[24]))))
                        *
                        ((float)Math.Sin(2 * ((float)Math.PI) * ((float)estado_actual[25]))))));
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[26];
                }
                if ((float)estado_ANTERIOR[27] != -1)
                {
                    estado_actual[24] = (float)-1;
                    estado_actual[25] = (float)-1;
                    estado_actual[26] = (float)-1;
                    estado_actual[28] = (float)estado_actual[28] + (float)estado_actual[27];
                    estado_actual[27] = (float)-1;
                }
            }

        }
       
        private void calcular_tiempo_embolsado(float cant)
        {
            if (cant == 1) estado_actual[29] = (float)0.08;
            else if (cant == 2) estado_actual[29] = (float)0.1;
            else estado_actual[29] = (float)0.11;
        }

        private void inicializar()
        {
            frm.dgv_resultado.Rows.Clear();

            estado_ANTERIOR = new ArrayList();

            // 0) evento
            estado_ANTERIOR.Add("Inicialización");
            // 1) reloj
            estado_ANTERIOR.Add((float)0.00);
            // 2) RND t entre llegadas
            estado_ANTERIOR.Add(obtener_random());
            // 3) t entre llegadas
            estado_ANTERIOR.Add((float)((-this.media) * Math.Log(1 - (float)estado_ANTERIOR[2])));
            // 4) próxima llegada cliente
            estado_ANTERIOR.Add((float)estado_ANTERIOR[1] + (float)estado_ANTERIOR[3]);
            // 5) RND acción 
            estado_ANTERIOR.Add((float)-1);
            // 6) acción al entrar
            estado_ANTERIOR.Add("---");            
            // fines de at
            for (int j = 7; j <= 30; j++)
            {
                estado_ANTERIOR.Add((float)-1);
            }
            //OBJETOS PERMANENTES
            // 31) estado despensa 
            estado_ANTERIOR.Add("Libre");
            // 32) cola
            estado_ANTERIOR.Add((float)0);
            // 33) estado panadero 1
            estado_ANTERIOR.Add("Libre");
            // 34) estado panadero 2
            estado_ANTERIOR.Add("Libre");
            // 35) cola panadero
            estado_ANTERIOR.Add((float)0);
            // 36) estado caja
            estado_ANTERIOR.Add("Libre");
            // 37) cola caja
            estado_ANTERIOR.Add((float)0);
            // METRICAS
            for (int k = 38; k <= 50; k++)
            {
                estado_ANTERIOR.Add((float)0);
            }
            
            // visualización de inicialización en dgv
            frm.dgv_resultado.Rows.Add();
            for (int i = 0; i < 51; i++)
            {
                comparacion = Convert.ToString(estado_ANTERIOR[i]);
                if (comparacion != "-1" && comparacion != "BORRADO" && comparacion != "---")
                {
                    frm.dgv_resultado.Rows[0].Cells[i].Value = estado_ANTERIOR[i];
                }
            }
            frm.dgv_resultado.Rows[frm.dgv_resultado.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Orange;

            frm.dgv_resultado.Columns[1].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[4].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[9].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[12].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[13].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[30].HeaderCell.Style.BackColor = Color.Black;
            frm.dgv_resultado.Columns[38].HeaderCell.Style.BackColor = Color.Red;
            frm.dgv_resultado.Columns[40].HeaderCell.Style.BackColor = Color.Red;
            frm.dgv_resultado.Columns[41].HeaderCell.Style.BackColor = Color.Red;
            frm.dgv_resultado.Columns[42].HeaderCell.Style.BackColor = Color.Red;
            frm.dgv_resultado.Columns[45].HeaderCell.Style.BackColor = Color.Red;
            frm.dgv_resultado.Columns[47].HeaderCell.Style.BackColor = Color.Red;
            frm.dgv_resultado.Columns[50].HeaderCell.Style.BackColor = Color.Red;

            estado_actual = new ArrayList(estado_ANTERIOR);
            estado_actual[0] = "Llegada cliente";
            estado_actual[1] = (float)estado_ANTERIOR[4];
        }
        
        private static float obtener_random()
        {
            float random = 0;
            random = (float)(Math.Truncate(rand.NextDouble() * 100) / 100);
            while (random == 0)
            {
                random = (float)(Math.Truncate(rand.NextDouble() * 100) / 100);
            }
            return random;
        }
                
        // 39) y 46) ac tiempo ocioso
        private void calcular_tiempos_ociosos()
        {
            // 39) Caja
            if ((string)estado_ANTERIOR[36] == "Libre")
            {
                //acumula
                estado_actual[39] = (float)estado_actual[1] - (float)estado_ANTERIOR[1] + (float)estado_ANTERIOR[39];
            }
            if ((string)estado_ANTERIOR[36] != "Libre")
            {
                //mantiene
                estado_actual[39] = (float)estado_ANTERIOR[39];
            }
            // 46) Despensa
            if ((string)estado_ANTERIOR[31] == "Libre")
            {
                //acumula
                estado_actual[46] = (float)estado_actual[1] - (float)estado_ANTERIOR[1] + (float)estado_ANTERIOR[46];
            }
            if ((string)estado_ANTERIOR[31] != "Libre")
            {
                //mantiene
                estado_actual[46] = (float)estado_ANTERIOR[46];
            }
        }
        //40) y 47) Porcentaje tiempo ocioso
        private void calcular_porcentaje()
        {
            // 40) caja
            if ((float)estado_actual[39] == 0) estado_actual[40] = (float)0;
            if ((float)estado_actual[39] != 0) estado_actual[40] = (float)((float)estado_actual[39] / (float)estado_actual[1]);
            // 47) despensa
            if ((float)estado_actual[46] == 0) estado_actual[47] = (float)0;
            if ((float)estado_actual[46] != 0) estado_actual[47] = (float)((float)estado_actual[46] / (float)estado_actual[1]);
        }
        // 41),42)
        private void calcular_cola_max()
        {
            // sacamos el max entre cola despensa y el max anterior de la metrica
            estado_actual[41] = Math.Max((float)estado_actual[32], (float)estado_ANTERIOR[41]);
            // idem con panaderia
            estado_actual[42] = Math.Max((float)estado_actual[35], (float)estado_ANTERIOR[42]);
        }        
        // 45) cola panaderia
        private void calcular_promedio_tiempo_en_cola()
        {
            if ((float)estado_actual[44] == 0)
            {
                estado_actual[45] = 0;
                return;
            }
            estado_actual[45] = (float)estado_actual[43] / (float)estado_actual[44];
        }
        // 50) promedio permanencia
        private void calcular_promedio_permanencia()
        {
            if ((float)estado_actual[49] == 0)
            {
                estado_actual[50] = 0;
                return;
            }
            estado_actual[50] = (float)estado_actual[48] / (float)estado_actual[49];
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
