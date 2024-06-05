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

        public List<Tarea> ObtenerTareas()
        {
            List<Tarea> tareas = new List<Tarea>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT * FROM Tarea";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tarea tarea = new Tarea
                                {
                                    ID = reader.GetInt32("ID"),
                                    Nombre = reader.GetString("Nombre"),
                                    Tipo = reader.GetString("Tipo"),
                                    Comentario = reader.GetString("Comentario"),
                                    Cursos_ID = reader.GetInt32("Cursos_ID")
                                };
                                tareas.Add(tarea);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tareas: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return tareas;
        }

        public void modificarTarea(Tarea tareaModificada)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "UPDATE Tarea SET Nombre = @Nombre, Tipo = @Tipo, Comentario = @Comentario, Cursos_ID = @Cursos_ID WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", tareaModificada.ID);
                        command.Parameters.AddWithValue("@Nombre", tareaModificada.Nombre);
                        command.Parameters.AddWithValue("@Tipo", tareaModificada.Tipo);
                        command.Parameters.AddWithValue("@Comentario", tareaModificada.Comentario);
                        command.Parameters.AddWithValue("@Cursos_ID", tareaModificada.Cursos_ID);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Tarea modificada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar tarea: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public void eliminarTarea(int tareaID)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "DELETE FROM Tarea WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", tareaID);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Tarea eliminada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar tarea: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public int obtenerIDTarea(string nombre, string comentario)
        {
            int tareaID = 0;
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT ID FROM tarea WHERE Nombre = @Nombre AND Comentario = @Comentario";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Comentario", comentario);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tareaID = reader.GetInt32("ID");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ID de la tarea: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return tareaID;
        }

    }
}
