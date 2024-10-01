using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.Ships
{
    public class Ship
    {
        public ShipType ShipType { get; private set; }
        public string ShipName { get { return ShipType.ToString(); } }

    }
}
