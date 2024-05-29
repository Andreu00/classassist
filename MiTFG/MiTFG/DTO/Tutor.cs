using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class Tutor
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string TlfnEmergencia { get; set; }
        public string Email { get; set; }
        public int IdAlumno { get; set; }

        public Tutor() { }

        public Tutor(int id, string nombre, string telefono, string tlfnEmergencia, string email, int idAlumno)
        {
            ID = id;
            Nombre = nombre;
            Telefono = telefono;
            TlfnEmergencia = tlfnEmergencia;
            Email = email;
            IdAlumno = idAlumno;
        }
    }
}
