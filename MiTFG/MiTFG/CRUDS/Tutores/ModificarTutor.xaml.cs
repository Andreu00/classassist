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
    /// Lógica de interacción para ModificarTutor.xaml
    /// </summary>
    public partial class ModificarTutor : Window
    {
        public ModificarTutor()
        {
            InitializeComponent();
            CargarTutores();
        }

        private void cbTutores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTutores.SelectedItem != null)
            {
                Tutor tutorSeleccionado = (Tutor)cbTutores.SelectedItem;
                txtNombre.Text = tutorSeleccionado.Nombre;
                txtTelefono.Text = tutorSeleccionado.Telefono;
                txtTlfnEmergencia.Text = tutorSeleccionado.TlfnEmergencia;
                txtEmail.Text = tutorSeleccionado.Email;
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (cbTutores.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un tutor.");
                return;
            }

            Tutor tutorSeleccionado = (Tutor)cbTutores.SelectedItem;

            tutorSeleccionado.Nombre = txtNombre.Text;
            tutorSeleccionado.Telefono = txtTelefono.Text;
            tutorSeleccionado.TlfnEmergencia = txtTlfnEmergencia.Text;
            tutorSeleccionado.Email = txtEmail.Text;

            DAOTutores daoTutores = new DAOTutores();
            daoTutores.ModificarTutor(tutorSeleccionado);

            MessageBox.Show("Tutor actualizado con éxito.");
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CargarTutores()
        {
            DAOTutores daoTutores = new DAOTutores();
            List<Tutor> tutores = daoTutores.ObtenerTutores();

            cbTutores.ItemsSource = tutores;
            cbTutores.DisplayMemberPath = "Nombre";
            cbTutores.SelectedValuePath = "ID";
        }
    }
}
