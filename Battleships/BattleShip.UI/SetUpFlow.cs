using System;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.UI;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;


namespace BattleShip.BLL.GameLogic
{
    public class SetUpFlow
    {
        

        internal GameState Start()
        {

            ConsoleOut.Welcome();
            // Instantiate the first player
            String p1 = ConsoleInput.GetPlayerName(1);
            String p2 = ConsoleInput.GetPlayerName(2);

            Board player1Board = BoardCreated(p1);

           // Player p1 = new Player(ConsoleInput.GetPlayerName(), BoardCreated());
            
            // Instantiate the second player
           // Player p2 = new Player(ConsoleInput.GetPlayerName(), BoardCreated());

            //Board Plyaer1Boad = BoardCreated(p1);

            Board player2Board = BoardCreated(p2);

            Player player1 = new Player(p1, player1Board);
            Player player2 = new Player(p2, player2Board);

            // Decide who goes first  

            bool isPlayerTurn = DecideWhoGoesFirst();
            // bool gameOver = false;

            // while (!gameOver)
            // {

            //}c3

            GameState gameState = new GameState(player1, player2, isPlayerTurn);

            return gameState;

        }

        private Board BoardCreated(String playerName)
        {
            Board gameBoard = new Board();
            //ShipType placeship = new ShipType();

            for (ShipType s = ShipType.Carrier; s >= ShipType.Destroyer; s--)
            {
                PlaceShipRequest request = new PlaceShipRequest();
                request.Coordinate = ConsoleInput.GetCoordinate();
                request.Direction = ConsoleInput.GetDirection();
                request.ShipType = s;
                var placement = gameBoard.PlaceShip(request);

                if (placement == ShipPlacement.Overlap)
                {
                    ConsoleOut.OverLapping();
                    s++;
                }
                else if (placement == ShipPlacement.NotEnoughSpace)
                {
                    ConsoleOut.NotEnoughSpace();
                    s++;
                }

               // else
                   // ConsoleOut.EnoughSpace();
                   

           
            }

            return gameBoard;
        }

        private bool DecideWhoGoesFirst()
        {
            return RNG.CoinFlip();
        }
    }
}