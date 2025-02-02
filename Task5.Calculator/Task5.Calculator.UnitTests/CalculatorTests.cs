﻿namespace Task5.Calculator.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly Calculator calculator = new Calculator(new CalculatorProccesor(), new ExpressionChecker());
        private readonly CalculatingResultsWriter resultsWriter = new CalculatingResultsWriter();

        [TestMethod]
        [DataRow("2+3-4-0+8", 9)]
        [DataRow("8*3/3*2*2", 32)]
        [DataRow("12+3*2*3-4/2*3", 24)]
        [DataRow("43-3*2*0*2*3", 43)]
        [DataRow("2+3/0", double.PositiveInfinity)]
        [DataRow("2+3+z", 0)]
        public void CalculateFromConsole_CorrectAnswer(string example, double expected)
        {
            //arrange
            double actual;

            //act
            actual = calculator.CalculateFromConsole(example);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new string[] { "((4-1)*2)+4+((22)-1)", "(12+3)+2*3-4/2*3", "4+6*3*3", "8+4-10-20" }, new string[] { "((4-1)*2)+4+((22)-1) = 31", "(12+3)+2*3-4/2*3 = 15", "4+6*3*3 = 58", "8+4-10-20 = -18" })]
        public void CalculateFromFile(string[] expressions, string[] expected)
        {
            //arrange
            string[] actual;
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
            string path = "FileToTest.txt";

            //act
            calculator.Subscribe(resultsWriter);
            File.WriteAllLines(path, expressions);

            foreach (string expression in expressions)
            {
                calculator.CalculateFromFile(expression);
            }
            resultsWriter.WriteResultsToFile(outputPath);
            actual = File.ReadAllLines(outputPath);

            //assert
            CollectionAssert.AreEqual(expected, actual);

            //Cleanup
            File.Delete(outputPath);
            File.Delete(path);
        }
    }

}

