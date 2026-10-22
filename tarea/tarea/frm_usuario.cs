using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tarea
{
    public partial class frm_usuario : Form
    {
        private DataSet ds;
        private CurrencyManager cm;

        public frm_usuario()
        {
            InitializeComponent();
        }

        private void frm_usuario_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Conexion_base_datos conexion = new Conexion_base_datos();
            ds = conexion.crearDs();

            if (ds.Tables["usuarios"].Rows.Count > 0)
            {
                cm = (CurrencyManager)this.BindingContext[ds, "usuarios"];
                MostrarDatos();
            }
        }

        private void MostrarDatos()
        {
            if (ds.Tables["usuarios"].Rows.Count > 0)
            {
                DataRow fila = ds.Tables["usuarios"].Rows[cm.Position];
                txtId.Text = fila["idUsuario"].ToString();
                txtUsuario.Text = fila["usuario"].ToString();
                txtClave.Text = fila["clave"].ToString();
                txtConfirmarClave.Text = fila["clave"].ToString();
                txtNombre.Text = fila["nombre"].ToString();
                txtDireccion.Text = fila["dirección"].ToString();
                txtTelefono.Text = fila["teléfono"].ToString();
            }
        }

        // Métodos con los nombres exactos que espera el diseñador
        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length < 6 || txtUsuario.Text.Length > 16)
            {
                MessageBox.Show("El usuario debe tener entre 6 y 16 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (txtClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarClave.Focus();
                return;
            }

            Conexion_base_datos conexion = new Conexion_base_datos();
            bool exito = conexion.mantenimiento_usuarios_usis018804(
                txtId.Text, txtUsuario.Text, txtClave.Text, txtNombre.Text, txtDireccion.Text, txtTelefono.Text, "Agregar"
            );

            if (exito)
            {
                MessageBox.Show("¡Usuario registrado con éxito!");
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al guardar el registro.");
            }
        }

        private void btnmodificarAlumno_Click(object sender, EventArgs e)
        {
            Conexion_base_datos conexion = new Conexion_base_datos();
            bool exito = conexion.mantenimiento_usuarios_usis018804(
                txtId.Text, txtUsuario.Text, txtClave.Text, txtNombre.Text, txtDireccion.Text, txtTelefono.Text, "Modificar"
            );

            if (exito)
            {
                MessageBox.Show("¡Usuario modificado con éxito!");
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al modificar el registro.");
            }
        }

        private void btnPrimero_Click_Click(object sender, EventArgs e)
        {
            if (cm != null && ds.Tables["usuarios"].Rows.Count > 0)
            {
                cm.Position = 0;
                MostrarDatos();
            }
        }

        private void btnAnterior_Click_Click(object sender, EventArgs e)
        {
            if (cm != null && cm.Position > 0)
            {
                cm.Position--;
                MostrarDatos();
            }
        }

        private void btnSiguiente_Click_Click(object sender, EventArgs e)
        {
            if (cm != null && cm.Position < ds.Tables["usuarios"].Rows.Count - 1)
            {
                cm.Position++;
                MostrarDatos();
            }
        }

        private void btnUltimo_Click_Click(object sender, EventArgs e)
        {
            if (cm != null && ds.Tables["usuarios"].Rows.Count > 0)
            {
                cm.Position = ds.Tables["usuarios"].Rows.Count - 1;
                MostrarDatos();
            }
        }

        // Métodos vacíos para evitar que el diseñador reclame eventos faltantes
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e) { }

    }
}

