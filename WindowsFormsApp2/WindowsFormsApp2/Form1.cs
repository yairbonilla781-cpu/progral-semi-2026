using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }


// 2. El namespace envuelve la clase
namespace Calcularlasdeduccionesdeley
    {
        // 3. La clase del formulario
        public partial class Form1 : Form
        {
            public Form1()
            {
           
            }

            private void btnCalcular_Click(object sender, EventArgs e)
            {
                // Código de tu botón aquí
            }
        }
    } 
  
          
namespace WindowsFormsApp2
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
               
                }

                private void btnCalcular_Click(object sender, EventArgs e)
                {
                    Calcular();
                }

                private void button1_Click(object sender, EventArgs e)
                {
                    Calcular();
                }

                private void Calcular()
                {
                    // Busca primero txtSalarioBruto o textBox1 para leer el monto
                    string textoMonto = "";

                    Control[] controles = this.Controls.Find("txtSalarioBruto", true);
                    if (controles.Length > 0 && controles[0] is TextBox)
                    {
                        textoMonto = ((TextBox)controles[0]).Text;
                    }
                    else
                    {
                        controles = this.Controls.Find("textBox1", true);
                        if (controles.Length > 0 && controles[0] is TextBox)
                        {
                            textoMonto = ((TextBox)controles[0]).Text;
                        }
                    }

                    if (decimal.TryParse(textoMonto, out decimal salarioBruto) && salarioBruto > 0)
                    {
                        // 1. ISSS (3% con tope máximo de $30.00)
                        decimal deduccionISSS = Math.Min(salarioBruto * 0.03m, 30.00m);

                        // 2. AFP (7.25% sin tope)
                        decimal deduccionAFP = salarioBruto * 0.0725m;

                        // 3. Base Renta
                        decimal baseRenta = salarioBruto - deduccionISSS - deduccionAFP;

                        // 4. ISR según tramos
                        decimal deduccionISR = CalcularISR(baseRenta);

                        // 5. Totales
                        decimal totalDeducciones = deduccionISSS + deduccionAFP + deduccionISR;
                        decimal salarioLiquido = salarioBruto - totalDeducciones;

                        MessageBox.Show($"Salario Bruto: ${salarioBruto:F2}\n\n" +
                                        $"Descuento ISSS (3%): ${deduccionISSS:F2}\n" +
                                        $"Descuento AFP (7.25%): ${deduccionAFP:F2}\n" +
                                        $"Descuento ISR (Renta): ${deduccionISR:F2}\n" +
                                        $"----------------------------------\n" +
                                        $"Total Deducciones: ${totalDeducciones:F2}\n\n" +
                                        $"SALARIO LÍQUIDO: ${salarioLiquido:F2}",
                                        "Resultado del Cálculo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un número válido en la casilla de salario.",
                                        "Monto Inválido",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }

                private decimal CalcularISR(decimal baseRenta)
                {
                    if (baseRenta <= 472.00m)
                        return 0.00m;
                    else if (baseRenta <= 895.24m)
                        return ((baseRenta - 472.00m) * 0.10m) + 17.67m;
                    else if (baseRenta <= 2038.10m)
                        return ((baseRenta - 895.24m) * 0.20m) + 60.00m;
                    else
                        return ((baseRenta - 2038.10m) * 0.30m) + 288.57m;
                }
            }
    }
}
