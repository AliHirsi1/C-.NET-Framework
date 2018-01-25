using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Flooring.BLL;
using Flooring.Models.Responses;
using Flooring.Models;
using Flooring.Data;
using System.IO;
namespace Flooring.Test

{
    [TestFixture]
    public class UnitTest
    {
        private const string _filePath = @"C:\Users\Guild\FlooringMastery\ProductionFiles\Orders_09222017.txt";
        private const string _OriginalDate = @"C:\Users\Guild\FlooringMastery\ProductionFiles\OrdersTest_09222017.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            File.Copy(_OriginalDate, _filePath);
        }

        [Test]
        public void CanLoadOrdersFromMemory()
        {
            OrdersTestRepository repo = new OrdersTestRepository();
            List<Order> order = repo.FindOrders(Convert.ToDateTime("09/30/2017"));
            Assert.IsNotNull(order);
            Assert.AreEqual(Convert.ToDateTime("09/30/2017"), order[0].Date);
            Assert.AreEqual("Wise", order[0].CustomerName);
            Assert.AreEqual(5.15M, order[0].CostPerSquareFoot);
          
        }
        
        [Test]
        public void CanLoadState()
        {
            TaxTestRepository repo = new TaxTestRepository();

            List<StateTax> tax = repo.GetAllStateTax();

            Assert.AreEqual("OH", tax[0].StateAbbreviation);
            Assert.AreEqual(.06875M, tax[0].TaxRate);
            Assert.AreEqual("MI", tax[2].StateAbbreviation);
            Assert.AreNotEqual("IN", tax[0].StateAbbreviation);
            Assert.AreNotEqual("MN", tax[1].StateAbbreviation);

        }

        [Test]
        public void CanLoadProducts()
        {
            ProductTestRepository repo = new ProductTestRepository();
            List<Product> products = repo.AllProducts();

            Assert.AreEqual("Carpet", products[0].ProductType);
            Assert.AreEqual(2.10M, products[0].LaborCostPerSquareFoot);
            Assert.AreNotEqual("Labtop", products[1].ProductType);
            Assert.AreEqual("Laminate", products[1].ProductType);

        }

        [Test]
        public void CanReadDataFromProductFile()
        {
            ProductFIleRepository repo = new ProductFIleRepository(@"C:\Users\Guild\FlooringMastery\ProductionFiles\Products.txt");

            List <Product> products = repo.AllProducts();

            Assert.AreEqual(4, products.Count());

            Product check = products[0];

            Assert.AreEqual("Carpet", check.ProductType);
            Assert.AreEqual(2.25M, check.CostPerSquareFoot);
            Assert.AreEqual(2.10M, check.LaborCostPerSquareFoot);

        }

        [Test]
        public void CanReadOrdersFromOrdersFile()
        {

            OrderFileRepository repo = new OrderFileRepository(_filePath);
            List<Order> orders = repo.FindOrders(Convert.ToDateTime("09/22/2017"));

            Assert.AreEqual(2, orders.Count());

            Order check = orders[1];
            Assert.AreEqual(1, check.OrderNumber);
            Assert.AreEqual("Wise", check.CustomerName);
            Assert.AreEqual("OH", check.StateAbbreviation);
            Assert.AreEqual(6.25M, check.TaxRate);
            Assert.AreEqual("Wood", check.ProductType);
        
        }
        
        [Test]
        public void CanReadTaxFromFile()
        {
            StateTaxFileRepository repo = new StateTaxFileRepository(@"C:\Users\Guild\FlooringMastery\ProductionFiles\Taxes.txt");

            List<StateTax> taxes = repo.GetAllStateTax();

            Assert.AreEqual(4, taxes.Count());

            StateTax check = taxes[3];
            Assert.AreEqual("IN", check.StateAbbreviation);
            Assert.AreEqual("Indiana", check.StateName);
            Assert.AreEqual(6.00M, check.TaxRate);

        }

        [Test]
        public void CanAddOrderToFile()
        {
            OrderFileRepository repo = new OrderFileRepository(_filePath);

            Order newOrder = new Order();
            newOrder.OrderNumber = 2;
            newOrder.CustomerName = "Hanad";
            newOrder.StateAbbreviation = "MN";
            newOrder.TaxRate = 6.25M;
            newOrder.ProductType = "Tile";
            newOrder.Area = 200.00M;
            newOrder.CostPerSquareFoot = 5.17M;
            newOrder.LaborCostPerSquareFoot = 4.90M;

            repo.AddOrders(newOrder);

            List<Order> orders = repo.FindOrders(Convert.ToDateTime("09/22/2017"));

            Assert.AreEqual(2, orders.Count());

            Order check = orders[1];
            Assert.AreEqual(2, check.OrderNumber);
            Assert.AreEqual("Hanad", check.CustomerName);
            Assert.AreEqual("MN", check.StateAbbreviation);
            Assert.AreEqual(200.00M, check.Area);
            Assert.AreEqual("Tile", check.ProductType);


        }

        [Test]
        public void CanRemoveOrderFromFile()
        {
            OrderFileRepository repo = new OrderFileRepository(_filePath);
           // repo.RemoveOrder(0);

           // List<Order> orders = repo.FindOrders();
           // Assert.AreEqual(1, orders.Count());
        }

    }
}
