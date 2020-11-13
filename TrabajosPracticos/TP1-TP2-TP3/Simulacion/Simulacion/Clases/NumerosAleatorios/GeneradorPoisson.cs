using Simulacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Clases
{
    class GeneradorPoisson
    {
        public int[] generarNumerosPoisson(int cantValores, double lambda)
        {
            //En Poisson media = varianza

            int[] listaNumerosPoisson = new int[cantValores];

            float p;
            int x;
            float a;
            var rnd = new Random();
            float u;

            for (int i = 0; i < cantValores; i++)
            {
                p = 1;

                a = (float)Math.Exp(-lambda);

                u = (float)rnd.NextDouble();

                p = p * u;
                x = 0;

                while (p >= a)
                {
                    u = (float)rnd.NextDouble();
                    p = p * u;
                    x = x + 1;
                }
                listaNumerosPoisson[i] = x;
            }
            return listaNumerosPoisson;
        }

        public void llenar_dgv(DataGridView dgv, int[] poissons)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            int cantidad = poissons.Length;
            dgv.Columns.Add("Column1", "Iteración");
            dgv.Columns.Add("Column2", "Nro Aleatorio");

            for (int i = 0; i < cantidad; i++)
            {
                dgv.Rows.Add(i + 1,  poissons[i]);
            }
        }

    }
}
