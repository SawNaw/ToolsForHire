using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolsForHire.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;  // Database contains values, so no need to seed.
            }

            var productSeeds = new Product[]
            {
                new Product { ProductCode = "15/0115-h", ProductName = "Ground Compactor", DailyHireCost = 2.35M },
                new Product { ProductCode = "15/1234-h", ProductName = "Hammer Drill", DailyHireCost = 3.50M },
                new Product { ProductCode = "15/2468-h", ProductName = "Dust Extractor", DailyHireCost = 4.20M },
                new Product { ProductCode = "15/0011-h", ProductName = "Angle Grinder", DailyHireCost = 2.88M },
                new Product { ProductCode = "22/0447-h", ProductName = "Reciprocating Saw", DailyHireCost = 12.75M },
                new Product { ProductCode = "07/0385-h", ProductName = "Circular Saw", DailyHireCost = 4.02M },
                new Product { ProductCode = "55/4398-h", ProductName = "Glass Hammer", DailyHireCost = 30.00M },
                new Product { ProductCode = "08/5478-h", ProductName = "Dust Buster", DailyHireCost = 22.00M },
                new Product { ProductCode = "23/8720-h", ProductName = "Ground Spike", DailyHireCost = 8.00M },
            };
            foreach (Product p in productSeeds)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

        }
       
    }
}
