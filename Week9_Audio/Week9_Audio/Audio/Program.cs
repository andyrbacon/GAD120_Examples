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
            // 0. Use namespace System.IO and System.Media
            // 1. Drag the .wav file from Windows explorer into Visual Studio / Solution Explorer / Project Name
            // 2. Click on the .wav file in the Solution Explorer to open it (not sure why you have to do this...)
            // 3. Change 'Copy to Output Directory' to 'Copy if newer'
            // 4. Create a SoundPlayer object and set its SoundLocation parameter to the sound file's path
            // 5. Use SoundPlayer.Play() to play the sound

            SoundPlayer soundPlayer = new SoundPlayer();
            string coinFilePath = Environment.CurrentDirectory + "/Blah.wav";
            string fireBallPath = Environment.CurrentDirectory + "/Fireball.wav";
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
