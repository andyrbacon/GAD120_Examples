using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // display a list of all moves
            // display the cost for each move
            // highlight the selected move
            // press keys to navigate up and down the list

            // display the enemy's HP
            // create a damage value for each move
            // substract the damage value from the enemy's HP when using a move

            // apply a move type to each move
            // - 3. lower defense
            // - 2. heal
            // - 1. attack

            int enemyHP = 100;

            int selectedMove = 0;
            int mana = 100;
            int movesNum = 5;
            string[] moveNames = new string[movesNum];
            int[] moveCosts = new int[movesNum];
            int[] moveValues = new int[movesNum];
            string[] moveTypes = new string[movesNum];

            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            moveNames[0] = "Thunderbolt";
            moveCosts[0] = 4;
            moveValues[0] = 20;
            moveTypes[0] = "attack";

            moveNames[1] = "Soft Boil";
            moveCosts[1] = 3;
            moveValues[1] = 30;
            moveTypes[1] = "heal";

            moveNames[2] = "Volt Tackle";
            moveCosts[2] = 12;
            moveValues[2] = 15;
            moveTypes[2] = "attack";

            moveNames[3] = "Tail Whip";
            moveCosts[3] = 2;
            moveValues[3] = 10;
            moveTypes[3] = "lower defense";

            moveNames[4] = "Flamethrower";
            moveCosts[4] = 50;
            moveValues[4] = 50;
            moveTypes[4] = "attack";

            // game loop
            while (true)
            {
                Console.Clear();

                // display enemy HP
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enemy HP: " + enemyHP + "\n");
                Console.ResetColor();

                // display mana
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Mana: " + mana + "\n");
                Console.ResetColor();

                for (int i = 0; i < movesNum; i++)
                {
                    if (i == selectedMove)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    // print the move
                    string moveLabel = (i + 1).ToString() + ". " + moveNames[i] + " (" + moveTypes[i] + ")";
                    Console.WriteLine(moveLabel);

                    // print the cost
                    string costLabel = "   Cost: " + moveCosts[i].ToString();
                    Console.WriteLine(costLabel);

                    // print the damage
                    string damageLabel = "   Damage: " + moveValues[i].ToString();
                    Console.WriteLine(damageLabel);

                    Console.WriteLine();
                }

                // get input from the user
                string input = Console.ReadKey(true).KeyChar.ToString();

                // if the user presses W, go up in the menu
                if (input == "w" && selectedMove > 0)
                {
                    selectedMove--;
                }

                // if the user presses S, go down in the menu
                if (input == "s" && selectedMove < movesNum-1)
                {
                    selectedMove++;
                }

                // if the user presses E, get the cost of the selected move and take that away from mana
                if (input == "e")
                {
                    int cost = moveCosts[selectedMove];

                    if (mana >= cost) // if you have enough mana, use the move
                    {
                        
                        string moveType = moveTypes[selectedMove];

                        if (moveType == "attack")
                        {
                            mana -= cost;
                            enemyHP -= moveValues[selectedMove];
                        } 

                    }
                }
            }
        }
    }
}
