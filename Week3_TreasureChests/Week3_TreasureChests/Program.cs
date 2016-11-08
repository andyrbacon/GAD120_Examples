using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_TreasureChests
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doLoop = true;
            while (doLoop == true)
            {
                Console.WriteLine("You wake up in a dark and dripping cave. Three treasure chests lie before you.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press 1 to open the chest on your left.");
                Console.WriteLine("Press 2 to open the chest in the center.");
                Console.WriteLine("Press 3 to open the chest on the right.");
                Console.WriteLine("Press Q to quit.");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string choice = Console.ReadLine();

                if (choice.ToUpper() == "Q")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThanks for playing. Goodbye.\n");
                    Console.ResetColor();
                    return;
                }

                int num = int.Parse(choice);

                Console.WriteLine("\n");
                Console.ResetColor();
                if (num == 1 || num == 2 || num == 3)
                {
                    if (num == 1)
                    {
                        Console.WriteLine("The chest is empty. Better luck next time.");
                    }

                    if (num == 2)
                    {
                        Console.WriteLine("The chest contains one dusty coin. You could have done better.");
                    }

                    if (num == 3)
                    {
                        Console.WriteLine("The chest is filled with glittering jewels. You choice wisely!");
                    }
                }
                else
                {
                    Console.WriteLine("That's not an option!");
                }

                Console.WriteLine("\n");
            }
        }
    }
}
