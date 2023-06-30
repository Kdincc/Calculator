using System.Globalization;

namespace Task5.Calculator
{
    public class Operation
    {
        private readonly NumberFormatInfo numberFormatInfo = NumberFormatInfo.InvariantInfo;

        public double LeftOperand { get; }
        public Operators Operator { get; }
        public double RightOperand { get; }

        public Operation(double leftOperand, Operators _operator, double rightOperand)
        {
            LeftOperand = leftOperand;
            Operator = _operator;
            RightOperand = rightOperand;
        }

        public override string ToString()
        {
            if (Operator == Operators.None)
            {
                return Operator.ToString();
            }

            return LeftOperand.ToString(numberFormatInfo) + (char)Operator + RightOperand.ToString(numberFormatInfo);
        }
    }
}
