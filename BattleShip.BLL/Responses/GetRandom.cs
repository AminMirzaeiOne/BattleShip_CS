﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.Responses
{
    public class GetRandom
    {
        public static System.Random rand = new System.Random();
        public static bool WhoseFirst()
        {
            return rand.Next(1, 10) <= 5;
        }
    }
}
