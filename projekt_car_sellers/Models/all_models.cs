using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projekt_car_sellers.Models
{
    public class all_models : lokalizacjaContext
    {
        public List<projekt_car_sellers.Models.marki> wszystkie_marki { get; set; }
        public List<projekt_car_sellers.Models.ogloszenia> wszystkie_ogloszenia { get; set; }

        public all_models()
        {
            this.wszystkie_marki = this.markiDb.ToList();
            this.wszystkie_ogloszenia = this.ogloszeniaDb.ToList();
        }

    }
}