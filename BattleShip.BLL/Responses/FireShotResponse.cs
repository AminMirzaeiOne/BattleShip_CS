﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.Responses
{
    public class FireShotResponse
    {
        public ShotStatus ShotStatus { get; set; }
        public string ShipImpacted { get; set; }

    }
}
