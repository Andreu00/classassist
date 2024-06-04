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
    internal class DAOTareas
    {
        public void agregarTarea(Tarea nuevaTarea)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "INSERT INTO Tarea (Nombre, Tipo, Comentario, Cursos_ID) VALUES (@Nombre, @Tipo, @Comentario, @Cursos_ID)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nuevaTarea.Nombre);
                        command.Parameters.AddWithValue("@Tipo", nuevaTarea.Tipo);
                        command.Parameters.AddWithValue("@Comentario", nuevaTarea.Comentario);
                        command.Parameters.AddWithValue("@Cursos_ID", nuevaTarea.Cursos_ID);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Tarea añadida con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir tarea: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

    }
}
