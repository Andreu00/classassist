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
    }
}
