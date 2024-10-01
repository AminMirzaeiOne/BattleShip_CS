using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Tests
{
    [TestFixture]
    public class ShipPlacementTests
    {
        [Test]
        public void CanNotPlaceShipOffBoard()
        {
            Board board = new Board();
            PlaceShipRequest request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(15, 10),
                Direction = ShipDirection.Up,
                ShipType = ShipType.Destroyer
            };

            var response = board.PlaceShip(request);

            Assert.AreEqual(ShipPlacement.NotEnoughSpace, response);
        }

        [Test]
        public void CanNotPlaceShipPartiallyOnBoard()
        {
            Board board = new Board();
            PlaceShipRequest request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(10, 10),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Carrier
            };

            var response = board.PlaceShip(request);

            Assert.AreEqual(ShipPlacement.NotEnoughSpace, response);
        }
    }
}
