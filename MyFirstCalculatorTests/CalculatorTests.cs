using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCalculator.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void SumTest()
        {
           var calculator = new Calculator();
            Assert.IsTrue(calculator.Sum(2, 2) == 4);
            Assert.IsTrue(calculator.Sum(2, 5) == 7);
        }

        [TestMethod()]
        public void SubTest()
        {
            var calculator = new Calculator();
            Assert.IsTrue(calculator.Sub(2, 2) == 0);
        }

        [TestMethod()]
        public void MulTest()
        {
            var calculator = new Calculator();
            Assert.IsTrue(calculator.Mul(2, 2) == 4);
        }

        [TestMethod()]
        public void DivTest()
        {
            var calculator = new Calculator();
            Assert.IsTrue(calculator.Div(10, 2) == 5);
        }
    }
}