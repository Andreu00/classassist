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
        public int Asignaturas_ID { get; set; }
        public string Tipo { get; set; }
        public string Comentario { get; set; }
        public string Evaluacion { get; set; }

        public Tarea() { }

        public Tarea(int id, string nombre, int asignaturas_ID, string tipo, string comentario, string evaluacion)
        {
            ID = id;
            Nombre = nombre;
            Asignaturas_ID = asignaturas_ID;
            Tipo = tipo;
            Comentario = comentario;
            Evaluacion = evaluacion;
        }
    }
}
