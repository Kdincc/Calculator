namespace Task5.Calculator.Interfaces
{
    public interface IInputChecker
    {
        bool IsCorrectMenuAnswer(string answer);

        bool IsFilePathExists(string path);
    }
}
