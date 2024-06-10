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

namespace MiTFG.CRUDS.Alumnos
{
    /// <summary>
    /// Lógica de interacción para ListarCriterios.xaml
    /// </summary>
    public partial class ListarCriterios : Window
    {
        private int tareaID;
        private int alumnoID;

        public ListarCriterios(int tareaID, int alumnoID)
        {
            InitializeComponent();
            this.tareaID = tareaID;
            this.alumnoID = alumnoID;
            CargarCriterios();
        }

        private void CargarCriterios()
        {
            DAOCriterios daoCriterios = new DAOCriterios();
            List<CriterioDeEvaluacion> criterios = daoCriterios.obtenerCriteriosPorTarea(tareaID);

            var criteriosView = criterios.Select(criterio => new CriteriosVista
            {
                ID = criterio.ID,
                NombreCriterio = criterio.NombreCriterio,
                Cumple = false // Inicialmente, ningún criterio se marca como cumplido
            }).ToList();

            dgCriterios.ItemsSource = criteriosView;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var criteriosView = dgCriterios.ItemsSource as List<CriteriosVista>;
            if (criteriosView == null)
            {
                MessageBox.Show("No hay criterios para guardar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Filtrar los criterios que cumplen
            List<AlumnoTareaCriterio> criteriosCumplidos = criteriosView
                .Where(item => item.Cumple)
                .Select(item => new AlumnoTareaCriterio
                {
                    AlumnoID = alumnoID,
                    TareaID = tareaID,
                    CriterioID = item.ID,
                    Cumple = item.Cumple
                }).ToList();

            if (criteriosCumplidos.Count == 0)
            {
                MessageBox.Show("No se han seleccionado criterios para guardar.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DAOCriterios daoCriterios = new DAOCriterios();
            daoCriterios.guardarCriteriosPorTarea(tareaID, alumnoID, criteriosCumplidos);
            MessageBox.Show("Criterios guardados con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
