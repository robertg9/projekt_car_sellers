namespace projekt_car_sellers.Migrations
{
    using projekt_car_sellers.Models;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bazaDanych : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.region",
                r => new
                {
                    id = r.Int(nullable: false, identity: true),
                    nazwa = r.String(maxLength: 100),
            }).PrimaryKey(r => r.id);

            CreateTable(
                "dbo.lokalizacja",
                l => new
                {
                    id = l.Int(nullable: false, identity: true),
                    miasto = l.String(maxLength: 100),
                    FK_region = l.Int(nullable: false),
            }).PrimaryKey(l => l.id);

            CreateTable(
                "dbo.marki",
                m => new
                {
                    id = m.Int(nullable: false, identity: true),
                    nazwa = m.String(maxLength: 100),
            }).PrimaryKey(m => m.id); ;

            CreateTable(
                "dbo.model",
                md => new
                {
                    id = md.Int(nullable: false, identity: true),
                    nazwa = md.String(maxLength: 100),
                    FK_marka = md.Int(nullable: false),
            }).PrimaryKey(md => md.id);

            CreateTable(
                "dbo.ogloszenia",
                o => new
                {
                    id = o.Int(nullable: false, identity: true),
                    opis = o.String(),
                    tytul = o.String(),
                    rocznik = o.Int(nullable: false),
                    przebieg = o.Int(nullable: false),
                    cena = o.Decimal(),
                    mocSilnika = o.Int(nullable: false),
                    pojemnoscSilnika = o.Int(nullable: false),
                    rodzajPaliwa = o.String(),
                    typNadwozia = o.String(),
                    FK_model = o.Int(nullable: false),
                    FK_uzytkownik = o.Int(nullable: false),
                    FK_lokalizacja = o.Int(nullable: false),
            }).PrimaryKey(o => o.id);

            CreateTable(
                "dbo.zdjecia",
                z => new
                {
                    id = z.Int(nullable: false, identity: true),
                    url = z.String(),
                    FK_ogloszenia = z.Int(nullable: false),
            }).PrimaryKey(z => z.id);

            AddForeignKey("zdjecia", "FK_ogloszenia", "ogloszenia", "id", true);
            AddForeignKey("model", "FK_marka", "marki", "id", true);
            AddForeignKey("ogloszenia", "FK_model", "model", "id", true);
            AddForeignKey("ogloszenia", "FK_lokalizacja", "lokalizacja", "id", true);
            AddForeignKey("ogloszenia", "FK_uzytkownik", "UserProfile", "UserId", true);
            AddForeignKey("lokalizacja", "FK_region", "region", "id", true);

        }
        
        public override void Down()
        {
            DropForeignKey("zdjecia", "FK_ogloszenia", "ogloszenia");
            DropForeignKey("model", "FK_marka", "marki");
            DropForeignKey("lokalizacja", "FK_region", "region");
            DropForeignKey("ogloszenia", "FK_model", "model");
            DropForeignKey("ogloszenia", "FK_lokalizacja", "lokalizacja");
            DropForeignKey("ogloszenia", "FK_uzytkownik", "UserProfile");

            DropTable("zdjecia");
            DropTable("model");
            DropTable("marki");
            DropTable("lokalizacja");
            DropTable("region");
            DropTable("ogloszenia");
        }
    }
}
