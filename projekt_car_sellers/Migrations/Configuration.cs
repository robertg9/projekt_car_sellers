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
            AutomaticMigrationsEnabled = false;
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
            seed_zdjecia();

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

                new marki{ nazwa = "Acura"},
                new marki{ nazwa = "GMC"},
                new marki{ nazwa = "Grecav"},
                new marki{ nazwa = "Lada"},
                new marki{ nazwa = "Lancia"},
                new marki{ nazwa = "Maserati"},
                new marki{ nazwa = "MG"},
                new marki{ nazwa = "Microcar"},
                new marki{ nazwa = "Moskowicz"},
                new marki{ nazwa = "Nysa"},
                new marki{ nazwa = "Saab"},
                new marki{ nazwa = "Saturn"},
                new marki{ nazwa = "Tolbot"},
                new marki{ nazwa = "Tech"},
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
                new ogloszenia {
                    id = 3, 
                    cena = 16000, 
                    FK_lokalizacja = id_lokalizacja_gdynia,
                    FK_model = id_model_audi,
                    FK_uzytkownik = id_uztkownik,
                    opis = "Alfa Romeo 147 2.0 T.SPARK, 150 KM, przebieg: 141 000 km wyposa¿enie – pe³ny pakiet (el. szyby, el. lusterka, klimatyzacja automatyczna dwustrefowa, wielofunkcyjna kierownica, tempomat, radio fabryczne, 8 poduszek, komputer, ASR, ESP itp., felgi aluminiowe... nie wiem co tu jeszcze napisac... :) – bez skóry, podgrzewania foteli i nawigacji; w pakiecie komplet opon zimowych na felgach stalowych auto serwisowane w autoryzowanej stacji AR – dostêpna lista napraw, przegl¹dów itp. jestem 2 w³aœcicielem, auto kupione w salonie w Polsce (posiadam wszystkie dokumenty) da³o siê bez wypadków i st³uczek samochód wymaga paru napraw lakierniczych (otarcia, zarysowania) auto zarejestrowane, ubezpieczone, mo¿na ogl¹daæ i targowaæ w Warszawie (Powiœle) po uprzednim kontakcie tel.(+48 600 22 73 73)",
                    tytul = "Alfa Romeo 147 2.0 T.S. ",
                    rocznik = 1992,
                    przebieg = 20000,
                    mocSilnika = 3999,
                    pojemnoscSilnika = 3200,
                    rodzajPaliwa = "benzyna",
                    typNadwozia = "heatchback",
                },
               new ogloszenia {
                    id = 4, 
                    cena = 26000, 
                    FK_lokalizacja = id_lokalizacja_gdynia,
                    FK_model = id_model_audi,
                    FK_uzytkownik = id_uztkownik,
                    opis = "Przedmiotem aukcji jest Mercedesa-Benz A150 benz.2005rok o mocy 95 KM i przebiegu 113,200 tyœ.km.Samochód ten zosta³ sprowadzony z Niemiec,jego stan wizualny jak i mechaniczny oceniam jako BARDZO DOBRY.Jest on op³acony i przygotowany do rejestracji. W razie szczegó³owych pytañ proszê o kontakt pod nr.tel:881-355-173",
                    tytul = "Mercedes-Benz A 150 2005r,113 tyœ,NAVI.BEZWY,OP£AC ",
                    rocznik = 1952,
                    przebieg = 25000,
                    mocSilnika = 1999,
                    pojemnoscSilnika = 3300,
                    rodzajPaliwa = "gaz",
                    typNadwozia = "kombi",
                },
                 new ogloszenia {
                    id = 5, 
                    cena = 66000, 
                    FK_lokalizacja = id_lokalizacja_gdynia,
                    FK_model = id_model_audi,
                    FK_uzytkownik = id_uztkownik,
                    opis = "4x4, el. szyby, el. lusterka, klimatyzacja, tapicerka skórzana, system nawigacji, centralny zamek, radio, wspomaganie kierownicy, komputer, tempomat, podgrzewane fotele, kierownica wielofunkcyjna",
                    tytul = "Honda CR-V GWARANCJA,EXECUTIVE,NAWIGACJA ",
                    rocznik = 1972,
                    przebieg = 15000,
                    mocSilnika = 1679,
                    pojemnoscSilnika = 2300,
                    rodzajPaliwa = "benzyna",
                    typNadwozia = "kombi",
                },
                 new ogloszenia {
                    id = 6, 
                    cena = 26000, 
                    FK_lokalizacja = id_lokalizacja_gdynia,
                    FK_model = id_model_audi,
                    FK_uzytkownik = id_uztkownik,
                    opis = "el. szyby, el. lusterka, klimatyzacja, tapicerka skórzana, system nawigacji, centralny zamek, radio, wspomaganie kierownicy, komputer, tempomat, podgrzewane fotele, czujnik deszczu, kierownica wielofunkcyjna, czujnik parkowania",
                    tytul = "Mercedes-Benz E 200 CDI AVANTGARDE 187 KM VAT 23% ",
                    rocznik = 2007,
                    przebieg = 5000,
                    mocSilnika = 2679,
                    pojemnoscSilnika = 3300,
                    rodzajPaliwa = "benzyna",
                    typNadwozia = "kombi",
                },
                 new ogloszenia {
                    id = 7, 
                    cena = 16000, 
                    FK_lokalizacja = id_lokalizacja_gdynia,
                    FK_model = id_model_audi,
                    FK_uzytkownik = id_uztkownik,
                    opis = "Czarna skórzana tapicerka, Instalacja pod Ipod, Zaciski hamulcowe w ¿ó³tym kolorze, Tarcza obrotomierza w ¿ó³tym kolorze, Kontroloa ciœnienia w oponach, Elektrycznie regulowane fotele, Termin dostawy tylko 2 tygodnie. Wystawiamy pe³n¹ fakturê VAT 22%, Mo¿liwy kredyt-leasing",
                    tytul = "Ferrari California Wersja EU",
                    rocznik = 2003,
                    przebieg = 15000,
                    mocSilnika = 3679,
                    pojemnoscSilnika = 2300,
                    rodzajPaliwa = "benzyna",
                    typNadwozia = "kombi",
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

        private void seed_zdjecia()
        {
            System.Data.Entity.Database.SetInitializer<projekt_car_sellers.Models.zdjeciaContext>(null);

            zdjeciaContext zdjeciaCont = new zdjeciaContext();

            int id_ogloszenie = pobierz_id_ogloszenie(2012);
            int id_ogloszenie2 = pobierz_id_ogloszenie(2002);
            int id_ogloszenie3 = pobierz_id_ogloszenie(1992);
            int id_ogloszenie4 = pobierz_id_ogloszenie(1952);
            int id_ogloszenie5 = pobierz_id_ogloszenie(1972);
            int id_ogloszenie6 = pobierz_id_ogloszenie(2007);
            int id_ogloszenie7 = pobierz_id_ogloszenie(2003);
            var link1 = "http://upload.wikimedia.org/wikipedia/commons/8/8d/Audi_A4_B8_front_20080414.jpg";
            var link2 = "http://gtoss.com/wp-content/uploads/2013/04/Audi-a4-590-189813.jpeg";
            var link3 = "http://niechwiedza.pl/upload/avatar_user/1360234943d699a2d06f90a5ca78ff2d50760c86a0alfa_romeo_159.jpg";
            var link4 = "http://www.autoviva.com/img/photos/036/mercedes_benz_a_150_large_5036.jpg";
            var link5 = "http://img.automobile.de/modellbilder/Honda-CR-V-32877_hon_crv_12_test_1.jpg";
            var link6 = "http://www.blogcdn.com/green.autoblog.com/media/2009/07/700901_1265600_4256_2832_08c1142_227.jpg";
            var link7 = "http://i.wp.pl/a/f/jpeg/30788/640-ferrari-laferrari.jpeg";
            zdjecia[] zdjecia_wszystkie = new zdjecia[] {
                new zdjecia{ id = 1, url = link1, FK_ogloszenia = id_ogloszenie },
                new zdjecia{ id = 2, url = link2, FK_ogloszenia = id_ogloszenie2 },
                new zdjecia{ id = 3, url = link3, FK_ogloszenia = id_ogloszenie3 },
                new zdjecia{ id = 4, url = link4, FK_ogloszenia = id_ogloszenie4 },
                new zdjecia{ id = 5, url = link5, FK_ogloszenia = id_ogloszenie5 },
                new zdjecia{ id = 6, url = link6, FK_ogloszenia = id_ogloszenie6 },
                new zdjecia{ id = 7, url = link7, FK_ogloszenia = id_ogloszenie7 },
            };

            zdjeciaCont.zdjeciaDb.AddOrUpdate(zdjecia_wszystkie);

            zdjeciaCont.SaveChanges();

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

        private int pobierz_id_ogloszenie(int rocznik)
        {
            int id_ogloszenie = 0;
            ogloszeniaContext ogloszeniaCont = new ogloszeniaContext();

            var ogloszenie = ogloszeniaCont.ogloszeniaDb.Where(x => x.rocznik == rocznik).First();
            id_ogloszenie = ogloszenie.id;
            return id_ogloszenie;
        }
    }
}
