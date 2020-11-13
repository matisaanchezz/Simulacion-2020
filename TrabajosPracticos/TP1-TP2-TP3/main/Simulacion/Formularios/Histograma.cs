using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Simulacion
{
    public partial class Histograma : Form
    {
        public Histograma()
        {
            InitializeComponent();
        }

        private void Histograma_Load(object sender, EventArgs e)
        {
            chart1.Show();
        }

        public void cargarHistograma(int cantIntervalos, int[,] matrizFrecuencias, int cantidadNrosAGenerar)
        {

            // arreglar el Label de los valores que se muestran en el gráfico
            chart1.Series.Clear();
            string[] nombres = { "fe: Frecuencia Esperada", "fo: Frecuencia Observada" };
            chart1.Palette = ChartColorPalette.Pastel;
            for(int i = 0; i < nombres.Length; i++)
            {                
                Series serie = chart1.Series.Add(nombres[i]);
                for(int j = 0; j < cantIntervalos; j++)
                {
                    serie.Points.Add(matrizFrecuencias[i, j]);
                }
            }

            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = cantIntervalos + 1;
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(cantidadNrosAGenerar + 2) / 3;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
