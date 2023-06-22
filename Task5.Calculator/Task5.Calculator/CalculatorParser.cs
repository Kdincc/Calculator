using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class CalculatorParser : ICalculatorParser
    {
        public string ParseFirstPriorityOperation(string expression, IFormatProvider formatProvider)
        {
            const string BRACKET_PATTERN = @"\((.*?)\)";
            Regex regex = new Regex(BRACKET_PATTERN);
            Match match = regex.Match(expression);

            return match.Value;
        }

        public Operation ParseSecondPriorityOperation(string expression, IFormatProvider formatProvider)
        {
            const string PATTERN = @"(-?\d+(\.\d+)?)([*/])(-?\d+(\.\d+)?)";

            return ParseOperation(formatProvider, PATTERN, expression);
        }

        public Operation ParseThirdPriorityOperation(string expression, IFormatProvider formatProvider)
        {
            const string PATTERN = @"(-?\d+(\.\d+)?)([+-])(-?\d+(\.\d+)?)";

            return ParseOperation(formatProvider, PATTERN, expression);
        }

        private Operation ParseOperation (IFormatProvider formatProvider, string pattern, string expression) 
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(expression);
            double leftOperand;

            if (match.Success)
            {
                if (match.Groups[1].Value == "-0")
                {
                    leftOperand = Math.CopySign(0.0, -1.0);
                }
                else
                {
                    leftOperand = Convert.ToDouble(match.Groups[1].Value, formatProvider);
                }
                
                Operators _operator = (Operators)char.Parse(match.Groups[3].Value);
                double rightOperand = Convert.ToDouble(match.Groups[4].Value, formatProvider);

                return new Operation(leftOperand, _operator, rightOperand);
            }

            return new Operation(0, Operators.None, 0);

        }
    }
}
