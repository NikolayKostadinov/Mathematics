//-----------------------------------------------------------------------
// <copyright file="RandomGenerator.cs" company="Business Management System Ltd.">
//     Copyright 2016 (c) Business Management System Ltd.. All rights reserved.
// </copyright>
// <author>Nikolay.Kostadinov</author>
//-----------------------------------------------------------------------

using System.Data.SqlTypes;
using Mathematics.Application.Contracts;

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
    /// Singleton RandomGenerator
    /// </summary>
    public class RandomGenerator : IRandomGenerator
    {
        private static readonly object lockObj = new object();
        [ThreadStatic]
        private static Random random;
        private static RandomGenerator generator;

        private RandomGenerator()
        {
            random = new Random();
        }

        public static RandomGenerator GetRandomGenerator
        {
            get
            {
                if (generator == null)
                {
                    lock (lockObj)
                    {
                        if (generator == null)
                        {
                            generator = new RandomGenerator();
                        }
                    }
                }

                return generator;
            }
        }

        public int Next(int minNumber = 0, int maxNumber = int.MaxValue) => random.Next(minNumber, maxNumber+1);
    }
}
