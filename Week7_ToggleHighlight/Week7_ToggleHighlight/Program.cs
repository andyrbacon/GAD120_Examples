using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7_ToggleHighlight
{
    class Program
    {
        static void Main(string[] args)
        {
            // use an array of booleans to display a vertical line of colored lights
            // the player can use the arrow keys to select a light
            // press the spacebar to toggle the selected light on and off
            Dictionary<ConsoleKey, ConsoleColor> keyColorDictionary = new Dictionary<ConsoleKey, ConsoleColor>();
            keyColorDictionary.Add(ConsoleKey.R, ConsoleColor.Red);
            keyColorDictionary.Add(ConsoleKey.G, ConsoleColor.Green);
            keyColorDictionary.Add(ConsoleKey.B, ConsoleColor.Blue);

            int selectedLightIndex = 0;
            Random random = new Random();
            int numberOfLights = 7;
            bool[] isLightOn = new bool[numberOfLights];
            ConsoleColor[] lightColors = new ConsoleColor[numberOfLights];
            ConsoleColor[] possibleColors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Cyan };
            
            // randomly fill up the arrays with booleans and colors
            for (int i = 0; i < numberOfLights; i++)
            {
                int randomNum = random.Next(0, 2);
                if (randomNum == 0)
                    isLightOn[i] = true;
                else
                    isLightOn[i] = false;

                lightColors[i] = possibleColors[random.Next(0, possibleColors.Length)];
            }

            while (true) // the game loop
            {
                Console.Clear();

                // display line of lights
                for (int i = 0; i < numberOfLights; i++)
                {                   
                    if (isLightOn[i] == true)
                        Console.ForegroundColor = lightColors[i];
                    else
                        Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write("☻ ");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < numberOfLights; i++)
                {   
                    if (i == selectedLightIndex)
                        Console.Write("▲ ");
                    else
                        Console.Write("  ");
                }

                ConsoleKey input = Console.ReadKey().Key;
                if (input == ConsoleKey.LeftArrow)
                {
                    // move the selection up
                    if (selectedLightIndex > 0)
                        selectedLightIndex--;
                    else
                        selectedLightIndex = numberOfLights - 1;
                }

                if (input == ConsoleKey.RightArrow)
                {
                    // move the selection down
                    if (selectedLightIndex < numberOfLights - 1)
                        selectedLightIndex++;
                    else
                        selectedLightIndex = 0;
                }

                if (input == ConsoleKey.Spacebar)
                {
                    // use the ! not operator to switch the selected light
                    isLightOn[selectedLightIndex] = !isLightOn[selectedLightIndex];

                    if (isLightOn[selectedLightIndex] == true)
                        lightColors[selectedLightIndex] = possibleColors[random.Next(0, possibleColors.Length)];
                }

                foreach(KeyValuePair<ConsoleKey, ConsoleColor> keyValue in keyColorDictionary)
                {
                    if (input == keyValue.Key)
                        lightColors[selectedLightIndex] = keyValue.Value;
                }
            }
        }
    }
}
