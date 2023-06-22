using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IMenu, Menu>();
            services.AddTransient<ICalculatingResultsWriter, CalculatingResultsWriter>();
            services.AddTransient<IOperationCalculator, OperationCalculator>();
            services.AddTransient<IExpressionChecker, ExpressionChecker>();
            services.AddTransient<ICalculatorParser, CalculatorParser>();
            services.AddTransient<ICalculateProcessor, CalculatorProcessor>();
            services.AddTransient<ICalculator, Calculator>();
            services.AddTransient<IUserInterface, UserInterface>();
            services.AddTransient<IInputChecker, InputChecker>();

            return services;
        }
    }
}
