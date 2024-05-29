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

namespace MiTFG.Views
{
    /// <summary>
    /// Lógica de interacción para admin.xaml
    /// </summary>
    public partial class admin : Page
    {
        public admin()
        {
            InitializeComponent();
            gBtnOpcionesUsuarios.Visibility = Visibility.Collapsed;
            gBtnOpcionesTutores.Visibility = Visibility.Collapsed;
        }

        private void btnGTutores_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesTutores.Visibility = Visibility.Visible;
            gBtnOpcionesUsuarios.Visibility = Visibility.Collapsed;
        }

        private void btnGUsuarios_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesTutores.Visibility = Visibility.Collapsed;
            gBtnOpcionesUsuarios.Visibility = Visibility.Visible;
        }

        private void btnListarT_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ListarAlumnosW();
            dataWindow.Show();
        }

        private void btnAniadirU_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new AñadirUsuario();
            dataWindow.Show();
        }

        private void btnModificarU_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ModificarEliminarUsuario();
            dataWindow.Show();
        }

        private void btnListarU_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new ListarUsuarios();
            dataWindow.Show();
        }
    }
}
