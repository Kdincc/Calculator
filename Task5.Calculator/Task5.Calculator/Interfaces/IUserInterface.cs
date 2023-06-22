using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Calculator.Interfaces
{
    public interface IUserInterface
    {
        string ChooseMenuVariant();

        string InputExpression();

        string InputFilePath();
    }
}
