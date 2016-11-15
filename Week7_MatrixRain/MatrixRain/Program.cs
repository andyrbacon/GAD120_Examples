using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MatrixRain
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doLoop = true;

            int width = 25;
            int height = 25;
            int rainNum = width;
            int[] rainY = new int[rainNum];
            bool[] doFall = new bool[rainNum];
            int[] fallDelay = new int[rainNum];
            string[] symbol = new string[rainNum];
            int[] rainSpeed = new int[rainNum];
            int minRainSpeed = 1;
            int maxRainSpeed = 10;
            int timer = 0;
            int sleepTime = 75;
            int cycleTime = 100;
            int rainLength = 5;

            Random random = new Random();
            for (int r = 0; r < rainNum; r++)
            {
                fallDelay[r] = random.Next(0, cycleTime);
                rainY[r] = -1;
                char c = (char)random.Next(0, 255);
                symbol[r] = c.ToString();
                rainSpeed[r] = random.Next(minRainSpeed, maxRainSpeed);
            }

            while (doLoop)
            {
                Console.Clear(); // clear the Console so that the map is only displayed once

                // start of grid loop
                for (int y = 0; y < height; y++) // loop through rows of the grid
                {
                    if (y > 0) Console.WriteLine("");

                    for (int x = width-1; x >= 0; x--) // loop through columns of the grid
                    {
                        if (y >= rainY[x] - rainLength && y <= rainY[x])
                        {
                            int spaceAway = rainY[x] - y;

                            string symb = ((char)random.Next(33, 126)).ToString();

                            if (spaceAway == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                //Console.Write(" A ");
                            }

                            if (spaceAway == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.Write(" B ");
                            }

                            if (spaceAway >= 2 && spaceAway <= rainLength)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                //Console.Write(" C ");
                            }

                            Console.Write(" " + symb + " ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("   ");
                        }
                    }
                }

                System.Threading.Thread.Sleep(sleepTime);
                //Console.ReadLine();
                if (timer < cycleTime) timer++; else timer = 0;

                // reset digital rain
                for (int r = 0; r < rainNum; r++)
                {
                    if (rainY[r] < height + rainLength && doFall[r])
                    {
                        rainY[r]++;
                        //char c = (string)(char)random.Next(33, 126);
                        symbol[r] = ((char)random.Next(33, 126)).ToString();
                    }
                    else
                    {
                        rainY[r] = -1;
                        doFall[r] = false;
                    }

                    if (doFall[r] == false && fallDelay[r] == timer)
                    {
                        doFall[r] = true;
                        fallDelay[r] = random.Next(0, cycleTime);
                        rainSpeed[r] = random.Next(minRainSpeed, maxRainSpeed);
                    }
                }
            }
        }
    }
}
