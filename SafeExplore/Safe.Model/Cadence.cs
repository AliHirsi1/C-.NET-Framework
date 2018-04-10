using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safe.Model
{
   public class Cadence
    {
        public int CadenceID { get; set; }
        public int Sequence { get; set; }
        public string ProgramIncrement { get; set; }
        public string Iteration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string Notes { get; set; }

    }
}
