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
    /// Lógica de interacción para ModificarAlumno.xaml
    /// </summary>
    public partial class ModificarAlumno : Window
    {
        public ModificarAlumno()
        {
            InitializeComponent();
            CargarAlumnos();
            CargarCursos();
            CargarTutores();
        }

        private void CargarAlumnos()
        {
            DAOAlumno daoAlumno = new DAOAlumno();
            List<Alumno> alumnos = daoAlumno.ObtenerAlumnos();

            cbAlumnos.ItemsSource = alumnos;
            cbAlumnos.DisplayMemberPath = "Nombre";
            cbAlumnos.SelectedValuePath = "ID";
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

        private void cbAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAlumnos.SelectedItem != null)
            {
                Alumno alumnoSeleccionado = (Alumno)cbAlumnos.SelectedItem;
                txtNombre.Text = alumnoSeleccionado.Nombre;
                txtApellidos.Text = alumnoSeleccionado.Apellidos;
                txtDNI.Text = alumnoSeleccionado.DNI;
                txtEmail.Text = alumnoSeleccionado.Email;
                txtNumeroTelefono.Text = alumnoSeleccionado.NumeroTelefono;
                cbCurso.SelectedValue = alumnoSeleccionado.Curso;
                dpFechaDeNacimiento.SelectedDate = alumnoSeleccionado.FechaDeNacimiento;
                cbTutor.SelectedValue = alumnoSeleccionado.TutoresID;
            }
        }

        private void btnActualizarAlumno_Click(object sender, RoutedEventArgs e)
        {
            if (cbAlumnos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un alumno.");
                return;
            }

            Alumno alumnoSeleccionado = (Alumno)cbAlumnos.SelectedItem;

            alumnoSeleccionado.Nombre = txtNombre.Text;
            alumnoSeleccionado.Apellidos = txtApellidos.Text;
            alumnoSeleccionado.DNI = txtDNI.Text;
            alumnoSeleccionado.Email = txtEmail.Text;
            alumnoSeleccionado.NumeroTelefono = txtNumeroTelefono.Text;
            alumnoSeleccionado.Curso = (int)cbCurso.SelectedValue;
            alumnoSeleccionado.FechaDeNacimiento = dpFechaDeNacimiento.SelectedDate;
            alumnoSeleccionado.TutoresID = (int)cbTutor.SelectedValue;

            DAOAlumno daoAlumno = new DAOAlumno();
            daoAlumno.ModificarAlumno(alumnoSeleccionado);

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
