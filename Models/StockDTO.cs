using System;


namespace LondonStockService.Models
{

      public record StockDTO
    {
       // Unique ID of stock
        public Guid Id {get;init;}
       
        // Date on which the stock has been created
        public DateTime StockCreatedDate {get;init;}

         //Name of the stock in ticker symbole 
        //Ex: LONSE:AMZ for Londo's stock exchange of Amazon 
        public string StockName {get;set;}

        // Description of Stock Name
        public string StockDescription {get;init;}
        //Current Value of Stock Name
        public decimal CurrentValue {get;set;}

        // The last update time of the stock value
        public DateTimeOffset ModifiedDate{get;set;}

        // To retrieve the broker details associated with each stock

        public BrokerStockDTO BrokersStock {get;set;}

        // Max(CurrentValue) - Min(CurretnValue) Group by  date in Modified date field
        public decimal RangePerDay {get;set;}

         // Max(CurrentValue) - Min(CurretnValue) Group by  month in Modified date field
        public decimal RangePerMonth {get;set;}

          // Max(CurrentValue) - Min(CurretnValue) Group by  year in Modified date field
          public decimal RangePerYear {get;set;}
    }
}
