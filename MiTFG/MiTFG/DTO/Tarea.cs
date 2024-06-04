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
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Comentario { get; set; }
        public int Cursos_ID { get; set; }

        public Tarea() { }

        public Tarea(int id, string nombre, string tipo, string comentario, int cursos_ID)
        {
            ID = id;
            Nombre = nombre;
            Tipo = tipo;
            Comentario = comentario;
            Cursos_ID = cursos_ID;
        }
    }
}
