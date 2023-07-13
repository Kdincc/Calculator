namespace Task5.Calculator.Interfaces
{
    public interface IExpressionChecker
    {
        bool IsCorrectConsoleExpression(string expression);

        bool IsCorrectFileExpression(string expression);
    }
}
