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

namespace MiTFG.CRUDS.Tareas
{
    /// <summary>
    /// Lógica de interacción para ListarTareas.xaml
    /// </summary>
    public partial class ListarTareas : Window
    {
        public ListarTareas()
        {
            InitializeComponent();
            CargarTareas();
        }

        private void CargarTareas()
        {
            DAOTareas daoTareas = new DAOTareas();
            List<Tarea> tareas = daoTareas.ObtenerTareas();
            dgTareas.ItemsSource = tareas;
        }

        private void btnEliminarTarea_Click(object sender, RoutedEventArgs e)
        {
            int tareaID = (int)((Button)sender).Tag;

            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta tarea?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                DAOTareas daoTareas = new DAOTareas();
                daoTareas.EliminarTarea(tareaID);
                CargarTareas();
            }
        }
    }
}
