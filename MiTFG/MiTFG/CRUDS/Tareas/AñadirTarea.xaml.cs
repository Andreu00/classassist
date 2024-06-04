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
            LlenarComboBoxCursos();
        }

        private void btnAñadirTarea_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string tipo = ((ComboBoxItem)cbTipo.SelectedItem)?.Content.ToString();
            string comentario = txtComentario.Text;
            int? cursoID = (int?)cbCurso.SelectedValue;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(tipo) || !cursoID.HasValue)
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            Tarea nuevaTarea = new Tarea
            {
                Nombre = nombre,
                Tipo = tipo,
                Comentario = comentario,
                Cursos_ID = cursoID.Value
            };

            DAOTareas daoTareas = new DAOTareas();
            daoTareas.agregarTarea(nuevaTarea);
            this.Close();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LlenarComboBoxCursos()
        {
            DAOCursos daoCursos = new DAOCursos();
            List<Curso> cursos = daoCursos.ObtenerCursos();
            cbCurso.ItemsSource = cursos;
            cbCurso.DisplayMemberPath = "Nombre";
            cbCurso.SelectedValuePath = "ID";
        }

    }
}
