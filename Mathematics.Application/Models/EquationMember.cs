//-----------------------------------------------------------------------
// <copyright file="EquationMember.cs" company="Business Management System Ltd.">
//     Copyright 2016 (c) Business Management System Ltd.. All rights reserved.
// </copyright>
// <author>Nikolay.Kostadinov</author>
//-----------------------------------------------------------------------

namespace Mathematics.Application.Models
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// Summary description for EquationMember
    /// </summary>
    public class EquationMember
    {
        public EquationMember(int value, Operations operation)
        {
            this.Value = value;
            this.Operation = operation;
        }

        public int Value { get; }
        public Operations Operation { get; }
        public EquationMember Clone()
        {
            return new EquationMember(this.Value, this.Operation);
        }
    }
}
