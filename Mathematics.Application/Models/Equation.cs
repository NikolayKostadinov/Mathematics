//-----------------------------------------------------------------------
// <copyright file="Equation.cs" company="Business Management System Ltd.">
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
    using System.Web.WebSockets;

    #endregion

    /// <summary>
    /// Summary description for Equation
    /// </summary>
    public class Equation
    {
        private readonly List<EquationMember> members;
        private readonly int result;
        private readonly int unknownPosition;
        private readonly UnknownType? unknownType;

        public Equation(IEnumerable<EquationMember> members, int result, int unknownPosition = 0,
            UnknownType? unknownType = null)
        {
            this.members = members.ToList();
            this.result = result;
            this.unknownPosition = unknownPosition;
            this.unknownType = unknownType;
        }

        public List<EquationMember> Members {
            get
            {
                var clonedMembers = new List<EquationMember>();
                foreach (var member in this.members)
                {
                    clonedMembers.Add(member.Clone());
                }
                return clonedMembers;
            }
        }

        public int Result {get { return this.result;}}
        public int UnknownPosition{ get { return this.unknownPosition; } }
        public UnknownType? UnknownTypeProp { get { return this.unknownType; } }

        public override string ToString()
        {
            var stringified = new StringBuilder();

            for (int i = 0; i < this.members.Count; i++)
            {
                if (unknownType != UnknownType.Result && i == unknownPosition)
                {
                    stringified.Append(this.unknownType == UnknownType.Value ? "?" : this.members[i].Value.ToString());
                    stringified.Append(this.unknownType == UnknownType.Operation ? '?' : Convert.ToChar(this.members[i].Operation));
                }
                else
                {
                    stringified.Append(this.members[i].Value);
                    stringified.Append(Convert.ToChar(this.members[i].Operation));
                }
            }

            stringified.Append(this.unknownType == UnknownType.Result ? "?" : this.result.ToString());

            return stringified.ToString();
        }

        public string ToEvaluatableString()
        {
            var stringified = new StringBuilder();

            foreach (var member in members)
            {
                stringified.Append(member.Value);
                string op = Convert.ToChar(member.Operation).ToString();
                if (op == "=")
                {
                    op = "==";
                }
                stringified.Append(op);
            }

            stringified.Append(this.result.ToString());
            return stringified.ToString();
        }

        public string ToEvaluatableMembers()
        {
            var stringified = new StringBuilder();
            int id = 0;
            foreach (var member in members)
            {
                stringified.Append(member.Value);
                string op = Convert.ToChar(member.Operation).ToString();
                if (id < members.Count-1)
                {
                    stringified.Append(op);
                }

                id++;
            }

            return stringified.ToString();
        }

        public string GetUnknown()
        {
            if (unknownType == null)
            {
                return this.result.ToString();
            }
            else
            {
                if (this.unknownType == UnknownType.Operation)
                {
                    return Convert.ToChar(members[this.unknownPosition].Operation).ToString();
                }
                else
                {
                    return members[this.unknownPosition].Value.ToString();
                }
            }
        }
    }
}
