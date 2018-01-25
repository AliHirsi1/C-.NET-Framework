using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SetUpFlow setFlow = new SetUpFlow();
            GameState state = setFlow.Start();

           // GameFlow gameFlow = new GameFlow();
            GameFlow.GamePlay(state);

        }
    }
}
