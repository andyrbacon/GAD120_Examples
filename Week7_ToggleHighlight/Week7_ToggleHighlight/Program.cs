using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7_ToggleHighlight
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doLoop = true;
            bool isHighlighted = false;
            string highlightMessage = "";
            string message = "";

            while (doLoop)
            {
                Console.Clear();

                if (isHighlighted == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    highlightMessage = "";
                }
                else
                {
                    Console.ResetColor();
                    highlightMessage = "not ";
                }

                message = "This is a message is " + highlightMessage + "highlighted.";

                Console.WriteLine(message);
                Console.WriteLine("Press H to toggle the highlight.");

                string input = Console.ReadKey(true).KeyChar.ToString();

                if (input == "h")
                {
                    isHighlighted = !isHighlighted;
                }
            }

        }
    }
}
