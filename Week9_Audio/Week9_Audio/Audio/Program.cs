using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;

namespace Week9_Audio
{
    class Program
    {
        static void Main(string[] args)
        {
            // SETUP:
            // 1. Drag the .wav file from Windows explorer into Visual Studio / Solution Explorer / Project Name
            // 2. Click on the .wav file in the Solution Explorer
            // 3. Change 'Copy to Output Directory' to 'Copy if newer'
            // 4. Double-click on the .wav file in the Solution Explorer to open the file

            SoundPlayer soundPlayer = new SoundPlayer();
            string coinFilePath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Blah.wav";
            string fireBallPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Fireball.wav";
            string spell = "";

            while (true)
            {
                Console.Clear();

                if (spell == "ccf")
                {
                    Console.WriteLine("YOU CAST A SPELL!");
                }

                if (spell == "ffc")
                {
                    Console.WriteLine("YOU CAST A DIFFERENT SPELL!");
                }

                if (spell.Length >= 3)
                {
                    spell = "";
                }

                string input = Console.ReadKey(true).KeyChar.ToString();

                if (input == "c")
                {
                    soundPlayer.SoundLocation = coinFilePath;
                    soundPlayer.Play();
                    spell += "c";
                }

                if (input == "f")
                {
                    soundPlayer.SoundLocation = fireBallPath;
                    soundPlayer.Play();
                    spell += "f";
                }
            }

        }
    }
}
