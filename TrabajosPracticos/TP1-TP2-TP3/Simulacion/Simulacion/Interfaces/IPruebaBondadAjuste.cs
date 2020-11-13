using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Interfaces
{
    interface IPruebaBondadAjuste
    {
        //llenado de dgv. No pone columnas, por lo que la tabla debería tener columnas específicas precargadas
        //ésto debería corregirse
        void realizar_prueba_en_dgv(DataGridView dgv, float[] desde, float[] hasta, float[] fo, float[] fe);

        //este método devuelve el estadístico de prueba solamente
        float realizar_prueba(float[] fo, float[] fe);

    }
}
