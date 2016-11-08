using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Poem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] poem = new string[9];

            poem[0] = "Even";
            poem[1] = "After";
            poem[2] = "All this time";
            poem[3] = "The sun never says to the Earth,";
            poem[4] = "You owe me.";
            poem[5] = "Look";
            poem[6] = "What happens";
            poem[7] = "With a love like that,";
            poem[8] = "It lights the whole sky.";

            int lineIndex = 0;

            while (lineIndex < poem.Length)
            {
                Console.WriteLine(poem[lineIndex]);
                lineIndex++;
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
