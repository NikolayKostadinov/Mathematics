//-----------------------------------------------------------------------
// <copyright file="IEquationGeneratorService.cs" company="Business Management System Ltd.">
//     Copyright 2016 (c) Business Management System Ltd.. All rights reserved.
// </copyright>
// <author>Nikolay.Kostadinov</author>
//-----------------------------------------------------------------------
namespace Mathematics.Application.Contracts
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    #endregion

    /// <summary>
    /// Summary description for IEquationGeneratorService
    /// </summary>
    public interface IEquationGeneratorService
    {
        Equation GetEquation(int numberOfMembers, int minDigit = 0, int maxDigit = int.MaxValue, UnknownType equationType = UnknownType.Result);
    }
}
