using api.Data;
using api.Dtos.Stock;
using api.Helper;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock> DeleteByIdAsync(int id)
        {
            var stock = await _context.Stock.FindAsync(id);
            if (stock == null) return null;
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            //return await _context.Stock.Include(c=>c.Comments).ToListAsync(); 
            var stocks =  _context.Stock.AsQueryable();
            Console.WriteLine("Data", stocks);
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s =>s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks= stocks.Where(s=>s.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Symbol",StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.isDescending ? stocks.OrderByDescending(s=>s.Symbol) : stocks.OrderBy(s=>s.Symbol);
                }
            }
            // Pagination
            var skipNumber = (query.PageNumber - 1) * query.pageSize; 
            return await stocks.Skip(skipNumber).Take(query.pageSize).Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.Include(c=>c.Comments).FirstOrDefaultAsync(s=>s.Id == id);
        }

        public async Task<bool> StockExist(int id)
        {
            return await _context.Stock.AnyAsync(s=>s.Id == id);
        }

        public async Task<Stock> UpdateByIdAsync(int id, UpdateRequestStockDto updateDto)
        {
            var stockModel = await _context.Stock.FindAsync(id);
            if (stockModel == null) return null;

            stockModel.Industry = updateDto.Industry;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.MarketCap = updateDto.MarketCap;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;

            await _context.SaveChangesAsync();
            return stockModel;
        }
    }
}
