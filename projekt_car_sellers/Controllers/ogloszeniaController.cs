using projekt_car_sellers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_car_sellers.Controllers
{
    public class ogloszeniaController : Controller
    {
        //
        // GET: /ogloszenia/

        public ActionResult Index()
        {
            markiContext markiCont = new markiContext();

            var marki = markiCont.markiDb.ToList();

            return View(marki);
        }

    }
}
