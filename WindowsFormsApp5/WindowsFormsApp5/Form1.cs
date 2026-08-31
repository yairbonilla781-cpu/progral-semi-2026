using System;
using System.Windows.Forms;

namespace WindowsFormsApp5 // Espacio de nombres corregido al proyecto actual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Evento del botón "calcular"
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtEmpleado.Text) || string.IsNullOrWhiteSpace(txtSueldo.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del empleado y su sueldo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el sueldo sea un número válido
            if (double.TryParse(txtSueldo.Text, out double sueldo))
            {
                string empleado = txtEmpleado.Text;

                // 1. Cálculo de ISSS (3%)
                // Techo máximo de $30 (3% de $1000).
                double isss = sueldo * 0.03;
                if (isss > 30.00)
                {
                    isss = 30.00;
                }

                // 2. Cálculo de AFP (7.25%)
                double afp = sueldo * 0.0725;

                // 3. Cálculo de Renta 
                double salarioMenosDescuentos = sueldo - isss - afp;
                double renta = 0;

                if (salarioMenosDescuentos > 472.00 && salarioMenosDescuentos <= 895.24)
                {
                    renta = (salarioMenosDescuentos - 472.00) * 0.10 + 17.67;
                }
                else if (salarioMenosDescuentos > 895.24 && salarioMenosDescuentos <= 2038.10)
                {
                    renta = (salarioMenosDescuentos - 895.24) * 0.20 + 60.00;
                }
                else if (salarioMenosDescuentos > 2038.10)
                {
                    renta = (salarioMenosDescuentos - 2038.10) * 0.30 + 288.57;
                }

                // 4. Total de Deducciones y Pago Neto
                double deducciones = isss + afp + renta;
                double pagoNeto = sueldo - deducciones;

                // Agregar los datos como una nueva fila en el DataGridView
                dataGridView1.Rows.Add(
                    empleado,
                    sueldo.ToString("F2"),
                    renta.ToString("F2"),
                    isss.ToString("F2"),
                    afp.ToString("F2"),
                    deducciones.ToString("F2"),
                    pagoNeto.ToString("F2")
                );
            }
            else
            {
                MessageBox.Show("El sueldo ingresado no tiene un formato numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón "agregar otro"
        private void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            // Limpiar las cajas de texto para ingresar uno nuevo
            txtEmpleado.Clear();
            txtSueldo.Clear();

            // Poner el cursor nuevamente en el campo del empleado
            txtEmpleado.Focus();
        }

        // Evento del botón "salir"
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación
            Application.Exit();
        }
    }
}