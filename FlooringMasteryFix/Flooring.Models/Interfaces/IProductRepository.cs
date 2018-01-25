using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Repo
{
    public interface IProductRepository
    {
        List<Product> AllProducts();
        Product LoadProducts(string productType);
        void SaveProdcuts(Product product);
    }
}
