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
            markiContext db = new markiContext();
            var marka = new model();
            /*
            db.markiDb.First();
            using (var marki = new markiContext())
            {
                var nazwa = "";
                foreach (var blog in marki.markiDb)
                {
                    nazwa = blog.nazwa;
                }
            }
          
            int id_marka = 0;
            markiContext markiCont = new markiContext();

            var marki = markiCont.markiDb.Where(x => x.nazwa == "BMW").First();
            id_marka = marki.id;
             */
            return View();
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
