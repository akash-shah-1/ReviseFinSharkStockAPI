using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock
{
    public class CreateRequestStockDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Symbol must be at least 1 character long")]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MinLength(2, ErrorMessage = "Company name must be at least 2 characters long")]
        [MaxLength(10, ErrorMessage = "Company name cannot be over 10 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000, ErrorMessage = "Purchase must be between 1 and 1,000,000,000")]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100, ErrorMessage = "Last dividend must be between 0.001 and 100")]
        public decimal LastDiv { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Industry must be at least 2 characters long")]
        [MaxLength(10, ErrorMessage = "Industry name cannot be over 10 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 5000000000, ErrorMessage = "Market cap must be between 1 and 5,000,000,000")]
        public string MarketCap { get; set; }
    }
}
