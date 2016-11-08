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
            int selection = 0; // create an int to track the player's current selection

            string[] items = new string[4];
            items[0] = "item 1";
            items[1] = "item 2";
            items[2] = "item 3";
            items[3] = "item 4";

            while (doLoop == true)
            {
                Console.Clear(); // clear the Console so the list is only displayed once

                // player instructions
                Console.WriteLine("Press W to move up.");
                Console.WriteLine("Press S to move down.");
                Console.WriteLine("Press Q to select.\n");

                // create an incrementer to loop through the items array 
                int i = 0; 
                while (i < items.Length) // loop through the items array
                {
                    // highlight the player's selection
                    if (i == selection)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    // display the array item
                    Console.WriteLine(items[i]);
                    i++;

                    // reset the Console colour so that only one item gets highlighted
                    Console.ResetColor();
                }
                Console.WriteLine("");

                // store the player input
                string input = Console.ReadKey(true).KeyChar.ToString();

                // move up in the list
                if (input == "w")
                {
                    if (selection > 0)
                        selection--;
                }

                // move down in the list
                if (input == "s")
                {
                    if (selection < items.Length-1)
                        selection++;
                }
            }

        }
    }
}
