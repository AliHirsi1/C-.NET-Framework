using DvdLibrarys.Data.ADO;
using DvdLibrarys.Data.EF;
using DvdLibrarys.Data.Mock;
using DvdLibrarys.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrarys.Bll
{
    public class DvdFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode)
            {
                case "Mock":
                    return new MockTestRepository();

                case "ADO":
                    return new ADORepo();

                case "EF":
                    return new EFRepo();

                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
