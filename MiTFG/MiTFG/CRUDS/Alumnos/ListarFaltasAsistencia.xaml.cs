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
    /// Lógica de interacción para ListarFaltasAsistencia.xaml
    /// </summary>
    public partial class ListarFaltasAsistencia : Window
    {
        public ListarFaltasAsistencia()
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

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            if (cbCursos.SelectedItem == null || dpFecha.SelectedDate == null)
            {
                MessageBox.Show("Por favor, selecciona un curso y una fecha.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int cursoID = (int)cbCursos.SelectedValue;
            DateTime fechaSeleccionada = (DateTime)dpFecha.SelectedDate;

            DAOFaltas daoFaltasAsistencia = new DAOFaltas();
            List<FaltaDeAsistencia> faltasAsistencia = daoFaltasAsistencia.ObtenerFaltasAsistenciaPorCursoYFecha(cursoID, fechaSeleccionada);

            // Transformar los datos para la visualización
            var faltasAsistenciaView = new List<dynamic>();
            DAOAlumno daoAlumno = new DAOAlumno();
            DAOAsignatura daoAsignaturas = new DAOAsignatura();

            for (int i = 0; i < faltasAsistencia.Count; i++)
            {
                var falta = faltasAsistencia[i];
                string nombreAlumno = daoAlumno.ObtenerNombreAlumnoPorID(falta.AlumnoID);
                string nombreAsignatura = daoAsignaturas.ObtenerNombreAsignaturaPorID(falta.AsignaturaID);

                faltasAsistenciaView.Add(new
                {
                    falta.ID,
                    falta.Fecha,
                    falta.Hora,
                    NombreAlumno = nombreAlumno,
                    NombreAsignatura = nombreAsignatura,
                    falta.Estado // Añadimos el estado a la vista
                });
            }

            dgFaltasAsistencia.ItemsSource = faltasAsistenciaView;
        }

    }
}
