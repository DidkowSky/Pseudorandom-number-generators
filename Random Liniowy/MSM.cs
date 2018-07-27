using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandom
{
    public class MSM : AbstractRandom
    {
        private uint x;
        private uint w;

        public uint X { get => x; set => x = value; }
        public uint W { get => w; set => w = value; }

        public MSM()
        {
            this.m = 0;
            this.x_max = 0;
            this.seed = 0;
            this.X = 0;
            this.W = 0;
        }
        
        public override void Srand(uint seed)
        {
            this.seed = seed;
        }

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

            if (this.x_max != x)
            {
                this.x_max = x;
                this.m = this.x_max + 1;
            }

            //Console.WriteLine("Wartość x kolejny raz: " + this.X);
            this.X *= this.X;

            this.X += (this.W += this.seed/2);
            //Console.WriteLine("Wartość x przed przesunieciami: " + Convert.ToString(this.X, 2) + " | " + this.X);
            this.X = (this.X << 16);
            //Console.WriteLine("Wartość x po przesunieciu w lewo: " + Convert.ToString(this.X, 2) + " | " + this.X);
            this.X = (this.X >> 16);
            //Console.WriteLine("Wartość x po przesunieciach: " + Convert.ToString(this.X, 2) + " | " + this.X);

            //Console.WriteLine("Kolejna wartość x: " + this.X);

            return this.X % this.m;
        }
        
        public override void PrintSeed()
        {
            Console.WriteLine("Ziarno: " + this.seed);
        }

        public override void PrintValues()
        {
            Console.WriteLine("X max: " + this.x_max);
            Console.WriteLine("m: " + this.m);
        }
    }
}
