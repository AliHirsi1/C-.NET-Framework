
using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace Flooring.UI
{
    public class ConsoleIO
    {
        // public DateTime Date { get; set; }

        public static DateTime UserInputDateValidation()
        {
            DateTime date = DateTime.Now;
            bool success = false;

            while (!success)
            {
                Console.Write("Enter a date(MMDDYYYY): ");
                String input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "MMddyyyy", null, DateTimeStyles.None, out date))
                {
                    success = true;
                }



            }


            return date;

        }

        public static int OrderNumberValidation()
        {
            int toReturn = int.MinValue;
            bool success = false;

            while (!success)
            {
                Console.Write("Enter Order Number: ");
                success = int.TryParse(Console.ReadLine(), out toReturn);

            }

            return toReturn;
        }

        public static string StateValidation()
        {

            Console.Write($"Enter one of the following states only (OH, PA, MI, or IN):  ");
            string state = Console.ReadLine();
            return state.ToUpper();


        }

        public static decimal AreaValidation()
        {
            int toReturn = int.MinValue;
            bool success = false;

            while (!success)
            {
                Console.Write("Enter area that is greater than 99 sqf: ");
                success = int.TryParse(Console.ReadLine(), out toReturn);
                if (success)
                {
                    success = toReturn > 99;

                    if (!success)
                    {
                        Console.WriteLine("Area must be greater than 99: ");

                    }
                }

            }


            return toReturn;


        }

        public static string ProductTypeValidatoin()
        {
            Console.Write("Enter one of the following Product types (Carpet, Laminate, Tile, Wood):  ");
            string productType = Console.ReadLine();
            return productType.First().ToString().ToUpper() + productType.Substring(1);
        }

        internal static void DisplayOrdersDetails(List<Order> orders)
        {
            foreach (var order in orders)
            {
                DisplayOrderDetails(order);
            }
        }

        public static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine($"OrderNumber: {order.OrderNumber}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.StateAbbreviation}");
            Console.WriteLine($"Tax Rate: {order.TaxRate}");
            Console.WriteLine($"Product Type: {order.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost Per Square foot: {order.CostPerSquareFoot}");
            Console.WriteLine($"Labor Cost Per Square foot: {order.LaborCostPerSquareFoot}");
            Console.WriteLine($"Material Cost: {order.MaterialCost}");
            Console.WriteLine($"Labor Cost: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
            
            Console.WriteLine("");
            //Console.Write("Press any key to continue...");
            //Console.ReadKey();
        }

        public static bool IsConfirmed()
        {
            Console.Write("Do you want to save this order(y/n): ");
            string saveOrder = Console.ReadLine();

            return (saveOrder.ToUpper() == "YES" || saveOrder.ToUpper() == "Y");
            
        }

        public static bool IsRemoved()
        {
            Console.Write("Do you want to remove this order(y/n): ");
            string saveOrder = Console.ReadLine();

            return (saveOrder.ToUpper() == "YES" || saveOrder.ToUpper() == "Y");

        }






        public static void AddNewOrder()
{

}

    public static string CustomerNameValidation()
{
    bool validName = false;
    string customerName = string.Empty;
    int toReturn = int.MinValue;

    while (!validName)
    {
        Console.Write("\nEnter customer name: ");
        customerName = Console.ReadLine();



        bool success = int.TryParse(customerName, out toReturn);

        if (customerName.Length > 0 && customerName != "" && !success && !customerName.Contains(",") && !customerName.Contains("."))
        {
            validName = success;
        }

        validName = true;
    }

    return customerName;

}

       
    }
}
