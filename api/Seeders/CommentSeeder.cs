using api.Data;
using api.Models;
using System;

namespace MyApp.Data.Seeders
{
    public static class CommentSeeder
    {
        public static void Seed(ApplicationDBContext context)
        {
            // Only seed if no comments exist
            if (!context.Comments.Any())
            {
                var comments = new List<Comment>
                {
                    new Comment
                    {
                        Title = "Great Growth Potential",
                        Content = "Apple's innovation keeps driving its stock up!",
                        CreatedAt = DateTime.Now.AddDays(-5),
                        StockId = 1 // Links to AAPL
                    },
                    new Comment
                    {
                        Title = "Solid Dividend",
                        Content = "Microsoft’s steady dividends make it a safe bet.",
                        CreatedAt = DateTime.Now.AddDays(-3),
                        StockId = 2 // Links to MSFT
                    },
                    new Comment
                    {
                        Title = "Risky but Exciting",
                        Content = "Tesla’s volatility is wild—huge upside if they deliver.",
                        CreatedAt = DateTime.Now.AddDays(-1),
                        StockId = 3 // Links to TSLA
                    },
                    new Comment
                    {
                        Title = "Undervalued?",
                        Content = "Apple might be a steal at this price.",
                        CreatedAt = DateTime.Now,
                        StockId = 1 // Another AAPL comment
                    }
                };

                context.Comments.AddRange(comments);
                context.SaveChanges();
            }
        }
    }
}