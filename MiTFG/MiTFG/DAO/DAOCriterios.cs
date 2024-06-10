using MiTFG.DAO;
using MiTFG.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiTFG.DAO
{
    internal class DAOCriterios
    {
        public List<CriterioDeEvaluacion> obtenerCriteriosPorTarea(int tareaID)
        {
            List<CriterioDeEvaluacion> criterios = new List<CriterioDeEvaluacion>();
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string query = @"
                        SELECT c.id, c.nombreCriterio
                        FROM criteriosdeevaluacion c
                        JOIN asignaturas_criterios ac ON c.id = ac.criteriosdeevaluacion_id
                        JOIN tarea t ON ac.asignaturas_ID = t.asignaturas_ID
                        WHERE t.ID = @TareaID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TareaID", tareaID);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CriterioDeEvaluacion criterio = new CriterioDeEvaluacion
                                {
                                    ID = reader.GetInt32("id"),
                                    NombreCriterio = reader.GetString("nombreCriterio")
                                };
                                criterios.Add(criterio);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener criterios: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
            return criterios;
        }

        public void guardarCriteriosPorTarea(int tareaID, int alumnoID, List<AlumnoTareaCriterio> criterios)
        {
            conexion objetoConexion = new conexion();
            try
            {
                using (MySqlConnection connection = objetoConexion.establecerConexion())
                {
                    string deleteQuery = @"
                        DELETE FROM alumnotareacriterio 
                        WHERE alumnoTarea_alumnos_ID = @AlumnoID 
                        AND alumnoTarea_tarea_ID = @TareaID";

                    using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@AlumnoID", alumnoID);
                        deleteCommand.Parameters.AddWithValue("@TareaID", tareaID);
                        deleteCommand.ExecuteNonQuery();
                    }

                    string insertQuery = @"
                        INSERT INTO alumnotareacriterio 
                        (alumnoTarea_alumnos_ID, alumnoTarea_tarea_ID, criteriosdeevaluacion_id, Cumple) 
                        VALUES (@AlumnoID, @TareaID, @CriterioID, @Cumple)";

                    foreach (var criterio in criterios)
                    {
                        using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@AlumnoID", alumnoID);
                            insertCommand.Parameters.AddWithValue("@TareaID", tareaID);
                            insertCommand.Parameters.AddWithValue("@CriterioID", criterio.CriterioID);
                            insertCommand.Parameters.AddWithValue("@Cumple", criterio.Cumple);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar criterios: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }
    }
}
