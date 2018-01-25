using Flooring.UI.WorkFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                // Display the Menu
                Console.Clear();
                Console.WriteLine("Floring Program");
                Console.WriteLine("==========================================");
                Console.WriteLine("");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("==========================================");
                Console.WriteLine("");
                Console.Write("Enter Q or q to Quit the Application \n");
                Console.WriteLine("");

                // Prompt user to enter their choice
                Console.Write("Enter your selection: ");
                string userInput = Console.ReadLine();


                // Step through the user's input and display the correct selection

                switch (userInput)
                {
                    case "1":
                        DisplayOrderWorkFlow displayOrder = new DisplayOrderWorkFlow();
                        displayOrder.Execute();
                        break;
                    case "2":
                        AddOrderWorkFlow addOrder = new AddOrderWorkFlow();
                        addOrder.Execute();
                        break;
                    case "3":
                        EditOrderWorkFlow editOrder = new EditOrderWorkFlow();
                        editOrder.Execute();
                        break;

                    case "4":
                        RemoveOrderWorkflow removeOrder = new RemoveOrderWorkflow();
                        removeOrder.Execute();
                        break;

                    case "Q":
                    case "q":
                        return;

                }

            }
        }
    }
}

