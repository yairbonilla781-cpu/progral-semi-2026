using System;
using System.Data;
using System.Data.SqlClient;

public class Conexion_base_datos
{
    private string cadenaConexion = "Server=(localdb)\\MSSQLLocalDB;Database=tarea;Trusted_Connection=True;";

    public DataSet crearDs()
    {
        DataSet ds = new DataSet();
        string query = "SELECT * FROM usuarios_usis018804";

        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            try
            {
                conexion.Open();

                // 1. Crea la tabla automáticamente si no existe en la base de datos
                string crearTabla = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='usuarios_usis018804' and xtype='U')
                    CREATE TABLE usuarios_usis018804 (
                        idUsuario INT IDENTITY(1,1) PRIMARY KEY,
                        usuario VARCHAR(35),
                        clave VARCHAR(35),
                        nombre VARCHAR(65),
                        dirección VARCHAR(85),
                        teléfono VARCHAR(9)
                    )";
                using (SqlCommand cmdTabla = new SqlCommand(crearTabla, conexion))
                {
                    cmdTabla.ExecuteNonQuery();
                }

                // 2. Llena el DataSet con los registros
                SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                adaptador.Fill(ds, "usuarios");

                // 3. Si la tabla está vacía, inserta un registro por defecto automáticamente
                if (ds.Tables["usuarios"].Rows.Count == 0)
                {
                    string insertDefault = "INSERT INTO usuarios_usis018804 (usuario, clave, nombre, dirección, teléfono) VALUES ('admin', '12345', 'Administrador', 'El Salvador', '123456789')";
                    using (SqlCommand cmdInsert = new SqlCommand(insertDefault, conexion))
                    {
                        cmdInsert.ExecuteNonQuery();
                    }
                    ds.Clear();
                    adaptador.Fill(ds, "usuarios");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el DataSet: " + ex.Message);
            }
        }

        return ds;
    }

    public bool mantenimiento_usuarios_usis018804(string id, string usuario, string clave, string nombre, string direccion, string telefono, string accion)
    {
        string sql = "";

        if (accion == "Agregar")
        {
            sql = "INSERT INTO usuarios_usis018804 (usuario, clave, nombre, dirección, teléfono) VALUES ('" + usuario + "', '" + clave + "', '" + nombre + "', '" + direccion + "', '" + telefono + "')";
        }
        else if (accion == "Modificar")
        {
            sql = "UPDATE usuarios_usis018804 SET usuario = '" + usuario + "', clave = '" + clave + "', nombre = '" + nombre + "', dirección = '" + direccion + "', teléfono = '" + telefono + "' WHERE idUsuario = " + id;
        }
        else if (accion == "Eliminar")
        {
            sql = "DELETE FROM usuarios_usis018804 WHERE idUsuario = " + id;
        }

        return procesar(sql);
    }

    public bool procesar(string sql)
    {
        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    // Método temporal que permite el acceso con cualquier usuario y contraseña
    public bool validarUsuario(string usuario, string clave)
    {
        return true;
    }
}