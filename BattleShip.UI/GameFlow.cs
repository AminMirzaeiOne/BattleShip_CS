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
    }
}
