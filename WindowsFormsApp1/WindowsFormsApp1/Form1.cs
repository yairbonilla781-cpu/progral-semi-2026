using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
        
          

namespace Calcularlasdeduccionesdeley
    {
        public partial class Form1 : Form
        {
            private object txtSalarioBruto;

            private void btnCalcular_Click(object sender, EventArgs e)
            {
                // Intenta leer el valor de la caja de texto llamada txtSalarioBruto
                // Si el control se llama textBox1 en tu diseño, cambia txtSalarioBruto por textBox1
                if (!(decimal.TryParse(txtSalarioBruto.Text, out decimal salarioBruto) && salarioBruto > 0))
                {
                    MessageBox.Show("Por favor, ingrese un número válido en la caja de salario.",
                                    "Monto Inválido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    // 1. ISSS (3% con tope máximo de $30.00)
                    decimal deduccionISSS = Math.Min(salarioBruto * 0.03m, 30.00m);

                    // 2. AFP (7.25% sin tope)
                    decimal deduccionAFP = salarioBruto * 0.0725m;

                    // 3. Base para Renta
                    decimal baseRenta = salarioBruto - deduccionISSS - deduccionAFP;

                    // 4. ISR según tramos
                    decimal deduccionISR = CalcularISR(baseRenta);

                    // 5. Salario Líquido final
                    decimal totalDeducciones = deduccionISSS + deduccionAFP + deduccionISR;
                    decimal salarioLiquido = salarioBruto - totalDeducciones;

                    // Muestra el resultado en una ventana emergente limpia
                    MessageBox.Show($"RESUMEN DE DEDUCCIONES\n\n" +
                                    $"Salario Bruto: ${salarioBruto:F2}\n" +
                                    $"ISSS (3%): ${deduccionISSS:F2}\n" +
                                    $"AFP (7.25%): ${deduccionAFP:F2}\n" +
                                    $"ISR (Renta): ${deduccionISR:F2}\n" +
                                    $"----------------------------------\n" +
                                    $"Total Deducciones: ${totalDeducciones:F2}\n\n" +
                                    $"SALARIO LÍQUIDO: ${salarioLiquido:F2}",
                                    "Cálculo Exitoso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
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
    }
}
