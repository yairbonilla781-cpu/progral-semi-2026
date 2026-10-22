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
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Conexion_base_datos conexion = new Conexion_base_datos();
            bool valido = conexion.validarUsuario(txtUsuario.Text, txtClave.Text);

            if (valido)
            {
                MessageBox.Show("¡Bienvenido al sistema!", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frm_usuario ventanaUsuarios = new frm_usuario();
                ventanaUsuarios.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Acceso denegado.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Clear();
                txtClave.Clear();
                txtUsuario.Focus();
            }
        }
    }
}