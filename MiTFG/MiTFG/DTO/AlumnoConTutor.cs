using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class AlumnoConTutor
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string NumeroTelefono { get; set; }
        public int? Curso { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string TutorNombre { get; set; }
    }
}
