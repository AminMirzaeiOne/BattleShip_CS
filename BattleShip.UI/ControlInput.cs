using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ControlInput
    {
        public static string[] GetNameFromUser()
        {
            string strComputer = "", strLevel = "", player1 = "", player2 = "";
            do
            {
                Console.Write("Play vs computer?Y/N : ");
                strComputer = Console.ReadLine(); strComputer = strComputer.Trim().ToLower();
                if (strComputer == "y")
                {
                    do
                    {
                        Console.Write("Choose level easy, medium or hard?E/M/H : ");
                        strLevel = Console.ReadLine(); strLevel = strLevel.Trim().ToLower();
                    } while (strLevel != "e" && strLevel != "m" && strLevel != "h");
                }
            } while (strComputer != "y" && strComputer != "n");

            do
            {
                Console.Write("Input player 1 name: ");
                player1 = Console.ReadLine();
            } while (player1.Trim() == "");
            if (strComputer.ToLower() == "n")
            {
                do
                {
                    Console.Write("Input player 2 name: ");
                    player2 = Console.ReadLine();
                } while (player2.Trim() == "");
            }
            else
            {
                player2 = "";
            }

            return new string[] { player1, player2, strLevel };
        }

        public static bool IsPlaceBoardAuto()
        {
            string strResult = "";
            do
            {
                Console.Write("Let the game places the ship on the board?Y/N : ");
                strResult = Console.ReadLine(); strResult = strResult.Trim().ToLower();
            } while (strResult != "y" && strResult != "n");
            return strResult == "y";
        }


        public static ShipDirection GetDirection(string direction)
        {
            switch (direction.ToLower())
            {
                case "l":
                    return ShipDirection.Left;
                case "r":
                    return ShipDirection.Right;
                case "u":
                    return ShipDirection.Up;
                default:
                    return ShipDirection.Down;
            }

        }

        public static PlaceShipRequest GetLocationFromUser(string ShipType)
        {
            PlaceShipRequest result = null;
            do
            {
                Console.Write("- " + ShipType + ": ");
                result = GetLocation(Console.ReadLine());
                if (result is null) ;
                else return result;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please input location and direiction. Ex:) a2, r");
                Console.ForegroundColor = ConsoleColor.White;
            } while (result is null);
            return result;
        }

        public static PlaceShipRequest GetLocation(string location)
        {
            string strX, strY, strDirection; int x, y;

            if (location.Split(',').Length == 2)
            {
                if (location.Split(',')[0].Trim().Length > 1)
                {
                    strX = location.Split(',')[0].Trim().Substring(0, 1);
                    strY = location.Split(',')[0].Trim().Substring(1);
                    strDirection = location.Split(',')[1].ToLower().Trim();

                    x = GetNumberFromLetter(strX);
                    if (x > 0 && x < 11 && int.TryParse(strY, out y) && y > 0 && y < 11
                        && (strDirection == "l"
                        || strDirection == "r"
                        || strDirection == "u"
                        || strDirection == "d"))
                    {
                        PlaceShipRequest ShipToPlace = new PlaceShipRequest();
                        ShipToPlace.Direction = getDirection(strDirection);
                        ShipToPlace.Coordinate = new Coordinate(x, y);
                        return ShipToPlace;
                    }
                }
            }
            return null;
        }

        public static PlaceShipRequest GetLocationFromComputer()
        {
            PlaceShipRequest ShipToPlace = new PlaceShipRequest();
            ShipToPlace.Direction = getDirection(GetRandom.GetDirection());
            ShipToPlace.Coordinate = new Coordinate(GetRandom.GetLocation(), GetRandom.GetLocation());
            return ShipToPlace;
        }

        public static Coordinate GetShotLocationFromUser()
        {
            string result = ""; int x, y;
            while (true)
            {
                Console.Write("Which location do you want to shot? ");
                result = Console.ReadLine();
                if (result.Trim().Length > 1)
                {
                    x = GetNumberFromLetter(result.Substring(0, 1));
                    if (x > 0 && int.TryParse(result.Substring(1), out y))
                    {
                        return new Coordinate(x, y);
                    }
                }
            }
        }

        public static Coordinate GetShotLocationFromComputer(Board victimboard, GameLevel gamelevel)
        {
            if (gamelevel == GameLevel.Hard)
                if (GetRandom.r.Next(1, 100) <= 60)
                    return GetRightLocationToShot(victimboard);
            if (gamelevel == GameLevel.Medium)
                if (GetRandom.r.Next(1, 100) <= 30)
                    return GetRightLocationToShot(victimboard);

            return new Coordinate(GetRandom.GetLocation(), GetRandom.GetLocation());
        }

    }
}
