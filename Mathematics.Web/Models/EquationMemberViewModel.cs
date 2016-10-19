//-----------------------------------------------------------------------
// <copyright file="EquationMemberViewModel.cs" company="Business Management System Ltd.">
//     Copyright 2016 (c) Business Management System Ltd.. All rights reserved.
// </copyright>
// <author>Nikolay.Kostadinov</author>
//-----------------------------------------------------------------------
namespace Mathematics.Web.Models
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Application.Models;
    using Infrastructure.Mapping;

    #endregion

    /// <summary>
    /// Summary description for $classname$
    /// </summary>
    public class EquationMemberViewModel:IMapFrom<EquationMember>
    {
        public int Value { get; set; }
        public Operations Operation { get; set; }
    }
}