using MiTFG.DAO;
using MiTFG.DTO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MiTFG.CRUDS.Tareas
{
    public partial class AsignarAlumnos : Window
    {
        private int tareaID;
        private int asignaturaID;

        public AsignarAlumnos(int tareaID, int asignaturaID)
        {
            InitializeComponent();
            this.tareaID = tareaID;
            this.asignaturaID = asignaturaID;
            CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            DAOAlumno daoAlumnos = new DAOAlumno();
            List<Alumno> alumnos = daoAlumnos.obtenerAlumnosPorAsignatura(asignaturaID);
            lbAlumnos.ItemsSource = alumnos;
        }

        private void btnSeleccionarTodos_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lbAlumnos.Items)
            {
                lbAlumnos.SelectedItems.Add(item);
            }
        }

        private void btnAsignar_Click(object sender, RoutedEventArgs e)
        {
            List<Alumno> alumnosSeleccionados = new List<Alumno>();
            foreach (Alumno alumno in lbAlumnos.SelectedItems)
            {
                alumnosSeleccionados.Add(alumno);
            }

            DAOTareas daoTareas = new DAOTareas();
            foreach (Alumno alumno in alumnosSeleccionados)
            {
                daoTareas.asignarTareaAlumno(alumno.ID, tareaID);
            }

            MessageBox.Show("Alumnos asignados con éxito.");
            this.Close();
        }
    }
}
