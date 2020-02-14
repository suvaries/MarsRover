using System;
using MarsRoverLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTest
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input = $"5 5{Environment.NewLine}1 2 N{Environment.NewLine}LMLMLMLMM{Environment.NewLine}3 3 E{Environment.NewLine}MMRMMRMRRM";
            string expected = $"1 3 N{Environment.NewLine}5 1 E";
            string actual = MarsRoverCalculator.Calculate(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
