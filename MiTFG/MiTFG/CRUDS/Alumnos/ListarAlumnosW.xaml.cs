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

namespace MiTFG
{
    /// <summary>
    /// Lógica de interacción para ListarAlumnosW.xaml
    /// </summary>
    public partial class ListarAlumnosW : Window
    {
        public ListarAlumnosW()
        {
            InitializeComponent();
            CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            DAOAlumno daoAlumno = new DAOAlumno();
            DAOTutores daoTutores = new DAOTutores();
            List<Alumno> alumnos = daoAlumno.ObtenerAlumnos();
            List<Tutor> tutores = daoTutores.ObtenerTutores();

            // Mapear el nombre del tutor a cada alumno
            var alumnosConTutores = from alumno in alumnos
                                    join tutor in tutores on alumno.TutoresID equals tutor.ID
                                    select new
                                    {
                                        alumno.ID,
                                        alumno.Nombre,
                                        alumno.Apellidos,
                                        alumno.DNI,
                                        alumno.Email,
                                        alumno.NumeroTelefono,
                                        alumno.Curso,
                                        alumno.FechaDeNacimiento,
                                        TutorNombre = tutor.Nombre
                                    };

            dgAlumnos.ItemsSource = alumnosConTutores.ToList();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            CargarAlumnos();
        }
    }
}
