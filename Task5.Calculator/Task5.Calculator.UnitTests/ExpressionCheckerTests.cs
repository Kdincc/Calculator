namespace Task5.Calculator.UnitTests
{
    [TestClass]
    public class ExpressionCheckerTests
    {
        private readonly ExpressionChecker checker = new ExpressionChecker();

        [TestMethod]
        [DataRow("2+3/0", true)]
        [DataRow("2+4/2", false)]
        public void IsContainsZeroDivide(string expression, bool expected)
        {
            //arrange
            bool actual;

            //act
            actual = checker.IsContainsZeroDivide(expression);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("2+3-4-0+8", true)]
        [DataRow("8*3/3*2*2", true)]
        [DataRow("3.4+0.2*0.2", true)]
        [DataRow("2+z-3", false)]
        [DataRow("(2+3)-4", false)]
        public void IsCorrectConsoleExpression(string expression, bool expected)
        {
            //arrange
            bool actual;

            //act
            actual = checker.IsCorrectConsoleExpression(expression);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("2+3-4-0+8", true)]
        [DataRow("8*3/3*2*2", true)]
        [DataRow("3.4+0.2*0.2", true)]
        [DataRow("2+z-3", false)]
        [DataRow("(2+3)-4", true)]
        [DataRow("-2+3-4*2/1)*2)-3+12+((-4+2)*3)-2*2-3*2-4+2*((3-2)*0-2+3", false)]
        [DataRow("-2+3-4*2/1*2-3+12+((-4+2)*3)-2*2-3*2-4+2*((3-2)*0-2)+3", true)]
        public void IsCorrectFileExpression(string expression, bool expected)
        {
            //arrange
            bool actual;

            //act
            actual = checker.IsCorrectFileExpression(expression);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
