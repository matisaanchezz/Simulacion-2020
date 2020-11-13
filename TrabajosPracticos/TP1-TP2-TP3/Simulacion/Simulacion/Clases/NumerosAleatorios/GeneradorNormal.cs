using System;
using System.Linq;
using System.Windows.Forms;
using Simulacion.Interfaces;


namespace Simulacion.Clases
{
    class GeneradorNormal : IGeneradorAleatorio
    {
        // Atributos
        private float media;
        private float desviacion;
        private string metodo;

        // Constructor
        public GeneradorNormal(float media, float desviacion, string metodo)
        {
            this.media = media;
            this.desviacion = desviacion;
            // Debe ser específicamente 'box_muller' o 'convolucion'
            this.metodo = metodo;
        }

        // Métodos
        public void llenar_dgv(DataGridView dgv, float[] normales)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.Columns.Add("Column1", "Iteración");
            int cantidad = normales.Length;

            if (this.metodo == "convolucion")
            {
                dgv.Columns.Add("Column2", "Nro Aleatorio");

                for (int i = 0; i < cantidad; i++)
                {
                    dgv.Rows.Add(i + 1, string.Format("{0:N4}", normales[i]));
                }
            }
            else if (this.metodo == "box_muller")
            {
                dgv.Columns.Add("Column2", "Nro Aleatorio 1");
                dgv.Columns.Add("Column3", "Nro Aleatorio 2");

                int mitad = cantidad / 2;
                for (int i = 0; i < mitad; i++)
                {
                    dgv.Rows.Add(i + 1, string.Format("{0:N4}", normales[i]), string.Format("{0:N4}", normales[mitad + i]));
                }
            }
            return;
        }

        public float[] generarNumeros(float[] pseudos)
        {
            if (this.metodo == "convolucion")
            {
                // deberían ser (cantNumeros * 12 números) pseudoaleatorios
                int cantNumeros = pseudos.Length / 12;
                float[] numerosAleatorios = new float[cantNumeros];

                float[] numPseudosIteracion = new float[12];

                int primera_pos_12_pseudos = 0;
                for (int i = 0; i < cantNumeros; i++)
                {
                    Array.Copy(pseudos, primera_pos_12_pseudos, numPseudosIteracion, 0, 12);
                    numerosAleatorios[i] = generadorConvolucionIndividual(numPseudosIteracion, media, desviacion);

                    primera_pos_12_pseudos += 12;
                }

                return numerosAleatorios;
            }
            else if (this.metodo == "box_muller")
            {
                // deberían ser (cantNumeros * 2 números) pseudoaleatorios
                int cantNumerosBM1 = pseudos.Length / 2;
                // Array --> BM1 concatenados con BM2
                int cant = cantNumerosBM1 * 2;
                float[] numerosAleatorios = new float[cant];


                for (int i = 0; i < cantNumerosBM1; i++)
                {
                    // Las dos partes del mismo array:

                    // Box Muller 1
                    numerosAleatorios[i] = (((((float)Math.Sqrt(-2 * (float)Math.Log(pseudos[i]))) * ((float)(Math.Cos(2 * (float)Math.PI * pseudos[cantNumerosBM1 + i]))) * desviacion) + media));

                    // Box Muller 2
                    numerosAleatorios[cantNumerosBM1 + i] = (((((float)Math.Sqrt(-2 * (float)Math.Log(pseudos[i]))) * ((float)(Math.Sin(2 * (float)Math.PI * pseudos[cantNumerosBM1 + i]))) * desviacion) + media));
                }

                return numerosAleatorios;
            }
            return null;
        }

        private float generadorConvolucionIndividual(float[] doce_pseudos, float media, float desviacion)
        {
            float suma_de_RND = 0;
            for (int i = 0; i < 12; i++)
            {
                suma_de_RND += doce_pseudos[i];
            }
            float elemento_aleatorio = (suma_de_RND - 6) * desviacion + media;
            return elemento_aleatorio;
        }

    }
}
