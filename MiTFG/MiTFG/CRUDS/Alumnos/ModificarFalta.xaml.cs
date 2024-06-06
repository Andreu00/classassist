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
    /// Lógica de interacción para ModificarFalta.xaml
    /// </summary>
    public partial class ModificarFalta : Window
    {
        private int faltaID;

        public ModificarFalta()
        {
            InitializeComponent();
            LlenarComboBoxFaltas();
            CargarHoras();
            CargarAlumnos();
        }

        private void LlenarComboBoxFaltas()
        {
            DAOFaltas daoFaltas = new DAOFaltas();
            List<FaltaDeAsistencia> faltas = daoFaltas.ObtenerFaltas();
            cmbFaltas.ItemsSource = faltas;
            cmbFaltas.DisplayMemberPath = "ID";
            cmbFaltas.SelectedValuePath = "ID";
        }

        private void CargarAlumnos()
        {
            DAOAlumno daoAlumno = new DAOAlumno();
            List<Alumno> alumnos = daoAlumno.ObtenerAlumnos();
            cmbAlumnos.ItemsSource = alumnos;
            cmbAlumnos.DisplayMemberPath = "Nombre";
            cmbAlumnos.SelectedValuePath = "ID";
        }

        private void CargarHoras()
        {
            var horasClase = new List<string>
            {
                "08:30 - 09:25",
                "09:25 - 10:20",
                "10:20 - 11:15",
                "11:45 - 12:40",
                "12:40 - 13:35",
                "13:35 - 14:30",
                "16:00 - 16:55",
                "16:55 - 17:50",
                "17:50 - 18:45",
                "19:00 - 19:55",
                "19:55 - 20:50",
                "20:50 - 21:45"
            };

            cmbHora.ItemsSource = horasClase;
        }

        private void CargarAsignatura(int asignaturaID)
        {
            DAOAsignatura daoAsignatura = new DAOAsignatura();
            string nombreAsignatura = daoAsignatura.ObtenerNombreAsignaturaPorID(asignaturaID);
            List<Asignatura> asignaturas = new List<Asignatura>
            {
                new Asignatura { ID = asignaturaID, Nombre = nombreAsignatura }
            };
            cmbAsignatura.ItemsSource = asignaturas;
            cmbAsignatura.DisplayMemberPath = "Nombre";
            cmbAsignatura.SelectedValuePath = "ID";

            cmbAsignatura.SelectedValue = asignaturaID;
        }

        private void cmbFaltas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FaltaDeAsistencia faltaSeleccionada = cmbFaltas.SelectedItem as FaltaDeAsistencia;
            if (faltaSeleccionada != null)
            {
                faltaID = faltaSeleccionada.ID;
                cmbAlumnos.SelectedValue = faltaSeleccionada.AlumnoID;
                dpFecha.SelectedDate = faltaSeleccionada.Fecha;
                cmbHora.SelectedItem = cmbHora.Items.Cast<string>().FirstOrDefault(item => item.StartsWith(faltaSeleccionada.Hora.ToString(@"hh\:mm")));
                CargarAsignatura(faltaSeleccionada.AsignaturaID);
                cbEstado.SelectedItem = cbEstado.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == faltaSeleccionada.Estado);

                // Deshabilitar todos los controles excepto el ComboBox de Estado
                cmbAlumnos.IsEnabled = false;
                dpFecha.IsEnabled = false;
                cmbHora.IsEnabled = false;
                cmbAsignatura.IsEnabled = false;
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (cbEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un estado.");
                return;
            }

            FaltaDeAsistencia faltaModificada = new FaltaDeAsistencia
            {
                ID = faltaID,
                Estado = ((ComboBoxItem)cbEstado.SelectedItem).Content.ToString()
            };

            DAOFaltas daoFaltas = new DAOFaltas();
            daoFaltas.ModificarFaltaEstado(faltaModificada);

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
