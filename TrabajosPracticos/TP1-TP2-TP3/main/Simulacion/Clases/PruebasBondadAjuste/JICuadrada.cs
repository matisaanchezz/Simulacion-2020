using Simulacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Clases.PruebasBondadAjuste
{

    class JICuadrada : IPruebaBondadAjuste
    {
        // ----- Atributos -----

        private float[] c_array;
        private float[] ca_array;

        // ----- Métodos -----

        public void realizar_prueba_en_dgv(DataGridView dgv, float[] desde, float[] hasta, float[] fo, float[] fe)
        {
            validar_fe_array(desde, hasta, fe, fo);
            realizar_prueba(fo, fe);

            int nroIntervalos = desde.Length;
            dgv.Rows.Clear();
            for (int i = 0; i < nroIntervalos; i++)
            {
                if (desde[i] == 0 && hasta[i] == 0) continue;
                dgv.Rows.Add(string.Format("[ " + "{0:N5}", desde[i]) + " ; " + string.Format("{0:N5}", hasta[i]) + " )", fo[i], string.Format("{0:N2}", fe[i]),
                    string.Format("{0:N4}", c_array[i]),
                    string.Format("{0:N4}", ca_array[i]));
            }
            dgv.Rows[dgv.Rows.Count - 1].Cells[4].Style.BackColor = Color.Orange;
        }

        public float realizar_prueba(float[] fo, float[] fe)
        {
            int nroIntervalos = fo.Length;

            //determinación de C y Cac
            this.c_array = new float[nroIntervalos];
            this.ca_array = new float[nroIntervalos];

            for (int i = 0; i < nroIntervalos; i++)
            {
                if (i == 0)
                {
                    // recordar que en JiCuadrada debemos tener un mínimo de 5 frecuencias por intervalo
                    if (fe[i] >= 5)
                    {
                        c_array[i] = (float)Math.Pow(fo[i] - fe[i], 2) / fe[i];
                        ca_array[i] = c_array[i];
                    }
                    else
                    {
                        c_array[i] = 0;
                        ca_array[i] = 0;
                    }
                }
                else
                {
                    if (fe[i] >= 5)
                    {
                        c_array[i] = (float)Math.Pow(fo[i] - fe[i], 2) / fe[i];
                    }
                    else
                    {
                        c_array[i] = 0;
                    }
                    ca_array[i] = c_array[i] + ca_array[i - 1];
                }
            }
            return ca_array[nroIntervalos - 1];
        }

        // ----- Junta intervalos adyacentes necesarios -----
        private void validar_fe_array(float[] desde, float[] hasta, float[] fe, float[] fo)
        {
            int cant = fe.Length;
            int ultima_pos = cant - 1;

            // de derecha a izquierda
            for (int i = ultima_pos; i > 0; i--)
            {
                if (fe[i] < (float)5)
                {
                    fe[i - 1] += fe[i];
                    fe[i] = (float)0.0000;
                    desde[i] = (float)0.0000;
                    hasta[i - 1] = hasta[i];
                    hasta[i] = (float)0.0000;
                    fo[i - 1] += fo[i];
                    fo[i] = (float)0.0000;
                }
            }

            //de izquierda a derecha
            if (fe[0] == (float)0.0000 || fe[0] >= 5) return;
            for (int i2 = 1; i2 < cant - 1; i2++)
            {
                if (fe[i2] >= 5)
                {
                    fe[i2] += fe[0];
                    fe[0] = (float)0.0000;
                    desde[i2] = desde[0];
                    desde[0] = (float)0.0000;
                    hasta[0] = (float)0.0000;
                    return;
                }
            }
        }

    }
}
