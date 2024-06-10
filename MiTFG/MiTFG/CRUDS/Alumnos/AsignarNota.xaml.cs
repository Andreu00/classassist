using MiTFG.DAO;
using MiTFG.DTO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MiTFG.CRUDS.Alumnos
{
    public partial class AsignarNota : Window
    {
        public AsignarNota()
        {
            InitializeComponent();
            CargarCursos();
        }

        private void CargarCursos()
        {
            DAOCursos daoCursos = new DAOCursos();
            List<Curso> cursos = daoCursos.ObtenerCursos();
            cbCursos.ItemsSource = cursos;
            cbCursos.DisplayMemberPath = "Nombre";
            cbCursos.SelectedValuePath = "ID";
        }

        private void CargarTareas(int cursoID)
        {
            DAOTareas daoTareas = new DAOTareas();
            List<Tarea> tareas = daoTareas.ObtenerTareasPorCurso(cursoID);
            cbTareas.ItemsSource = tareas;
            cbTareas.DisplayMemberPath = "Nombre";
            cbTareas.SelectedValuePath = "ID";
        }

        private void cbCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCursos.SelectedItem != null)
            {
                int cursoID = (int)cbCursos.SelectedValue;
                CargarTareas(cursoID);
            }
        }

        private void cbTareas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTareas.SelectedItem != null)
            {
                int cursoID = (int)cbCursos.SelectedValue;
                int tareaID = (int)cbTareas.SelectedValue;

                DAOTareas daoTareas = new DAOTareas();
                List<AlumnoTarea> alumnosTareas = daoTareas.ObtenerAlumnosPorTarea(cursoID, tareaID);

                // Transformar los datos para la visualización
                var alumnosTareasView = new List<AlumnoTareaView>();
                DAOAlumno daoAlumno = new DAOAlumno();

                foreach (var alumnoTarea in alumnosTareas)
                {
                    string nombreAlumno = daoAlumno.ObtenerNombreAlumnoPorID(alumnoTarea.Alumnos_ID);

                    alumnosTareasView.Add(new AlumnoTareaView
                    {
                        Alumno_ID = alumnoTarea.Alumnos_ID,
                        Tarea_ID = alumnoTarea.Tarea_ID,
                        NombreAlumno = nombreAlumno,
                        Nota = alumnoTarea.Nota // Añadimos la nota a la vista
                    });
                }

                dgAlumnos.ItemsSource = alumnosTareasView;
            }
        }

        private void btnAsignarNotas_Click(object sender, RoutedEventArgs e)
        {
            // Obtener las notas ingresadas
            var alumnosTareasView = dgAlumnos.ItemsSource as List<AlumnoTareaView>;

            if (alumnosTareasView == null)
            {
                MessageBox.Show("No hay notas para guardar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DAOTareas daoTareas = new DAOTareas();

            foreach (var alumnoTareaView in alumnosTareasView)
            {
                int alumnoID = alumnoTareaView.Alumno_ID;
                int tareaID = alumnoTareaView.Tarea_ID;
                double? nota = alumnoTareaView.Nota;

                if (nota.HasValue)
                {
                    daoTareas.ActualizarNotaTarea(alumnoID, tareaID, nota.Value);
                }
            }

            MessageBox.Show("Notas guardadas con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnCriterios_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int alumnoID = (int)button.Tag;
            int tareaID = (int)cbTareas.SelectedValue;

            ListarCriterios listarCriterios = new ListarCriterios(tareaID, alumnoID);
            listarCriterios.ShowDialog();
        }
    }
}
