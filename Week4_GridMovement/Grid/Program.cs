﻿using System;
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
            Console.Title = "Grid Movement";

            int width = 10;
            int height = 10;

            Random r = new Random();
            int playerX = r.Next(1, width);
            int playerY = r.Next(1, height);

            int treasureX = r.Next(1, width);
            int treasureY = r.Next(1, height);

            // keep choosing a random position for the treasure until it is different than the player's position
            while (playerX == treasureX && playerY == treasureY)
            {
                treasureX = r.Next(1, width);
                treasureY = r.Next(1, height);
            }

            bool hasFoundTreasure = false;
            bool doShowTreasure = true;

            // keep displaying the map and instructions until the player finds the treasure
            while (hasFoundTreasure == false)
            {
                Console.Clear(); // clear the Console so that the map is only displayed once

                // start of grid loop
                for (int y = 1; y <= height; y++) // loop through rows of the grid
                {
                   Console.WriteLine(); // reset the row

                    for (int x = 1; x <= width; x++) // loop through columns of the grid
                    {
          
                        if (x == playerX && y == playerY)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" [P] "); // player
                        }
                        else if (x == treasureX && y == treasureY && doShowTreasure == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" [T] "); // treasure
                        }
                        else
                        {
                            Console.ResetColor();
                            Console.Write(" [ ] "); // add grid spaces to the row 
                        }
                    }
                }
                // end of grid loop

                // instructions
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Enter 'W' to move up.");
                Console.WriteLine("Enter 'A' to move left.");
                Console.WriteLine("Enter 'D' to move right.");
                Console.WriteLine("Enter 'S' to move down.");

                string input = Console.ReadKey(true).KeyChar.ToString();

                string lowerInput = input.ToLower();

                // horizontal movement
                if (lowerInput == "a")
                {
                    if (playerX > 1)
                        playerX--;
                    else
                        playerX = width;
                }
                if (lowerInput == "d")
                {
                    if (playerX < width)
                        playerX++;
                    else
                        playerX = 1;
                }

                //vertical movement
                if (lowerInput == "w")
                {
                    if (playerY > 1)
                        playerY--;
                    else
                        playerY = height;
                }
                if (lowerInput == "s")
                {
                    if (playerY < height)
                        playerY++;
                    else
                        playerY = 1;
                }
            }
        }
    }
}
