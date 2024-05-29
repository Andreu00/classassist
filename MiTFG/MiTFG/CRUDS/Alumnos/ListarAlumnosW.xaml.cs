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
            List<AlumnoConTutor> alumnosConTutores = daoAlumno.ObtenerAlumnosConTutores();
            dgAlumnos.ItemsSource = alumnosConTutores;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int alumnoID = (int)((Button)sender).Tag;

            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este alumno?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                DAOAlumno daoAlumno = new DAOAlumno();
                daoAlumno.EliminarAlumno(alumnoID);
                CargarAlumnos(); // Actualiza la lista después de eliminar
            }
        }
    }
}
