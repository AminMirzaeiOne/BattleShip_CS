using System;
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

        public static string GetDirection()
        {
            switch (rand.Next(1, 4))
            {
                case 1:
                    return "l";
                case 2:
                    return "r";
                case 3:
                    return "u";
                case 4:
                    return "d";
                default:
                    return "";
            }
        }

        public static int GetLocation()
        {
            return rand.Next(1, 10);
        }
    }

    public enum ShipPlacement
    {
        NotEnoughSpace,
        Overlap,
        Ok
    }
}
