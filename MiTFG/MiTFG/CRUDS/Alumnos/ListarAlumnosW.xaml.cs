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
            
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
