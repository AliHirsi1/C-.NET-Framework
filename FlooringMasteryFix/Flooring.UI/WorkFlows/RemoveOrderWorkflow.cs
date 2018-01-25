using Flooring.BLL;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flooring.UI.WorkFlows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            
            OrderManager manager = OrderManagerFactory.Create();
           
            // Prompt user to enter order date
            DateTime date = ConsoleIO.UserInputDateValidation();

           

            RemoveOrderResponse response = new RemoveOrderResponse();
            DisplayOrderResponse lookUp = manager.DisplayOrders(date);


           // lookUp = manager.DisplayOrders(date);   // Load all the orders

            if (lookUp.Success)
            {
                
                Console.Clear();
                Console.WriteLine("Display Orders");
                Console.WriteLine("=====================");
                ConsoleIO.DisplayOrdersDetails(lookUp.Orders);
                // Prompt user to enter valid date
                int orderNumber = ConsoleIO.OrderNumberValidation();

                // prompt user if they want to remove this order

                if (ConsoleIO.IsRemoved())
                {
                    var reload = manager.RemoveOrder(date, orderNumber);
                }

            }




            else
            {
                Console.WriteLine("");
                Console.WriteLine("There are no orders from that date to be deleted!");
                Console.Write("Press any key to continue... ");
                Console.ReadKey();
            }





        }

    }
}
