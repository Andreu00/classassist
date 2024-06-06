using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class AlumnoTarea
    {
        public int Alumnos_ID { get; set; }
        public int Tarea_ID { get; set; }
        public int? Nota { get; set; }  //La interrogacion "?" nos permite que la variable int sea nula, en caso de no tenerla el valor de double deberia ser obligatorio

        public AlumnoTarea() { }

        public AlumnoTarea(int alumnos_ID, int tarea_ID, int? nota)
        {
            Alumnos_ID = alumnos_ID;
            Tarea_ID = tarea_ID;
            Nota = nota;
        }
    }
}
