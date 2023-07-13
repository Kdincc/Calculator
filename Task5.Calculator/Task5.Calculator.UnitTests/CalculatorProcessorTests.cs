using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Calculator.UnitTests
{
    [TestClass]
    public class CalculatorProcessorTests
    {
        private readonly CalculatorProccesor calculatorProccesor = new CalculatorProccesor();

        [TestMethod]
        [DataRow("3-4+2", 1)]
        [DataRow("3+2*(-3)", -3)]
        [DataRow("3*4+(2-2)*3", 12)]
        public void ProcessExpression(string expression, double expected)
        {
            //arrange
            double actual;

            //act
            actual = calculatorProccesor.ProcessMathExpression(expression);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
