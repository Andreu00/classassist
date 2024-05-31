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
    internal class DAOAsignatura
    {
        public List<Asignatura> ObtenerAsignaturas()
        {
            List<Asignatura> asignaturas = new List<Asignatura>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT ID, Nombre, CursoID FROM Asignaturas";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                asignaturas.Add(new Asignatura
                                {
                                    ID = reader.GetInt32("ID"),
                                    Nombre = reader.GetString("Nombre"),
                                    CursoID = reader.GetInt32("CursoID")
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

        public string ObtenerNombreAsignaturaPorID(int asignaturaID)
        {
            string nombreAsignatura = null;
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "SELECT Nombre FROM Asignaturas WHERE ID = @AsignaturaID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AsignaturaID", asignaturaID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreAsignatura = reader.GetString("Nombre");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener nombre de la asignatura: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return nombreAsignatura;
        }
    }
}
