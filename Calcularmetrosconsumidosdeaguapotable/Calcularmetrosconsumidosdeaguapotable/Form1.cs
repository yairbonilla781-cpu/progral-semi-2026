using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculadoraAgua
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Validar que se haya ingresado un número válido
            if (double.TryParse(txtConsumo.Text, out double metros) && metros >= 0)
            {
                double total = 0;

                // Cálculo por tramos progresivos
                if (metros <= 10)
                {
                    total = 3.00; // Tarifa mínima fija
                }
                else if (metros <= 30)
                {
                    total = 3.00 + ((metros - 10) * 0.50);
                }
                else if (metros <= 50)
                {
                    total = 3.00 + (20 * 0.50) + ((metros - 30) * 0.80);
                }
                else
                {
                    total = 3.00 + (20 * 0.50) + (20 * 0.80) + ((metros - 50) * 1.20);
                }

                // Mostrar el resultado formateado en la etiqueta
                lblResultado.Text = $"Total a pagar: ${total:F2}";
                lblResultado.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número válido de metros consumidos.",
                                "Error de Entrada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtConsumo.Focus();
                txtConsumo.SelectAll();
            }
        }
    }
}