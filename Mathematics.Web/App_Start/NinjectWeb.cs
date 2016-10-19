//-----------------------------------------------------------------------
// <copyright file="NinjectWeb.cs" company="Business Management System Ltd.">
//     Copyright 2016 (c) Business Management System Ltd.. All rights reserved.
// </copyright>
// <author>Nikolay.Kostadinov</author>
//-----------------------------------------------------------------------
    /// <summary>
    /// Summary description for $classname$
    /// </summary>

using Mathematics.Web.App_start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWeb), "Start")]
namespace Mathematics.Web.App_start
{
        using Microsoft.Web.Infrastructure.DynamicModuleHelper;

        using Ninject.Web;
        using Ninject.Web.Common;

        public static class NinjectWeb
        {
            /// <summary>
            /// Starts the application
            /// </summary>
            public static void Start()
            {
                DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            }
        }
    }