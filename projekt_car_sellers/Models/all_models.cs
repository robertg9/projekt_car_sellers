using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projekt_car_sellers.Models
{
    public class all_models
    {
        public ogloszeniaContext ogloszenia { get; set; }
        public markiContext marki { get; set; }

        public List<projekt_car_sellers.Models.marki> wszystkie_marki { get; set; }
        public List<projekt_car_sellers.Models.ogloszenia> wszystkie_ogloszenia { get; set; }

        public all_models()
        {
            marki = new markiContext();
            this.wszystkie_marki = marki.markiDb.ToList();
            this.wszystkie_ogloszenia = marki.ogloszeniaDb.ToList();
        }

    }
}