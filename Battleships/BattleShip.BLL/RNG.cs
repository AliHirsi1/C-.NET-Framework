using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL
{
    public static class RNG
    {
        static Random _generator = new Random();

        public static bool CoinFlip()
        {
            return _generator.NextDouble() < 0.5;
        }
    }
}
