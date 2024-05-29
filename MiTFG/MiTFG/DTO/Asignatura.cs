using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class Asignatura
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int CursoID { get; set; }

        public Asignatura() { }

        public Asignatura(int id, string nombre, int cursoID)
        {
            ID = id;
            Nombre = nombre;
            CursoID = cursoID;
        }
    }
}
