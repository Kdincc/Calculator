using System.Globalization;

namespace Task5.Calculator.UnitTests
{
    [TestClass]
    public class CalculatorParserTests
    {
        private readonly CalculatorParser calculatorParser = new CalculatorParser();
        private readonly NumberFormatInfo numberFormatInfo = NumberFormatInfo.InvariantInfo;

        [TestMethod]
        [DataRow("2+3*2*4-2", "3*2")]
        [DataRow("3/2", "3/2")]
        [DataRow("2+3", "None")]
        public void ParseSecondPriorityOperation(string expression, string expected)
        {
            //arrange
            string actual;

            //act
            actual = calculatorParser.ParseSecondPriorityOperation(expression, numberFormatInfo).ToString();

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow("2+3*2*4-2", "2+3")]
        [DataRow("3/2", "None")]
        [DataRow("2+3", "2+3")]
        public void ParseThirdPriorityOperation(string expression, string expected)
        {
            //arrange
            string actual;

            //act
            actual = calculatorParser.ParseThirdPriorityOperation(expression, numberFormatInfo).ToString();

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow("2+3*2*4-2", "")]
        [DataRow("3/2-(4+2*2)", "(4+2*2)")]
        [DataRow("(2+3-4)+(8*2/4)", "(2+3-4)")]
        public void ParseFirstPriorityOperation(string expression, string expected)
        {
            //arrange
            string actual;

            //act
            actual = calculatorParser.ParseFirstPriorityOperation(expression, numberFormatInfo).ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
