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
    internal class DAOAlumnoTarea
    {
        public void agregarAlumnoTarea(AlumnoTarea alumnoTarea)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "INSERT INTO alumnotarea (alumnos_ID, tarea_ID) VALUES (@Alumnos_ID, @Tarea_ID)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Alumnos_ID", alumnoTarea.Alumnos_ID);
                        command.Parameters.AddWithValue("@Tarea_ID", alumnoTarea.Tarea_ID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar tarea a alumno: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        public void ActualizarNota(int alumnoID, int tareaID, double? nota)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = "UPDATE alumnotarea SET nota = @Nota WHERE alumnos_ID = @Alumnos_ID AND tarea_ID = @Tarea_ID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nota", (object)nota ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Alumnos_ID", alumnoID);
                        command.Parameters.AddWithValue("@Tarea_ID", tareaID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar nota: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }
    }
}
