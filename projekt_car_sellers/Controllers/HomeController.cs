using projekt_car_sellers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace projekt_car_sellers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var viewModel = new all_models();

            ViewBag.marki = viewModel.wszystkie_marki;

            var query = (from o in viewModel.ogloszeniaDb
                        join z in viewModel.zdjeciaDb on o.id equals z.id
                        select new ogloszenieZdjecia()
                        {
                            id = o.id,
                            tytul = o.tytul,
                            url = z.url,
                            rocznik = o.rocznik,
                            przebieg = o.przebieg,
                            pojemnoscSilnika = o.pojemnoscSilnika,
                            rodzajPaliwa = o.rodzajPaliwa
                        }).Take(2).ToList();
            return View(query);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
