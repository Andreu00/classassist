using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class CriteriosVista
    {
        public int ID { get; set; }
        public string NombreCriterio { get; set; }
        public bool Cumple { get; set; }

        public CriteriosVista() { }

        public CriteriosVista(int id, string nombreCriterio, bool cumple)
        {
            ID = id;
            NombreCriterio = nombreCriterio;
            Cumple = cumple;
        }
    }
}
