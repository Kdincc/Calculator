namespace Task5.Calculator.Interfaces
{
    public interface IExpressionChecker
    {
        bool IsContainsZeroDivide(string expression);

        bool IsCorrectConsoleExpression(string expression);

        bool IsCorrectFileExpression(string expression);
    }
}
