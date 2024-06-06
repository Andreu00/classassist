using MiTFG.DAO;
using MiTFG.DTO;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para ModificarTarea.xaml
    /// </summary>
    public partial class ModificarTarea : Window
    {
        private int tareaID;
        public ModificarTarea()
        {
            InitializeComponent();
            LlenarComboBoxTareas();
            LlenarComboBoxAsignaturas();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string tipo = ((ComboBoxItem)cbTipo.SelectedItem)?.Content.ToString();
            string comentario = txtComentario.Text;
            int? asignaturaID = (int?)cbAsignaturas.SelectedValue;
            string evaluacion = ((ComboBoxItem)cbEvaluacion.SelectedItem)?.Content.ToString();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(tipo) || !asignaturaID.HasValue || string.IsNullOrEmpty(evaluacion))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            Tarea tareaModificada = new Tarea
            {
                ID = tareaID,
                Nombre = nombre,
                Tipo = tipo,
                Comentario = comentario,
                Asignaturas_ID = asignaturaID.Value,
                Evaluacion = evaluacion
            };

            DAOTareas daoTareas = new DAOTareas();
            daoTareas.ModificarTarea(tareaModificada);

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbTarea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tarea tareaSeleccionada = cbTarea.SelectedItem as Tarea;
            if (tareaSeleccionada != null)
            {
                tareaID = tareaSeleccionada.ID;
                txtNombre.Text = tareaSeleccionada.Nombre;
                txtComentario.Text = tareaSeleccionada.Comentario;

                cbTipo.SelectedItem = cbTipo.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == tareaSeleccionada.Tipo);
                cbAsignaturas.SelectedValue = tareaSeleccionada.Asignaturas_ID;
                cbEvaluacion.SelectedItem = cbEvaluacion.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == tareaSeleccionada.Evaluacion);
            }
        }

        private void LlenarComboBoxTareas()
        {
            DAOTareas daoTareas = new DAOTareas();
            List<Tarea> tareas = daoTareas.ObtenerTareas();
            cbTarea.ItemsSource = tareas;
            cbTarea.DisplayMemberPath = "Nombre";
            cbTarea.SelectedValuePath = "ID";
        }

        private void LlenarComboBoxAsignaturas()
        {
            DAOAsignatura daoAsignaturas = new DAOAsignatura();
            List<Asignatura> asignaturas = daoAsignaturas.ObtenerAsignaturas();
            cbAsignaturas.ItemsSource = asignaturas;
            cbAsignaturas.DisplayMemberPath = "Nombre";
            cbAsignaturas.SelectedValuePath = "ID";
        }
    }
}
