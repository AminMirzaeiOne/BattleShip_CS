using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
