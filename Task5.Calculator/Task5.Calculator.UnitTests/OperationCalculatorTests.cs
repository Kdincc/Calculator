using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Calculator.UnitTests
{
    [TestClass]
    public class OperationCalculatorTests
    {
        private readonly OperationCalculator calculator = new OperationCalculator();

        [TestMethod]
        [DataRow(2, Operators.Plus, 4, 6)]
        [DataRow(5.5, Operators.Plus, 4.5, 10)]
        [DataRow(2, Operators.Minus, 4, -2)]
        [DataRow(5.5, Operators.Minus, 4.5, 1)]
        [DataRow(2, Operators.Multiplication, 4, 8)]
        [DataRow(5.5, Operators.Multiplication, 4.5, 24.75)]
        [DataRow(6, Operators.Division, 3, 2)]
        [DataRow(6, Operators.Division, 0.5, 12)]

        public void CalculateOperation(double leftOperand, Operators _operator, double rightOperand, double expected)
        {
            //arrange
            Operation operation = new Operation(leftOperand, _operator, rightOperand);
            double actual;

            //act
            actual = calculator.CalculateOperation(operation);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
