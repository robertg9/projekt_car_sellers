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
    public class lokalizacjaContext : zdjeciaContext
    {
        public DbSet<lokalizacja> lokalizacjaDb { get; set; }
    }

    [Table("lokalizacja")]
    public class lokalizacja
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string miasto { get; set; }
        public int FK_region { get; set; }
    }
}