using System;

namespace Task5.Calculator.Interfaces
{
    public interface ICalculateProcessor
    {
        string ProcessSecondPriorityOperations(string expression, IFormatProvider formatProvider);

        string ProcessThirdPriorityOperations(string expression, IFormatProvider formatProvider);

        string ProcessFirstPriorityOperations(string expression, IFormatProvider formatProvider);

    }
}
