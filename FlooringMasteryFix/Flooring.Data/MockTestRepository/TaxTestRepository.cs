using Flooring.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using System.IO;

namespace Flooring.Data
{
    public class TaxTestRepository : IStateTaxRepository
    {
        List<StateTax> taxes = new List<StateTax>();

        public List<StateTax> GetAllStateTax()
        {
            

            taxes.Add(new StateTax
            {
                StateAbbreviation = "OH",
                StateName = "OHIO",
                TaxRate = 0.06875M

            });

            taxes.Add(new StateTax
            {
                StateAbbreviation = "PA",
                StateName = "Pennsylvania",
                TaxRate = 0.0675M

            });

            taxes.Add(new StateTax
            {
                StateAbbreviation = "MI",
                StateName = "Michigan",
                TaxRate = 0.0575M
                
            });

            taxes.Add(new StateTax
            {
                StateAbbreviation = "IN",
                StateName = "Indiana",
                TaxRate = 0.600M
                
            });

            return taxes;
             
        }


        public StateTax LoadStateTax(string stateName)
        {
            List<StateTax> _stateTaxes = GetAllStateTax();
            var stateTax = _stateTaxes.SingleOrDefault(s => s.StateName == stateName);
            if (stateTax != null)
            {
                return stateTax;
            }
            else
            {
                return null;
            }
        }

        public void SaveStateTax(StateTax stateTax)
        {
            taxes.Add(stateTax);
        }
    }

}

