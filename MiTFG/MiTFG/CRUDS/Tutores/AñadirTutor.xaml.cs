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
    /// Lógica de interacción para AñadirTutor.xaml
    /// </summary>
    public partial class AñadirTutor : Window
    {
        public AñadirTutor()
        {
            InitializeComponent();
        }

        private void btnAñadirTutor_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtTlfnEmergencia.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Crear el nuevo tutor
            Tutor nuevoTutor = new Tutor
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                TlfnEmergencia = txtTlfnEmergencia.Text,
                Email = txtEmail.Text
            };

            // Guardar el tutor en la base de datos
            DAOTutores daoTutores = new DAOTutores();
            daoTutores.AgregarTutor(nuevoTutor);

            // Cerrar la ventana después de añadir el tutor
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
