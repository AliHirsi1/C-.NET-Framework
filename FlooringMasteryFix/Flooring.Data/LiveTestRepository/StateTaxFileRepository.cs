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
    public class StateTaxFileRepository : IStateTaxRepository
    {

        string _filePath ;

        public StateTaxFileRepository(string filePath)
        {
            _filePath = filePath;
        }
        public List<StateTax> GetAllStateTax()
        {
            

            List<StateTax> taxes = new List<StateTax>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    StateTax tax = new StateTax();

                    string[] space = line.Split(',');

                    tax.StateAbbreviation = space[0];
                    tax.StateName = space[1];
                    tax.TaxRate = decimal.Parse(space[2]);

                    taxes.Add(tax);
                }
            }

            return taxes;
        }

        public StateTax LoadStateTax(string stateName)
        {
            throw new NotImplementedException();
        }

        public void SaveStateTax(StateTax stateTax)
        {
            throw new NotImplementedException();
        }
    }
}
