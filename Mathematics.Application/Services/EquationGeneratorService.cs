//-----------------------------------------------------------------------
// <copyright file="EquationGeneratorService.cs" company="Business Management System Ltd.">
//     Copyright 2016 (c) Business Management System Ltd.. All rights reserved.
// </copyright>
// <author>Nikolay.Kostadinov</author>
//-----------------------------------------------------------------------
namespace Mathematics.Application.Services
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Models;

    #endregion

    /// <summary>
    /// Summary description for EquationGeneratorService
    /// </summary>
    public class EquationGeneratorService : IEquationGeneratorService
    {
        private readonly IRandomGenerator random;
        private readonly ICalculatorService calculator;

        public EquationGeneratorService(IRandomGenerator randomGenerator, ICalculatorService calculator)
        {
            this.random = randomGenerator;
            this.calculator = calculator;
        }

        public Equation GetEquation(int numberOfMembers, int minDigit = 0, int maxDigit = int.MaxValue, UnknownType equationType = UnknownType.Result)
        {
            var members = new List<EquationMember>();
            int nextMaxNumber = maxDigit;
            int result = this.random.Next(minDigit, maxNumber: maxDigit);
            var operations = Enum.GetValues(typeof(Operations)).OfType<Operations>().ToArray();
            for (int i = 0; i < numberOfMembers; i++)
            {
                EquationMember member;

                if (i < numberOfMembers - 1)
                {
                    member = new EquationMember(this.random.Next(minDigit, maxNumber: nextMaxNumber), operations[this.random.Next(0, 1)]);
                    members.Add(member);
                    nextMaxNumber = this.GetMax(maxDigit, member?.Value ?? 0, member?.Operation ?? Operations.Equal);
                }
                else
                {
                    if (equationType == UnknownType.Result || equationType == UnknownType.Value)
                    {
                        var tmrEq = new Equation(members, 0);
                        var calculatedValue = this.calculator.Calculate<int, int>(tmrEq.ToEvaluatableMembers(),
                            string.Empty, 0);
                        //Debug.WriteLine($"{tmrEq}");
                        if (calculatedValue >= maxDigit)
                        {
                            members[i - 1] = new EquationMember(members[i - 1].Value, Operations.Minus);
                            int lastValue = this.random.Next(calculatedValue - maxDigit, maxDigit);
                            member = new EquationMember(lastValue, Operations.Equal);
                        }
                        else
                        {
                            int lastValue = this.random.Next(maxNumber: nextMaxNumber);
                            member = new EquationMember(lastValue, Operations.Equal);
                        }

                        members.Add(member);
                        tmrEq = new Equation(members, 0);
                        result = this.calculator.Calculate<int, int>(tmrEq.ToEvaluatableMembers(),
                            string.Empty, 0);
                    }
                    else
                    {
                        int value = this.random.Next(minDigit, maxNumber: nextMaxNumber);
                        members.Add(new EquationMember(value, Operations.Equal));
                        var tmrEq = new Equation(members, 0);
                        var calculatedValue = this.calculator.Calculate<int, int>(tmrEq.ToEvaluatableMembers(),
                            string.Empty, 0);
                        var lastOperation = operations[calculatedValue.CompareTo(result) + 3];
                        members[i] = new EquationMember(value, lastOperation);
                    }
                }
            }

            var generategEq = this.GetResult(equationType, members, result);
            //Debug.WriteLine(generategEq.ToEvaluatableString());
            return generategEq;

        }

        private Equation GetResult(UnknownType equationType, List<EquationMember> members, int result)
        {
            int numberOfMembers = members.Count;

            switch (equationType)
            {
                case UnknownType.Value:
                    return new Equation(members, result, random.Next(maxNumber: numberOfMembers - 1), equationType);
                case UnknownType.Operation:
                    return new Equation(members, result, numberOfMembers - 1, equationType);
                case UnknownType.Result:
                    return new Equation(members, result, unknownType: equationType);
                default:
                    return new Equation(members, result, random.Next(maxNumber: numberOfMembers - 1),
                        (UnknownType) this.random.Next(maxNumber: 1));
            }
        }

        private int GetMax(int maxDigit, int lastValue, Operations lastOperation)
        {
            int nextMaxNumber;

            if (lastOperation == Operations.Minus)
            {
                nextMaxNumber = (lastValue == 0) ? 0 : lastValue - 1;
            }
            else if (lastOperation == Operations.Plus)
            {
                nextMaxNumber = maxDigit - lastValue;
            }
            else
            {
                nextMaxNumber = maxDigit;
            }

            return nextMaxNumber;
        }
    }
}
