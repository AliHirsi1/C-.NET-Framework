using Flooring.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class OrderFileRepository : IOrderRepository
    {
        string _directory;
        string _firstPath = @"\Orders_";
        string _fileFormat = ".txt";
        

        public OrderFileRepository(string directory)
        {
            _directory = directory;
        }

        public void AddOrders(Order order)
        {

            
            string directory = GenerateFilePath(order.Date);

            if (!File.Exists(directory))
            {
                using (StreamWriter sr = new StreamWriter(directory, true))
                {
                    string line = CreateFormat(order);
                    sr.WriteLine(line);
                }
            }
        }

        public void EditOrder(Order order, int orderNumber, DateTime orderDate)
        {
            var orders = FindOrders(orderDate);
            orders[orderNumber] = order;
            CreateOrderFile(orders, orderDate);
        }

        

        public List<Order> FindOrders(DateTime orderDate)
        {
            List<Order> orders = new List<Order>();

            string filePath = GenerateFilePath(orderDate);


            try
            {

                if (File.Exists(filePath))
                {


                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        sr.ReadLine();
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Order order = new Order();

                            string[] space = line.Split(',');

                            order.OrderNumber = int.Parse(space[0]);
                            order.CustomerName = space[1];
                            order.StateAbbreviation = space[2];
                            order.TaxRate = decimal.Parse(space[3]);
                            order.ProductType = space[4];
                            order.Area = decimal.Parse(space[5]);
                            order.CostPerSquareFoot = decimal.Parse(space[6]);
                            order.LaborCostPerSquareFoot = decimal.Parse(space[8]);

                            orders.Add(order);


                        }


                    }


                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred, file cannot be opened {ex.Message}", ex.Message);
            }

            return orders;
        }

        private string GenerateFilePath(DateTime orderDate)
        {
            string filePath = @"C:\Users\Guild\FlooringMastery\ProductionFiles";
            string createFilePath = filePath + _firstPath + orderDate.Date.ToString("MMddyyyy") + _fileFormat;

            return createFilePath;

        }

        public List<Order> GetOneOrder(Order oderDate, int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int orderNumber)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(DateTime orderDate, int orderNumber)
        {
            var orders = FindOrders(orderDate);
            orders.RemoveAt(orderNumber);

            CreateOrderFile(orders, orderDate);
        }

        public Order AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        private string CreateFormat(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                        order.OrderNumber, order.CustomerName, order.StateAbbreviation, order.TaxRate,
                        order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot,
                        order.MaterialCost, order.LaborCost, order.Tax, order.Total);

        }
        private void CreateOrderFile(List<Order> orders, DateTime orderDate)
        {
            
            if (File.Exists(GenerateFilePath(orderDate)))
            {
                File.Delete(GenerateFilePath(orderDate));

                using (StreamWriter sr = new StreamWriter(GenerateFilePath(orderDate)))
                {

                    sr.WriteLine("OrderNumber, CustomerName, StateAbbreviation, TaxRate, ProductType, Area, CostPerSquareFoot, LaborCostPerSquareFoor, MaterialCost, LaborCost, Tax, Total");
                    foreach(var order in orders )
                    {
                        sr.WriteLine(CreateFormat(order));
                    }
                }
            }
        }

        bool IOrderRepository.EditOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }





}


