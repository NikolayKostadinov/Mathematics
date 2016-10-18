using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Application.Contracts;
using Mathematics.Application.Models;
using Mathematics.Application.Services;
using Mathematics.Application.Services.CalculatorService;

namespace Mathematics.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EquationMember> members = new List<EquationMember>
            {
                new EquationMember(value: 1, operation: Operations.Plus),
                new EquationMember(value: 2, operation: Operations.Minus),
                new EquationMember(value: 3, operation: Operations.Plus),
                new EquationMember(value: 4, operation: Operations.Equal)
            };

            int result = 4;

            var eq = new Equation(members, result);
            ICalculatorService service = new CalculatorService();
            var evaluated = service.Calculate<int, bool>(eq.ToEvaluatableString(), "p", 0);
            Console.WriteLine($"Result from evaluation of {eq.ToEvaluatableString()} is {evaluated}");
            Console.WriteLine($"Equation is {eq}");
            Console.WriteLine($"The Unknown is {eq.GetUnknown()}");

            for (int i = 0; i < 20; i++)
            {
                var cs = new EquationGeneratorService(RandomGenerator.GetRandomGenerator, new CalculatorService());
                eq = cs.GetEquation(RandomGenerator.GetRandomGenerator.Next(2,3),1,5,UnknownType.Value);
                Console.WriteLine($"{eq}\n{eq.ToEvaluatableString()}\nUnknown is: {eq.GetUnknown()}\n");
            }
        }
    }
}