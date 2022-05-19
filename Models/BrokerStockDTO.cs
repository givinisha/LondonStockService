using LondonStockService.Entities;

namespace LondonStockService.Models
{
    public class BrokerStockDTO
    {
          //Broker Entity
         public Broker Broker {get;set;}
         
         //Stock name that the broker is assigned to 
         public string StockName {get;set;}

         //Number of stocks assigned to the Broker
         public int NumberOfStocks{get;set;}
    }
}