using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class Tarea
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public int IdAlumno { get; set; }
        public decimal Nota { get; set; }
        public string Comentario { get; set; }

        public Tarea() { }

        public Tarea(int id, string tipo, int idAlumno, decimal nota, string comentario)
        {
            ID = id;
            Tipo = tipo;
            IdAlumno = idAlumno;
            Nota = nota;
            Comentario = comentario;
        }
    }
}
