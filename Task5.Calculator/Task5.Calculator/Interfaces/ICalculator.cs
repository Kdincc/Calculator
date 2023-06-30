namespace Task5.Calculator.Interfaces
{
    public interface ICalculator
    {
        string CalculateFromConsole(string expression);

        void CalculateFromFile(string path);
    }
}
