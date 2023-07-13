using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly Calculator calculator = new Calculator(new CalculatorProccesor(), new ExpressionChecker());

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
        [DataRow(new string[] { "(12+3)+2*3-4/2*3", "4+6*3*3", "8+4-10-20" }, new string[] { "(12+3)+2*3-4/2*3 = 15", "4+6*3*3 = 58", "8+4-10-20 = -18" })]
        public void CalculateFromFile(string[] expressions, string[] expected)
        {
            //arrange
            string[] actual;
            string testInputPath = @"\Task5\Task5.Calculator\Task5.Calculator.UnitTests\InputFileToTest.txt";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.txt");

            //act
            File.WriteAllLines(testInputPath, expressions);
            calculator.CalculateFromFile(testInputPath);
            actual = File.ReadAllLines(outputPath);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }

}

