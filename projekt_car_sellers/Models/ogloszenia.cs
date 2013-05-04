using projekt_car_sellers.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace projekt_car_sellers.Models
{
    public class ogloszeniaContext : DbContext
    {
        public ogloszeniaContext() : base("DefaultConnection") {}

        public DbSet<ogloszenia> ogloszeniaDb { get; set; }
    }

    [Table("ogloszenia")]
    public class ogloszenia
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int FK_model { get; set; }
        public int FK_uzytkownik { get; set; }
        public int FK_lokalizacja { get; set; }
        public string opis { get; set; }
        public string tytul { get; set; }
        public int rocznik { get; set; }
        public int przebieg { get; set; }
        public decimal cena { get; set; }
        public int mocSilnika { get; set; }
        public int pojemnoscSilnika { get; set; }
        public string rodzajPaliwa { get; set; }
        public string typNadwozia { get; set; }
    }
}