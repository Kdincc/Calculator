using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Calculator.Interfaces
{
    public interface IExpressionChecker
    {
        bool IsContainsZeroDivide(string expression);

        bool IsCorrectConsoleExpression(string expression);

        bool IsCorrectFileExpression(string expression);
    }
}
