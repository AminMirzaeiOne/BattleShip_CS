using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class GameSetup
    {
        GameState _gm;
        public GameSetup(GameState gm)
        {
            _gm = gm;
        }

        public void Setup()
        {
            Console.ForegroundColor = ConsoleColor.White;
            ControlOutput.ShowFlashScreen();
            ControlOutput.ShowHeader();

            GameLevel gamelevel = GameLevel.Easy;
            string[] userSetUp = ControlInput.GetNameFromUser();
            switch (userSetUp[2])
            {
                case "h":
                    gamelevel = GameLevel.Hard;
                    break;
                case "m":
                    gamelevel = GameLevel.Medium;
                    break;
                default:
                    gamelevel = GameLevel.Easy;
                    break;
            }

            _gm.Player1.Name = userSetUp[0];
            _gm.Player1.IsPC = false;
            _gm.Player1.Win = 0;
            _gm.Player1.GameLevel = gamelevel;

            _gm.Player2.Name = userSetUp[1];
            _gm.Player2.Win = 0;
            _gm.Player2.GameLevel = gamelevel;

            //vs Computer
            if (userSetUp[1] == "")
            {
                _gm.Player2.Name = "Computer";
                _gm.Player2.IsPC = true;
            }
        }

        public void SetBoard()
        {
            ControlOutput.ResetScreen(new Player[] { _gm.Player1, _gm.Player2 });

            _gm.IsPlayer1 = BLL.Responses.GetRandom.WhoseFirst();

            _gm.Player1.PlayerBoard = new Board();
            PlaceShipOnBoard(_gm.Player1);
            ControlOutput.ResetScreen(new Player[] { _gm.Player1, _gm.Player2 });

            _gm.Player2.PlayerBoard = new Board();
            PlaceShipOnBoard(_gm.Player2);
            Console.WriteLine("All ship were placed successfull! Press any key to continue...");
            Console.ReadKey();
        }

        public void PlaceShipOnBoard(Player player)
        {
            bool IsPlaceBoardAuto = false;
            if (player.IsPC != true)
            {
                ControlOutput.ShowWhoseTurn(player);
                IsPlaceBoardAuto = ControlInput.IsPlaceBoardAuto();
                if (!IsPlaceBoardAuto)
                    Console.WriteLine("Input the location and direction(l, r, u, d) of the ships. Ex:) a2, r:");
            }
            for (ShipType s = ShipType.Destroyer; s <= ShipType.Carrier; s++)
            {
                PlaceShipRequest ShipToPlace = new PlaceShipRequest();
                ShipPlacement result;
                do
                {
                    if (!player.IsPC && !IsPlaceBoardAuto)
                    {
                        ShipToPlace = ControlInput.GetLocationFromUser(s.ToString());
                        ShipToPlace.ShipType = s;
                        result = player.PlayerBoard.PlaceShip(ShipToPlace);
                        if (result == ShipPlacement.NotEnoughSpace)
                            Console.WriteLine("Not Enough Space!");
                        else if (result == ShipPlacement.Overlap)
                            Console.WriteLine("Overlap placement!");
                    }
                    else
                    {
                        ShipToPlace = ControlInput.GetLocationFromComputer();
                        ShipToPlace.ShipType = s;
                        result = player.PlayerBoard.PlaceShip(ShipToPlace);
                    }

                } while (result != ShipPlacement.Ok);
            }
        }
    }
}
