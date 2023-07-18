using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Calculator.UnitTests
{
    [TestClass]
    public class InputCheckerTests
    {
        private readonly InputChecker checker = new InputChecker();

        [TestMethod]
        [DataRow("23+3-3+2", true)]
        [DataRow("23+3sa+2", false)]
        [DataRow("((23+3)-3)+2", true)]
        [DataRow("\\file.txt", false)]
        public void IsMathExpression(string input, bool expected)
        {
            //arrange
            bool actual;

            //actual
            actual = checker.IsMathExpression(input);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
