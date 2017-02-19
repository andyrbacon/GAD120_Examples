using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawBar
{
    class Program
    {
        static void Healthbar(int value, int maxValue, string label = "", bool showNum = false, ConsoleColor backColor = ConsoleColor.DarkYellow, ConsoleColor fillColor = ConsoleColor.Yellow, string symbol = "|")
        {
            if (label != "")
            {
                Console.ForegroundColor = fillColor;
                Console.WriteLine(label);
            }

            for (int i = 0; i < maxValue; i++)
            {
                if (value >= i) Console.ForegroundColor = fillColor;
                else Console.ForegroundColor = backColor;

                Console.Write(symbol);
            }

            if (showNum) Console.Write(" " + value.ToString() + "/" + maxValue.ToString());
        }

        static void Main(string[] args)
        {
            Healthbar(20, 30, "HEALTHBAR");
            Console.WriteLine("\n\n");

            int playerMaxHealth = 30;
            int health = playerMaxHealth / 2;
            Healthbar(health, playerMaxHealth, "PLAYER HP", true, ConsoleColor.DarkRed, ConsoleColor.Red, "/");

            Console.WriteLine("\n\n");

            int enemyMaxHealth = 30;
            int enemyHealth = enemyMaxHealth / 4;
            Healthbar(enemyHealth, enemyMaxHealth, "ENEMY HP", true, ConsoleColor.DarkGreen, ConsoleColor.Green, "<");

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
