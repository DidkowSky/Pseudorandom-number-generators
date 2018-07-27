using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PRNG_Charts;

namespace PRNG_Tests
{
    [TestClass]
    public class ChartsTest
    {
        [TestMethod]
        public void ReadFileThatDoesntExist()
        {
            FilesManager target = new FilesManager();
            String[] actual;

            actual = target.ReadFile("Nieistniejacy Plik.csv");

            Assert.AreEqual(null, actual);
        }
    }
}
