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

        public List<FaltaDeAsistencia> ObtenerFaltasAsistenciaPorCursoYFecha(int cursoID, DateTime fechaSeleccionada)
        {
            List<FaltaDeAsistencia> faltasAsistencia = new List<FaltaDeAsistencia>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = @"
                        SELECT fa.ID, fa.Fecha, fa.Hora, fa.AlumnoID, fa.AsignaturaID
                        FROM faltasdeasistencia fa
                        JOIN Alumnos a ON fa.AlumnoID = a.ID
                        WHERE a.Curso = @CursoID AND fa.Fecha = @FechaSeleccionada";
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
    }
}
