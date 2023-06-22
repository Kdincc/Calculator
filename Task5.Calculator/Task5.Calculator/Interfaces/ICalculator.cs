using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Calculator.Interfaces
{
    public interface ICalculator
    {
        string CalculateFromConsole(string expression);

        void CalculateFromFile(string path);
    }
}
