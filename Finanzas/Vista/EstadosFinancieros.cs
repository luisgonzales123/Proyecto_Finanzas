﻿using Finanzas.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finanzas.Vista
{
    public partial class EstadosFinancieros: Form
    {
        public EstadosFinancieros ()
        {
            InitializeComponent();
        }

        public void Cargar_datos ()
        {
            int año = datepicker_BG.Value.Year;
            tabla_activo.DataSource = Controlador.CConsulta.Consulta(año, "ACTIVO");
            tabla_pasivo.DataSource = Controlador.CConsulta.Consulta(año, "PASIVO");
            tabla_capital.DataSource = Controlador.CConsulta.Consulta(año, "CAPITAL");
            tabla_er.DataSource = Controlador.CCuenta.Estado_Resultados(año);

            double montoPC = (suma_monto_datagrid(tabla_pasivo) + suma_monto_datagrid(tabla_capital));
            label_activo.Text = "TOTAL ACTIVO :" + suma_monto_datagrid(tabla_activo);
            label_pc.Text = "TOTAL PASIVO Y CAPITAL:" + montoPC;

            tabla_activo.Columns ["Monto"].DefaultCellStyle.Format = "N2";
            tabla_pasivo.Columns ["Monto"].DefaultCellStyle.Format = "N2";
            tabla_capital.Columns ["Monto"].DefaultCellStyle.Format = "N2";
            tabla_er.Columns ["Monto"].DefaultCellStyle.Format = "N2";
        }
        

        private void EstadosFinancieros_Load (object sender, EventArgs e)
        {
            Cargar_datos();
        }

        private void btn_salir_Click (object sender, EventArgs e)
        {
            this.Hide();
        }

        private void datepicker_BG_ValueChanged (object sender, EventArgs e)
        {
            Cargar_datos();
        }

        private void btn_nuevo_Click (object sender, EventArgs e)
        {
            NuevoEstadoFinanciero nuevo_estado = new NuevoEstadoFinanciero();
            nuevo_estado.Show();
            this.Hide();
        }

        private void btn_bg_Click (object sender, EventArgs e)
        {
            pages_EF.SelectedIndex = 0;
        }

        private void btn_er_Click (object sender, EventArgs e)
        {
            pages_EF.SelectedIndex = 1;
        }

        public double suma_monto_datagrid (Bunifu.UI.WinForms.BunifuDataGridView datagrid)
        {
            double monto = 0;
            for (int i = 0 ;i < datagrid.RowCount ;i++)
            {
                if (datagrid.Rows [i].Cells [1].Value != null)
                {
                    monto += double.Parse(datagrid.Rows [i].Cells [1].Value.ToString());
                }
            }
            return monto;
        }

    }
}
