using Simulacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Clases.PruebasBondadAjuste
{
    class KolSmir : IPruebaBondadAjuste
    {
        float IPruebaBondadAjuste.realizar_prueba(float[] fo, float[] fe)
        {
            throw new NotImplementedException();
        }

        void IPruebaBondadAjuste.realizar_prueba_en_dgv(DataGridView dgv, float[] desde, float[] hasta, float[] fo, float[] fe)
        {
            throw new NotImplementedException();
        }
    }
}
