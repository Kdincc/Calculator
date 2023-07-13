using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        [TestMethod]
        [DataRow(5, '+', 4, 9)]
        [DataRow(20, '*', 5, 100)]
        [DataRow(40, '/', 8, 5)]
        [DataRow(8, '-', 4, 4)]
        public void PerformOperation(double leftOperand, char operation, double rightOperand, double expected)
        {
            //arrange
            double actual;

            //act
            actual = CalculatorProccesor.PerformOperation(leftOperand, operation, rightOperand);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow('+', true)]
        [DataRow('*', true)]
        [DataRow('/', true)]
        [DataRow('-', true)]
        [DataRow('^', false)]
        public void IsOperator(char oper, bool expected)
        {
            //arrange
            bool actual;

            //act
            actual = calculatorProccesor.IsOperator(oper);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
