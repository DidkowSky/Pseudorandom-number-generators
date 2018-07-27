using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CustomRandom;

namespace PRNG_Tests
{
    [TestClass]
    public class MSMTests
    {
        [TestMethod]
        public void MSM_Next_Test()
        {
            MSM target = new MSM();
            uint max = 10;

            target.Srand(2);
            uint result = target.Next(max);

            Assert.IsTrue(result >= 0, "Wartosc losowa MSM jest mniejsza od 0!");
            Assert.IsTrue(result <= max, "Wartosc losowa MSM jest większa niż podana wartość maksymalna!");

        }
    }
}
