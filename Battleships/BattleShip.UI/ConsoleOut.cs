using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleOut
    {
        public static void Welcome()
        {
            // Welcome player to the game
            Console.WriteLine("Welcome to battleShip");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
        }

        // Prompt coordinates

        public static void PromptCoordinates()
        {
            Console.Write($"Enter your coordinates  (A --J) && (1 -- 10) such as B5: ");

        }

        internal static void  PromptCorrectCoordinates()
        {
             Console.Write("Please enter correct coordinates: ");
             Console.ReadLine();
        }

       

        internal static void PromptDirection()
        {
            Console.Write("Please enter Your Direction as follows: 0 = UP; 1 = Right; 2 = down; 3 = Left  ");
        }

        internal static void PromptCorrectdirection()
        {
            Console.Write("Please enter correct direction as asked: ");
        }


        internal static void PromptCoordinatesToBeFiredAt()
        {
            Console.Write("Please enter coordinates to fire ex (A --J) && (1 -- 10) such as B5: ");
        }





        internal static bool IsPlayerfirst()
        {
            bool isPlayerTurns = false;

            //if(RNG.CoinFlip() < .5)
            {
                isPlayerTurns = true;
                Console.WriteLine("Player 1 is first to fire!");

            }

            isPlayerTurns = false;
            Console.WriteLine("Player 2 is first to fire!");
            return isPlayerTurns;

        }

        internal static void EnoughSpace()
        {
            Console.WriteLine("There is enough space to be placed");
        }

        internal static void NotEnoughSpace()
        {
            Console.WriteLine("There is no enough space to place this ship");

        }

        internal static void OverLapping()
        {
            Console.WriteLine("Your ship Placement is overlapping");
        }

        internal static void DrawBoard(Board playerBoard)
        {
            for (int y = 1; y <= 10; y++)
            {
                for (int x = 1; x <= 10; x++)
                {
                    ShotHistory currentState = playerBoard.CheckCoordinate(new Coordinate(y, x));
                    switch (currentState)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("H");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Unknown:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("U");
                            Console.ResetColor();
                            break;
                        
                    }
                    Console.Write(" |");
                   
                }

                Console.WriteLine(" ");
                Console.WriteLine("---------------------------------");

            }

            //ConsoleOut.IsPlayerfirst();

           // Console.ReadLine();

        }



    }
}
