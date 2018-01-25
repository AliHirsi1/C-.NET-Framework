using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;


namespace BattleShip.UI
{
    public class ConsoleInput
    {

        public static String GetPlayerName(int playerName)
        {
            Console.Write($"Player {playerName} What is your name: ");
            String name = Console.ReadLine();
            return name;

            // Console.Clear();
        }

        public static bool CoordinateTryParse(String userInput, out Coordinate toReturn)
        {


            toReturn = null;
            int col;
            int row;
            char yPart = userInput[0];

            String xPart = userInput.Substring(1);



            if (int.TryParse(xPart, out row))
            {

                if (row >= 1 && row <= 10)
            {
                    col = (yPart - 'a' + 1);
                    toReturn = new Coordinate(col, row);
                    return true;

                }
            }


            return false;

        }

        internal static Coordinate GetCoordinate()
        {
            bool isValid = false;
            Coordinate toReturn = null;

            while (!isValid)
            {
                ConsoleOut.PromptCoordinates();                  // This calls console output 
                String userInput = Console.ReadLine().ToLower();
                isValid = CoordinateTryParse(userInput, out toReturn);

                if (!isValid)
                {
                    ConsoleOut.PromptCoordinates();                  // This calls console output 
                    userInput = Console.ReadLine().ToLower();
                }

            }

            return toReturn;

        }

        internal static ShipDirection GetDirection()
        {
            //int output;
            ConsoleOut.PromptDirection();
            String inputDirection = Console.ReadLine();




            ShipDirection ship = new ShipDirection();
            bool validDirection = false;

            while (!validDirection)
            {
                switch (inputDirection)
                {
                    case "0":
                        ship = ShipDirection.Up;
                        validDirection = true;
                        break;

                    case "1":
                        ship = ShipDirection.Right;
                        validDirection = true;
                        break;

                    case "2":
                        ship = ShipDirection.Down;
                        validDirection = true;
                        break;

                    case "3":
                        ship = ShipDirection.Left;
                        validDirection = true;
                        break;

                    default:
                        ConsoleOut.PromptDirection();
                        inputDirection = Console.ReadLine();
                        break;

                }



            }

            return ship;
        }

    }
}