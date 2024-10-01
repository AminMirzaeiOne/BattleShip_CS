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

        [Test]
        public void CanNotOverlapShips()
        {
            Board board = new Board();

            // let's put a carrier at (10,10), (9,10), (8,10), (7,10), (6,10)
            var carrierRequest = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(10, 10),
                Direction = ShipDirection.Left,
                ShipType = ShipType.Carrier
            };

            var carrierResponse = board.PlaceShip(carrierRequest);

            Assert.AreEqual(ShipPlacement.Ok, carrierResponse);

            // now let's put a destroyer overlapping the y coordinate
            var destroyerRequest = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(9, 9),
                Direction = ShipDirection.Down,
                ShipType = ShipType.Destroyer
            };

            var destroyerResponse = board.PlaceShip(destroyerRequest);

            Assert.AreEqual(ShipPlacement.Overlap, destroyerResponse);
        }

    }
}
