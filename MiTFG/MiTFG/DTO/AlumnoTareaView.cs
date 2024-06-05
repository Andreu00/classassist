using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class AlumnoTareaView
    {
        public int Alumno_ID { get; set; }
        public string NombreAlumno { get; set; }
        public int Tarea_ID { get; set; }
        public string NombreTarea { get; set; }
        public double? Nota { get; set; }
    }
}
