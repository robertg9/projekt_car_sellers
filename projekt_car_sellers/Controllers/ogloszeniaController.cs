using projekt_car_sellers.Models;
using projekt_car_sellers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using projekt_car_sellers.App_Start;
using WebMatrix.WebData;
using System.Data;

namespace projekt_car_sellers.Controllers
{
    public class ogloszeniaController : Controller
    {
        //
        // GET: /ogloszenia/

        public ActionResult Index(int strona = 1, int marka = 0, int model = 0)
        {
            int userid = (int)WebSecurity.CurrentUserId;
            ViewBag.userId = userid;
            ViewBag.model = model;
            ViewBag.marka = marka;
            ViewBag.strona = strona;
            strona = (strona - 1) * 5;
            var viewModel = new all_models();

            if (marka == 0)
            {
                ViewBag.markiModelNazwa = "Brand";
                ViewBag.markiModel = viewModel.wszystkie_marki;
            }
            else
            {
                ViewBag.markiModelNazwa = "Model";
                ViewBag.markiModel = viewModel.modelDb.Where(m => m.FK_marka == marka).ToList();
            }
            if (marka == 0)
            {
                var ilosc = (from o in viewModel.ogloszeniaDb
                             join z in viewModel.zdjeciaDb on o.id equals z.FK_ogloszenia

                             select new ogloszenieZdjecia(){});

                var query = (from o in viewModel.ogloszeniaDb
                             join z in viewModel.zdjeciaDb on o.id equals z.FK_ogloszenia

                             select new ogloszenieZdjecia()
                             {
                                 id = o.id,
                                 tytul = o.tytul,
                                 url = z.url,
                                 rocznik = o.rocznik,
                                 przebieg = o.przebieg,
                                 pojemnoscSilnika = o.pojemnoscSilnika,
                                 rodzajPaliwa = o.rodzajPaliwa,
                                 typNadwozia = o.typNadwozia,
                                 cena = o.cena,
                                 FK_uzytkownik = o.FK_uzytkownik
                             }).OrderByDescending(o => o.id).Skip(strona).Take(5).ToList();

                int iloscStron = ilosc.Count() / 5;
                if ((ilosc.Count() % 5) != 0)
                {
                    iloscStron = iloscStron + 1;
                }

                ViewBag.iloscStron = iloscStron;

                return View(query);
            }
            else if (marka > 0)
            {
                if (model > 0)
                {
                    var ilosc_model = (from o in viewModel.ogloszeniaDb
                                 join z in viewModel.zdjeciaDb on o.id equals z.FK_ogloszenia
                                 where o.FK_model == model
                                 select new ogloszenieZdjecia() { });

                    var query_model = (from o in viewModel.ogloszeniaDb
                                 join z in viewModel.zdjeciaDb on o.id equals z.FK_ogloszenia
                                 where o.FK_model == model
                                 select new ogloszenieZdjecia()
                                 {
                                     id = o.id,
                                     tytul = o.tytul,
                                     url = z.url,
                                     rocznik = o.rocznik,
                                     przebieg = o.przebieg,
                                     pojemnoscSilnika = o.pojemnoscSilnika,
                                     rodzajPaliwa = o.rodzajPaliwa,
                                     typNadwozia = o.typNadwozia,
                                     cena = o.cena,
                                     FK_uzytkownik = o.FK_uzytkownik
                                 }).OrderByDescending(o => o.id).Skip(strona).Take(5).ToList();

                    int iloscStron_model = ilosc_model.Count() / 5;
                    if ((ilosc_model.Count() % 5) != 0)
                    {
                        iloscStron_model = iloscStron_model + 1;
                    }

                    ViewBag.iloscStron = iloscStron_model;

                    return View(query_model);
                }
                var modele = viewModel.modelDb.Where(m => m.FK_marka == marka);

                var ilosc = (from o in viewModel.ogloszeniaDb
                             join m in modele on o.FK_model equals m.id
                             join z in viewModel.zdjeciaDb on o.id equals z.FK_ogloszenia
                             select new ogloszenieZdjecia() { });

                var query = (from o in viewModel.ogloszeniaDb
                             join m in modele on o.FK_model equals m.id
                             join z in viewModel.zdjeciaDb on o.id equals z.FK_ogloszenia
                             select new ogloszenieZdjecia()
                             {
                                 id = o.id,
                                 tytul = o.tytul,
                                 url = z.url,
                                 rocznik = o.rocznik,
                                 przebieg = o.przebieg,
                                 pojemnoscSilnika = o.pojemnoscSilnika,
                                 rodzajPaliwa = o.rodzajPaliwa,
                                 typNadwozia = o.typNadwozia,
                                 cena = o.cena,
                                 FK_uzytkownik = o.FK_uzytkownik
                             }).OrderByDescending(o => o.id).Skip(strona).Take(5).ToList();

                int iloscStron = ilosc.Count() / 5;
                if ((ilosc.Count() % 5) != 0)
                {
                    iloscStron = iloscStron + 1;
                }

                ViewBag.iloscStron = iloscStron;
                return View(query);

            }


            return View();

        }

        // GET: /ogloszenia/podglad/

        public ActionResult podglad(int id = 1)
        {
            var viewModel = new all_models();
            var dane_ogloszenie = viewModel.ogloszeniaDb.Where(o => o.id == id).First();
            var zdjecie_glowne = viewModel.zdjeciaDb.Where(z => z.FK_ogloszenia == id).First();
            var model = viewModel.modelDb.Where(m => m.id == dane_ogloszenie.FK_model).First();
            var marka = viewModel.markiDb.Where(mr => mr.id == model.FK_marka).First();
            var lokalizacja = viewModel.lokalizacjaDb.Where(l => l.id == dane_ogloszenie.FK_lokalizacja).First();
            var region = viewModel.regionDb.Where(r => r.id == lokalizacja.FK_region).First();

            ViewBag.zdjecie_glowne = zdjecie_glowne;
            ViewBag.model = model;
            ViewBag.marka = marka;
            ViewBag.lokalizacja = lokalizacja;
            ViewBag.region = region;

            return View(dane_ogloszenie);
        }

        // GET: /ogloszenia/dodaj/
        [Authorize]
        public ActionResult dodaj(int id = 0)
        {
            var viewModel = new all_models();

            if (id > 0)
            {
                var ogloszenie = viewModel.ogloszeniaDb.Find(id);
                ViewBag.ogloszenie = ogloszenie;
                var zdjecie = viewModel.zdjeciaDb.Where(z => z.FK_ogloszenia == id).First();
                ViewBag.zdjecie = zdjecie;
            }
            else
            {
                ogloszenia ogloszenie = new ogloszenia
                {
                    opis = "",
                    tytul = "",
                    rocznik = 0,
                    przebieg = 0,
                    cena = 0,
                    mocSilnika = 0,
                    pojemnoscSilnika = 0,
                    rodzajPaliwa = "",
                    typNadwozia = ""
                };
                ViewBag.ogloszenie = ogloszenie;
                var zdjecie = new zdjecia { url = "" };
                ViewBag.zdjecie = zdjecie;
            } 

            var query = (from md in viewModel.modelDb
                         join mr in viewModel.markiDb on md.FK_marka equals mr.id
                         select new MarkaModel()
                         {
                             id_model = md.id,
                             nazwa_marka = mr.nazwa,
                             nazwa_model = md.nazwa
                         }).ToList();

            var lokal = viewModel.lokalizacjaDb.ToList();

            ViewBag.lokalizacja = lokal;

            ViewBag.model = query;


            return View();
        }

        // GET: /ogloszenia/zapisz/
        [Authorize]
        public void zapisz(string tytul , string opis, int rocznik, int przebieg, decimal cena, int mocSilnika,
            int pojemnoscSilnika, string rodzajPaliwa, string typNadwozia, string url, int FK_model, int FK_lokalizacja)
        {
            var viewModel = new all_models();

            int userid = (int)WebSecurity.CurrentUserId;
            ogloszenia nowe_ogloszenie = new ogloszenia { 
                tytul = tytul,
                opis = opis,
                rocznik = rocznik,
                przebieg = przebieg,
                cena = cena,
                mocSilnika = mocSilnika,
                pojemnoscSilnika = pojemnoscSilnika,
                rodzajPaliwa = rodzajPaliwa,
                typNadwozia = typNadwozia,
                FK_model = FK_model,
                FK_lokalizacja = FK_lokalizacja,
                FK_uzytkownik = userid
            };

            viewModel.ogloszeniaDb.Add(nowe_ogloszenie);

            new ogloszeniaContext().SaveChanges();
            viewModel.SaveChanges();

            zdjecia zdj = new zdjecia { url = url, FK_ogloszenia = nowe_ogloszenie.id };

            viewModel.zdjeciaDb.Add(zdj);
            new zdjeciaContext().SaveChanges();
            viewModel.SaveChanges();      

            Response.Redirect("/ogloszenia/");
        }

        [Authorize]
        public void usun(int id)
        {
            var viewModel = new all_models();
            var ogloszenie = viewModel.ogloszeniaDb.Find(id);
            viewModel.ogloszeniaDb.Remove(ogloszenie);

            viewModel.SaveChanges();
            Response.Redirect("/ogloszenia/");
        }

    }

}

