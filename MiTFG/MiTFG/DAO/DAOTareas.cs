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
        public void AgregarTarea(Tarea tarea)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "INSERT INTO Tarea (Nombre, Asignaturas_ID, Tipo, Comentario, Evaluacion) VALUES (@Nombre, @Asignaturas_ID, @Tipo, @Comentario, @Evaluacion)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", tarea.Nombre);
                        command.Parameters.AddWithValue("@Asignaturas_ID", tarea.Asignaturas_ID);
                        command.Parameters.AddWithValue("@Tipo", tarea.Tipo);
                        command.Parameters.AddWithValue("@Comentario", tarea.Comentario);
                        command.Parameters.AddWithValue("@Evaluacion", tarea.Evaluacion);

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
                                    Asignaturas_ID = reader.GetInt32("Asignaturas_ID"),
                                    Tipo = reader.GetString("Tipo"),
                                    Comentario = reader.GetString("Comentario"),
                                    Evaluacion = reader.GetString("Evaluacion")
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

        public void ModificarTarea(Tarea tarea)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "UPDATE Tarea SET Nombre = @Nombre, Asignaturas_ID = @Asignaturas_ID, Tipo = @Tipo, Comentario = @Comentario, Evaluacion = @Evaluacion WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", tarea.Nombre);
                        command.Parameters.AddWithValue("@Asignaturas_ID", tarea.Asignaturas_ID);
                        command.Parameters.AddWithValue("@Tipo", tarea.Tipo);
                        command.Parameters.AddWithValue("@Comentario", tarea.Comentario);
                        command.Parameters.AddWithValue("@Evaluacion", tarea.Evaluacion);
                        command.Parameters.AddWithValue("@ID", tarea.ID);

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

        public void EliminarTarea(int tareaID)
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

        public List<Tarea> ObtenerTareasPorAsignatura(int asignaturaID)
        {
            List<Tarea> tareas = new List<Tarea>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT * FROM tarea WHERE Asignaturas_ID = @AsignaturaID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AsignaturaID", asignaturaID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tarea tarea = new Tarea
                                {
                                    ID = reader.GetInt32("ID"),
                                    Nombre = reader.GetString("Nombre"),
                                    Asignaturas_ID = reader.GetInt32("Asignaturas_ID"),
                                    Tipo = reader.GetString("Tipo"),
                                    Comentario = reader.IsDBNull(reader.GetOrdinal("Comentario")) ? null : reader.GetString("Comentario"),
                                    Evaluacion = reader.GetString("Evaluacion")
                                };
                                tareas.Add(tarea);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tareas por asignatura: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return tareas;
        }

        public List<Tarea> ObtenerTareasPorCurso(int cursoID)
        {
            List<Tarea> tareas = new List<Tarea>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    // Primero, obtenemos las asignaturas del curso
                    string queryAsignaturas = "SELECT ID FROM asignaturas WHERE CursoID = @CursoID";
                    List<int> asignaturasIDs = new List<int>();

                    using (MySqlCommand commandAsignaturas = new MySqlCommand(queryAsignaturas, connection))
                    {
                        commandAsignaturas.Parameters.AddWithValue("@CursoID", cursoID);
                        using (MySqlDataReader readerAsignaturas = commandAsignaturas.ExecuteReader())
                        {
                            while (readerAsignaturas.Read())
                            {
                                asignaturasIDs.Add(readerAsignaturas.GetInt32("ID"));
                            }
                        }
                    }

                    // Ahora, obtenemos las tareas de cada asignatura
                    foreach (int asignaturaID in asignaturasIDs)
                    {
                        string queryTareas = "SELECT * FROM tarea WHERE asignaturas_ID = @AsignaturaID";

                        using (MySqlCommand commandTareas = new MySqlCommand(queryTareas, connection))
                        {
                            commandTareas.Parameters.AddWithValue("@AsignaturaID", asignaturaID);
                            using (MySqlDataReader readerTareas = commandTareas.ExecuteReader())
                            {
                                while (readerTareas.Read())
                                {
                                    Tarea tarea = new Tarea
                                    {
                                        ID = readerTareas.GetInt32("ID"),
                                        Nombre = readerTareas.GetString("Nombre"),
                                        Asignaturas_ID = readerTareas.GetInt32("Asignaturas_ID"),
                                        Tipo = readerTareas.GetString("Tipo"),
                                        Comentario = readerTareas.IsDBNull(readerTareas.GetOrdinal("Comentario")) ? null : readerTareas.GetString("Comentario"),
                                        Evaluacion = readerTareas.GetString("Evaluacion")
                                    };
                                    tareas.Add(tarea);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tareas por curso: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return tareas;
        }

        // Método para asignar nota
        public void asignarNota(int alumnoID, int tareaID, double nota)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "UPDATE alumnotarea SET nota = @Nota WHERE alumnos_ID = @AlumnoID AND tarea_ID = @TareaID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nota", nota);
                        command.Parameters.AddWithValue("@AlumnoID", alumnoID);
                        command.Parameters.AddWithValue("@TareaID", tareaID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar nota: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }
    }
}
