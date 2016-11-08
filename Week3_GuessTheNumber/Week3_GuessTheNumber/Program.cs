using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int lowestNum = 0;
            int highestNum = 10;
            Random r = new Random();
            int number = r.Next(lowestNum, highestNum);
            int maxGuesses = 4;
            int currentGuess = 0;

            Console.WriteLine("*** GUESS THE NUMBER ***");

            while (currentGuess < maxGuesses)
            {
                Console.ResetColor();
                int guessesLeft = maxGuesses - currentGuess;
                Console.WriteLine("\nChoose a number between " + lowestNum + " and " + highestNum + ".\nYou have " + guessesLeft + " guesses left.");

                Console.ForegroundColor = ConsoleColor.Yellow;
                int guess = Convert.ToInt32(Console.ReadLine());


                if (guess < number)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Too low.");
                }
                else if (guess > number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Too high.");
                }
                else if (guess == number)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("*** That's right! You guessed it! The number is " + number + "! ***");
                    Console.ResetColor();
                    return;
                }

                currentGuess++;
            }

            Console.WriteLine("No more guesses left! You lose! The number was " + number + ".");
            Console.ResetColor();
        }
    }
}
