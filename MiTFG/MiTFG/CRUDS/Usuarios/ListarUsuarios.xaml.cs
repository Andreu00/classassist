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
    }
}
