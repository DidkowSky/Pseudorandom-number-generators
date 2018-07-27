using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandom
{
    public class LFG : AbstractRandom
    {
        private List<uint> history = new List<uint>();

        public List<uint> History { get => history; set => history = value; }

        public LFG()
        {
            this.m = 0;
            this.x_max = 0;
            this.seed = 0;
        }

        public override void Srand(uint seed)
        {
            this.seed = seed;

            ClearList();
            InitializeList(this.seed);
            PrintList();
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

            uint result = 0;
            int j = this.History.Count - 1;
            int k = this.History.Count - this.History.Count / 3;

            if (j == k && k > 0)
                k--;

            result = (uint)(this.History[j] + this.History[k]) % this.m;
            //Console.WriteLine("[" + (this.History.Count - j) + "] " +this.History[this.History.Count - j] + " + [" + (this.History.Count - k) + "] " + this.History[this.History.Count - k] + " % " + this.m + " = " + result);

            AddNextToList(result);

            if(history.Count > 100)
                RemoveFirstFromList();

            return result;
        }

        private void ClearList()
        {
            this.History.Clear();
        }

        private void RemoveFirstFromList()
        {
            this.History.RemoveAt(0);
        }

        private void AddNextToList(uint x)
        {
            this.History.Add(x);
        }

        private void InitializeList(uint seed)
        {
            this.History.Add((uint)seed / 7);
            this.History.Add((uint)seed / 3);
            this.History.Add((uint)seed / 2);
            this.History.Add((uint)seed);
            this.History.Add((uint)seed / 4);
            this.History.Add((uint)seed / 5);
        }

        public void PrintList()
        {
            int j = 0;

            while (j < this.History.Count)
            {
                Console.WriteLine(this.History[j]);
                j++;
            }
            Console.WriteLine("----------------");
        }

        public override void PrintSeed()
        {
            Console.WriteLine("Ziarno: " + this.seed);
        }

        public override void PrintValues()
        {
            Console.WriteLine("x_max: " + this.x_max);
            Console.WriteLine("m: " + this.m);
        }
    }
}
