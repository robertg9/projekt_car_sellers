namespace projekt_car_sellers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using projekt_car_sellers.Migrations;
    using projekt_car_sellers.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<projekt_car_sellers.Models.modelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(projekt_car_sellers.Models.modelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            seed_marki();
            seed_model();

            seed_region();
            seed_lokalizacja();

            seed_ogloszenia();

        }

        private void seed_model()
        {
            System.Data.Entity.Database.SetInitializer<projekt_car_sellers.Models.modelContext>(null);
            modelContext modelCont = new modelContext();

            int id_bmw = pobierz_id_marki("BMW");
            int id_audi = pobierz_id_marki("Audi");
            int id_alfa_romeo = pobierz_id_marki("Alfa Romeo");
            int id_fiat = pobierz_id_marki("Fiat");
            int id_ford = pobierz_id_marki("Ford");

            model[] modele = new model[] {
                new model{ nazwa = "315", FK_marka = id_bmw},
                new model{ nazwa = "316", FK_marka = id_bmw},
                new model{ nazwa = "A4", FK_marka = id_audi},
                new model{ nazwa = "A6", FK_marka = id_audi},
                new model{ nazwa = "A1", FK_marka = id_audi},
                new model{ nazwa = "A3", FK_marka = id_audi},
                new model{ nazwa = "147", FK_marka = id_alfa_romeo},
                new model{ nazwa = "159", FK_marka = id_alfa_romeo},
                new model{ nazwa = "Doblo", FK_marka = id_fiat},
                new model{ nazwa = "Ducato", FK_marka = id_fiat},
                new model{ nazwa = "Escort", FK_marka = id_ford},
                new model{ nazwa = "Escape", FK_marka = id_ford},
            };
            modelCont.modelDb.AddOrUpdate(m => m.nazwa, modele);

            modelCont.SaveChanges();
        }

        private int pobierz_id_marki(string nazwa_marki)
        {
            int id_marka = 0;
            markiContext markiCont = new markiContext();

            var marki = markiCont.markiDb.Where(x => x.nazwa == nazwa_marki).First();
            id_marka = marki.id;
            return id_marka;
        }

        private void seed_marki() {
            System.Data.Entity.Database.SetInitializer<projekt_car_sellers.Models.markiContext>(null);

            markiContext markiCont = new markiContext();

            marki[] wszystkie_marki = new marki[] {
                new marki{ nazwa = "BMW"},
                new marki{ nazwa = "Audi"},
                new marki{ nazwa = "Alfa Romeo"},
                new marki{ nazwa = "Fiat"},
                new marki{ nazwa = "Ford"},
                new marki{ nazwa = "Honda"},
                new marki{ nazwa = "Kia"},
                new marki{ nazwa = "Mazda"},
                new marki{ nazwa = "Nissan"},
                new marki{ nazwa = "Mitsubishi"},
                new marki{ nazwa = "Renault"},
                new marki{ nazwa = "Suzuki"},
                new marki{ nazwa = "Toyota"},
                new marki{ nazwa = "Volkswagen"},
            };

            markiCont.markiDb.AddOrUpdate(m => m.nazwa, wszystkie_marki);

            markiCont.SaveChanges();
        }

        private void seed_ogloszenia() {
            System.Data.Entity.Database.SetInitializer<projekt_car_sellers.Models.ogloszeniaContext>(null);

            ogloszeniaContext markiCont = new ogloszeniaContext();

            int id_lokalizacja_gdynia = pobierz_id_lokalizacja("Gdynia");
            int id_model_audi = pobierz_id_model("A4");
            int id_uztkownik = pobierz_id_uzytkownik("robertg9");
            ogloszenia[] ogloszenia_wszystkie = new ogloszenia[] {
                new ogloszenia {
                    id = 1, 
                    cena = 3000, 
                    FK_lokalizacja = id_lokalizacja_gdynia,
                    FK_model = id_model_audi,
                    FK_uzytkownik = id_uztkownik,
                    opis = "Mam do sprzedania Audi A4 w bardzo dobrym stanie Proszê o kontakt telefoniczny",
                    tytul = "Sprzedam Audi A4 stan bardzo dobry Cena do negocjacji !!!",
                    rocznik = 2002,
                    przebieg = 198000,
                    mocSilnika = 999,
                    pojemnoscSilnika = 1800,
                    rodzajPaliwa = "gaz,benzyna",
                    typNadwozia = "kombi",
                },
                 new ogloszenia {
                    id = 2, 
                    cena = 6000, 
                    FK_lokalizacja = id_lokalizacja_gdynia,
                    FK_model = id_model_audi,
                    FK_uzytkownik = id_uztkownik,
                    opis = "Mam do sprzedania Audi A4 w idealnym stanie Proszê o kontakt telefoniczny",
                    tytul = "Sprzedam prawie nowe Audi A4",
                    rocznik = 2012,
                    przebieg = 10000,
                    mocSilnika = 1999,
                    pojemnoscSilnika = 2200,
                    rodzajPaliwa = "gaz,benzyna",
                    typNadwozia = "heatchback",
                },
            };

            markiCont.ogloszeniaDb.AddOrUpdate(ogloszenia_wszystkie);

            markiCont.SaveChanges();
        }

        private void seed_region()
        {
            System.Data.Entity.Database.SetInitializer<projekt_car_sellers.Models.regionContext>(null);

            regionContext regionCont = new regionContext();

            region[] region_wszystkie = new region[] {
                new region{ id = 1, nazwa = "warmiñsko-mazurskie"},
                new region{ id = 1, nazwa = "pomorskie"},
                new region{ id = 1, nazwa = "mazowieckie"},
            };

            regionCont.regionDb.AddOrUpdate(r => r.nazwa, region_wszystkie);

            regionCont.SaveChanges();
        }

        private void seed_lokalizacja()
        {
            System.Data.Entity.Database.SetInitializer<projekt_car_sellers.Models.lokalizacjaContext>(null);

            lokalizacjaContext lokalizacjaCont = new lokalizacjaContext();

            int id_region = pobierz_id_region("pomorskie");
            lokalizacja[] lokalizacja_wszystkie = new lokalizacja[] {
                new lokalizacja{ id = 1, miasto = "Gdañsk", FK_region = id_region },
                new lokalizacja{ id = 1, miasto = "Gdynia", FK_region = id_region },
                new lokalizacja{ id = 1, miasto = "Sopot", FK_region = id_region },
            };

            lokalizacjaCont.lokalizacjaDb.AddOrUpdate(l => l.miasto, lokalizacja_wszystkie);

            lokalizacjaCont.SaveChanges();
        }

        private int pobierz_id_region(string nazwa)
        {
            int id_region = 0;
            regionContext regionCont = new regionContext();

            var region = regionCont.regionDb.Where(x => x.nazwa == nazwa).First();
            id_region = region.id;
            return id_region;
        }

        private int pobierz_id_uzytkownik(string nazwa)
        {
            System.Data.Entity.Database.SetInitializer<projekt_car_sellers.Models.UsersContext>(null);
            int id_uzytkownik = 0;
            UsersContext uzytkownikContext = new UsersContext();

            var uzytkownik = uzytkownikContext.UserProfiles.Where(x => x.UserName == nazwa).First();
            id_uzytkownik = uzytkownik.UserId;
            return id_uzytkownik;
        }

        private int pobierz_id_lokalizacja(string nazwa)
        {
            int id_lokalizacja = 0;
            lokalizacjaContext lokalizacjaCont = new lokalizacjaContext();

            var lokalizacja = lokalizacjaCont.lokalizacjaDb.Where(x => x.miasto == nazwa).First();
            id_lokalizacja = lokalizacja.id;
            return id_lokalizacja;
        }

        private int pobierz_id_model(string nazwa_marki)
        {
            int id_model = 0;
            modelContext modelCont = new modelContext();

            var model = modelCont.modelDb.Where(x => x.nazwa == nazwa_marki).First();
            id_model = model.id;
            return id_model;
        }
    }
}
