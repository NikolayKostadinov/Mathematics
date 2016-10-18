using ExpressionEvaluator;

namespace Mathematics.Application.Services.CalculatorService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CollectingProductionDataSystem.Application.CalculatorService;
    using Mathematics.Application.Contracts;


    public class CalculatorService : ICalculatorService
    {

        /// <summary>
        /// Calculates the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="expressionArgumentName">Name of the expression argument.</param>
        /// <param name="argumentsCount">The arguments count.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        public Tout Calculate<Tin, Tout>(string expression, string expressionArgumentName, int argumentsCount, Dictionary<string, Tin> arguments = null)
        {
            if (argumentsCount != ((arguments?.Count) ?? 0))
            {
                string message = $"Invalid arguments count. Expected {argumentsCount} actual {arguments?.Count}";
                throw new ArgumentException(message);
            }

            var inputObject = (arguments == null) ? new object() : ObjectBuilder.CreateObject(arguments);
            var reg = new TypeRegistry();
            reg.RegisterType(expressionArgumentName + "s", inputObject.GetType());
            reg.RegisterSymbol(expressionArgumentName, inputObject);
            reg.RegisterType(nameof(DateTime), typeof(DateTime));
            reg.RegisterType(nameof(Math), typeof(Math));
            reg.RegisterType(nameof(Convert), typeof(Convert));
            var p = new CompiledExpression(expression) { TypeRegistry = reg };
            return (Tout) p.Eval();
        }
    }
}
