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
                    string query = "SELECT ID, Nombre FROM Alumnos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                alumnos.Add(new Alumno
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

        public void AgregarAlumno(Alumno nuevoAlumno)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "INSERT INTO Alumnos (Nombre, Apellidos, DNI, Email, NumeroTelefono, Curso, FechaDeNacimiento, tutores_ID) VALUES (@Nombre, @Apellidos, @DNI, @Email, @NumeroTelefono, @Curso, @FechaDeNacimiento, @TutoresID)";
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
                    string query = "UPDATE Alumnos SET Nombre = @Nombre, Apellidos = @Apellidos, DNI = @DNI, Email = @Email, NumeroTelefono = @NumeroTelefono, Curso = @Curso, FechaDeNacimiento = @FechaDeNacimiento, tutores_ID = @TutoresID WHERE ID = @ID";
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
                    string query = "DELETE FROM Alumnos WHERE ID = @ID";
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



    }
}
