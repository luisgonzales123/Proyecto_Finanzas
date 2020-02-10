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
    public partial class Razones_años: Form
    {

        int año1 = 0, año2 = 0;

        public Razones_años ()
        {
            InitializeComponent();
        }

        private void btn_salir_Click (object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_minimizar_Click (object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir_Click_1 (object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void btn_is_Click (object sender, EventArgs e)
        {
            double valor1 = CRazónCuenta.Razon_cuenta("Indice_solvencia", bunifuDatePicker1.Value);
            double valor2 = CRazónCuenta.Razon_cuenta("Indice_solvencia", bunifuDatePicker2.Value);

            string texto = "Por cada córdoba o dólar de deuda a corto plazo se cuenta <br> " +
                            "con " + valor1 + " de activo circulante para responder a esta obligación.<br>"+
                            Mensaje_razón(valor1, valor2) + " en el " + bunifuDatePicker2.Value.Year ;

            string formula = "Fórmula <br>" +
                             "Activo Circ. / Pasivo Circ.";

            new MessageWindow("Indice de solvencia", texto, formula).Show();
        }

        private void btn_deuda_Click (object sender, EventArgs e)
        {
            double valor = CRazónCuenta.Razon_cuenta("Razón_deuda", bunifuDatePicker1.Value);
            string texto = "El " + valor + "% de los bienes de la empresa las debe a los acreedores.<br>" +
                            "Es decir del total de los activos de la empresa se debe el " + valor + "%";

            string formula = "Fórmula <br>" +
                                "Total Pasivo / Total Activo";
            new MessageWindow("Razón de deuda", texto, formula).Show();
        }

        private void btn_cnt_Click (object sender, EventArgs e)
        {
            double valor1 = CRazónCuenta.Razon_cuenta("Capital_Trabajo", bunifuDatePicker1.Value);
            double valor2 = CRazónCuenta.Razon_cuenta("Capital_Trabajo", bunifuDatePicker2.Value);

            string texto = "El Capital neto de trabajo es de " + valor1 + ", esto quiere decir cuenta <br> " +
                            "con ese dinero una vez habiendo cancelado con todas las <br> " +
                            "obligaciones  a corto plazo." + Mensaje_razón(valor1, valor2) + " en el " + bunifuDatePicker2.Value.Year;

            string formula = "Fórmula <br>" +
                                 "Activo Circ. - Pasivo Circ.";
            new MessageWindow("Capital Neto Trabajo", texto, formula).Show();
        }

        private void btn_pa_Click (object sender, EventArgs e)
        {

            double valor1 = CRazónCuenta.Razon_cuenta("Razon_ácida", bunifuDatePicker1.Value);
            double valor2 = CRazónCuenta.Razon_cuenta("Razon_ácida", bunifuDatePicker2.Value);

            string texto = "La razón para el año, significa que por cada córdoba de deuda <br> " +
                            "de la empresa esta en capacidad de responder con " + valor1 + " <br> " +
                            "centavos si esta decidiera no entregar sus inventarios.<br>" + 
                            Mensaje_razón(valor1, valor2) + " en el " + bunifuDatePicker2.Value.Year;

            string formula = "Fórmula <br>" +
                                 "Costo de venta / Inventario";
            new MessageWindow("Razón de prueba ácida", texto, formula).Show();
        }

        private void btn_RotInt_Click (object sender, EventArgs e)
        {
            double valor = CRazónCuenta.Razon_cuenta("Rotacion_Interes", bunifuDatePicker1.Value);

            string texto = "" + valor;

            string formula = "Fórmula <br>" +
                                 "UAII / cargos por interes";
            new MessageWindow("Rotación de interes a utilidad", texto, formula).Show();
        }

        private void btn_rotaciónInventario_Click (object sender, EventArgs e)
        {
            double valor1 = CRazónCuenta.Razon_cuenta("Rotación_Inventario", bunifuDatePicker1.Value);
            double valor2 = CRazónCuenta.Razon_cuenta("Rotación_Inventario", bunifuDatePicker2.Value);

            string texto = "La razón para el año, significa que por cada córdoba de deuda de la <br> " +
                           "empresa esta en capacidad de responder con " + valor1 + " centavos <br>" +
                           "si esta decidiera no entregar sus inventarios." + Mensaje_razón(valor1, valor2) + " en el " + bunifuDatePicker2.Value.Year;

            string formula = "Fórmula <br>" +
                                 "(Activo Circ. - Inventario) / Pasivo Circ.";
            new MessageWindow("Rotación de inventario", texto, formula).Show();
        }

        private void btn_CuentasCobrar_Click (object sender, EventArgs e)
        {
            double valor = CRazónCuenta.Razon_cuenta("Rotación_Cuentas_por_cobrar", bunifuDatePicker1.Value);
            double veces = (12 / valor) * 100;


            string texto = "Significa que la compañía esta realizando la cobranza " + valor + " veces <br>" +
                            "por año osea que cobra " + veces + " por año.";

            string formula = "Fórmula <br>" +
                              "Ventas / Cuentas por cobrar";
            new MessageWindow("Rotación cuentas por cobrar ", texto, formula).Show();
        }

        private void btn_ActivoFijo_Click (object sender, EventArgs e)
        {
            double valor1 = CRazónCuenta.Razon_cuenta("Rotación_ActivoFijo", bunifuDatePicker1.Value);
            double valor2 = CRazónCuenta.Razon_cuenta("Rotación_ActivoFijo", bunifuDatePicker2.Value);

            string texto = "EL índice indica que por cada córdoba invertido en activos fijos netos <br>" +
                           "proporciona " + valor1 + " en ventas." + Mensaje_razón(valor1, valor2) + " en el " + bunifuDatePicker2.Value.Year;

            string formula = "Fórmula <br>" +
                                 "Ventas / Activo fijo";
            new MessageWindow("Razón activo fijo", texto, formula).Show();
        }

        private void btn_ActivoTotal_Click (object sender, EventArgs e)
        {
            double valor1 = CRazónCuenta.Razon_cuenta("Rotación_ActivoTotal", bunifuDatePicker1.Value);
            double valor2 = CRazónCuenta.Razon_cuenta("Rotación_ActivoTotal", bunifuDatePicker2.Value);

            string texto = "Al dividir las ventas entre la inversión concentrada en los activos <br> " +
                           "totales se determina que cada córdoba invertido en activos es <br> " +
                           "capaz de generar " + valor1 + " centavos de ingresos por ventas.<br>" + 
                            Mensaje_razón(valor1, valor2) + " en el " + bunifuDatePicker2.Value.Year;

            string formula = "Fórmula <br>" +
                                "Ventas / activo total";
            new MessageWindow("Razón activo total", texto, formula).Show();
        }

        private void btn_UtilidadBruta_Click (object sender, EventArgs e)
        {
            double valor1 = CRazónCuenta.Razon_cuenta("MUB", bunifuDatePicker1.Value);
            double valor2 = CRazónCuenta.Razon_cuenta("MUB", bunifuDatePicker2.Value);

            string texto = "Indica que por cada dólar de venta se obtiene un MUB de " + valor1 + " <br> centavos de dolar." +
                            Mensaje_razón(valor1, valor2) + " en el " + bunifuDatePicker2.Value.Year;

            string formula = "Fórmula <br>" +
                                "Utilidad Bruta / Ventas";
            new MessageWindow("Margen de utilidad bruta", texto, formula).Show();
        }

        private void btn_UtilidadOper_Click (object sender, EventArgs e)
        {
            double valor1 = CRazónCuenta.Razon_cuenta("MUO", bunifuDatePicker1.Value);
            double valor2 = CRazónCuenta.Razon_cuenta("MUO", bunifuDatePicker2.Value);

            string texto = "La utilidad de operación representa el " + valor1 + " de las ventas; es decir <br> "
                            + valor1 + " centavos por cada dólar en venta." + Mensaje_razón(valor1, valor2) + "en el " + bunifuDatePicker2.Value.Year;

            string formula = "Fórmula <br>" +
                                 "Utilidad Operativa / ventas";
            new MessageWindow("Margen de utilidad operativa", texto, formula).Show();
        }

        private void btn_UtilidadNeta_Click (object sender, EventArgs e)
        {
            double valor1 = CRazónCuenta.Razon_cuenta("MUN", bunifuDatePicker1.Value);
            double valor2 = CRazónCuenta.Razon_cuenta("MUN", bunifuDatePicker2.Value);

            string texto = "El margen de utilidad neta es de " + valor1 + " centavos por cada dólar <br> en venta." + 
                            Mensaje_razón(valor1, valor2) + "en el " + bunifuDatePicker2.Value.Year;

            string formula = "Fórmula <br>" +
                                "Utilidad Neta / Ventas";
            new MessageWindow("Margen de utilidad neta", texto, formula).Show();
        }

        private void btn_PeriCobro_Click (object sender, EventArgs e)
        {
            string formula = "Fórmula <br>" +
                                 "Costo de ventas / Proveedores";
            string texto = null;
            new MessageWindow("Capital Neto Trabajo", texto, formula).Show();
        }

        private void btn_PasivoCap_Click (object sender, EventArgs e)
        {
            double valor1 = CRazónCuenta.Razon_cuenta("Razon_PasivoCapital", bunifuDatePicker1.Value) * 100;
            double valor2 = CRazónCuenta.Razon_cuenta("Razon_PasivoCapital", bunifuDatePicker2.Value) * 100;

            string texto = "El índice explica que el " + (valor1) + " % de nuestro capital social representa <br>" +
                           "el pasivo a largo plazo." + Mensaje_razón(valor1, valor2) + "% en el " + bunifuDatePicker2.Value.Year;

            string formula = "Fórmula <br>" +
                                 "Pasivo a LP / Capital Social";
            new MessageWindow("Razón pasivo/capital", texto, formula).Show();
        }

        public string Mensaje_razón (double valor1, double valor2)
        {
            if (valor1 > valor2 )
            {
                return "Hubo una disminicion de " + valor2 ;
            }
            else if (valor1 < valor2)
            {
                return "Hubo un aumento de " + valor2;
            }
            else
            {
                return "No hubo cambio";
            }
        }


    }
}
