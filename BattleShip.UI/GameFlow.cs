using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameFlow
    {
        GameState gm;

        public GameFlow()
        {
            gm = new GameState() { IsPlayer1 = false, Player1 = new Player(), Player2 = new Player() };
        }

        public void Start()
        {
            GameSetup GameSetup = new GameSetup(gm);
            GameSetup.Setup();

            do
            {
                GameSetup.SetBoard();
                FireShotResponse shotresponse;
                do
                {
                    ControlOutput.ResetScreen(new Player[] { gm.Player1, gm.Player2 });
                    ControlOutput.ShowWhoseTurn(gm.IsPlayer1 ? gm.Player1 : gm.Player2);
                    ControlOutput.DrawHistory(gm.IsPlayer1 ? gm.Player2 : gm.Player1);
                    Coordinate ShotPoint = new Coordinate(1, 1);
                    shotresponse = Shot(gm.IsPlayer1 ? gm.Player2 : gm.Player1, gm.IsPlayer1 ? gm.Player1 : gm.Player2, out ShotPoint);

                    ControlOutput.ResetScreen(new Player[] { gm.Player1, gm.Player2 });
                    ControlOutput.ShowWhoseTurn(gm.IsPlayer1 ? gm.Player1 : gm.Player2);
                    ControlOutput.DrawHistory(gm.IsPlayer1 ? gm.Player2 : gm.Player1);
                    ControlOutput.ShowShotResult(shotresponse, ShotPoint, gm.IsPlayer1 ? gm.Player1.Name : gm.Player2.Name);
                    if (shotresponse.ShotStatus != ShotStatus.Victory)
                    {
                        Console.WriteLine("Press any key to continue to switch to " + (gm.IsPlayer1 ? gm.Player2.Name : gm.Player1.Name));
                        gm.IsPlayer1 = !gm.IsPlayer1;
                        Console.ReadKey();
                    }
                } while (shotresponse.ShotStatus != ShotStatus.Victory);

            } while (ControlInput.CheckQuit());
        }
    }
}
