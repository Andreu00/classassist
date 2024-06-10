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

namespace MiTFG.CRUDS.Usuarios
{
    public partial class ListarUsuarios : Window
    {
        public ListarUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            List<Usuario> usuarios = daoUsuario.obtenerUsuarios();
            dgUsuarios.ItemsSource = usuarios;
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int usuarioID = (int)((Button)sender).Tag;  // Tag almacena el ID del usuario de la línea en la que se ha seleccionado el botón eliminar

            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                // Eliminar relaciones en CursoProfesores
                DAOCursoProfesores daoCursoProfesores = new DAOCursoProfesores();
                daoCursoProfesores.eliminarRelacionesDeProfesor(usuarioID);

                // Eliminar usuario
                DAOUsuario daoUsuario = new DAOUsuario();
                daoUsuario.eliminarUsuario(usuarioID);
                CargarUsuarios();  // Actualizar la lista de usuarios
            }
        }
    }
}
