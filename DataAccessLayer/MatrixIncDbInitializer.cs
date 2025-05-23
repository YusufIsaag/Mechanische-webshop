using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            // TODO: Hier moet ik nog wat namen verzinnen die betrekking hebben op de matrix.
            // - Denk aan de m3 boutjes, moertjes en ringetjes.
            // - Denk aan namen van schepen
            // - Denk aan namen van vliegtuigen            
            var customers = new Customer[]
            {
                new Customer { Name = "Neo", Address = "123 Elm St" , Active=true},
                new Customer { Name = "Morpheus", Address = "456 Oak St", Active = true },
                new Customer { Name = "Trinity", Address = "789 Pine St", Active = true }
            };
            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-01-01")},
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[1], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[2], OrderDate = DateTime.Parse("2021-03-01")}
            };  
            context.Orders.AddRange(orders);

            var products = new Product[]
            {
                new Product { Naam = "Gegroefde kogellager", Beschrijving = "Ideaal voor toepassingen in machines en transportbanden.Vervaardigd uit hoogwaardig staal met precisie-afwerking voor minimale wrijving en maximale levensduur.", Prijs = 34m },
                new Product { Naam = "Tandwiel smal achter", Beschrijving = "Smal achtertandwiel met 70 tanden voor scooters en lichte motorvoertuigen. Hoogwaardig staal voor duurzaamheid en optimale krachtoverdracht.", Prijs = 89m },
                new Product { Naam = "Krukas origineel Piaggio", Beschrijving = "Originele Piaggio krukas voor 2-takt motoren. Hoogwaardige afwerking voor betrouwbare prestaties en soepele rotatie.", Prijs = 209m },
                new Product { Naam = "Nokkenkas", Beschrijving = "Hoogwaardige nokkenas van slijtvast staal voor precisie in klepbediening. Ideaal voor motortiming en betrouwbaarheid.", Prijs = 169m },
                new Product { Naam = "Drijfstang ItalianRP", Beschrijving = "Set van 4 drijfstangen voor 1.8 20VT motoren. Hoogwaardig gesmeed staal voor extreme belasting en duurzaamheid.", Prijs = 329m },
                new Product { Naam = "Professionele netwerkkabel krimptang", Beschrijving = "Metaal krimptang met ratelmechanisme voor RJ45/RJ11 connectoren. Ergonomisch ontwerp voor precisie en comfort.", Prijs = 19m },
                new Product { Naam = "Bout M16 x 130 set", Beschrijving = "Complete set met bout, moer en ringen M16 voor zware constructies. Hoogwaardig staal voor industriële toepassingen.", Prijs = 18m },
                new Product { Naam = "Moer voor draaideind M10x1", Beschrijving = "Verzinkte moer M10x1 met sleutelwijdte 14. Corrosiebestendig voor automotive en industriële toepassingen.", Prijs = 0.99m },
                new Product { Naam = "Getangde aandrijfriem", Beschrijving = "Duurzame getande aandrijfriem voor efficiënte krachttransmissie. Slijtvast materiaal voor motoren en machines.", Prijs = 64.99m }
            };
            context.Products.AddRange(products);

            var parts = new Part[]
            {
                new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen"},
                new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules"},
                new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen"},
                new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen."}
            };
            context.Parts.AddRange(parts);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
