using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class GameFlow
    {
        internal static void GamePlay(GameState state)
        {
            // Decide who is going to shoot first
            // Draw the board of the defender player

            Player attackinPlayer = null;
            Player defendingPlayer = null;

            

            ShotStatus status = new ShotStatus();


            // Decide who goes first and alternate each shot.

           



            //ConsoleOut.DrawBoard(defendingPlayer.PlayerBoard);
          
            // var statuss = ShotStatus.Miss;
            //var gameStatus = ShotStatus.Victory;



            bool isVictory = false;
            while (!isVictory)
            {

                if (state.isPlayerOneTurn)
                {
                    attackinPlayer = state.P1;
                    defendingPlayer = state.P2;

                }

                else
                {
                    defendingPlayer = state.P2;
                    attackinPlayer = state.P1;

                }

                ConsoleOut.DrawBoard(defendingPlayer.PlayerBoard);

                var coord = ConsoleInput.GetCoordinate();
                //ConsoleOut.DrawBoard(attackinPlayer.PlayerBoard);

                //FireShotResponse response = new FireShotResponse();



                FireShotResponse response = defendingPlayer.PlayerBoard.FireShot(coord);



                switch (response.ShotStatus)
                {
                    case ShotStatus.Hit:
                        Console.WriteLine("It is a hit!");
                        state.isPlayerOneTurn = !state.isPlayerOneTurn;
                        break;

                    case ShotStatus.Duplicate:
                        Console.WriteLine("It is a duplicate!");
                        break;

                    case ShotStatus.Invalid:
                        Console.WriteLine("It is invalid");
                        break;

                    case ShotStatus.Miss:
                        Console.WriteLine("It is a miss");
                        state.isPlayerOneTurn = !state.isPlayerOneTurn;
                        break;

                    case ShotStatus.Victory:
                        Console.WriteLine("Congratulation you win the game");
                        state.isPlayerOneTurn = !state.isPlayerOneTurn;
                        break;

                    case ShotStatus.HitAndSunk:
                        Console.WriteLine("Congratulation you win the game");
                        break;

                }

                

               /* if (response.ShotStatus == ShotStatus.Victory)
                {
                    isVictory = true;
                }
                else
                {
                    isVictory = false;
                    Player temp = defendingPlayer;
                    defendingPlayer = attackinPlayer;
                    attackinPlayer = temp;

                }*/
            }


        }
    }
}

