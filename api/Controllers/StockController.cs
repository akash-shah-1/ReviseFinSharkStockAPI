using api.Data;
using api.Dtos;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        //Get all Stocks
        [HttpGet]
        public IActionResult GetAllStocks()
        {
            var stocks = _context.Stock.ToList().Select(s=>s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetStockById([FromRoute] int id)
        {
            var stock = _context.Stock.Find(id);
            if (stock == null) return NotFound();
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult CreateStock([FromBody] CreateRequestStockDto stockDto)
        {
            var stockModel = stockDto.ToCreateRequestDto();
            _context.Stock.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, stockModel.ToStockDto());

        }

        [HttpPut("{id}")]
        public IActionResult UpdateStock([FromRoute] int id, [FromBody] UpdateRequestStockDto UpdateDto)
        {
            var stockModel = _context.Stock.FirstOrDefault(stock=>stock.Id == id);
            if (stockModel == null) return NotFound();
            
            stockModel.Symbol = UpdateDto.Symbol;
            stockModel.CompanyName = UpdateDto.CompanyName;
            stockModel.Purchase = UpdateDto.Purchase;
            stockModel.LastDiv = UpdateDto.LastDiv;
            stockModel.Industry = UpdateDto.Industry;
            stockModel.MarketCap = UpdateDto.MarketCap;

            _context.SaveChanges();
            return Ok(new
            {
                message = $"Stock model with Id = {stockModel.Id} is Updated successfully 🙌",
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStock([FromRoute] int id) { 
        
            var stock = _context.Stock.FirstOrDefault(stock=> stock.Id == id);
            if (stock == null) return NotFound();
            _context.Stock.Remove(stock);
            _context.SaveChanges();
            return Ok(new
            {
                message = $"Stock model with Id = {stock.Id} is Deleted successfully 🙌",
            });
        }
    }
}
