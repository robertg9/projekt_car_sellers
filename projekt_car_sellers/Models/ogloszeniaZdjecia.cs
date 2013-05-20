using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projekt_car_sellers.Models
{
    public class ogloszenieZdjecia
    {
        public int id { get; set; }
        public string tytul { get; set; }
        public string url { get; set; }
        public int rocznik { get; set; }
        public int przebieg { get; set; }
        public int pojemnoscSilnika { get; set; }
        public string rodzajPaliwa { get; set; }

    }
}