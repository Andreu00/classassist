using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string usuarioAcceso { get; set; }
        public string password { get; set; }
        public int? Curso { get; set; }
        public string Rango { get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string usuarioAcceso, string password, int? curso, string rango)
        {
            this.id = id;
            this.nombre = nombre;
            this.usuarioAcceso = usuarioAcceso;
            this.password = password;
            this.Curso = curso;
            this.Rango = rango;
        }
    }
}
