using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class Curso
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public Curso() { }

        public Curso(int id, string nombre, int profesores)
        {
            ID = id;
            Nombre = nombre;
        }
    }
}
