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
    internal class DAOCursos
    {
        public List<Curso> ObtenerCursos()
        {
            List<Curso> cursos = new List<Curso>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT ID, Nombre FROM Cursos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cursos.Add(new Curso
                                {
                                    ID = reader.GetInt32("ID"),
                                    Nombre = reader.GetString("Nombre")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener cursos: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return cursos;
        }

        public void InsertarCursoProfesor(CursoProfesores cursoProfesor)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "INSERT INTO CursoProfesores (CursoID, ProfesorID) VALUES (@CursoID, @ProfesorID)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CursoID", cursoProfesor.CursoID);
                        command.Parameters.AddWithValue("@ProfesorID", cursoProfesor.ProfesorID);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Relación curso-profesor añadida con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir la relación curso-profesor: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }


        public List<Asignatura> ObtenerAsignaturasPorCurso(int cursoID)
        {
            List<Asignatura> asignaturas = new List<Asignatura>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT ID, Nombre FROM Asignaturas WHERE CursoID = @CursoID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CursoID", cursoID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                asignaturas.Add(new Asignatura
                                {
                                    ID = reader.GetInt32("ID"),
                                    Nombre = reader.GetString("Nombre")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener asignaturas: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return asignaturas;
        }

        public int ObtenerCursoPorNombreAlumno(string nombreAlumno)
        {
            int cursoID = -1; //Se inicializa en -1 para tener un valor por defecto en caso de que la consulta a la base de datos no devuelva ningún resultado
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT Curso FROM Alumnos WHERE Nombre = @Nombre";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreAlumno);
                        cursoID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el curso del alumno: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return cursoID;
        }






    }
}
