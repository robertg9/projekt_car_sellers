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
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }


        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }
       
        public void InitializeDatabase(DbContext context)
        {
            if (context.Database.Exists())
            {
                if (context.Database.CompatibleWithModel(throwIfNoMetadata: true))
                {
                    return;
                }

                context.Database.Delete();
            }

            // Database didn't exist or we deleted it, so we now create it again.
            context.Database.Create();

            context.SaveChanges();
        }
        
        public markiContext()
            : base("DefaultConnection")
        {
        }
        */
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