using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTFG.DTO
{
    internal class AsignaturaCriterio
    {
        public int AsignaturasID { get; set; }
        public int CriteriosDeEvaluacionID { get; set; }

        public AsignaturaCriterio() { }

        public AsignaturaCriterio(int asignaturasID, int criteriosDeEvaluacionID)
        {
            AsignaturasID = asignaturasID;
            CriteriosDeEvaluacionID = criteriosDeEvaluacionID;
        }
    }
}

