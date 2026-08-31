using System;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                string empleado = txtEmpleado.Text.Trim();
                string textoSueldo = txtSueldo.Text.Trim().Replace(',', '.');

                if (string.IsNullOrEmpty(empleado))
                {
                    MessageBox.Show("Ingresa el nombre del empleado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmpleado.Focus();
                    return;
                }

                if (!decimal.TryParse(textoSueldo, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal sueldo) || sueldo <= 0)
                {
                    MessageBox.Show("Sueldo inválido. Ejemplo: 200 o 200.50", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSueldo.Focus();
                    return;
                }

                // 1. Descuentos de Ley (ISSS y AFP)
                decimal isss = sueldo * 0.03m;
                if (isss > 30.00m) isss = 30.00m; // Tope máximo del ISSS $30.00

                decimal afp = sueldo * 0.0725m;

                // 2. Base imponible para Renta
                decimal sueldoImponible = sueldo - isss - afp;

                // 3. Cálculo de Renta (Tabla de Retención mensual El Salvador)
                decimal renta = 0m;

                if (sueldoImponible > 2038.10m)
                {
                    renta = (sueldoImponible - 2038.10m) * 0.30m + 288.57m;
                }
                else if (sueldoImponible > 895.24m)
                {
                    renta = (sueldoImponible - 895.24m) * 0.20m + 60.00m;
                }
                else if (sueldoImponible > 472.00m)
                {
                    renta = (sueldoImponible - 472.00m) * 0.10m + 17.67m;
                }

                // 4. Totales
                decimal deducciones = isss + afp + renta;
                decimal pago = sueldo - deducciones;

                // 5. Agregar fila al DataGridView (Coincidiendo con el orden visual de tu interfaz)
                // Col 1: Empleado | Col 2: Sueldo | Col 3: Renta | Col 4: ISSS 3% | Col 5: AFP 7.25% | Col 6: Deducciones | Col 7: Pago
                dataGridView1.Rows.Add(
                    empleado,
                    sueldo.ToString("N2"),
                    renta.ToString("N2"),
                    isss.ToString("N2"),
                    afp.ToString("N2"),
                    deducciones.ToString("N2"),
                    pago.ToString("N2")
                );

                // Limpiar campos
                txtEmpleado.Clear();
                txtSueldo.Clear();
                txtEmpleado.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            txtEmpleado.Clear();
            txtSueldo.Clear();
            txtEmpleado.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}