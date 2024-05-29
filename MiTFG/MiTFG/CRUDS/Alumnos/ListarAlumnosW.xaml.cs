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
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el objeto que se va a eliminar
            Button button = sender as Button;
            DataGridRow row = DataGridRow.GetRowContainingElement(button);
            if (row != null)
            {
                // Aquí podrías querer remover el objeto del origen de datos, por ejemplo:
                dataGrid.Items.Remove(row.Item);
            }
        }
    }
}
