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
                    string query = "INSERT INTO faltasdeasistencia (Fecha, Hora, AlumnoID, AsignaturaID, Estado) VALUES (@Fecha, @Hora, @AlumnoID, @AsignaturaID, @Estado)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", falta.Fecha);
                        command.Parameters.AddWithValue("@Hora", falta.Hora);
                        command.Parameters.AddWithValue("@AlumnoID", falta.AlumnoID);
                        command.Parameters.AddWithValue("@AsignaturaID", falta.AsignaturaID);
                        command.Parameters.AddWithValue("@Estado", falta.Estado);
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

        public List<FaltaDeAsistencia> ObtenerFaltasAsistenciaPorCursoYFecha(int cursoID, DateTime fechaSeleccionada)
        {
            List<FaltaDeAsistencia> faltasAsistencia = new List<FaltaDeAsistencia>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = @"
                        SELECT fa.ID, fa.Fecha, fa.Hora, fa.Estado, fa.AlumnoID, fa.AsignaturaID
                        FROM faltasdeasistencia fa
                        INNER JOIN alumnos a ON fa.AlumnoID = a.ID
                        INNER JOIN asignaturas asg ON fa.AsignaturaID = asg.ID
                        WHERE asg.CursoID = @CursoID AND fa.Fecha = @Fecha";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CursoID", cursoID);
                        command.Parameters.AddWithValue("@FechaSeleccionada", fechaSeleccionada);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FaltaDeAsistencia faltaAsistencia = new FaltaDeAsistencia
                                {
                                    ID = reader.GetInt32("ID"),
                                    Fecha = reader.GetDateTime("Fecha"),
                                    Hora = reader.GetTimeSpan("Hora"),
                                    Estado = reader.GetString("Estado"),
                                    AlumnoID = reader.GetInt32("AlumnoID"),
                                    AsignaturaID = reader.GetInt32("AsignaturaID")
                                };
                                faltasAsistencia.Add(faltaAsistencia);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener faltas de asistencia: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return faltasAsistencia;
        }

        public void ModificarFaltaEstado(FaltaDeAsistencia falta)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "UPDATE faltasdeasistencia SET Estado = @Estado WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", falta.ID);
                        command.Parameters.AddWithValue("@Estado", falta.Estado);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Falta de asistencia modificada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar falta de asistencia: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public List<FaltaDeAsistencia> ObtenerFaltas()
        {
            List<FaltaDeAsistencia> faltas = new List<FaltaDeAsistencia>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT * FROM faltasdeasistencia";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FaltaDeAsistencia falta = new FaltaDeAsistencia
                                {
                                    ID = reader.GetInt32("ID"),
                                    Fecha = reader.GetDateTime("Fecha"),
                                    Hora = reader.GetTimeSpan("Hora"),
                                    AlumnoID = reader.GetInt32("AlumnoID"),
                                    AsignaturaID = reader.GetInt32("AsignaturaID"),
                                    Estado = reader.GetString("Estado")
                                };
                                faltas.Add(falta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener faltas de asistencia: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return faltas;
        }
    }
}
