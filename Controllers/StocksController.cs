using Microsoft.AspNetCore.Mvc;
using LondonStockService.Repositories;
using System.Collections.Generic;
using LondonStockService.Entities;
using System.Linq;
using LondonStockService.Models;

namespace LondonStockService.Controllers
{  
   
    [ApiController]
    [Route("stocks")]
    public class StocksController: ControllerBase
    {
        private readonly IStockRepository repository;
        public StocksController(IStockRepository repository){
            this.repository = repository;
        }
//GET /Stocks
        [HttpGet]
        public  IEnumerable<StockDTO> GetStocks(){
            var stocks = repository.GetStocks().Select(stock => stock.AsDTO());
            return stocks;
        }
        [HttpGet("{stockName}")]
        public ActionResult<StockDTO> GetStock(string stockName){

            var stock = repository.GetStock(stockName);
            if(stock is null){
                return NotFound();
            }

            return stock.AsDTO();
        }
    }
}