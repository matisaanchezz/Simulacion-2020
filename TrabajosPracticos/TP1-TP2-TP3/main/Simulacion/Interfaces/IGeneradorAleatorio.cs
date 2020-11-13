using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Interfaces
{
    interface IGeneradorAleatorio
    {
        // Iteración y Número Aleatorio
        void llenar_dgv(DataGridView dgv, float[] numeros);

        float[] generarNumeros(float[] numerosPseudo);

    }
}
