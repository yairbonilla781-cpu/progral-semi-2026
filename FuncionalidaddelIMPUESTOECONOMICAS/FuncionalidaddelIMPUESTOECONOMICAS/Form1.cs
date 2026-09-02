using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace FuncionalidaddelIMPUESTOECONOMICAS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal monto))
            {
                decimal impuesto = 0m;

                if (monto >= 1000.01m)
                {
                    decimal excedente = monto - 1000.01m;
                    impuesto = (excedente / 1000m) * 3m + 3m;
                }
                else
                {
                    impuesto = 3m;
                }

                impuesto = Math.Round(impuesto, 2);
                label2.Text = $"Valor a pagar: ${impuesto}";
            }
            else
            {
                MessageBox.Show("Monto inválido. Revisa si debes usar coma (,) en lugar de punto (.) para los decimales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}