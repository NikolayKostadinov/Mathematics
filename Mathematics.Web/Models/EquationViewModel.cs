//-----------------------------------------------------------------------
// <copyright file="EquationViewModel.cs" company="Business Management System Ltd.">
//     Copyright 2016 (c) Business Management System Ltd.. All rights reserved.
// </copyright>
// <author>Nikolay.Kostadinov</author>
//-----------------------------------------------------------------------
namespace Mathematics.Web.Models
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Web;
    using Application.Models;
    using Infrastructure.Mapping;

    #endregion

    /// <summary>
    /// Summary description for EquationViewModel
    /// </summary>
    public class EquationViewModel:IMapFrom<Equation>
    {
        //[UIHint("ListOfEquationModels")]
        public List<EquationMemberViewModel> Members { get; set; }

        public int Result { get; set; }
        public int UnknownPosition { get; set; }
        public UnknownType? UnknownTypeProp { get; set; }

        public bool? IsAnsverCorrect { get; set; }

        public string CorrectAnswer { get; set; }

        public string Answer{ get; set; }


        public override string ToString()
        {
            var stringified = new StringBuilder();

            for (int i = 0; i < this.Members.Count; i++)
            {
                if (this.UnknownTypeProp != UnknownType.Result && i == this.UnknownPosition)
                {
                    stringified.Append(this.UnknownTypeProp == UnknownType.Value ? "?" : this.Members[i].Value.ToString());
                    stringified.Append(this.UnknownTypeProp == UnknownType.Operation ? '?' : Convert.ToChar(this.Members[i].Operation));
                }
                else
                {
                    stringified.Append(this.Members[i].Value);
                    stringified.Append(Convert.ToChar(this.Members[i].Operation));
                }
            }

            stringified.Append(this.UnknownTypeProp == UnknownType.Result ? "?" : this.Result.ToString());

            return stringified.ToString();
        }

        public string GetUnknown()
        {
            if (UnknownTypeProp == null)
            {
                return this.Result.ToString();
            }
            else
            {
                if (this.UnknownTypeProp == UnknownType.Operation)
                {
                    return Convert.ToChar(Members[this.UnknownPosition].Operation).ToString();
                }
                else
                {
                    return Members[this.UnknownPosition].Value.ToString();
                }
            }
        }
    }
}
