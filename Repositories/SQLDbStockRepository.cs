using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LondonStockService.Entities;
using LondonStockService.Models;
using Microsoft.EntityFrameworkCore;

namespace LondonStockService.Repositories
{
    /*
    Repository class to fetch the respective data from SQL database

    */
    public class SQLDbStockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public SQLDbStockRepository(AppDbContext appDbContext)
        {
            //  Applying repository pattern to query the data from database and send back to the data model.
            this._context = appDbContext;

        }
        /*
        //FETCH the stock details of the particular stock name 
        by JOINING Stock table and BrokersStock Table 
        WHERE StockName = InputParam        
        */
        public async Task<StockDTO> GetStock(string stockName)
        {
            return await _context.stocks
            .Include(b => b.BrokersStock)
            .FirstOrDefaultAsync( a => a.StockName == stockName);
        }
         /*
        //FETCH the stock details of the all stocks  
        by JOINING Stock table and BrokersStock Table 
        ON  BrokersStock.StockID = Stock.ID        
        */
        public async Task<IEnumerable<StockDTO>> GetStocks()
        { 
            return await _context.stocks.ToListAsync();;
              
        }
        /*
        //FETCH the range of stock value per day, per month and per year by applying the below mention formula.        
        */
        public async Task<StockDTO> GetRangeofStocks(string stockName)
        {

             return await _context.stocks
            .Include(b => b.BrokersStock)
            .FirstOrDefaultAsync( a => a.StockName == stockName);
            /*
            return stock object  by assigning below values
                Stock.stockName = stockName;
                Stock.RangePerDay = <Max(CurrentValue) - Min(CurrentValue) Group by  date in Modified date field>
                Stock.RangePerMonth = <Max(CurrentValue) - Min(CurrentValue) Group by  month in Modified date field>
                Stock.RangePerYear = <Max(CurrentValue) - Min(CurrentValue) Group by  year in Modified date field>
            */
        }
    }
}

