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

namespace MiTFG.CRUDS.Tutores
{
    /// <summary>
    /// Lógica de interacción para ListarTutores.xaml
    /// </summary>
    public partial class ListarTutores : Window
    {
        public ListarTutores()
        {
            InitializeComponent();
            CargarTutores();
        }
        private void CargarTutores()
        {
            DAOTutores daoTutores = new DAOTutores();
            List<Tutor> tutores = daoTutores.ObtenerTutores();
            dgTutores.ItemsSource = tutores;
        }
        private void btnEliminarTutor_Click(object sender, RoutedEventArgs e)
        {
            int tutorID = (int)((Button)sender).Tag;

            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este tutor?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                DAOTutores daoTutores = new DAOTutores();
                daoTutores.EliminarTutor(tutorID);
                CargarTutores(); // Actualiza la lista después de eliminar
            }

        }
    }
}
