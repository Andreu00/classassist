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
    /// Lógica de interacción para AñadirAlumno.xaml
    /// </summary>
    public partial class AñadirAlumno : Window
    {
        public AñadirAlumno()
        {
            InitializeComponent();
            CargarCursos();
            CargarTutores();
        }
        private void CargarCursos()
        {
            DAOCursos daoCursos = new DAOCursos();
            List<Curso> cursos = daoCursos.ObtenerCursos();

            cbCurso.ItemsSource = cursos;
            cbCurso.DisplayMemberPath = "Nombre";
            cbCurso.SelectedValuePath = "ID";
        }

        private void CargarTutores()
        {
            DAOTutores daoTutores = new DAOTutores();
            List<Tutor> tutores = daoTutores.ObtenerTutores();

            cbTutor.ItemsSource = tutores;
            cbTutor.DisplayMemberPath = "Nombre";
            cbTutor.SelectedValuePath = "ID";
        }

        private void btnAniadirAlumno_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellidos.Text) || string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtNumeroTelefono.Text) || cbCurso.SelectedValue == null || cbTutor.SelectedValue == null || dpFechaDeNacimiento.SelectedDate == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Crear el nuevo alumno
            Alumno nuevoAlumno = new Alumno
            {
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                DNI = txtDNI.Text,
                Email = txtEmail.Text,
                NumeroTelefono = txtNumeroTelefono.Text,
                Curso = (int?)cbCurso.SelectedValue,
                FechaDeNacimiento = dpFechaDeNacimiento.SelectedDate,
                TutoresID = (int)cbTutor.SelectedValue
            };

            // Guardar el alumno en la base de datos usando DAOAlumno
            DAOAlumno daoAlumno = new DAOAlumno();
            daoAlumno.AgregarAlumno(nuevoAlumno);

            // Cerrar la ventana después de añadir el alumno
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
