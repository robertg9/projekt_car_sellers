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
    public class regionContext : modelContext
    {
        public DbSet<region> regionDb { get; set; }
    }

    [Table("region")]
    public class region
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nazwa { get; set; }
    }
}