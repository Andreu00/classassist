using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class CriterioDeEvaluacion
    {
        public int Id { get; set; }
        public string NombreCriterio { get; set; }

        public CriterioDeEvaluacion() { }

        public CriterioDeEvaluacion(int id, string nombreCriterio)
        {
            Id = id;
            NombreCriterio = nombreCriterio;
        }
    }
}
