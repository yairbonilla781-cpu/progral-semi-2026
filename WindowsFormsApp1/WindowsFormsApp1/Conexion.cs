using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data; //Esta libreria es para usar bases de datos
using System.Data.SqlClient; //ESTA libreria permite usar SQLServer
namespace WindowsFormsApp1
{
    internal class Conexion
    {
        //Definir los miembro, atributos y metodos de la clase
        public SqlConnection objconexion = new SqlConnection();//conectarme a la BD
    }
}

