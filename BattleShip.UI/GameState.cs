using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    public class GameState
    {
        public bool IsPlayer1 { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

    }
}
