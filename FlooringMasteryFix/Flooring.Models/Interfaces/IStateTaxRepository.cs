using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Repo
{
    public interface IStateTaxRepository
    {
        List<StateTax> GetAllStateTax();
        StateTax LoadStateTax(string stateName);
        void SaveStateTax(StateTax stateTax);
    }
}

