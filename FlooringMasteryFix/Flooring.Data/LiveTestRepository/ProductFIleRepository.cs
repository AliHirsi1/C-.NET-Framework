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
   public class ProductFIleRepository : IProductRepository
    {

        string _filePath;
        public ProductFIleRepository(string filePath)
        {
            _filePath = filePath;
        }

        public Product LoadProducts(string productType)
        {
            var prod = AllProducts();
            return prod.FirstOrDefault(a => a.ProductType == productType);
        }

        public List<Product> AllProducts()
        {
           

            List<Product> products = new List<Product>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Product product = new Product();

                    string [] space = line.Split(',');

                    product.ProductType = space[0];
                    product.CostPerSquareFoot = decimal.Parse(space[1]);
                    product.LaborCostPerSquareFoot = decimal.Parse(space[2]);

                    products.Add(product);


                }

            }

            return products;
        }

       

        public void SaveProdcuts(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
