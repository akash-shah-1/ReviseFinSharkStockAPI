﻿namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        // Acts as a foreign key to the Stock table
        public int? StockId { get; set; }
        public Stock? Stock { get; set; }
    }
}
