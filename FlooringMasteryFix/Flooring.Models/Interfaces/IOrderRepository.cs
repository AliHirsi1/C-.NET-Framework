using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public interface IOrderRepository
    {

        List<Order> FindOrders(DateTime orderDate);
        void RemoveOrder(Order order);
        Order AddOrder(Order order);
        void AddOrders(Order order);
        List<Order> GetOneOrder(Order oderDate, int id);

        bool EditOrder(Order order);
        

        Order GetOrder(int orderNumber);

    }
}
