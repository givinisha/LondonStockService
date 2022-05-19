using System.Collections.Generic;
using System.Threading.Tasks;
using LondonStockService.Entities;

namespace LondonStockService.Repositories
{
public interface IStockRepository
    {
      public  Task<Stock> GetStock(string stockName);
      public Task<IEnumerable<Stock>> GetStocks();
    }
}
