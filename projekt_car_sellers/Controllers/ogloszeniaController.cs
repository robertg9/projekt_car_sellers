using projekt_car_sellers.Models;
using projekt_car_sellers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace projekt_car_sellers.Controllers
{
    public class ogloszeniaController : Controller
    {
        //
        // GET: /ogloszenia/

        public ActionResult Index()
        {
            var viewModel = new all_models();

            ViewBag.marki = viewModel.wszystkie_marki;

            var query = (from o in viewModel.ogloszeniaDb
                        join z in viewModel.zdjeciaDb on o.id equals z.id
                        select new ogloszenieZdjecia() { 
                            id = o.id,
                            tytul = o.tytul, 
                            url = z.url, 
                            rocznik = o.rocznik,
                            przebieg = o.przebieg,
                            pojemnoscSilnika = o.pojemnoscSilnika,
                            rodzajPaliwa = o.rodzajPaliwa,
                            typNadwozia = o.typNadwozia,
                            cena = o.cena
                        }).Take(5).ToList();
            return View(query);

        }


    }

}
