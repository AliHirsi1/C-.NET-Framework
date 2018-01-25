using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class OrdersTestRepository : IOrderRepository
    {
        public static List<Order> _orders = new List<Order>
        {
            new Order
            {

                Date = Convert.ToDateTime("09/30/2017"),
                OrderNumber = 1,
                CustomerName = "Wise",
                StateAbbreviation = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
            },


            

            new Order
            {
                Date = Convert.ToDateTime("09/30/2017"),
                OrderNumber = 2,
                CustomerName = "Ali",
                StateAbbreviation = "MN",
                TaxRate = 6.25M,
                ProductType = "Tile",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                

            },
        };



        public List<Order> FindOrders(DateTime orderDate)
        {
            return _orders.OrderBy(o => o.OrderNumber).ToList();
               
        }
       
           


        public Order GetOrder(int orderNumber)
        {

            return _orders.Find(o => o.OrderNumber == o.OrderNumber);
        }

        public void RemoveOrder(Order order)
        {
            throw new NotImplementedException();
        }




        public void AddOrder(Order order)
        {
            
            _orders.Add(order);

        }

        Order IOrderRepository.AddOrder(Order order)
        {
            _orders.Add(order);
            return order;
        }

        public List<Order> GetOneOrder(Order oderDate, int id)
        {
            throw new NotImplementedException();
        }

        //public void RemoveOrder(Order order)
        //{
        //    throw new NotImplementedException();
        //}

       
        public  bool EditOrder(Order order)
        {
           
            try
            {
                _orders.RemoveAll(o => o.OrderNumber == order.OrderNumber);

                _orders.Add(order);
                return true;

            }
            catch 
            {
                return false;
            }



        }

        public void AddOrders(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
