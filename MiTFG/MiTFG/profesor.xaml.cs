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
            gBtnOpcionesCriterios.Visibility = Visibility.Collapsed;
        }

        private void btnGTareas_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesTareas.Visibility = Visibility.Visible;
            gBtnOpcionesCriterios.Visibility = Visibility.Collapsed;
        }

        private void btnGCriterios_Click(object sender, RoutedEventArgs e)
        {
            gBtnOpcionesTareas.Visibility = Visibility.Collapsed;
            gBtnOpcionesCriterios.Visibility = Visibility.Visible;
        }
    }
}
