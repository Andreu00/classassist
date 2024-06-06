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
    /// Lógica de interacción para AñadirTarea.xaml
    /// </summary>
    public partial class AñadirTarea : Window
    {
        public AñadirTarea()
        {
            InitializeComponent();
            LlenarComboBoxAsignaturas();
        }

        private void LlenarComboBoxAsignaturas()
        {
            DAOAsignatura daoAsignaturas = new DAOAsignatura();
            List<Asignatura> asignaturas = daoAsignaturas.ObtenerAsignaturas();
            cbAsignaturas.ItemsSource = asignaturas;
            cbAsignaturas.DisplayMemberPath = "Nombre";
            cbAsignaturas.SelectedValuePath = "ID";
        }

        private void btnAñadirTarea_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            int asignaturaID = (int)cbAsignaturas.SelectedValue;
            string tipo = ((ComboBoxItem)cbTipo.SelectedItem)?.Content.ToString();
            string comentario = txtComentario.Text;
            string evaluacion = ((ComboBoxItem)cbEvaluacion.SelectedItem)?.Content.ToString();

            // Validar datos
            if (string.IsNullOrEmpty(nombre) || asignaturaID == 0 || string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(evaluacion))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            Tarea nuevaTarea = new Tarea
            {
                Nombre = nombre,
                Asignaturas_ID = asignaturaID,
                Tipo = tipo,
                Comentario = comentario,
                Evaluacion = evaluacion
            };

            DAOTareas daoTareas = new DAOTareas();
            daoTareas.AgregarTarea(nuevaTarea);

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
