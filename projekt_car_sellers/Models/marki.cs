using projekt_car_sellers.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Web.Security;

namespace projekt_car_sellers.Models
{
    public class markiContext : ogloszeniaContext
    {
        public DbSet<marki> markiDb { get; set; }
    }

    [Table("marki")]
    public class marki
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nazwa { get; set; }
    }
}