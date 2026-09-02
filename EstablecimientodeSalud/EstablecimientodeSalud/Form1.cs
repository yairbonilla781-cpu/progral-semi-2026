using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EstablecimientodeSalud
{
    public partial class Form1 : Form
    {
        private List<Paciente> listaPacientes = new List<Paciente>();
        private string prioridadSeleccionada = "";

        
        private TextBox txtNombre;
        private TextBox txtEdad;
        private ComboBox cmbMotivo;
        private DataGridView tabla;

        
        private Label lbl2;
        private Label lbl3;
        private Label lbl4;

        public Form1()
        {
            InitializeComponent();
            EnlazarControles();
        }

        private void EnlazarControles()
        {
            
            var textBoxes = this.Controls.OfType<TextBox>().OrderBy(t => t.Left).ToList();

            if (textBoxes.Count >= 2)
            {
                txtNombre = textBoxes[0];
                txtEdad = textBoxes[1];
            }
            else if (textBoxes.Count == 1)
            {
                txtNombre = textBoxes[0];
            }

            
            cmbMotivo = this.Controls.OfType<ComboBox>().FirstOrDefault();
            tabla = this.Controls.OfType<DataGridView>().FirstOrDefault();

            
            if (tabla != null)
            {
                tabla.AutoGenerateColumns = false;

                
                if (tabla.Columns.Count >= 4)
                {
                    tabla.Columns[0].DataPropertyName = "Nombre";
                    tabla.Columns[1].DataPropertyName = "Edad";
                    tabla.Columns[2].DataPropertyName = "Motivo";
                    tabla.Columns[3].DataPropertyName = "HoraIngreso";
                }
                else if (tabla.Columns.Count == 0)
                {
                    tabla.AutoGenerateColumns = true;
                }
            }

            
            lbl2 = this.Controls.Find("label2", true).FirstOrDefault() as Label;
            lbl3 = this.Controls.Find("label3", true).FirstOrDefault() as Label;
            lbl4 = this.Controls.Find("label4", true).FirstOrDefault() as Label;

            if (lbl2 == null || lbl3 == null || lbl4 == null)
            {
                var labels = this.Controls.OfType<Label>().OrderBy(l => l.Top).ToList();
                if (labels.Count >= 4)
                {
                    lbl2 = labels[1];
                    lbl3 = labels[2];
                    lbl4 = labels[3];
                }
            }

            
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    string texto = btn.Text.ToLower();

                    if (texto.Contains("rojo") || texto.Contains("prioridad 1") || texto.Contains("prioridad i"))
                        btn.Click += (s, e) => SeleccionarPrioridad("Prioridad 1 - Rojo");
                    else if (texto.Contains("amarillo") || texto.Contains("prioridad 2") || texto.Contains("prioridad ii"))
                        btn.Click += (s, e) => SeleccionarPrioridad("Prioridad 2 - Amarillo");
                    else if (texto.Contains("verde") || texto.Contains("prioridad 3") || texto.Contains("prioridad iii"))
                        btn.Click += (s, e) => SeleccionarPrioridad("Prioridad 3 - Verde");
                    else if (texto.Contains("registrar"))
                        btn.Click += RegistrarPaciente;
                    else if (texto.Contains("atender") || texto.Contains("siguiente"))
                        btn.Click += AtenderSiguiente;
                }
            }

           
            if (cmbMotivo != null)
            {
                cmbMotivo.Items.Clear();
                cmbMotivo.Items.Add("General / Chequeo");
                cmbMotivo.Items.Add("Dolor agudo / Lesión");
                cmbMotivo.Items.Add("Fiebre alta");
                cmbMotivo.Items.Add("Emergencia crítica");
                cmbMotivo.SelectedIndex = 0;
            }
        }

        private void SeleccionarPrioridad(string prioridad)
        {
            prioridadSeleccionada = prioridad;
            MessageBox.Show($"Prioridad seleccionada: {prioridad}", "Prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RegistrarPaciente(object sender, EventArgs e)
        {
            if (txtNombre == null || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del paciente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtEdad == null || !int.TryParse(txtEdad.Text.Trim(), out int edad) || edad < 0 || edad > 120)
            {
                MessageBox.Show("Por favor, ingrese una edad válida (debe estar entre 0 y 120 años).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(prioridadSeleccionada))
            {
                MessageBox.Show("Seleccione un botón de prioridad (Rojo, Amarillo o Verde).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Paciente nuevo = new Paciente
            {
                Nombre = txtNombre.Text.Trim(),
                Edad = edad,
                Motivo = cmbMotivo?.SelectedItem?.ToString() ?? "General",
                Prioridad = prioridadSeleccionada,
                HoraIngreso = DateTime.Now.ToString("hh:mm:ss tt")
            };

            listaPacientes.Add(nuevo);
            RefrescarTabla();

            txtNombre.Clear();
            txtEdad.Clear();
            prioridadSeleccionada = "";
        }

        private void AtenderSiguiente(object sender, EventArgs e)
        {
            if (listaPacientes.Count == 0)
            {
                MessageBox.Show("No hay pacientes en espera.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            Paciente siguiente = listaPacientes
                .OrderBy(p => p.Prioridad.Contains("Rojo") ? 1 : p.Prioridad.Contains("Amarillo") ? 2 : 3)
                .First();

            if (lbl2 != null) lbl2.Text = $"Nombre: {siguiente.Nombre} ({siguiente.Edad} años)";
            if (lbl3 != null) lbl3.Text = $"Motivo: {siguiente.Motivo}";
            if (lbl4 != null) lbl4.Text = $"Prioridad: {siguiente.Prioridad}";

            listaPacientes.Remove(siguiente);
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            if (tabla != null)
            {
                tabla.DataSource = null;
                tabla.DataSource = listaPacientes.ToList();
            }
        }

        
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }

    
    public class Paciente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Motivo { get; set; }
        public string Prioridad { get; set; }
        public string HoraIngreso { get; set; }
    }
}