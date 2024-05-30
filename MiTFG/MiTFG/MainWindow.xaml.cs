using MiTFG.DAO;
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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuarioAcceso = txtUsuario.Text;
            string password = txtPassword.Password;

            DAOUsuario daoUsuario = new DAOUsuario();
            string rango = daoUsuario.VerificarUsuario(usuarioAcceso, password);

            if (!string.IsNullOrEmpty(rango))
            {
                switch (rango)
                {
                    case "profesor":
                        framePrincipal.Navigate(new Uri("profesor.xaml", UriKind.Relative));
                        break;
                    case "admin":
                        framePrincipal.Navigate(new Uri("admin.xaml", UriKind.Relative));
                        break;
                    case "ambos":
                        framePrincipal.Navigate(new Uri("admin_profesor.xaml", UriKind.Relative));
                        break;
                    default:
                        MessageBox.Show("Rango de usuario no reconocido.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
