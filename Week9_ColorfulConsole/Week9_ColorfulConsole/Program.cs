using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

// https://github.com/tomakita/Colorful.Console
// Go to Tools / NuGet Package Manager / Package Manager Console
// Enter: PM> Install-Package Colorful.Console
// Colorful.Console can only write to the console in 16 different colors (including the black that's used as the console's background, by default!) in a single console session.

namespace Week9_ColorfulConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = 225;
            int g = 255;
            int b = 250;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("LINE " + (i+1).ToString(), Color.FromArgb(255, r, g, b));
                r -= 30;
                b -= 15;
            }

            Console.WriteLine();
            Color[] colors = new Color[] { Color.Orange, Color.Pink, Color.Purple, Color.AliceBlue, Color.MediumAquamarine, Color.LightGoldenrodYellow, Color.PaleTurquoise, Color.Violet, Color.SandyBrown };

            foreach(Color c in colors)
            {
                Console.WriteLine(c.Name, c);
            }

            Console.ResetColor();
        }
    }
}
