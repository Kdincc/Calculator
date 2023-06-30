namespace Task5.Calculator.Interfaces
{
    public interface ICalculatingResultsWriter
    {
        void AddResult(string expression, string result);
        void WriteResults(string path);
    }
}
