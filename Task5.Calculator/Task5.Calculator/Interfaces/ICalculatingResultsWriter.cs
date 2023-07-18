using System;

namespace Task5.Calculator.Interfaces
{
    public interface ICalculatingResultsWriter : IObserver<string>
    {
        void WriteResultsToFile(string path);
        void WriteResultsToConsole();
    }
}
