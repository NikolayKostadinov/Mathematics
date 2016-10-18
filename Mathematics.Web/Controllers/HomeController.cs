using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mathematics.Web.Controllers
{
    using Application.Contracts;
    using AutoMapper;
    using Models;

    public class HomeController : Controller
    {
        private readonly IEquationGeneratorService service;

        public HomeController(IEquationGeneratorService serviceParam)
        {
            this.service = serviceParam;
        }

        public ActionResult Index()
        {
            var model = new List<EquationViewModel>();
            for (int i = 0; i < 10; i++)
            {
                model.Add(Mapper.Map<EquationViewModel>(this.service.GetEquation(3,0,5)));
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}