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
    internal class DAOAlumno
    {
        public List<Alumno> ObtenerAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT * FROM alumnos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                alumnos.Add(new Alumno
                                {
                                    ID = reader.GetInt32("ID"),
                                    Nombre = reader.GetString("Nombre"),
                                    Apellidos = reader.GetString("Apellidos"),
                                    DNI = reader.GetString("DNI"),
                                    Email = reader.GetString("Email"),
                                    NumeroTelefono = reader.GetString("NumeroTelefono"),
                                    Curso = reader.IsDBNull(reader.GetOrdinal("Curso")) ? (int?)null : reader.GetInt32("Curso"),
                                    FechaDeNacimiento = reader.IsDBNull(reader.GetOrdinal("FechaDeNacimiento")) ? (DateTime?)null : reader.GetDateTime("FechaDeNacimiento"),
                                    TutoresID = reader.GetInt32("tutores_ID")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener alumnos: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return alumnos;
        }

        public int ObtenerCursoPorNombreAlumno(string nombreAlumno)
        {
            int cursoID = -1;
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT Curso FROM alumnos WHERE Nombre = @Nombre";
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

        public void AgregarAlumno(Alumno nuevoAlumno)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "INSERT INTO alumnos (Nombre, Apellidos, DNI, Email, NumeroTelefono, Curso, FechaDeNacimiento, tutores_ID) VALUES (@Nombre, @Apellidos, @DNI, @Email, @NumeroTelefono, @Curso, @FechaDeNacimiento, @TutoresID)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nuevoAlumno.Nombre);
                        command.Parameters.AddWithValue("@Apellidos", nuevoAlumno.Apellidos);
                        command.Parameters.AddWithValue("@DNI", nuevoAlumno.DNI);
                        command.Parameters.AddWithValue("@Email", nuevoAlumno.Email);
                        command.Parameters.AddWithValue("@NumeroTelefono", nuevoAlumno.NumeroTelefono);
                        command.Parameters.AddWithValue("@Curso", (object)nuevoAlumno.Curso ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FechaDeNacimiento", (object)nuevoAlumno.FechaDeNacimiento ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TutoresID", nuevoAlumno.TutoresID);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Alumno añadido con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir alumno: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public void ModificarAlumno(Alumno alumno)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "UPDATE alumnos SET Nombre = @Nombre, Apellidos = @Apellidos, DNI = @DNI, Email = @Email, NumeroTelefono = @NumeroTelefono, Curso = @Curso, FechaDeNacimiento = @FechaDeNacimiento, tutores_ID = @TutoresID WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        command.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
                        command.Parameters.AddWithValue("@DNI", alumno.DNI);
                        command.Parameters.AddWithValue("@Email", alumno.Email);
                        command.Parameters.AddWithValue("@NumeroTelefono", alumno.NumeroTelefono);
                        command.Parameters.AddWithValue("@Curso", (object)alumno.Curso ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FechaDeNacimiento", (object)alumno.FechaDeNacimiento ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TutoresID", alumno.TutoresID);
                        command.Parameters.AddWithValue("@ID", alumno.ID);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Alumno modificado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar alumno: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public void EliminarAlumno(int id)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "DELETE FROM alumnos WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Alumno eliminado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar alumno: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public List<AlumnoConTutor> ObtenerAlumnosConTutores()
        {
            List<AlumnoConTutor> alumnosConTutores = new List<AlumnoConTutor>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = @"
                        SELECT a.ID, a.Nombre, a.Apellidos, a.DNI, a.Email, a.NumeroTelefono, a.Curso, a.FechaDeNacimiento, t.Nombre AS TutorNombre
                        FROM alumnos a
                        JOIN Tutores t ON a.tutores_ID = t.ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AlumnoConTutor alumnoConTutor = new AlumnoConTutor
                                {
                                    ID = reader.GetInt32("ID"),
                                    Nombre = reader.GetString("Nombre"),
                                    Apellidos = reader.GetString("Apellidos"),
                                    DNI = reader.GetString("DNI"),
                                    Email = reader.GetString("Email"),
                                    NumeroTelefono = reader.GetString("NumeroTelefono"),
                                    Curso = reader.IsDBNull(reader.GetOrdinal("Curso")) ? (int?)null : reader.GetInt32("Curso"),
                                    FechaDeNacimiento = reader.IsDBNull(reader.GetOrdinal("FechaDeNacimiento")) ? (DateTime?)null : reader.GetDateTime("FechaDeNacimiento"),
                                    TutorNombre = reader.GetString("TutorNombre")
                                };
                                alumnosConTutores.Add(alumnoConTutor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener alumnos con tutores: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return alumnosConTutores;
        }

        public string ObtenerNombreAlumnoPorID(int alumnoID)
        {
            string nombreAlumno = null;
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT Nombre FROM alumnos WHERE ID = @AlumnoID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AlumnoID", alumnoID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreAlumno = reader.GetString("Nombre");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener nombre del alumno: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return nombreAlumno;
        }

        public List<int> obtenerAlumnosPorCurso(int cursoID)
        {
            List<int> alumnosIDs = new List<int>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT ID FROM alumnos WHERE Curso = @CursoID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CursoID", cursoID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                alumnosIDs.Add(reader.GetInt32("ID"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener IDs de los alumnos: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return alumnosIDs;
        }

        public List<AlumnoTareaView> ObtenerAlumnosConTarea(int cursoID, int tareaID)
        {
            List<AlumnoTareaView> alumnosConTarea = new List<AlumnoTareaView>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT a.ID AS Alumno_ID, a.Nombre AS NombreAlumno, at.nota AS Nota " +
                                   "FROM Alumnos a " +
                                   "JOIN alumnotarea at ON a.ID = at.alumnos_ID " +
                                   "WHERE a.Curso = @CursoID AND at.tarea_ID = @TareaID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CursoID", cursoID);
                        command.Parameters.AddWithValue("@TareaID", tareaID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AlumnoTareaView alumnoTareaView = new AlumnoTareaView
                                {
                                    Alumno_ID = reader.GetInt32("Alumno_ID"),
                                    NombreAlumno = reader.GetString("NombreAlumno"),
                                    Nota = reader.IsDBNull(reader.GetOrdinal("Nota")) ? (double?)null : reader.GetDouble("Nota")
                                };
                                alumnosConTarea.Add(alumnoTareaView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener alumnos con tarea: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return alumnosConTarea;
        }


    }
}
