using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.GameLogic
{
    public class Board
    {
        public const int xCoordinator = 10;
        public const int yCoordinator = 10;
        private Dictionary<Coordinate, ShotHistory> ShotHistory;
        private int _currentShipIndex;

        public Ship[] Ships { get; private set; }

        public Board()
        {
            ShotHistory = new Dictionary<Coordinate, ShotHistory>();
            Ships = new Ship[5];
            _currentShipIndex = 0;
        }


        public FireShotResponse FireShot(Coordinate coordinate)
        {
            var response = new FireShotResponse();

            // is this coordinate on the board?
            if (!IsValidCoordinate(coordinate))
            {
                response.ShotStatus = ShotStatus.Invalid;
                return response;
            }

            // did they already try this position?
            if (ShotHistory.ContainsKey(coordinate))
            {
                response.ShotStatus = ShotStatus.Duplicate;
                return response;
            }

            CheckShipsForHit(coordinate, response);
            CheckForVictory(response);

            return response;
        }

        public ShotHistory CheckCoordinate(Coordinate coordinate)
        {
            if (ShotHistory.ContainsKey(coordinate))
            {
                return ShotHistory[coordinate];
            }
            else
            {
                return Responses.ShotHistory.Unknown;
            }
        }

        public ShipPlacement PlaceShip(PlaceShipRequest request)
        {
            if (_currentShipIndex > 4)
                throw new Exception("You can not add another ship, 5 is the limit!");

            if (!IsValidCoordinate(request.Coordinate))
                return ShipPlacement.NotEnoughSpace;

            Ship newShip = ShipCreator.CreateShip(request.ShipType);
            switch (request.Direction)
            {
                case ShipDirection.Down:
                    return PlaceShipDown(request.Coordinate, newShip);
                case ShipDirection.Up:
                    return PlaceShipUp(request.Coordinate, newShip);
                case ShipDirection.Left:
                    return PlaceShipLeft(request.Coordinate, newShip);
                default:
                    return PlaceShipRight(request.Coordinate, newShip);
            }
        }

    }
}
