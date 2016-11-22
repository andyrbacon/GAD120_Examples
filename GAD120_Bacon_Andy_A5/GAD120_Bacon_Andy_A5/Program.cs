using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAD120_Bacon_Andy_A5
{
    class Program
    {
        static void DrawLine(int length, string lineMessage)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(lineMessage);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // SETUP
            int maxPlayerHealth = 10;
            int playerHealth = maxPlayerHealth;
            int maxEnemyHealth = 10;
            int enemyHealth = maxEnemyHealth;
            int spaceW = 8;
            int battleFieldLength = 5;
            string player = "(>'-')> ";
            string enemy = " <('-'<)";
            string spaceMessage = "";
            string lineMessage = "";
            for (int i = 0; i < spaceW; i++)
            {
                spaceMessage += " ";
                lineMessage += "_";
            }

            Random random = new Random();
            int selection = 0;
            
            string[] playerAttacks = new string[4];
            
            playerAttacks[0] = "TICKLE";
            playerAttacks[1] = "ATTEMP A JOKE";
            playerAttacks[2] = "MAKE A FACE";
            playerAttacks[3] = "IGNORE THE ENEMY";

            string message = "";

            // GAME
            bool doLoop = true;
            while (doLoop)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(message);
                Console.ResetColor();
                message = "";

                DrawLine(battleFieldLength, lineMessage);
                Console.WriteLine();

                // draw battle field
                for (int i = 0; i < battleFieldLength; i++)
                {
                    if (i == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(player);
                    }
                    else if (i == battleFieldLength - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(enemy);
                    }
                    else
                    {
                        Console.Write(spaceMessage);
                    }
                }
                Console.WriteLine();

                // draw line
                Console.ResetColor();
                DrawLine(battleFieldLength, lineMessage);

                // draw names
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("PLAYER  ");
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < battleFieldLength - 2; i++)
                {
                    Console.Write(spaceMessage);
                }
                Console.Write("   ENEMY");
                Console.WriteLine();

                // draw health
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("HP " + playerHealth + "/" + maxPlayerHealth);
                for (int i = 0; i < battleFieldLength - 2; i++)
                {
                    Console.Write(spaceMessage);
                }
                Console.Write("HP " + enemyHealth + "/" + maxEnemyHealth);
                Console.WriteLine();

                // draw attacks
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nCHOOSE AN ATTACK (W and S to move, A to select)");
                Console.ResetColor();
                for (int i = 0; i < playerAttacks.Length; ++i)
                {
                    // highlight the player's selection
                    if (i == selection)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    // display the array item
                    Console.WriteLine(" - " + playerAttacks[i]);

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
                    else
                        selection = playerAttacks.Length - 1;
                }

                // move down in the list
                if (input == "s")
                {
                    if (selection < playerAttacks.Length - 1)
                        selection++;
                    else
                        selection = 0;
                }

                // select item in the list
                if (input == "a")
                {
                    int damage = random.Next(0, 5);
                    enemyHealth -= damage;
                    if (enemyHealth <= 0)
                    {
                        enemyHealth = 0;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n*** YOU DEFEATED THE ENEMY ***\n");
                        return;
                    }
                    message = "YOU USED '" + playerAttacks[selection] + "' AND DEALT " + damage + " DAMAGE";

                    int enemyAttackIndex = random.Next(0, playerAttacks.Length - 1);
                    string enemyAttack = playerAttacks[enemyAttackIndex];
                    int enemyDamage = random.Next(0, 5);
                    playerHealth -= enemyDamage;
                    if (playerHealth <= 0)
                    {
                        playerHealth = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*** YOU DIED! ***\n");
                        return;
                    }
                    message += "\nTHE ENEMY USED '" + enemyAttack + "' AND DEALT " + enemyDamage + " DAMAGE";
                }
            } 
        }
    }
}
