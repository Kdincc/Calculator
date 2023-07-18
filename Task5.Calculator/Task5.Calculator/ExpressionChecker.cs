using System.Linq;
using System.Text.RegularExpressions;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class ExpressionChecker : IExpressionChecker
    {
        public bool IsCorrectConsoleExpression(string expression)
        {
            const string pattern = @"^-?\d+(\.\d+)?([/+*-]-?\d+(\.\d+)?)*$";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(expression))
            {
                return true;
            }

            return false;
        }

        public bool IsCorrectFileExpression(string expression)
        {
            string pattern = @"^-?(\d+(\.\d+)?|\(+-?\d+(\.\d+)?)([-+*/](\(+)?\d+(\.\d+)?\)*([-+*/]\(+-?\d+(\.\d+)?)*)*$";
            Regex regex = new Regex(pattern);
            int leftBracketCount = expression.Where(x => x == (char)Operators.LeftBracket).Count();
            int rightBracketCount = expression.Where(x => x == (char)Operators.RightBracket).Count();

            return (leftBracketCount == rightBracketCount) && regex.IsMatch(expression);
        }
    }
}
