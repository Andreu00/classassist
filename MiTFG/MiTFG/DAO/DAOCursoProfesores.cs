using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiTFG.DAO
{
    internal class DAOCursoProfesores
    {
        public void eliminarRelacionesDeProfesor(int profesorID)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "DELETE FROM CursoProfesores WHERE ProfesorID = @ProfesorID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProfesorID", profesorID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar relaciones de profesor: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public void ActualizarRelacionesDeProfesor(int profesorID, List<int> cursosSeleccionados, string nuevoRango)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    // Primero, eliminamos las relaciones existentes
                    string queryDelete = "DELETE FROM CursoProfesores WHERE ProfesorID = @ProfesorID";
                    using (MySqlCommand commandDelete = new MySqlCommand(queryDelete, connection))
                    {
                        commandDelete.Parameters.AddWithValue("@ProfesorID", profesorID);
                        commandDelete.ExecuteNonQuery();
                    }

                    // Luego, insertamos las nuevas relaciones si el rango es "profesor" o "ambos"
                    if (nuevoRango == "profesor" || nuevoRango == "ambos")
                    {
                        foreach (int cursoID in cursosSeleccionados)
                        {
                            string queryInsert = "INSERT INTO CursoProfesores (CursoID, ProfesorID) VALUES (@CursoID, @ProfesorID)";
                            using (MySqlCommand commandInsert = new MySqlCommand(queryInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@CursoID", cursoID);
                                commandInsert.Parameters.AddWithValue("@ProfesorID", profesorID);
                                commandInsert.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar relaciones de profesor: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public List<int> ObtenerCursosDeProfesor(int profesorID)
        {
            List<int> cursos = new List<int>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT CursoID FROM CursoProfesores WHERE ProfesorID = @ProfesorID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProfesorID", profesorID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cursos.Add(reader.GetInt32("CursoID"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener cursos de profesor: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return cursos;
        }
    }
}
