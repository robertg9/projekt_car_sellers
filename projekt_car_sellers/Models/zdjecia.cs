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
    public class zdjeciaContext : DbContext
    {
        public zdjeciaContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<zdjecia> zdjeciaDb { get; set; }
    }

    [Table("zdjecia")]
    public class zdjecia
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string url { get; set; }
        public int FK_ogloszenia { get; set; }
    }
}