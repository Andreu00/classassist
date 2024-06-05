using MiTFG.DAO;
using MiTFG.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiTFG.CRUDS.Alumnos
{
    /// <summary>
    /// Lógica de interacción para AsignarNota.xaml
    /// </summary>
    public partial class AsignarNota : Window
    {
        public AsignarNota()
        {
            InitializeComponent();
            LlenarComboBoxCursos();
        }

        private void cbCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCursos.SelectedIndex != -1)
            {
                int cursoID = (int)cbCursos.SelectedValue;
                LlenarComboBoxTareas(cursoID);
            }
        }

        private void cbTareas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTareas.SelectedIndex != -1 && cbCursos.SelectedIndex != -1)
            {
                int cursoID = (int)cbCursos.SelectedValue;
                int tareaID = (int)cbTareas.SelectedValue;
                CargarAlumnosConTarea(cursoID, tareaID);
            }
        }

        private void btnAsignarNota_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el botón clicado
            Button button = sender as Button;
            if (button != null)
            {
                // Obtener el objeto AlumnoTareaView asociado al botón clicado
                AlumnoTareaView alumnoTarea = button.DataContext as AlumnoTareaView;

                if (alumnoTarea != null)
                {
                    DAOAlumnoTarea daoAlumnoTarea = new DAOAlumnoTarea();
                    daoAlumnoTarea.ActualizarNota(alumnoTarea.Alumno_ID, alumnoTarea.Tarea_ID, alumnoTarea.Nota);
                    MessageBox.Show("Nota actualizada con éxito.");
                }
            }
        }

        private void LlenarComboBoxCursos()
        {
            DAOCursos daoCursos = new DAOCursos();
            List<Curso> cursos = daoCursos.ObtenerCursos();
            cbCursos.ItemsSource = cursos;
            cbCursos.DisplayMemberPath = "Nombre";
            cbCursos.SelectedValuePath = "ID";
        }

        private void LlenarComboBoxTareas(int cursoID)
        {
            DAOTareas daoTareas = new DAOTareas();
            List<Tarea> tareas = daoTareas.ObtenerTareasPorCurso(cursoID);
            cbTareas.ItemsSource = tareas;
            cbTareas.DisplayMemberPath = "Nombre";
            cbTareas.SelectedValuePath = "ID";
        }

        private void CargarAlumnosConTarea(int cursoID, int tareaID)
        {
            DAOAlumno daoAlumnos = new DAOAlumno();
            List<AlumnoTareaView> alumnosConTarea = daoAlumnos.ObtenerAlumnosConTarea(cursoID, tareaID);
            dgAlumnos.ItemsSource = alumnosConTarea;
        }
    }
}
