//-----------------------------------------------------------------------
// <copyright file="IRandomGenerator.cs" company="Business Management System Ltd.">
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
    /// Summary description for IRandomGenerator
    /// </summary>
    public interface IRandomGenerator
    {
        int Next(int minNumber = 0, int maxNumber = int.MaxValue);
    }
}
