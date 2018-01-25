using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.Models.Responses;

namespace Flooring.UI.WorkFlows
{
    public class DisplayOrderWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();
            Console.WriteLine("Display Orders");
            Console.WriteLine("=====================");

            // prompt user to enter a date of orders

           
            DateTime orderDate = ConsoleIO.UserInputDateValidation();
            Console.WriteLine("");

            DisplayOrderResponse resonse = manager.DisplayOrders(orderDate);

            if (resonse.Success)
            {
                ConsoleIO.DisplayOrdersDetails(resonse.Orders);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(resonse.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
