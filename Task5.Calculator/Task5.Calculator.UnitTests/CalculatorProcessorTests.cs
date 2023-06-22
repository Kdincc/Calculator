using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Calculator.UnitTests
{
    [TestClass]
    public class CalculatorProcessorTests
    {
        private readonly NumberFormatInfo numberFormatInfo = NumberFormatInfo.InvariantInfo;
        private readonly ExpressionChecker exampleChecker = new ExpressionChecker();
        private readonly OperationCalculator operationCalculator = new OperationCalculator();
        private readonly CalculatorParser calculatorParser = new CalculatorParser();
        private readonly CalculatorProcessor calculatorProcessor;

        public CalculatorProcessorTests() 
        {
            calculatorProcessor = new CalculatorProcessor(calculatorParser, exampleChecker, operationCalculator);
        }

        [TestMethod]
        [DataRow("8*3/3*2*2", "32")]
        [DataRow("8*3/-3+2", "-8+2")]
        [DataRow("3+4-2+2", "3+4-2+2")]
        [DataRow("2+3/0", "Divide by zero! 3/0")]
        public void ProcessSecondPriorityOperations(string expression, string expected)
        {
            //act
            string actual;

            //arrange
            actual = calculatorProcessor.ProcessSecondPriorityOperations(expression, numberFormatInfo);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("4-4+8", "8")]
        [DataRow("-3.4+0.2-0.2", "-3.4")]
        [DataRow("3+4-2+2", "7")]
        public void ProcessThirdPriorityOperations(string expression, string expected)
        {
            //act
            string actual;

            //arrange
            actual = calculatorProcessor.ProcessThirdPriorityOperations(expression, numberFormatInfo);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("4-4+(8*2)", "4-4+16")]
        [DataRow("-3.4+0.2-(0.2*5)", "-3.4+0.2-1")]
        [DataRow("(2*3-2)+2+2*(3*2)", "4+2+2*6")]

        public void ProcessFirstPriorityOperations(string expression, string expected)
        {
            //act
            string actual;

            //arrange
            actual = calculatorProcessor.ProcessFirstPriorityOperations(expression, numberFormatInfo);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
