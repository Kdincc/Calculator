namespace Task5.Calculator.Interfaces
{
    public interface IInputChecker
    {
        bool IsFilePathExists(string path);

        bool IsMathExpression(string expression);
    }
}
