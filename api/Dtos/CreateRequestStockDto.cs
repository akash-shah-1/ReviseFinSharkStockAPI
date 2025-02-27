﻿namespace api.Dtos
{
    public class CreateRequestStockDto
    {
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public string MarketCap { get; set; } = string.Empty;
    }
}
