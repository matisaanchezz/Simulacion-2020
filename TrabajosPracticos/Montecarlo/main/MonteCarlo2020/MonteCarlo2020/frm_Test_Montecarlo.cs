using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonteCarlo2020
{
    public partial class frm_Test_Montecarlo : Form
    {
        public frm_Test_Montecarlo()
        {
            InitializeComponent();
        }

        private void frm_Test_Montecarlo_Load(object sender, EventArgs e)
        {
            DataGridViewColumn column;
            for(int i = 0; i < dgv.Columns.Count; i++)
            {
                column = dgv.Columns[i];
                column.Width = 60;
            }

        }

        private void btn_grafica_Click(object sender, EventArgs e)
        {
            Grafica_MonteCarlo grafica_MonteCarlo = new Grafica_MonteCarlo();
            grafica_MonteCarlo.ShowDialog();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
