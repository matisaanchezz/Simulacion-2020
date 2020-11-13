using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Colas
{
    public partial class frmTabla : Form
    {
        public frmTabla()
        {
            InitializeComponent();
        }

        private void dgv_resultado_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 1;
        }
    }

}
