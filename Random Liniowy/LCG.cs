using System;
using System.IO;

namespace CustomRandom
{
    public class LCG : AbstractRandom
    {
        /// <summary>
        /// Xn = (a * Xn-1 + c) mod m
        /// </summary>

        private float x;      // wartosc pseudolosowa
        private uint a;      // mnoznik
        private uint c;      // przyrost

        public LCG()
        {
            this.x = 0.0f;
            this.a = 1;
            this.c = 1;
            this.seed = 0;
            this.m = 0;
            this.x_max = 0;
        }

        //ustawianie ziarna
        public override void Srand(uint seed)
        {
            this.seed = seed;
            this.x = seed;
        }

        // funkcja zwracajaca kolejna wartosc pseudolosowa
        public override uint Next(uint x)
        {
            try
            {
                if (this.seed == 0)
                {
                    throw SeedDoesntSet;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(-1);
            }

            if (x != this.x_max)
            {
                this.x_max = x;

                CountValues();
                //System.Console.WriteLine("Zmiana!!");
            }

            this.x = (this.a * this.x + this.c) % this.m;

            return (uint)this.x;
        }

        // obliczanie wartosci m, c i a
        private void CountValues()
        {
            if (this.x_max < 1) return;

            //Console.WriteLine("X max: " + this.x_max);

            this.m = this.x_max + 1;
            //Console.WriteLine("m: " + this.m);

            this.c = 2;

            do
            {
                this.c++;
            } while (NWD(this.c, this.m) != 1);
            //Console.WriteLine("c: " + this.c);

            uint g = this.m;
            uint x = this.m;
            uint d = 2;

            while (d <= g)
            {
                if (x % d == 0)
                {
                    this.a *= d;

                    do
                    {
                        x /= d;
                    } while (x % d == 0);
                }
                if (d == 2) d++;
                else d += 2;
                if (x < d) break;
            }
            this.a *= x;
            if (m % 4 == 0) this.a <<= 1;
            this.a++;

            //Console.WriteLine("a: " + this.a);
        }

        //największy wspólny dzielnik dwóch liczb a i b jeśli zwraca 1 - to brak wspólnego dzielnika
        private uint NWD(uint a, uint b)
        {
            while (a != b)
            {
                if (a < b)
                {
                    b -= a;
                }
                else
                {
                    a -= b;
                }
            }
            return a;
        }
        
        public override void PrintSeed()
        {
            Console.WriteLine("Ziarno: " + this.seed);
        }
        
        public override void PrintValues()
        {
            Console.WriteLine("X max: " + this.x_max);
            Console.WriteLine("m: " + this.m);
            Console.WriteLine("c: " + this.c);
            Console.WriteLine("a: " + this.a);
        }
    }
}