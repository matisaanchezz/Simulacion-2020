using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Clases
{
    class IOException
    {
        public static implicit operator Exception(IOException v)
        {
            throw new NotImplementedException();
        }
        public void validar_Carga(TextBox textBox1 = null, TextBox textBox2 = null, TextBox textBox3 = null, TextBox textBox4 = null, TextBox textBox5 = null, TextBox textBox6 = null, Button btn = null)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Cargue todos los casilleros por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (btn != null)
                    btn.Enabled = false;
            }
        }
        public void otroError()
        {
            MessageBox.Show("Ha ocurrido un problema. Disculpe los inconvenientes ocasionados.");

        }

    }
}
