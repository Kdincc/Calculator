using System.Linq;
using System.Text.RegularExpressions;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class ExpressionChecker : IExpressionChecker
    {
        public bool IsContainsZeroDivide(string divideOperation)
        {
            const string PATTERN = @"\d+(\.\d+)?\/0";
            Regex regex = new Regex(PATTERN);

            if (regex.IsMatch(divideOperation))
            {
                return true;
            }

            return false;
        }

        public bool IsCorrectConsoleExpression(string expression)
        {
            const string PATTERN = @"^-?\d+(\.\d+)?([/+*-]-?\d+(\.\d+)?)*$";
            Regex regex = new Regex(PATTERN);

            if (regex.IsMatch(expression))
            {
                return true;
            }

            return false;
        }

        public bool IsCorrectFileExpression(string expression)
        {
            const string PATTERN = @"^-?(\d+(\.\d+)?|\(+-?\d+(\.\d+)?)([-+*/]\d+(\.\d+)?\)?([-+*/]\(+-?\d+(\.\d+)?)*)*$";
            Regex regex = new Regex(PATTERN);
            int leftBracketCount = expression.Where(x => x == (char)Operators.LeftBracket).Count();
            int rightBracketCount = expression.Where(x => x == (char)Operators.RightBracket).Count();

            return (leftBracketCount == rightBracketCount) && regex.IsMatch(expression);
        }
    }
}
