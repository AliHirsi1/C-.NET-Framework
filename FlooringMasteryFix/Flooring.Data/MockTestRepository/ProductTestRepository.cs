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
    public class ProductTestRepository : IProductRepository
    {
        List<Product> prod = new List<Product>();

        public List<Product> AllProducts()
        {
            prod.Add(new Product
            {
                ProductType = "Carpet",
                CostPerSquareFoot = 2.25M,
                LaborCostPerSquareFoot = 2.10M
            });

            prod.Add(new Product
            {
                ProductType = "Laminate",
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M
                
            });


            return prod;
        }

              

        public Product LoadProducts(string productType)
        {
            List<Product> _products = AllProducts();
            var product = _products.SingleOrDefault(p => p.ProductType == productType);

           if(product != null)
            {
                return product;
            }
           else
            {
                return null;
            }
        }

        public void SaveProdcuts(Product product)
        {
            prod.Add(product);
        }
        
    }
}
