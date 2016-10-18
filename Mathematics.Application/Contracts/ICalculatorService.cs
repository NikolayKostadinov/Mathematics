//-----------------------------------------------------------------------
// <copyright file="ICalculatorService.cs" company="Business Management System Ltd.">
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

    #endregion

    /// <summary>
    /// Summary description for ICalculatorService
    /// </summary>
    public interface ICalculatorService
    {
        /// <summary>
        /// Calculates the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="expressionArgumentName">Name of the expression argument.</param>
        /// <param name="argumentsCount">The arguments count.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        Tout Calculate<Tin,Tout>(string expression, string expressionArgumentName, int argumentsCount, Dictionary<string, Tin> arguments=null);
    }
}
