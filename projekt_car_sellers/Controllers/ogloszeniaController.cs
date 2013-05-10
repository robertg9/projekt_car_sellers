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
            //regionContext ogloszeniaCont = new regionContext();
            //ogloszeniaContext ogloszeniaCont = new ogloszeniaContext();
            //markiContext markiCont = new markiContext();
            //ogloszeniaContext ogloszeniaCont = new ogloszeniaContext();

            //ViewBag.ogloszenia = ogloszeniaCont;

            //ViewBag.marki = markiCont.markiDb.ToList();
            //var ogloszenia = ogloszeniaCont.ogloszeniaDb.ToList();

            //ViewBag.ogloszenia = ogloszeniaCont.ogloszeniaDb.ToList();
           
            //var model = ogloszeniaCont.regionDb.ToList();

            var viewModel = new all_models();
            ViewBag.ogloszenia = viewModel.wszystkie_ogloszenia;
            ViewBag.marki = viewModel.wszystkie_marki;

            return View();
        }

    }
}
