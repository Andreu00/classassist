using MiTFG.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiTFG.DAO
{
    internal class DAOFaltas
    {
        public void AgregarFalta(FaltaDeAsistencia falta)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "INSERT INTO FaltasDeAsistencia (Fecha, Hora, AlumnoID, AsignaturaID) VALUES (@Fecha, @Hora, @AlumnoID, @AsignaturaID)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", falta.Fecha);
                        command.Parameters.AddWithValue("@Hora", falta.Hora);
                        command.Parameters.AddWithValue("@AlumnoID", falta.AlumnoID);
                        command.Parameters.AddWithValue("@AsignaturaID", falta.AsignaturaID);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Falta de asistencia añadida con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir falta de asistencia: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }
    }
}
