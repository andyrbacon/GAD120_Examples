using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_InfiniteCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            bool doLoop = true;
            while (doLoop == true)
            {
                Console.WriteLine(number);
                number++;
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
