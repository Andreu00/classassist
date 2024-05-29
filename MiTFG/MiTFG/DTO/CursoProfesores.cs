using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class CursoProfesores
    {
        public int CursoID { get; set; }
        public int ProfesorID { get; set; }

        public CursoProfesores() { }

        public CursoProfesores(int cursoID, int profesorID)
        {
            CursoID = cursoID;
            ProfesorID = profesorID;
        }
    }
}
