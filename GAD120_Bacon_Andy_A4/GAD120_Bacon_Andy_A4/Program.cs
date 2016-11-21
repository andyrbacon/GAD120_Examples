using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAD120_Bacon_Andy_A4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Treasure Map";

            ConsoleColor instructionsColour = ConsoleColor.Gray;
            ConsoleColor gridColour = ConsoleColor.DarkGray;
            ConsoleColor foundTreasureColour = ConsoleColor.Magenta;
            ConsoleColor hintColour = ConsoleColor.Magenta;
            ConsoleColor inputColour = ConsoleColor.DarkYellow;
            ConsoleColor deathColour = ConsoleColor.Red;

            int width = 6;
            int height = 6;
            int daysLeft = 14;

            Random r = new Random();
            int playerX = r.Next(1, width);
            int playerY = r.Next(1, height);

            int treasureX = r.Next(1, width);
            int treasureY = r.Next(1, height);

            bool doMoveMonsterX = true;

            // keep choosing a random position for the treasure until it is different than the player's position
            while (playerX == treasureX && playerY == treasureY)
            {
                treasureX = r.Next(1, width);
                treasureY = r.Next(1, height);
            }

            int monsterX = r.Next(1, width);
            int monsterY = r.Next(1, height);
            while (playerX == monsterX && playerY == monsterY)
            {
                monsterX = r.Next(1, width);
                monsterY = r.Next(1, height);
            }

            bool doShowTreasure = true;

            string hintMessage = "";

            // keep displaying the map and instructions until the player finds the treasure or dies
            bool doLoop = true;
            while(doLoop)
            {
                Console.Clear();

                // display the days left
                Console.ResetColor();
                Console.Write("You have ");
                Console.ForegroundColor = deathColour;
                Console.Write(daysLeft.ToString());
                Console.ResetColor();
                Console.Write(" days left to find the treasure.\n");

                // display a grid
                // **************************************************************************************
                for (int y = 1; y <= height; y++) // loop through rows of the grid
                {
                    Console.WriteLine();

                    for (int x = 1; x <= width; x++) // loop through columns of the grid
                    {
                        if (x == monsterX && y == monsterY) // monster
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[M]");
                        }
                        else if (x == playerX && y == playerY) // player
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[P]");
                        }
                        else if (x == treasureX && y == treasureY && doShowTreasure == true) // treasure
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("[T]");
                        }
                        else
                        {
                            Console.ForegroundColor = gridColour;
                            Console.Write("[ ]");
                        }
                    }

                    
                }
                // **************************************************************************************

                Console.WriteLine("\n");

                // check if monster kills player
                if (playerX == monsterX && playerY == monsterY)
                {
                    Console.ForegroundColor = deathColour;
                    Console.WriteLine("\n*** THE MONSTER ATE YOU! ***\n");
                    Console.ResetColor();
                    return;
                }

                if (hintMessage != "")
                {
                    Console.ForegroundColor = hintColour;
                    Console.WriteLine(hintMessage);
                }

                Console.ForegroundColor = instructionsColour;
                Console.WriteLine("Press 'W' to move up.");
                Console.WriteLine("Press 'A' to move left.");
                Console.WriteLine("Press 'D' to move right.");
                Console.WriteLine("Press 'S' to move down.");
                Console.WriteLine("Press 'Q' to search.");

                Console.ForegroundColor = inputColour;
                string input = Console.ReadKey(true).KeyChar.ToString();
                string inputLower = input.ToLower();

                // search
                hintMessage = ""; // reset hint message

                if (inputLower == "q")
                {
                    if (playerX == treasureX && playerY == treasureY)
                    {
                        Console.ForegroundColor = foundTreasureColour;
                        Console.WriteLine("\n*** YOU FOUND THE TREASURE! ***\n");
                        Console.ResetColor();
                        return;
                    } else
                    {
                        string xDirection = "", yDirection = "";

                        if (playerX < treasureX) xDirection = "east";
                        else if (playerX > treasureX) xDirection = "west";

                        if (playerY < treasureY) yDirection = "south";
                        else if (playerY > treasureY) yDirection = "north";

                        hintMessage = "The treasure is to the ";
                        if (playerY != treasureY) hintMessage += yDirection;
                        if (playerX != treasureX) hintMessage += xDirection;
                        hintMessage += ".";
                    }
                }

                // horizontal movement
                if (inputLower == "a")
                {
                    if (playerX > 1)
                        playerX--;
                    else
                        playerX = width;
                }
                if (inputLower == "d")
                {
                    if (playerX < width)
                        playerX++;
                    else
                        playerX = 1;
                }

                //vertical movement
                if (inputLower == "w")
                {
                    if (playerY > 1)
                        playerY--;
                    else
                        playerY = height;
                }
                if (inputLower == "s")
                {
                    if (playerY < height)
                        playerY++;
                    else
                        playerY = 1;
                }

                // move the monster
                if (doMoveMonsterX)
                {
                    monsterX += r.Next(-1, 1);
                    if (monsterX == 0) monsterX = width;
                    if (monsterX == width + 1) monsterX = 1;
                } else
                {
                    monsterY += r.Next(-1, 1);
                    if (monsterY == 0) monsterY = height;
                    if (monsterY == height + 1) monsterY = 1;
                }
                doMoveMonsterX = !doMoveMonsterX;

                daysLeft--;
                if (daysLeft < 0)
                {
                    Console.ForegroundColor = deathColour;
                    Console.WriteLine("\n*** YOU RAN OUT OF DAYS! ***\n");
                    Console.ResetColor();
                    return;
                }
            }
        }
    }
}
