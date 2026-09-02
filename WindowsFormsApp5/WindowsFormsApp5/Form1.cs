using System;
using System.Windows.Forms;

namespace WindowsFormsApp5 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtEmpleado.Text) || string.IsNullOrWhiteSpace(txtSueldo.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del empleado y su sueldo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (double.TryParse(txtSueldo.Text, out double sueldo))
            {
                string empleado = txtEmpleado.Text;

                
                
                double isss = sueldo * 0.03;
                if (isss > 30.00)
                {
                    isss = 30.00;
                }

                
                double afp = sueldo * 0.0725;

                
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

                
                double deducciones = isss + afp + renta;
                double pagoNeto = sueldo - deducciones;

                
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

        
        private void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            
            txtEmpleado.Clear();
            txtSueldo.Clear();

            
            txtEmpleado.Focus();
        }

        
        private void btnSalir_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Close(); 
        }
    }
}