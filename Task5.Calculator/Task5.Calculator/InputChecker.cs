using System.IO;
using System.Text.RegularExpressions;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public class InputChecker : IInputChecker
    {
        public bool IsFilePathExists(string path)
        {
            if (File.Exists(path) && Directory.Exists(Path.GetDirectoryName(path)))
            {
                return true;
            }

            return false;
        }

        public bool IsMathExpression(string expression)
        {
            string pattern = @"^-?(\d+(\.\d+)?|\(+-?\d+(\.\d+)?)([-+*/](\(+)?\d+(\.\d+)?\)*([-+*/]\(+-?\d+(\.\d+)?)*)*$";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(expression)) 
            {
                return true;
            }

            return false;
        }
    }
}
