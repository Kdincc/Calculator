namespace Task5.Calculator.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly CalculatingResultsWriter calculatingResultsWriter = new CalculatingResultsWriter();
        private readonly ExpressionChecker exampleChecker = new ExpressionChecker();
        private readonly OperationCalculator operationCalculator = new OperationCalculator();
        private readonly CalculatorParser calculatorParser = new CalculatorParser();
        private readonly CalculatorProcessor calculatorProcessor;
        private readonly Calculator calculator;

        public CalculatorTests()
        {
            calculatorProcessor = new CalculatorProcessor(calculatorParser, exampleChecker, operationCalculator);
            calculator = new Calculator(calculatorProcessor, calculatingResultsWriter, exampleChecker);
        }

        [TestMethod]
        [DataRow("2+3-4-0+8", "9")]
        [DataRow("8*3/3*2*2", "32")]
        [DataRow("12+3*2*3-4/2*3", "24")]
        [DataRow("43-3*2*0*2*3", "43")]
        [DataRow("2+3/0", "Divide by zero! 3/0")]
        [DataRow("2+3+z", "Incorrect expression!")]
        public void CalculateFromConsole_CorrectAnswer(string example, string expected)
        {
            //arrange
            string actual;

            //act
            actual = calculator.CalculateFromConsole(example);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new string[] { "(12+3)+2*3-4/2*3", "4+6*3*3", "8+4-10-20" }, new string[] { "(12+3)+2*3-4/2*3 = 15", "4+6*3*3 = 58", "8+4-10-20 = -18" })]
        public void CalculateFromFile(string[] expressions, string[] expected)
        {
            //arrange
            string[] actual;
            string testInputPath = @"\Task5\Task5.Calculator\Task5.Calculator.UnitTests\InputFileToTest.txt";
            string outputPath = @"\Task5\Task5.Calculator\Output.txt";

            //act
            File.WriteAllLines(testInputPath, expressions);
            calculator.CalculateFromFile(testInputPath);
            actual = File.ReadAllLines(outputPath);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}