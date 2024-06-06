using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class FaltaDeAsistencia
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int AlumnoID { get; set; }
        public int AsignaturaID { get; set; }
        public string Estado { get; set; }

        // Constructor vacío
        public FaltaDeAsistencia() { }

        // Constructor con parámetros
        public FaltaDeAsistencia(int id, DateTime fecha, TimeSpan hora, int alumnoID, int asignaturaID, string estado)
        {
            ID = id;
            Fecha = fecha;
            Hora = hora;
            AlumnoID = alumnoID;
            AsignaturaID = asignaturaID;
            Estado = estado;
        }
    }
}
