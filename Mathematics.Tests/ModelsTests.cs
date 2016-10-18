using System;
using System.Collections.Generic;
using Mathematics.Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mathematics.Tests
{
    [TestClass]
    public class ModelsTests
    {
        private char fromOperation(Operations operation)
        {
            switch (operation)
            {
                case Operations.Equal:
                    return '=';
                case Operations.GreaterThan:
                    return '>';
                case Operations.LessThan:
                    return '<';
                case Operations.Minus:
                    return '-';
                case Operations.Plus:
                    return '+';
                default:
                    return '?';
            }
        }

        [TestMethod]
        public void OperationSignsAreCorrect()
        {
            //Arrange
            var operations = Enum.GetValues(typeof(Operations));
            Dictionary<Operations, char> results = new Dictionary<Operations, char>();

            //Act
            foreach (Operations operation in operations)
            {
                results.Add(operation, Convert.ToChar((int) operation));
            }

            //Assert
            foreach (var result in results)
            {
                char expected = fromOperation(result.Key);
                Assert.AreEqual(expected, result.Value, $"Expected operation sign is {expected} but actually it is {result.Value}!");
            }
        }

        [TestMethod]
        public void EcuationToStringIsCorrect()
        {
            //Arrange
            List<EquationMember> members = new List<EquationMember>
            {
                new EquationMember(value: 1, operation: Operations.Plus),
                new EquationMember(value: 2, operation: Operations.Minus),
                new EquationMember(value: 3, operation: Operations.Plus),
                new EquationMember(value: 4, operation: Operations.Equal)
            };

            int result = 4;

            //Act
            var eq = new Equation(members, result);
            Assert.AreEqual("1+2-3+4=?", eq.ToString(), $"Result must be 1+2-3+4=? but actual is {eq}");

            eq = new Equation(members, result, 0, UnknownType.Value);
            Assert.AreEqual("?+2-3+4=4", eq.ToString(), $"Result must be ?+2-3+4=4 but actual is {eq}");

            eq = new Equation(members, result, 0, UnknownType.Operation);
            Assert.AreEqual("1?2-3+4=4", eq.ToString(), $"Result must be 1?2-3+4=4 but actual is {eq}");

            eq = new Equation(members, result, 1, UnknownType.Value);
            Assert.AreEqual("1+?-3+4=4", eq.ToString(), $"Result must be 1+?-3+4=4 but actual is {eq}");

            eq = new Equation(members, result, 1, UnknownType.Operation);
            Assert.AreEqual("1+2?3+4=4", eq.ToString(), $"Result must be 1+2?3+4=4 but actual is {eq}");

            eq = new Equation(members, result, 2, UnknownType.Value);
            Assert.AreEqual("1+2-?+4=4", eq.ToString(), $"Result must be 1+2-?+4=4 but actual is {eq}");

            eq = new Equation(members, result, 2, UnknownType.Operation);
            Assert.AreEqual("1+2-3?4=4", eq.ToString(), $"Result must be 1+2-3?4=4 but actual is {eq}");


            eq = new Equation(members, result, 3, UnknownType.Value);
            Assert.AreEqual("1+2-3+?=4", eq.ToString(), $"Result must be 1+2-3+?=4 but actual is {eq}");

            eq = new Equation(members, result, 3, UnknownType.Operation);
            Assert.AreEqual("1+2-3+4?4", eq.ToString(), $"Result must be 1+2-3+4?4 but actual is {eq}");

        }
    }
}
