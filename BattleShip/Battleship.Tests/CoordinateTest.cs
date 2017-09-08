using BattleShip.BLL.Requests;
using NUnit.Framework;
using BattleShip.UI;

namespace BattleShip.TestCase
{
    [TestFixture]
    public class BattleShipTests
    {
        [TestCase("a10", 1, 10, true)]
        [TestCase("z11", 26, 11, false)]
        [TestCase("b5", 2, 5, true)]
        [TestCase("y22", 25, 22, false)]
        [TestCase(" ", 0, 0, false)]

        public void ValidCoordinates(string userInput, int xCoord, int yCoord, bool expected)
        {
            string input = userInput;
            Coordinate coordinate = new Coordinate(xCoord, yCoord);
            bool isValid = ConsoleInput.CoordinateTryParse(userInput, out coordinate);
            Assert.AreEqual(expected, isValid);
        }
    }
}
