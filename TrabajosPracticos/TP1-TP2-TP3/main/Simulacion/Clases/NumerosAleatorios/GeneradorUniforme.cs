using Simulacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Clases
{
    class GeneradorUniforme : IGeneradorAleatorio
    {
        // Atributos
        private float a;
        private float b;

        // Constructor
        public GeneradorUniforme(float a, float b)
        {
            this.a = a;
            this.b = b;
        }

        // Métodos
        public float[] generarNumeros(float[] pseudos)
        {
            int cantidad = pseudos.Length;
            float[] numerosUniformes = new float[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                numerosUniformes[i] = a + pseudos[i] * (b - a);
            }

            return numerosUniformes;
        }

        public void llenar_dgv(DataGridView dgv, float[] uniformes)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            int cantidad = uniformes.Length;
            dgv.Columns.Add("Column1", "Iteración");
            dgv.Columns.Add("Column2", "Nro Aleatorio");

            for (int i = 0; i < cantidad; i++)
            {
                dgv.Rows.Add(i + 1, string.Format("{0:N4}", uniformes[i]));
            }
        }

    }
}
