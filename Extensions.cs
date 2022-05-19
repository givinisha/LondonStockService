using LondonStockService.Entities;
using LondonStockService.Models;

namespace LondonStockService
{

    /*
    This extension class is used to hide the actual contract between client and the Data model.
    */
    public static class Extensions{
         public static StockDTO AsDTO(this Stock stock){
            return new  StockDTO{
                Id = stock.Id,
                StockName = stock.StockName,
                CurrentValue = stock.CurrentValue,
                StockDescription = stock.StockDescription,
                ModifiedDate = stock.ModifiedDate
                //TODO: Map the required fields of DTO and the entity class fields.
            };
   
    }
    }
}