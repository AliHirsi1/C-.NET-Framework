using Flooring.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models.Responses;
using Flooring.Models;

namespace Flooring.UI.WorkFlows
{
    class EditOrderWorkFlow
    {
        public void Execute()
        {
            Console.Clear();
            OrderManager manager = OrderManagerFactory.Create();

            // prompt user to enter date
            DateTime date = ConsoleIO.UserInputDateValidation();

            // prompt user to enter ordernumber
            int OrderNumber = ConsoleIO.OrderNumberValidation();




            EditOrderResponse response = new EditOrderResponse();

            DisplayOrderResponse lookupDate = new DisplayOrderResponse();


            lookupDate = manager.DisplayOrders(date);

            // Determine if a date  exists 
            if (lookupDate.Orders.Count == 0)
            {
                Console.WriteLine("There are no orders based on that date");
                Console.Write("\nPress any key to continue... ");
                Console.ReadKey();

            }


            Order editedOrder = lookupDate.Orders.FirstOrDefault(o => o.OrderNumber == OrderNumber);

            
            ConsoleIO.DisplayOrderDetails(editedOrder);
           



            // Edit the order
            

            do
            {
              
                string CustomerName = ConsoleIO.CustomerNameValidation();
                if(CustomerName != "")
                {
                    editedOrder.CustomerName = CustomerName;
                }

                if(CustomerName == "")
                {
                    editedOrder.CustomerName = editedOrder.CustomerName;
                }

                string stateName = ConsoleIO.StateValidation();
                if(stateName != editedOrder.StateAbbreviation)
                {
                    editedOrder.StateAbbreviation = stateName;
                }


                string productType = ConsoleIO.ProductTypeValidatoin();

                if(productType != editedOrder.ProductType)
                {
                    editedOrder.ProductType = productType;
                }

               

                decimal area = ConsoleIO.AreaValidation();

                if(area != editedOrder.Area)
                {
                    editedOrder.Area = area;
                }



            } while(false);


            if (ConsoleIO.IsConfirmed())
            {
                var reload = manager.EditOrder(editedOrder, date, OrderNumber);
                Console.Clear();
                Console.WriteLine("Changed Order Summary");
                Console.WriteLine("===========================================================================================================================================");
                Console.WriteLine("OrderNumber CustomerName SateAbbreviation TaxRate ProductType Area CostPerSquareFoot LaborCostPerSquareFoot MaterialCost LaborCost Tax Total");
                string format = "{0, -1} {1, -23} {2, -2} {3, -4:c} {4, -8} {5, -4:c} {6, -4:c} {7, -4:c} {8, -4:c} {9, -5:c} {10, -4:c} {11, -6:c}";
                Console.WriteLine(format, editedOrder.OrderNumber, editedOrder.CustomerName, editedOrder.StateAbbreviation, editedOrder.TaxRate, editedOrder.ProductType, editedOrder.Area, editedOrder.CostPerSquareFoot, editedOrder.LaborCostPerSquareFoot, editedOrder.MaterialCost, editedOrder.LaborCost, editedOrder.Tax, editedOrder.Total);

            }








        }
    }
}


