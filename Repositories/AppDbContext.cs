using LondonStockService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LondonStockService.Repositories
{
    public class AppDbContext :DbContext
    {

        private IConfigurationRoot _config;
         public AppDbContext(DbContextOptions<AppDbContext> options,IConfigurationRoot config){
                _config = config;
        }
        public DbSet<StockDTO> stocks {get;set;}
        public DbSet<BrokerDTO> broker {get;set;}
        public DbSet<BrokerStockDTO> brokersStock {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder  optionBuilder){
                base.OnConfiguring(optionBuilder);
                optionBuilder.UseSqlServer(_config["Data:ConnectionString"]);
        }
        ~AppDbContext()
        {
        
        }
    }
}