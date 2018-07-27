using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomRandom;

namespace ProgramGlowny
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractRandom rand = new MSM();            

            rand.Srand(156654);

            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine("Nastepna wartosc ciagu: " + rand.Next(5)); ;
            }
            rand.PrintValues();


            Console.ReadKey();
        }
    }
}
