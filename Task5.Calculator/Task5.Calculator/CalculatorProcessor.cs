using System;
using System.Linq;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class CalculatorProcessor : ICalculateProcessor
    {
        private readonly ICalculatorParser _parser;
        private readonly IExpressionChecker _expressionChecker;
        private readonly IOperationCalculator _operationCalculator;

        public CalculatorProcessor(ICalculatorParser parser, IExpressionChecker expressionChecker, IOperationCalculator operationCalculator)
        {
            _parser = parser;
            _expressionChecker = expressionChecker;
            _operationCalculator = operationCalculator;
        }

        public string ProcessFirstPriorityOperations(string expression, IFormatProvider formatProvider)
        {
            string bracketExpression = _parser.ParseFirstPriorityOperation(expression, formatProvider);
            string processedBracketExpression;
            char[] brackets = new char[] { (char)Operators.LeftBracket, (char)Operators.RightBracket };

            if (string.IsNullOrEmpty(bracketExpression))
            {
                return expression;
            }

            var openedBracketExpression = ProcessBracketExpression(bracketExpression, formatProvider);
            processedBracketExpression = openedBracketExpression;

            if (CheckOperators(openedBracketExpression, Operators.Division, Operators.Multiplication))
            {
                processedBracketExpression = ProcessSecondPriorityOperations(openedBracketExpression, formatProvider);
            }

            processedBracketExpression = ProcessThirdPriorityOperations(processedBracketExpression, formatProvider);

            string processedExample = expression.ReplaceFirstOccurrence(openedBracketExpression, processedBracketExpression.Trim(brackets));

            if (CheckOperators(processedExample, Operators.LeftBracket, Operators.RightBracket))
            {
                return ProcessFirstPriorityOperations(processedExample, formatProvider);
            }

            return processedExample;
        }

        public string ProcessSecondPriorityOperations(string expression, IFormatProvider formatProvider)
        {
            Operation operation = _parser.ParseSecondPriorityOperation(expression, formatProvider);

            if (IsEmptyOperation(operation))
            {
                return expression;
            }

            if (_expressionChecker.IsContainsZeroDivide(operation.ToString()))
            {
                return "Divide by zero! " + operation.ToString();
            }

            string processedExpression = ProcessOperation(operation, expression, formatProvider);

            if (CheckOperators(processedExpression, Operators.Division, Operators.Multiplication))
            {
                return ProcessSecondPriorityOperations(processedExpression, formatProvider);
            }

            return processedExpression;
        }

        public string ProcessThirdPriorityOperations(string expression, IFormatProvider formatProvider)
        {
            Operation operation = _parser.ParseThirdPriorityOperation(expression, formatProvider);

            if (IsEmptyOperation(operation))
            {
                return expression;
            }

            string processedExample = ProcessOperation(operation, expression, formatProvider);

            if (CheckOperators(processedExample, Operators.Plus, Operators.Minus))
            {
                return ProcessThirdPriorityOperations(processedExample, formatProvider);
            }

            return processedExample;
        }

        private string ProcessBracketExpression(string bracketExpression, IFormatProvider formatProvider)
        {
            var openedBracketExpression = _parser.ParseFirstPriorityOperation(bracketExpression, formatProvider);
            var trimedBracketExpression = openedBracketExpression.RemoveFirstAndLastOccurrence((char)Operators.LeftBracket, (char)Operators.RightBracket);

            if (CheckOperators(trimedBracketExpression, Operators.LeftBracket, Operators.RightBracket))
            {
                return ProcessBracketExpression(trimedBracketExpression, formatProvider);
            }

            return openedBracketExpression;
        }
        private string ProcessOperation(Operation operation, string expression, IFormatProvider formatProvider)
        {
            double result;
            string strOperation = operation.ToString();

            result = _operationCalculator.CalculateOperation(operation);

            return expression.ReplaceFirstOccurrence(strOperation, result.ToString(formatProvider));
        }

        private bool CheckOperators(string processedExpression, Operators firstOperator, Operators secondOperator)
        {
            if (processedExpression.Any(x => x == (char)firstOperator || x == (char)secondOperator))
            {
                return true;
            }

            return false;
        }

        private bool IsEmptyOperation(Operation operation)
        {
            if (operation.Operator == Operators.None)
            {
                return true;
            }

            return false;
        }

    }
}