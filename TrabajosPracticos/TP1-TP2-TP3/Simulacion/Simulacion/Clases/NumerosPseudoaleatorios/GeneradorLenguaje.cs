using Simulacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Clases
{
    class GeneradorLenguaje : IGeneradorPseudo
    {
        public void agregar_fila_dgv(DataGridView dgv)
        {
            throw new NotImplementedException();
        }

        public float[] generarPseudoaleatorios(int n)
        {
            var rnd = new Random();
            //creo una lista por las dudas la necesite en un futuro próximo, que es lo más probable
            float[] lista_pseudoaleatorios = new float[n];
            for (int i = 0; i < n; i++)
            {
                float valor_pseudo = (float)(Math.Truncate(rnd.NextDouble() * 10000) / 10000);
                lista_pseudoaleatorios[i] = valor_pseudo;
            }

            return lista_pseudoaleatorios;
        }

        public void llenar_dgv(DataGridView dgv, int cant_elemenos)
        {
            throw new NotImplementedException();
        }

    }
}

