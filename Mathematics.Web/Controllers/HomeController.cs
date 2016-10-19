using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mathematics.Web.Controllers
{
    using System.Diagnostics;
    using Application.Contracts;
    using Application.Models;
    using AutoMapper;
    using Models;

    public class HomeController : Controller
    {
        private readonly IEquationGeneratorService service;
        private readonly IRandomGenerator random;

        public HomeController(IEquationGeneratorService serviceParam, IRandomGenerator randomParam)
        {
            this.service = serviceParam;
            this.random = randomParam;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<EquationViewModel>();
            for (int i = 0; i < 15; i++)
            {
                model.Add(Mapper.Map<EquationViewModel>(this.service.GetEquation(this.random.Next(2,3),0,5)));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<EquationViewModel> model)
        {
            var modelList = model.ToList();
            if (this.ModelState.IsValid)
            {
                var equations = Mapper.Map<IEnumerable<Equation>>(modelList).ToList();
                for (int i = 0; i < model.Count(); i++)
                {
                    if (equations[i].GetUnknown() != modelList[i].Answer)
                    {
                        modelList[i].IsAnsverCorrect = false;
                    }
                    else
                    {
                        modelList[i].IsAnsverCorrect = true;
                    }

                    modelList[i].CorrectAnswer = equations[i].GetUnknown();
                }
            }
            return View("IndexResult",model);
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