using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Calculator.Interfaces
{
    public interface ICalculatingResultsWriter
    {
        void AddResult(string expression, string result);
        void WriteResults(string path);
    }
}
