using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Esta libreria es para usar bases de datos
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates; //Esta libreria permite usar SQLServer

namespace WindowsFormsApp2
{
    internal class conexion
    {
        //Definir los miembros, atributos y metodos de la clase
        public SqlConnection objconexion = new SqlConnection(); //conectarme a la BD
        public SqlCommand objcomand = new SqlCommand(); //Ejecutar consultas (Insert, update, delete, select) SQL en la BD
        public SqlDataAdapter objDataAdapter = new SqlDataAdapter();//un puente entre la BD y la aplicacion.
        DataSet objDs = new DataSet();//Representa una copia en memoria de la arquitectura de la BD
        private string cadenaCoenxion;
        private SqlCommand objecomando;

        public conexion()
        {
            string cadena = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\db_academica.mdf;Integrated Security=True;";
            cadenaCoenxion = cadena;
            objconexion.ConnectionString = cadenaCoenxion;
        }

      
        public DataSet obtenerDatos()
        {
            objDs.Clear(); // Limpiar el DataSet.
            objcomand.Connection = objconexion; // Establecer la conexión para ejecutar consultas a la BD

            objDataAdapter.SelectCommand = objecomando;
            objcomand.CommandText = "SELECT * FROM alumnos";
            objDataAdapter.Fill(objDs,"alumnos");//tomamos los datos de la BD y llenamos el ds

            return objDs;
        }
    }
}