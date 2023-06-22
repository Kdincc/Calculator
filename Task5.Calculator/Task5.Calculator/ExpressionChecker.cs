using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class ExpressionChecker: IExpressionChecker
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
            const string PATTERN = @"^(-?\d+(\.\d+)?|-?\(-?\d+(\.\d+)?[*/+-]\d+(\.\d+)?\))([*/+-]((-?\d+(\.\d+)?)|(\(-?\d+(\.\d+)?[*/+-]\d+(\.\d+)?\))))*$";
            Regex regex = new Regex(PATTERN);

            if (regex.IsMatch(expression))
            {
                return true;
            }

            return false;
        }
    }
}
