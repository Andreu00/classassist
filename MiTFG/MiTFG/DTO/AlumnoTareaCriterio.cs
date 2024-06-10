using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class AlumnoTareaCriterio
    {
        public int AlumnoID { get; set; }
        public int TareaID { get; set; }
        public int CriterioID { get; set; }
        public bool Cumple { get; set; }

        public AlumnoTareaCriterio() { }

        public AlumnoTareaCriterio(int alumnoID, int tareaID, int criterioID, bool cumple)
        {
            AlumnoID = alumnoID;
            TareaID = tareaID;
            CriterioID = criterioID;
            Cumple = cumple;
        }
    }
}
