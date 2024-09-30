using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ControlOutput
    {
        static int counttime = 0;
        public static void ShowFlashScreen()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        ********************************************");
            Console.Write("        *"); Console.ForegroundColor = ConsoleColor.White; Console.Write("             Battleship Game              "); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("*");
            Console.WriteLine("        ********************************************");
            Console.ForegroundColor = ConsoleColor.White;

            System.Threading.Timer t = new System.Threading.Timer(ClearFlashScreen, null, 0, 1000);
            Thread.Sleep(2100);
            t.Dispose();

        }

        private static void ClearFlashScreen(Object state)
        {
            if (counttime < 2)
                counttime += 1;
            else
            {
                Console.Clear();
                counttime = 0;
            }
        }

    }
}
