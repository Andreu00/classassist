using MiTFG.CRUDS.Alumnos;
using MiTFG.CRUDS.Tareas;
using MiTFG.CRUDS.Tutores;
using MiTFG.CRUDS.Usuarios;
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

namespace MiTFG
{
    /// <summary>
    /// Lógica de interacción para admin_profesor.xaml
    /// </summary>
    public partial class admin_profesor : Page
    {
        public admin_profesor()
        {
            InitializeComponent();
            gBtnOpcionesUsuarios.Visibility = Visibility.Collapsed;
            gBtnOpcionesTareas.Visibility = Visibility.Collapsed;
            gBtnAlumnos.Visibility = Visibility.Collapsed;              
            gBtnOpcionesTutores.Visibility = Visibility.Collapsed;
        }

        private void btnGUsuarios_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesUsuarios.Visibility = Visibility.Visible;
            gBtnOpcionesTareas.Visibility = Visibility.Collapsed;
            gBtnAlumnos.Visibility = Visibility.Collapsed;
            gBtnOpcionesTutores.Visibility = Visibility.Collapsed;
        }
        private void btnGTareas_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesTareas.Visibility = Visibility.Visible;
            gBtnAlumnos.Visibility = Visibility.Collapsed;
            gBtnOpcionesTutores.Visibility = Visibility.Collapsed;
            gBtnOpcionesUsuarios.Visibility = Visibility.Collapsed;
        }

        private void btnGAlumnos_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesUsuarios.Visibility = Visibility.Collapsed;
            gBtnOpcionesTareas.Visibility = Visibility.Collapsed;
            gBtnAlumnos.Visibility = Visibility.Visible;
            gBtnOpcionesTutores.Visibility = Visibility.Collapsed;
        }

        private void btnGTutores_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesUsuarios.Visibility = Visibility.Collapsed;
            gBtnOpcionesTareas.Visibility = Visibility.Collapsed;
            gBtnAlumnos.Visibility = Visibility.Collapsed;
            gBtnOpcionesTutores.Visibility = Visibility.Visible;
        }

        private void btnAniadirU_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new AñadirUsuario();
            dataWindow.Show();
        }

        private void btnModificarU_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ModificarUsuario();
            dataWindow.Show();
        }

        private void btnListarU_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ListarUsuarios();
            dataWindow.Show();
        }

        private void btnAniadirFa_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new AñadirFalta();
            dataWindow.Show();
        }

        private void btnModificarFa_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ModificarFalta();
            dataWindow.Show();
        }

        private void btnListarFa_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ListarFaltasAsistencia();
            dataWindow.Show();
        }

        private void btnAniadirA_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new AñadirAlumno();
            dataWindow.Show();
        }

        private void btnListarA_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ListarAlumnosW();
            dataWindow.Show();
        }

        private void btnModificarA_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ModificarAlumno();
            dataWindow.Show();
        }

        private void btnAniadirTu_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new AñadirTutor();
            dataWindow.Show();
        }

        private void btnModificarTu_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ModificarTutor();
            dataWindow.Show();
        }

        private void btnListarTu_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ListarTutores();
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

        private void btnAsignarNota_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new AsignarNota();
            dataWindow.Show();
        }

        
    }
}
