using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tablademesesacumuladosmeses
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Enlazar de forma forzada los eventos de los botones al iniciar
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Asigna el evento Clic a cualquier botón visible en la pantalla (como 'generar')
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    ((Button)c).Click -= EjecutarCalculo;
                    ((Button)c).Click += EjecutarCalculo;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Método que realiza la lectura y llena el DataGridView
        private void EjecutarCalculo(object sender, EventArgs e)
        {
            // 1. Obtener todas las cajas de texto y la tabla del formulario
            List<TextBox> cajasTexto = ObtenerTodosLosTextBox(this).OrderBy(t => t.Left).ToList();
            DataGridView tabla = ObtenerTodosLosControls<DataGridView>(this).FirstOrDefault();

            if (tabla == null)
            {
                MessageBox.Show("No se encontró la tabla DataGridView en la interfaz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cajasTexto.Count < 3)
            {
                MessageBox.Show($"Se encontraron {cajasTexto.Count} campos de texto. Se requieren 3 campos (Valor, N Meses e Incremento).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Asignación de valores por posición (de izquierda a derecha):
            // Criterio según tu diseño: [Valor] | [numero de meses (N)] | [Incremento mensual proyectado]
            string txtValor = cajasTexto[0].Text;
            string txtMeses = cajasTexto[1].Text;
            string txtIncremento = cajasTexto[2].Text;

            // 2. Convertir y validar los números
            if (!double.TryParse(txtValor, out double valorInicial))
            {
                MessageBox.Show("Ingrese un monto numérico válido en el primer campo (Valor).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtMeses, out double nMesesVal) || nMesesVal <= 0)
            {
                MessageBox.Show("Ingrese un número de meses válido (> 0) en el segundo campo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtIncremento, out double incremento))
            {
                MessageBox.Show("Ingrese un monto válido en el tercer campo (Incremento).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nMeses = (int)Math.Floor(nMesesVal);

            // 3. Limpiar la tabla y calcular
            tabla.Rows.Clear();

            string[] nombresMeses = {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };

            double montoMensual = valorInicial;
            double montoAcumulado = 0;

            for (int i = 0; i < nMeses; i++)
            {
                montoAcumulado += montoMensual;
                string nota = (i == 0) ? "Valor Inicial" : $"+${incremento:N2}";

                tabla.Rows.Add(
                    i + 1,
                    nombresMeses[i % 12],
                    montoMensual.ToString("C2"),
                    montoAcumulado.ToString("C2"),
                    nota
                );

                montoMensual += incremento;
            }

            // Fila final con la suma total
            tabla.Rows.Add("Total", "-", "-", montoAcumulado.ToString("C2"), "Proyección final");
        }

        // Funciones auxiliares para buscar controles incluso si están agrupados
        private List<TextBox> ObtenerTodosLosTextBox(Control contenedor)
        {
            return ObtenerTodosLosControls<TextBox>(contenedor);
        }

        private List<T> ObtenerTodosLosControls<T>(Control contenedor) where T : Control
        {
            List<T> lista = new List<T>();
            foreach (Control c in contenedor.Controls)
            {
                if (c is T) lista.Add((T)c);
                if (c.HasChildren) lista.AddRange(ObtenerTodosLosControls<T>(c));
            }
            return lista;
        }
    }
}