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
    /// Lógica de interacción para AñadirFalta.xaml
    /// </summary>
    public partial class AñadirFalta : Window
    {
        public AñadirFalta()
        {
            InitializeComponent();
            CargarAlumnos();
            CargarHoras();
        }
        private void CargarAlumnos()
        {
            DAOAlumno daoAlumno = new DAOAlumno();
            List<Alumno> alumnos = daoAlumno.ObtenerAlumnos();

            cmbAlumnos.ItemsSource = alumnos;
            cmbAlumnos.DisplayMemberPath = "Nombre";
            cmbAlumnos.SelectedValuePath = "ID";
        }

        private void CargarAsignaturasPorCurso(int cursoID)
        {
            DAOAsignatura daoAsignatura = new DAOAsignatura();
            List<Asignatura> asignaturas = daoAsignatura.ObtenerAsignaturasPorCurso(cursoID);

            cmbAsignatura.ItemsSource = asignaturas;
            cmbAsignatura.DisplayMemberPath = "Nombre";
            cmbAsignatura.SelectedValuePath = "ID";
        }

        private void CargarHoras()
        {
            var horasClase = new List<string>
            {
                "08:30 - 09:25",
                "09:25 - 10:20",
                "10:20 - 11:15",
                "11:45 - 12:40",
                "12:40 - 13:35",
                "13:35 - 14:30",
                "16:00 - 16:55",
                "16:55 - 17:50",
                "17:50 - 18:45",
                "19:00 - 19:55",
                "19:55 - 20:50",
                "20:50 - 21:45"
            };

            cmbHora.ItemsSource = horasClase;
        }

        private void cmbAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAlumnos.SelectedItem != null)
            {
                // Obtener el nombre del alumno seleccionado
                string nombreAlumno = (cmbAlumnos.SelectedItem as Alumno)?.Nombre;
                if (!string.IsNullOrEmpty(nombreAlumno))
                {
                    DAOCursos daoCursos = new DAOCursos();
                    // Obtener el ID del curso del alumno seleccionado
                    int cursoID = daoCursos.ObtenerCursoPorNombreAlumno(nombreAlumno);
                    if (cursoID != -1)
                    {
                        // Cargar las asignaturas correspondientes al curso
                        CargarAsignaturasPorCurso(cursoID);
                    }
                }
            }
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAlumnos.SelectedItem == null || cmbAsignatura.SelectedItem == null || dpFecha.SelectedDate == null || cmbHora.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            var horaSeleccionada = cmbHora.SelectedItem.ToString().Split('-')[0].Trim();
            TimeSpan hora = TimeSpan.Parse(horaSeleccionada);

            FaltaDeAsistencia nuevaFalta = new FaltaDeAsistencia
            {
                Fecha = dpFecha.SelectedDate.Value,
                Hora = hora,
                AlumnoID = (int)cmbAlumnos.SelectedValue,
                AsignaturaID = (int)cmbAsignatura.SelectedValue,
                Estado = ((ComboBoxItem)cbEstado.SelectedItem).Content.ToString()
        };

            DAOFaltas daoFaltas = new DAOFaltas();
            daoFaltas.AgregarFalta(nuevaFalta);

            MessageBox.Show("Falta de asistencia añadida con éxito.");
            this.Close();
        }
    }
}
