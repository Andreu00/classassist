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
    internal class DAOUsuario
    {
        public string VerificarUsuario(string nombre, string contraseña)
        {
            string rangoUsuario = "";
            string consulta = "SELECT ID, rango FROM Usuarios WHERE usuarioAcceso = @usuarioAcceso AND password = @password;";
            conexion objetoConexion = new conexion();

            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    using (MySqlCommand myCommand = new MySqlCommand(consulta, connection))
                    {
                        myCommand.Parameters.AddWithValue("@usuarioAcceso", nombre);
                        myCommand.Parameters.AddWithValue("@password", contraseña);

                        using (MySqlDataReader reader = myCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rangoUsuario = reader["rango"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Usuario no encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comprobar usuario: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }

            return rangoUsuario;
        }

        public void agregarUsuario(Usuario nuevoUsuario)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "INSERT INTO Usuarios (Nombre, usuarioAcceso, password, rango) VALUES (@Nombre, @UsuarioAcceso, @Password, @Rango)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nuevoUsuario.nombre);
                        command.Parameters.AddWithValue("@UsuarioAcceso", nuevoUsuario.usuarioAcceso);
                        command.Parameters.AddWithValue("@Password", nuevoUsuario.password);
                        command.Parameters.AddWithValue("@Rango", nuevoUsuario.Rango);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Usuario añadido con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir usuario: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public int obtenerIDUsuario(string usuarioAcceso)
        {
            int usuarioID = 0;
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT ID FROM Usuarios WHERE usuarioAcceso = @usuarioAcceso";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuarioAcceso", usuarioAcceso);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuarioID = reader.GetInt32("ID");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ID del usuario: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return usuarioID;
        }

        public List<Usuario> obtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT ID, Nombre, usuarioAcceso, password,  rango FROM usuarios";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuarios.Add(new Usuario
                                {
                                    id = reader.GetInt32("ID"),
                                    nombre = reader.GetString("Nombre"),
                                    usuarioAcceso = reader.GetString("usuarioAcceso"),
                                    password = reader.GetString("password"),
                                    Rango = reader.GetString("rango")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener usuarios: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return usuarios;
        }

        public void modificarUsuario(Usuario usuario)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "UPDATE Usuarios SET Nombre = @Nombre, usuarioAcceso = @UsuarioAcceso, password = @Password, curso = @Curso, rango = @Rango WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", usuario.id);
                        command.Parameters.AddWithValue("@Nombre", usuario.nombre);
                        command.Parameters.AddWithValue("@UsuarioAcceso", usuario.usuarioAcceso);
                        command.Parameters.AddWithValue("@Password", usuario.password);
                        command.Parameters.AddWithValue("@Curso", (object)usuario.Curso ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Rango", usuario.Rango);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Usuario modificado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public void eliminarUsuario(int id)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "DELETE FROM Usuarios WHERE ID = @ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Usuario eliminado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }
    }
}
