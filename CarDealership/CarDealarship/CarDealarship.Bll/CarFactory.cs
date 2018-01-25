using CarDealarship.Data.EF;
using CarDealarship.Data.Mock;
using CarDealarship.Model.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Bll
{
    public class CarFactory
    {
        public static IVehicleRepository Create()
        {
           
            string mode = ConfigurationManager.AppSettings["mode"].ToString();
            
            switch (mode)
            {
                case "Mock":
                    return new MockRepo();

                case "EF":
                    return new EFRepo();

                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}

