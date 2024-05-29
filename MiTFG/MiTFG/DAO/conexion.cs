using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiTFG.DAO
{
    internal class conexion
    {
        MySqlConnection conexionS = new MySqlConnection();
        static string servidor = "localhost";
        static string db = "classassit";
        static string usuario = "root";
        static string password = "";
        static string puerto = "3306";
        string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario
        + "; password=" + password + "; database=" + db + ";";
        public MySqlConnection establecerConexion()
        {
            try
            {
                conexionS.ConnectionString = cadenaConexion;
                conexionS.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos, error: " + ex.ToString());
            }
            return conexionS;
        }
        public void cerrarConexion()
        {
            conexionS.Close();
        }
    }
}
