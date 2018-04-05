using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safe.Model
{
    public class Capacity
    {
        public int CapacityID { get; set; }
        public virtual Cadence CadenceID { get; set; }
        public string TeamID { get; set; }
        public string TeamName { get; set; }
        public string ProgramIncrement { get; set; }
        public int Iteration1 { get; set; }
        public int Iteration2 { get; set; }
        public int Iteration3 { get; set; }
        public int Iteration4 { get; set; }
        public int Iteration5 { get; set; }
        public int Iteration6 { get; set; }
        public int Total { get; set; }


    }
}
