using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ControlInput
    {
        public static string[] GetNameFromUser()
        {
            string strComputer = "", strLevel = "", player1 = "", player2 = "";
            do
            {
                Console.Write("Play vs computer?Y/N : ");
                strComputer = Console.ReadLine(); strComputer = strComputer.Trim().ToLower();
                if (strComputer == "y")
                {
                    do
                    {
                        Console.Write("Choose level easy, medium or hard?E/M/H : ");
                        strLevel = Console.ReadLine(); strLevel = strLevel.Trim().ToLower();
                    } while (strLevel != "e" && strLevel != "m" && strLevel != "h");
                }
            } while (strComputer != "y" && strComputer != "n");

            do
            {
                Console.Write("Input player 1 name: ");
                player1 = Console.ReadLine();
            } while (player1.Trim() == "");
            if (strComputer.ToLower() == "n")
            {
                do
                {
                    Console.Write("Input player 2 name: ");
                    player2 = Console.ReadLine();
                } while (player2.Trim() == "");
            }
            else
            {
                player2 = "";
            }

            return new string[] { player1, player2, strLevel };
        }
    }
}
