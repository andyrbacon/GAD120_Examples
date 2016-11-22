using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLights
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = 15;
            bool[] isOn = new bool[height];
            int selection = 0;

            bool doLoop = true;
            while (doLoop == true)
            {
                Console.Clear();
                for (int i = 0; i < height; i++)
                {
                    if (selection == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    if (isOn[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write("O\n");
                }

                string input = Console.ReadKey(false).KeyChar.ToString();
                if (input == "w")
                {
                    if (selection > 0)
                        selection--;
                }
                else if (input == "s")
                {
                    if (selection < height - 1)
                        selection++;
                }
                else if (input == "e")
                {
                    isOn[selection] = !isOn[selection];
                }
            }
        }
    }
}
