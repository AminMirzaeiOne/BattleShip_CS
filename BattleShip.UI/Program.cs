﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameFlow flow = new GameFlow();
            flow.Start();
        }
    }
}
