using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Flooring.Data;


namespace Flooring.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {


        string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch(mode)
            {
                
                case "GeneralTest":
                    return new OrderManager(new OrdersTestRepository(),  new TaxTestRepository(), new ProductTestRepository());


                case "ProdTest":
                    return new OrderManager(new OrderFileRepository(@"C:\Users\Guild\FlooringMastery\ProductionFiles"), new StateTaxFileRepository(@"C:\Users\Guild\FlooringMastery\ProductionFiles\Taxes.txt"), new ProductFIleRepository(@"C:\Users\Guild\FlooringMastery\ProductionFiles\Products.txt"));


                default:
                    throw new Exception("Mode Configuration value in app config is not valid. Check OrderManagerFactory class in Models Project.");
            }
        }
    }
}
