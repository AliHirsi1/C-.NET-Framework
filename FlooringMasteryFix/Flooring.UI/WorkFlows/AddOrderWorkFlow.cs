using Flooring.BLL;
using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.WorkFlows
{
    public class AddOrderWorkFlow
    {
        public void Execute()
        {
            Console.Clear();

            OrderManager manager = OrderManagerFactory.Create();
          

            // prompt user to enter valid date
            DateTime date = ConsoleIO.UserInputDateValidation();

            // Prompt user to enter date
           // Console.Write("Enter customer name: ");
            string customerName = ConsoleIO.CustomerNameValidation();

            string state = ConsoleIO.StateValidation();



            // prompt user to enter one of the products we sell

            string productType = ConsoleIO.ProductTypeValidatoin();
            
            // prompt user to enter valid area
            
            decimal area = ConsoleIO.AreaValidation();



            Order order = new Order();

            order.Date = date;
            order.CustomerName = customerName;
            order.StateAbbreviation = state;
            order.ProductType = productType;
            order.Area = area;

            

           AddOrderResponse response = new AddOrderResponse();

            Console.Clear();
            Console.WriteLine("New Order Summary");
            Console.WriteLine("=========================");

           
            if (ConsoleIO.IsConfirmed())
            {
                response = manager.AddOrder(order);

            }

        }
    }
}
