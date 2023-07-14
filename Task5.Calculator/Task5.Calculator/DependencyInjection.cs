using Microsoft.Extensions.DependencyInjection;
using Task5.Calculator.Interfaces;

namespace Task5.Calculator
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<CalculatorAdapter>();
            services.AddTransient<ICalculator, Calculator>();
            services.AddTransient<ICalculatingResultsWriter, CalculatingResultsWriter>();
            services.AddTransient<IExpressionChecker, ExpressionChecker>();
            services.AddTransient<IUserInterface, UserInterface>();
            services.AddTransient<IInputChecker, InputChecker>();
            services.AddTransient<ICalculateProcessor, CalculatorProccesor>();

            return services;
        }
    }
}
