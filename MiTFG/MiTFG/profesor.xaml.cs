using MiTFG.CRUDS.Alumnos;
using MiTFG.CRUDS.Tareas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiTFG.Views
{
    /// <summary>
    /// Lógica de interacción para profesor.xaml
    /// </summary>
    public partial class profesor : Page
    {
        public profesor()
        {
            InitializeComponent();
            gBtnOpcionesTareas.Visibility = Visibility.Collapsed;
            gBtnAlumnos.Visibility = Visibility.Collapsed;
        }

        private void btnGTareas_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesTareas.Visibility = Visibility.Visible;
            gBtnAlumnos.Visibility = Visibility.Collapsed;
        }
        private void btnGAlumnos_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesTareas.Visibility = Visibility.Collapsed;
            gBtnAlumnos.Visibility = Visibility.Visible;
        }

        private void btnAniadirA_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new AñadirAlumno();
            dataWindow.Show();
        }

        private void btnModificarA_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ModificarAlumno();
            dataWindow.Show();
        }

        private void btnListarA_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ListarAlumnosW();
            dataWindow.Show();
        }

        private void btnAniadirFa_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new AñadirFalta();
            dataWindow.Show();
        }

        private void btnListarFa_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ListarFaltasAsistencia();
            dataWindow.Show();
        }

        private void btnAniadirTa_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new AñadirTarea();
            dataWindow.Show();
        }

        private void btnModificarTa_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ModificarTarea();
            dataWindow.Show();
        }

        private void btnListarTa_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ListarTareas();
            dataWindow.Show();
        }
    }
}
