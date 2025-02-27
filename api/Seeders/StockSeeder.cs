using api.Data;
using api.Models;
using System;

namespace MyApp.Data.Seeders
{
    public static class StockSeeder
    {
        public static void Seed(ApplicationDBContext context)
        {
            // Check if the table is empty to avoid duplicates
            if (!context.Stock.Any())
            {
                var stocks = new List<Stock>
                {
                    new Stock
                    {
                        Symbol = "AAPL",
                        CompanyName = "Apple Inc.",
                        Purchase = 150.25m,
                        LastDiv = 0.82m,
                        Industry = "Technology",
                        MarketCap = "2.5T"
                    },
                    new Stock
                    {
                        Symbol = "MSFT",
                        CompanyName = "Microsoft Corporation",
                        Purchase = 299.50m,
                        LastDiv = 0.68m,
                        Industry = "Technology",
                        MarketCap = "2.2T"
                    },
                    new Stock
                    {
                        Symbol = "TSLA",
                        CompanyName = "Tesla, Inc.",
                        Purchase = 248.75m,
                        LastDiv = 0.00m,
                        Industry = "Automotive",
                        MarketCap = "1.1T"
                    }
                };

                context.Stock.AddRange(stocks);
                context.SaveChanges();
            }
        }
    }
}