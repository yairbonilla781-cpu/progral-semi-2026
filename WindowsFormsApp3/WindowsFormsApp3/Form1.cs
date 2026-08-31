using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private int contador = 1;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnSalir;

        public Form1()
        {
            InitializeComponent();              // método generado por el diseñador
            InitializeCustomComponents();       // tu inicialización personalizada
            if (dgvEmpleados == null)
            {
                dgvEmpleados = new System.Windows.Forms.DataGridView
                {
                    Name = "dgvEmpleados",
                    Location = new System.Drawing.Point(10, 10),
                    Size = new System.Drawing.Size(700, 250),
                    AllowUserToAddRows = false
                };
                this.Controls.Add(dgvEmpleados);
            }

            ConfigurarDataGridView();
        }

        private void InitializeCustomComponents()
        {
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();

            // txtEmpleado
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Location = new System.Drawing.Point(10, 270);
            this.txtEmpleado.Size = new System.Drawing.Size(200, 23);

            // txtSueldo
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.Location = new System.Drawing.Point(220, 270);
            this.txtSueldo.Size = new System.Drawing.Size(100, 23);

            // btnAgregar
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new System.Drawing.Point(330, 268);
            this.btnAgregar.Size = new System.Drawing.Size(75, 25);
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // btnCalcular (si lo usas)
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.Location = new System.Drawing.Point(410, 268);
            this.btnCalcular.Size = new System.Drawing.Size(75, 25);
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);

            // btnSalir
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir";
            this.btnSalir.Location = new System.Drawing.Point(490, 268);
            this.btnSalir.Size = new System.Drawing.Size(75, 25);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // Añadir controles al formulario
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.txtSueldo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.btnSalir);
        }

        private void ConfigurarDataGridView()
        {
            if (dgvEmpleados == null)
            {
                dgvEmpleados = new System.Windows.Forms.DataGridView();
                this.Controls.Add(dgvEmpleados);
            }

            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.Columns.Clear();

            dgvEmpleados.Columns.Add("colNum", "#");
            dgvEmpleados.Columns.Add("colEmpleado", "Empleado");

            dgvEmpleados.Columns.Add("colSueldo1", "sueldo");
            dgvEmpleados.Columns.Add("colSueldo2", "sueldo");

            dgvEmpleados.Columns.Add("colISSS", "ISSS");
            dgvEmpleados.Columns.Add("colAFP", "afp");
            dgvEmpleados.Columns.Add("colDeducciones", "deducciones");
            dgvEmpleados.Columns.Add("colPago", "pago");
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Opcional: podrías mostrar resultados en labels,
            // pero como tu imagen muestra tabla, calculamos al agregar.

            // Validación básica
            if (!decimal.TryParse(txtSueldo.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal sueldo))
            {
                MessageBox.Show("Ingresa un sueldo válido.");
                return;
            }

            if (sueldo < 0)
            {
                MessageBox.Show("El sueldo no puede ser negativo.");
                return;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validación
            string empleado = txtEmpleado.Text.Trim();

            if (string.IsNullOrWhiteSpace(empleado))
            {
                MessageBox.Show("Ingresa el nombre del empleado.");
                return;
            }

            if (!decimal.TryParse(txtSueldo.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal sueldo))
            {
                MessageBox.Show("Ingresa un sueldo válido (ej: 1000.50).");
                return;
            }

            // 📌 Fórmulas (ajústalas si tu tarea usa otros porcentajes)
            decimal issS = sueldo * 0.03m;  // ejemplo 3%
            decimal afp = sueldo * 0.0725m; // ejemplo 7.25%

            decimal deducciones = issS + afp;
            decimal pago = sueldo - deducciones;

            dgvEmpleados.Rows.Add(
                contador++,
                empleado,
                sueldo.ToString("0.00"),
                sueldo.ToString("0.00"),
                issS.ToString("0.00"),
                afp.ToString("0.00"),
                deducciones.ToString("0.00"),
                pago.ToString("0.00")
            );

            // Limpieza opcional
            txtSueldo.Clear();
            txtSueldo.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}