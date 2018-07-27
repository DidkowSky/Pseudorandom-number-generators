using System;

abstract public class AbstractRandom
{
    protected Exception SeedDoesntSet = new Exception("Ziarno nie zostało ustawione");

    protected uint seed;    // ziarno
    protected uint m;      // modul
    protected uint x_max;  // maksymalny x zbioru

    public abstract void Srand(uint seed);
    public abstract uint Next(uint x);
    public abstract void PrintSeed();
    public abstract void PrintValues();
}