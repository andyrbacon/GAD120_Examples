using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace Week9_ColorfulConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = 225;
            int g = 255;
            int b = 250;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("TEXT", Color.FromArgb(255, r, g, b));
                r -= 18;
                b -= 9;
            }

            Console.WriteLine("ORANGE TEXT", Color.Orange);
        }
    }
}
