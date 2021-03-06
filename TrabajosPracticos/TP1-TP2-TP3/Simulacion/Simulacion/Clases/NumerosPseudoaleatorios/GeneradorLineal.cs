﻿using Simulacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Clases
{
    class GeneradorLineal : IGeneradorPseudo
    {
        // Atributos

        private float x0;
        private float a;
        private float c;
        private float m;

        //Constructor
        public GeneradorLineal(float x0, float k, float c, float g)
        {
            this.x0 = x0;
            this.a = 1 + (4 * k);
            this.c = c;
            this.m = (float)Math.Pow(2, g);
        }

        //Metodos

        // Recibe una dgv cualquiera, la resetea y luego la carga
        public void llenar_dgv(DataGridView dgv, int cant_elemenos)
        {
            dgv.Rows.Clear();

            for (int i = 0; i < cant_elemenos; i++)
            {
                agregar_fila_dgv(dgv);
            }
        }

        // Recibe la dgv que previamente debe generar el metodo llenar_dgv() y luego le agrega la próxima fila. Si recibe otra dgv se rompe todo.
        public void agregar_fila_dgv(DataGridView dgv)
        {
            int cant_filas_dgv = dgv.Rows.Count;
            float a_xi_c;
            float xi_mas_uno;
            //float rnd;

            if (cant_filas_dgv == 0)
            {
                a_xi_c = a * x0 + c;
                xi_mas_uno = a_xi_c % m;

                dgv.Rows.Add(1, a_xi_c, xi_mas_uno, string.Format("{0:N4}", xi_mas_uno / m));
            }
            else
            {
                a_xi_c = a * float.Parse(dgv.Rows[cant_filas_dgv - 1].Cells[2].Value.ToString()) + c;
                xi_mas_uno = a_xi_c % m;

                dgv.Rows.Add(cant_filas_dgv + 1, a_xi_c, xi_mas_uno, string.Format("{0:N4}", xi_mas_uno / m));
            }
        }

        // devuelve una lista con n pseudoaleatorios --> método todavía no probado
        public float[] generarPseudoaleatorios(int n)
        {
            float[] lista_pseudoaleatorios = new float[n];


            float a_xi_c = a * x0 + c;
            float xi_mas_uno = (float)a_xi_c % m;

            for (int i = 0; i < n; i++)
            {
                float rnd = (float)xi_mas_uno / (float)(m);

                rnd = (float)Math.Truncate(10000 * rnd) / 10000;
                lista_pseudoaleatorios[i] = rnd;

                a_xi_c = a * xi_mas_uno + c;
                xi_mas_uno = a_xi_c % m;
            }

            return lista_pseudoaleatorios;
        }

    }
}
