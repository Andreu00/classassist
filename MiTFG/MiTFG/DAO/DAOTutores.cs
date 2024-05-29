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
    internal class DAOTutores
    {
        public List<Tutor> ObtenerTutores()
        {
            List<Tutor> tutores = new List<Tutor>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT ID, Nombre, Telefono, TlfnEmergencia, Email FROM Tutores";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tutor tutor = new Tutor
                                {
                                    ID = reader.GetInt32("ID"),
                                    Nombre = reader.GetString("Nombre"),
                                    Telefono = reader.GetString("Telefono"),
                                    TlfnEmergencia = reader.GetString("TlfnEmergencia"),
                                    Email = reader.GetString("Email")
                                };
                                tutores.Add(tutor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tutores: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return tutores;
        }

        public void AgregarTutor(Tutor nuevoTutor)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "INSERT INTO Tutores (Nombre, Telefono, TlfnEmergencia, Email) VALUES (@Nombre, @Telefono, @TlfnEmergencia, @Email)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nuevoTutor.Nombre);
                        command.Parameters.AddWithValue("@Telefono", nuevoTutor.Telefono);
                        command.Parameters.AddWithValue("@TlfnEmergencia", nuevoTutor.TlfnEmergencia);
                        command.Parameters.AddWithValue("@Email", nuevoTutor.Email);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Tutor añadido con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir tutor: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public void ModificarTutor(Tutor tutor)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "UPDATE Tutores SET Nombre = @Nombre, Telefono = @Telefono, TlfnEmergencia = @TlfnEmergencia, Email = @Email WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", tutor.Nombre);
                        command.Parameters.AddWithValue("@Telefono", tutor.Telefono);
                        command.Parameters.AddWithValue("@TlfnEmergencia", tutor.TlfnEmergencia);
                        command.Parameters.AddWithValue("@Email", tutor.Email);
                        command.Parameters.AddWithValue("@ID", tutor.ID);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Tutor modificado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar tutor: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public void EliminarTutor(int id)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "DELETE FROM Tutores WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Tutor eliminado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar tutor: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }
    }
}
