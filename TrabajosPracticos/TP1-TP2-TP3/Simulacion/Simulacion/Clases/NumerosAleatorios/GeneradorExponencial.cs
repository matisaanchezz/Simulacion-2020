using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulacion.Interfaces;

namespace Simulacion.Clases
{
    class GeneradorExponencial : IGeneradorAleatorio
    {
        // Atributos
        private float media;

        // Constructor
        public GeneradorExponencial(float media)
        {
            this.media = media;
        }

        // Métodos
        public float[] generarNumeros(float[] pseudos)
        {
            int cant = pseudos.Length;
            float[] numerosExponenciales = new float[cant];

            for (int i = 0; i < cant; i++)
            {
                numerosExponenciales[i] = (float)Math.Log(1 - pseudos[i]) * (-this.media);
            }

            return numerosExponenciales;
        }

        public void llenar_dgv(DataGridView dgv, float[] exponenciales)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.Columns.Add("Column1", "Iteración");
            dgv.Columns.Add("Column2", "Nro Aleatorio");

            for (int i = 0; i < exponenciales.Length; i++)
            {
                dgv.Rows.Add(i + 1, string.Format("{0:N4}", exponenciales[i]));
            }
        }

    }
}
