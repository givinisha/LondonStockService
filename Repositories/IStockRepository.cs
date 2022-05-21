using System.Collections.Generic;
using System.Threading.Tasks;
using LondonStockService.Models;

namespace LondonStockService.Repositories
{
public interface IStockRepository
    {
      public  Task<StockDTO> GetStock(string stockName);
     public  Task<IEnumerable<StockDTO>> GetStocks();
    }
}
