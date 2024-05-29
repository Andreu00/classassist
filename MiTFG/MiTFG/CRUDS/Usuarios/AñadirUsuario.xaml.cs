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
    /// Lógica de interacción para AñadirUsuario.xaml
    /// </summary>
    public partial class AñadirUsuario : Window
    {
        public AñadirUsuario()
        {
            InitializeComponent();
            rellenarCursos();
        }

        private void rellenarCursos()
        {
            DAOCursos daoCursos = new DAOCursos();
            List<Curso> cursos = daoCursos.ObtenerCursos();

            lbCursos.ItemsSource = cursos;
        }

        private void btnAniadirUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Capturar datos de los controles
            string nombre = txtNombre.Text;
            string usuarioAcceso = txtUsuarioAcceso.Text;
            string password = txtPassword.Password;
            string rango = ((ComboBoxItem)cbRango.SelectedItem)?.Content.ToString();

            // Validar datos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(usuarioAcceso) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(rango))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            // Crear el nuevo usuario
            Usuario nuevoUsuario = new Usuario
            {
                nombre = nombre,
                usuarioAcceso = usuarioAcceso,
                password = password,
                Rango = rango
            };

            // Guardar el usuario en la base de datos usando DAOUsuario
            DAOUsuario daoUsuario = new DAOUsuario();
            daoUsuario.agregarUsuario(nuevoUsuario);

            // Obtener el ID del usuario recién agregado
            int usuarioID = daoUsuario.obtenerIDUsuario(usuarioAcceso);

            if (usuarioID > 0)
            {
                // Si el usuario es profesor o ambos, añadir a CursoProfesores
                if (rango == "profesor" || rango == "ambos")
                {
                    DAOCursoProfesores daoCursoProfesores = new DAOCursoProfesores();
                    List<int> cursosSeleccionados = lbCursos.SelectedItems.Cast<Curso>().Select(c => c.ID).ToList();
                    daoCursoProfesores.ActualizarRelacionesDeProfesor(usuarioID, cursosSeleccionados, rango);
                }

                MessageBox.Show("Usuario añadido con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al añadir el usuario.");
            }
        }
    }
}
