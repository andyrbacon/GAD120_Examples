using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DigitalRain
{
    class Program
    {
        public enum State { menu, rain };
        public static State state = State.menu;

        static void Main(string[] args)
        {
            Console.Title = "--- Digital Rain ---";

            int width = 25;
            int height = 25;
            int rainNum = width;
            int minRainSpeed = 1;
            int maxRainSpeed = 4;
            int[] rainY = new int[rainNum];
            int[] rainSpeed = new int[rainNum];
            bool[] doFall = new bool[rainNum];
            int[] fallDelay = new int[rainNum];
            int[] yChanger = new int[rainNum];
            string[,] symbols = new string[width, height];
            int timer = 0;
            int sleepTime = 30;
            int cycleTime = 12;
            int rainLength = 10;

            Random random = new Random();
            for (int r = 0; r < rainNum; r++)
            {
                doFall[r] = false;
                fallDelay[r] = random.Next(1, cycleTime);
                rainY[r] = -1;
                yChanger[r] = random.Next(0, height);
                rainSpeed[r] = random.Next(minRainSpeed, maxRainSpeed);
            }

            // fill the grid with random characters
            for (int y = 0; y < height; y++)
            {
                for (int x = width - 1; x >= 0; x--)
                {
                    symbols[x, y] = ((char)random.Next(33, 126)).ToString();
                }
            }

            // setup colors
            int colorIndex = 0;
            ConsoleColor[] darkColors = new ConsoleColor[6];
            ConsoleColor[] lightColors = new ConsoleColor[6];

            darkColors[0] = ConsoleColor.DarkGreen;
            lightColors[0] = ConsoleColor.Green;
            darkColors[1] = ConsoleColor.DarkRed;
            lightColors[1] = ConsoleColor.Red;
            darkColors[2] = ConsoleColor.DarkYellow;
            lightColors[2] = ConsoleColor.Yellow;
            darkColors[3] = ConsoleColor.DarkCyan;
            lightColors[3] = ConsoleColor.Cyan;
            darkColors[4] = ConsoleColor.DarkMagenta;
            lightColors[4] = ConsoleColor.Magenta;
            darkColors[5] = ConsoleColor.DarkGray;
            lightColors[5] = ConsoleColor.Gray;

            ConsoleColor darkColor = darkColors[0];
            ConsoleColor lightColor = lightColors[0];

            ConsoleColor titleColor = ConsoleColor.Gray;
            ConsoleColor arrowColor = ConsoleColor.White;
            string arrowOn = " -> ";
            string arrowOff = "    ";

            while (state == State.menu)
            {
                Console.Clear();
                Console.ForegroundColor = titleColor;
                Console.WriteLine("--- Digital Rain ---\n");
                Console.WriteLine("   by Andy Bacon\n\n");

                // display color options
                Console.Write("Use the ARROW KEYS to choose a color. \nPress SPACE to start.\n\n");
                for (int i = 0; i < darkColors.Length; i++)
                {
                    string arrow = "";
                    if (i == colorIndex) arrow = arrowOn;
                    else arrow = arrowOff;
                    Console.ForegroundColor = arrowColor;
                    Console.Write(arrow);

                    string colorMessage = (i + 1).ToString() + ". " + lightColors[i].ToString();
                    if (colorIndex == i) Console.ForegroundColor = lightColors[i];
                    else Console.ForegroundColor = darkColors[i];
                    Console.WriteLine(colorMessage);
                }
                Console.ResetColor();

                string glitchArrow = "";
                if (colorIndex == lightColors.Length) glitchArrow = arrowOn;
                else glitchArrow = arrowOff;
                Console.ForegroundColor = arrowColor;
                Console.Write(glitchArrow);

                // display glitch option
                string rainbowName = (lightColors.Length + 1).ToString() + ". Glitch";
                int cIndex = 0;
                foreach (char c in rainbowName)
                {
                    if (colorIndex == lightColors.Length) Console.ForegroundColor = lightColors[cIndex];
                    else Console.ForegroundColor = darkColors[cIndex];
                    Console.Write(c.ToString());
                    if (cIndex < lightColors.Length - 1) cIndex++; else cIndex = 0;
                }

                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (colorIndex > 0) colorIndex--;
                }

                if (key == ConsoleKey.DownArrow)
                {
                    if (colorIndex < lightColors.Length) colorIndex++;
                }

                if (key == ConsoleKey.Spacebar)
                {
                    if (colorIndex < darkColors.Length)
                    {
                        darkColor = darkColors[colorIndex];
                        lightColor = lightColors[colorIndex];
                    }

                    state = State.rain;
                }
            }

            

            while (state == State.rain)
            {
                Console.Clear();
                
                // start of grid loop
                for (int y = 0; y < height; y++) // loop through rows of the grid
                {
                    if (y > 0) Console.WriteLine("");

                    for (int x = 0; x < width; x++) // loop through columns of the grid
                    {
                        int spaceAway = rainY[x] - y;

                        if (yChanger[x] == y)
                        {
                            symbols[x, y] = ((char)random.Next(33, 126)).ToString();
                        }
                        if (spaceAway == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (spaceAway >= 1 && spaceAway <= 8)
                        {
                            if (colorIndex == darkColors.Length) Console.ForegroundColor = lightColors[random.Next(0, lightColors.Length - 1)];
                            else Console.ForegroundColor = lightColor;
                        }
                        else if (spaceAway > 8 && spaceAway <= rainLength)
                        {
                            if (colorIndex == darkColors.Length) Console.ForegroundColor = darkColors[random.Next(0, darkColors.Length - 1)];
                            else Console.ForegroundColor = darkColor;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }

                        Console.Write(" " + symbols[x, y] + " ");
                    }
                }

                System.Threading.Thread.Sleep(sleepTime);

                if (timer < cycleTime) timer++; else timer = 0;

                // reset digital rain
                for (int r = 0; r < rainNum; r++)
                {
                    if (timer % rainSpeed[r] == 0)
                    {
                        if (rainY[r] < height + rainLength && doFall[r])
                        {
                            rainY[r]++;
                        }
                        else
                        {
                            rainY[r] = -1;
                            doFall[r] = false;
                        }
                    }

                    if (doFall[r] == false && fallDelay[r] == timer)
                    {
                        doFall[r] = true;
                        fallDelay[r] = random.Next(0, cycleTime);
                        rainSpeed[r] = random.Next(minRainSpeed, maxRainSpeed);
                        yChanger[r] = random.Next(0, height);
                    }
                }
            }
        }
    }
}
