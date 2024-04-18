using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace AppRestcliente.Conexion
{
    public class CONEXIONMAESTRA
    {
        public static string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "connection.txt");
        public static string text = File.ReadAllText(ruta);
        public static string conexion = text;
        public static SqlConnection conectar = new SqlConnection(conexion);
        public static void abrir()
        { 
            if(conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
        public static void cerrar ()
        {
            if(conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
