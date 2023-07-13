using System;

namespace Task5.Calculator.Interfaces
{
    public interface ICalculator : IObservable<string>
    {
        double CalculateFromConsole(string expression);

        void CalculateFromFile(string path);
    }
}
