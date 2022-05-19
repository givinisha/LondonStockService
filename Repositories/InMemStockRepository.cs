using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LondonStockService.Entities;

namespace LondonStockService.Repositories
{
    /*
        Used as stub to consume the API by the client application,
        untill the Database changes are ready.
    */
    public class InMemStockRepository : IStockRepository
    {
        
        private  readonly List<Stock> stocks = new()
       {
           //Till the Database changes are ready, the API can be tested using this hard coded values.
           /*
          new Stock  { Id = Guid.NewGuid(),StockName = "LONSE:AMZ", StockDescription = "Amazon" ,CurrentValue = 2142.25M} ,
          new Stock  { Id = Guid.NewGuid(),StockName = "LONSE:ACC",StockDescription = "Accenture" ,CurrentValue = 2140.25M} ,
          new Stock  { Id = Guid.NewGuid(),StockName = "LONSE:APL",StockDescription = "Apple" ,CurrentValue = 2149.25M} ,
      */
       };


        /*
        Description: Fetch all the stocks that are available in the system
        And the CurrentValue is fetched by average of the share value of all records..         
       */
           public async Task<IEnumerable<Stock>> GetStocks()
        {
            return stocks;
        }

        /*
         Fetch the stock details of the particular stock name.
        */
       public async Task<Stock> GetStock(string stockName)
        {
            return  stocks.Where(stocks => stocks.StockName == stockName).SingleOrDefault();
        }
        /*
         Fetch the range of stock details
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