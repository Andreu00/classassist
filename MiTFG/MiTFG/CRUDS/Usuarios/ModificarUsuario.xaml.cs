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

namespace MiTFG.CRUDS.Usuarios
{
    /// <summary>
    /// Lógica de interacción para ModificarEliminarUsuario.xaml
    /// </summary>
    public partial class ModificarUsuario : Window
    {
        private List<int> cursosAnteriores;
        public ModificarUsuario()
        {
            InitializeComponent();
            LlenarComboBoxUsuarios();
            LlenarComboBoxCursos();
        }

        private void LlenarComboBoxUsuarios()
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            List<Usuario> usuarios = daoUsuario.obtenerUsuarios();

            cbUsuarios.Items.Clear(); // Limpiar los ítems existentes
            cbUsuarios.Items.Add("Seleccionar Usuario"); // Agregar ítem por defecto
            foreach (var usuario in usuarios)
            {
                cbUsuarios.Items.Add(usuario);
            }
            cbUsuarios.SelectedIndex = 0; // Seleccionar el ítem por defecto
        }

        private void LlenarComboBoxCursos()
        {
            DAOCursos daoCursos = new DAOCursos();
            List<Curso> cursos = daoCursos.ObtenerCursos();

            lbCursos.ItemsSource = cursos;
        }

        private void cbUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbUsuarios.SelectedIndex > 0) // Ignorar el ítem por defecto
            {
                Usuario usuarioSeleccionado = cbUsuarios.SelectedItem as Usuario;
                if (usuarioSeleccionado != null)
                {
                    txtNombre.Text = usuarioSeleccionado.nombre;
                    txtUsuarioAcceso.Text = usuarioSeleccionado.usuarioAcceso;
                    txtPassword.Password = usuarioSeleccionado.password;

                    // Obtener cursos anteriores del usuario
                    DAOCursoProfesores daoCursoProfesores = new DAOCursoProfesores();
                    cursosAnteriores = daoCursoProfesores.ObtenerCursosDeProfesor(usuarioSeleccionado.id);
                    lbCursos.SelectedItems.Clear();
                    foreach (int cursoID in cursosAnteriores)
                    {
                        lbCursos.SelectedItems.Add(lbCursos.Items.Cast<Curso>().FirstOrDefault(c => c.ID == cursoID));
                    }

                    cbRango.SelectedItem = cbRango.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == usuarioSeleccionado.Rango);
                }
            }
            else
            {
                // Limpiar los campos si se selecciona el ítem por defecto
                txtNombre.Text = string.Empty;
                txtUsuarioAcceso.Text = string.Empty;
                txtPassword.Password = string.Empty;
                lbCursos.SelectedItems.Clear();
                cbRango.SelectedIndex = -1;
                cursosAnteriores = null;
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (cbUsuarios.SelectedIndex > 0) // Ignorar el ítem por defecto
            {
                Usuario usuarioSeleccionado = cbUsuarios.SelectedItem as Usuario;
                if (usuarioSeleccionado != null)
                {
                    usuarioSeleccionado.nombre = txtNombre.Text;
                    usuarioSeleccionado.usuarioAcceso = txtUsuarioAcceso.Text;
                    usuarioSeleccionado.password = txtPassword.Password;
                    usuarioSeleccionado.Rango = ((ComboBoxItem)cbRango.SelectedItem)?.Content.ToString();

                    DAOUsuario daoUsuario = new DAOUsuario();
                    daoUsuario.modificarUsuario(usuarioSeleccionado);

                    // Actualizar relaciones en CursoProfesores
                    DAOCursoProfesores daoCursoProfesores = new DAOCursoProfesores();
                    List<int> cursosSeleccionados = lbCursos.SelectedItems.Cast<Curso>().Select(c => c.ID).ToList();
                    daoCursoProfesores.ActualizarRelacionesDeProfesor(usuarioSeleccionado.id, cursosSeleccionados, usuarioSeleccionado.Rango);

                    LlenarComboBoxUsuarios(); // Actualizar la lista de usuarios en el ComboBox
                }
                else
                {
                }
            }
        }
    }
}
