using System.IO;
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
    }
}
