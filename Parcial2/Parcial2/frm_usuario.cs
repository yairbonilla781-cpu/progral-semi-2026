using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public partial class frm_usuario : Form
{
    private int posicionActual = 0;
    private DataSet dsUsuarios;
    private object txtUsuario;

    public frm_usuario()
    {
        InitializeComponent();
        CargarDatos();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void CargarDatos()
    {
        Conexion_base_datos db = new Conexion_base_datos();
        dsUsuarios = db.crearDs("SELECT * FROM usuarios_usis018804");
        MostrarRegistro(posicionActual);
    }

    private void MostrarRegistro(int index)
    {
        if (dsUsuarios != null && dsUsuarios.Tables["usuarios_usis018804"].Rows.Count > 0)
        {
            DataRow fila = dsUsuarios.Tables["usuarios_usis018804"].Rows[index];
            txtUsuario.Text = fila["usuario"].ToString();
            txtClave.Text = fila["clave"].ToString();
            txtConfirmarClave.Text = fila["clave"].ToString();
            txtNombre.Text = fila["nombre"].ToString();
            txtDireccion.Text = fila["dirección"].ToString();
            txtTelefono.Text = fila["teléfono"].ToString();
        }
    }

    // Método privado para validar todas las reglas antes de guardar o modificar
    private bool ValidarFormulario()
    {
        // 1. Validar que el usuario tenga como mínimo 6 caracteres y como máximo 16
        if (txtUsuario.Text.Length < 6 || txtUsuario.Text.Length > 16)
        {
            MessageBox.Show("El usuario debe tener un mínimo de 6 caracteres y un máximo de 16.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsuario.Focus();
            return false;
        }

        // 2. Validar que la clave y la confirmación coincidan
        if (txtClave.Text != txtConfirmarClave.Text)
        {
            MessageBox.Show("Las contraseñas no coinciden. Por favor, verifíquelas.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmarClave.Focus();
            return false;
        }

        // 3. Validar que la clave contenga obligatoriamente letras y números
        bool tieneLetras = Regex.IsMatch(txtClave.Text, "[a-zA-Z]");
        bool tieneNumeros = Regex.IsMatch(txtClave.Text, "[0-9]");

        if (!tieneLetras || !tieneNumeros)
        {
            MessageBox.Show("La clave debe llevar obligatoriamente letras y números.", "Error de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtClave.Focus();
            return false;
        }

        return true;
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        string sql = $"INSERT INTO usuarios_usis018804 (usuario, clave, nombre, dirección, teléfono) VALUES ('{txtUsuario.Text}', '{txtClave.Text}', '{txtNombre.Text}', '{txtDireccion.Text}', '{txtTelefono.Text}')";

        Conexion_base_datos db = new Conexion_base_datos();
        int resultado = db.mantenimiento_usuarios_usis018804(sql);

        if (resultado > 0)
        {
            MessageBox.Show("¡Usuario registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }
        else
        {
            MessageBox.Show("No se pudo registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        string sql = $"UPDATE usuarios_usis018804 SET clave='{txtClave.Text}', nombre='{txtNombre.Text}', dirección='{txtDireccion.Text}', teléfono='{txtTelefono.Text}' WHERE usuario='{txtUsuario.Text}'";

        Conexion_base_datos db = new Conexion_base_datos();
        int resultado = db.mantenimiento_usuarios_usis018804(sql);

        if (resultado > 0)
        {
            MessageBox.Show("¡Usuario modificado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }
        else
        {
            MessageBox.Show("No se pudo modificar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        string sql = $"DELETE FROM usuarios_usis018804 WHERE usuario='{txtUsuario.Text}'";

        Conexion_base_datos db = new Conexion_base_datos();
        int resultado = db.mantenimiento_usuarios_usis018804(sql);

        if (resultado > 0)
        {
            MessageBox.Show("¡Usuario eliminado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }
        else
        {
            MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Botones de Navegación
    private void btnSiguiente_Click(object sender, EventArgs e)
    {
        if (dsUsuarios != null && posicionActual < dsUsuarios.Tables["usuarios_usis018804"].Rows.Count - 1)
        {
            posicionActual++;
            MostrarRegistro(posicionActual);
        }
    }

    private void btnAnterior_Click(object sender, EventArgs e)
    {
        if (dsUsuarios != null && posicionActual > 0)
        {
            posicionActual--;
            MostrarRegistro(posicionActual);
        }
    }
}