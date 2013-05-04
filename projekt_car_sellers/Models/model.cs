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
    public class modelContext : DbContext
    {
        public modelContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<model> modelDb { get; set; }
    }

    [Table("model")]
    public class model
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nazwa { get; set; }
        public int FK_marka { get; set; }
    }
}