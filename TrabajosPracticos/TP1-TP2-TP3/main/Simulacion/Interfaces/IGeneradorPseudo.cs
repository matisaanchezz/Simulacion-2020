using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Interfaces
{
    interface IGeneradorPseudo
    {
        void llenar_dgv(DataGridView dgv, int cant_elemenos);

        void agregar_fila_dgv(DataGridView dgv);

        float[] generarPseudoaleatorios(int cantidad);

    }
}
