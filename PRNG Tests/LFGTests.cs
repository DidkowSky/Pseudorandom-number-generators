using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CustomRandom;

namespace PRNG_Tests
{
    [TestClass]
    public class LFGTests
    {
        [TestMethod]
        public void LFG_Next_Test()
        {
            LFG target = new LFG();
            uint max = 10;

            target.Srand(2);
            uint result = target.Next(max);

            Assert.IsTrue(result >= 0, "Wartosc losowa LFG jest mniejsza od 0!");
            Assert.IsTrue(result <= max, "Wartosc losowa LFG jest większa niż podana wartość maksymalna!");

        }
    }
}
