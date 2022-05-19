using System.Collections.Generic;
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
        public AppDbContext appDbContext { get; }

        public SQLDbStockRepository(AppDbContext appDbContext)
        {
            //  Applying repository pattern to query the data from database and send back to the data model.
            this.appDbContext = appDbContext;

        }
        /*
        //FETCH the stock details of the particular stock name 
        by JOINING Stock table and BrokersStock Table 
        WHERE StockName = InputParam        
        */
        public async Task<Stock> GetStock(string stockName)
        {
            return await appDbContext.Stocks
            .Include(e=>e.BrokersStock)
            .FirstOrDefaultAsync(a=>a.stockName= stockName)
            ;
        }
         /*
        //FETCH the stock details of the all stocks  
        by JOINING Stock table and BrokersStock Table 
        ON  BrokersStock.StockID = Stock.ID        
        */
        public async Task<IEnumerable<Stock>> GetStocks()
        {
            return await appDbContext.Stocks.ToList();
        }
        /*
        //FETCH the range of stock value per day, per month and per year by applying the below mention formula.        
        */
        public async Task<Stock> GetRangeofStocks(string stockName)
        {
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

/*
STOCK TABLE
------------

CREATE TABLE STOCK(
VARCHAR(100) ID PRIMARY KEY,
DAteTIME StockCreated DEFAULT DATETIME.UTC()
VARCHAR(7) StockName Unique Key,
VARCHAR(100) StockDescription null,
DOUBLE CurrentValue not NULL,
DAteTIME ModifiedDateTime DEFAULT DATETIME.UTC()
);

BROKER TABLE:
------------

CREATE TABLE BROKER(
VARCHAR(100) ID PRIMARY KEY,
VARCHAR(7) Name  Not Null,
VARCHAR(100) Address null,
DOUBLE ContactNumber not NULL,
DAteTIME CreatedDate DEFAULT DATETIME.UTC()

);

BROKERS_STOCK TABLE
------------------
CREATE TABLE BROKER(
VARCHAR(100) BROKERID FOREIGN KEY of BROKER TABLE,
VARCHAR(100) STOCKID FOREIGN KEY of STOCK TABLE,
DOUBLE SharesQuantity not NULL,
DateTIME ModifiedTime DEFAULT DATETIME.UTC()

);

*/