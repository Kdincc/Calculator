using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly NumberFormatInfo numberFormatInfo = NumberFormatInfo.InvariantInfo;
        private readonly ICalculateProcessor _processor;
        private readonly ICalculatingResultsWriter _calculatingResultsWriter;
        private readonly IExpressionChecker _exampleChecker;
        
        public Calculator(ICalculateProcessor parser, ICalculatingResultsWriter calculatingResultsWriter, IExpressionChecker exampleChecker) 
        {
            _processor = parser;
            _calculatingResultsWriter = calculatingResultsWriter;
            _exampleChecker = exampleChecker;
        }

        public string CalculateFromConsole(string expression)
        {
            string result;

            if (!_exampleChecker.IsCorrectConsoleExpression(expression))
            {
                return "Incorrect expression!";
            }

            var processedExpression = _processor.ProcessSecondPriorityOperations(expression, numberFormatInfo);

            if (_exampleChecker.IsContainsZeroDivide(processedExpression))
            {
                return processedExpression;
            }

            result = _processor.ProcessThirdPriorityOperations(processedExpression, numberFormatInfo);


            return result;
        }

        public void CalculateFromFile(string path)
        {
            const string OUTPUT_PATH = @"\Task5\Task5.Calculator\Output.txt";
            string result;

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    var expression = streamReader.ReadLine();
                    result = "Incorrect expression!";

                    if (_exampleChecker.IsCorrectFileExpression(expression))
                    {
                        var processedExample = _processor.ProcessFirstPriorityOperations(expression, numberFormatInfo);
                        
                        processedExample = _processor.ProcessSecondPriorityOperations(processedExample, numberFormatInfo);
                        
                        result = _processor.ProcessThirdPriorityOperations(processedExample, numberFormatInfo);
                    }

                    _calculatingResultsWriter.AddResult(expression, result);
                }
            };

            _calculatingResultsWriter.WriteResults(OUTPUT_PATH);
        }

    }
}
