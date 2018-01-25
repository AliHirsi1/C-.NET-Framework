using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BattleShip.UI;

namespace Battleship.Tests
{
    [TestFixture]
    class CoordinateCheck
    {
        [TestCase ("a7", 1,7, true)]
        [TestCase ("j1", 10,1, true)]
        [TestCase("k11", 11, 11, false)]
        [TestCase("a11", 1, 11, false)]
        [TestCase("5", 0, 5, false)]
        [TestCase("a", 1, 0, false)]
        [TestCase(",", 0, 0, false)]

        public void checkCoordiate(String userInput, int x, int y, bool expected)
        {
            String output = userInput;
            Coordinate newCoordinate = new Coordinate(x, y);

            bool isValid = ConsoleInput.CoordinateTryParse(userInput, out  newCoordinate);

            Assert.AreEqual(expected, isValid);
        }


    }
}

