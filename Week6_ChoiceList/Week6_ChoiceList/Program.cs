using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_ChoiceList
{
    class Program
    {
        static void Main(string[] args)
        {
            // display a list of items
            // highlight the selected item
            // do something different based on what item you chose

            bool doLoop = true;
            int selection = 0;

            while (doLoop == true)
            {
                string[] attacks = new string[4];
                attacks[0] = "attack 1";
                attacks[1] = "attack 2";
                attacks[2] = "attack 3";
                attacks[3] = "attack 4";

                int i = 0;

                Console.WriteLine("Press W to move up.");
                Console.WriteLine("Press S to move down.");
                Console.WriteLine("Press Q to select.\n");

                while (i < attacks.Length)
                {
                    if (i == selection)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    Console.WriteLine(attacks[i]);
                    i++;

                    Console.ResetColor();
                }
                Console.WriteLine("");

                string input = Console.ReadKey(true).KeyChar.ToString();

                if (input == "w")
                {
                    if (selection > 0)
                        selection--;
                }

                if (input == "s")
                {
                    if (selection < attacks.Length-1)
                        selection++;
                }
            }

        }
    }
}
