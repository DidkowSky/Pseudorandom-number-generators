using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CustomRandom;

namespace PRNG_Tests
{
    [TestClass]
    public class LCGTests
    {
        [TestMethod]
        public void LCG_Next_Test()
        {
            LCG target = new LCG();
            uint max = 10;

            target.Srand(2);
            uint result = target.Next(max);

            Assert.IsTrue(result >= 0, "Wartosc losowa LCG jest mniejsza od 0!");
            Assert.IsTrue(result <= max, "Wartosc losowa LCG jest większa niż podana wartość maksymalna!");

        }
    }
}
