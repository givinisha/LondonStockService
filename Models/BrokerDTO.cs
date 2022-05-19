namespace LondonStockService.Models
{
    public class BrokerDTO
    {
        //Unique ID of the Broker
        public double ID {get;init;}
        // Name of the Broker
        public string Name {get;set;}
        //Contact details of the Broker
        public double ContactNumber {get;set;}
        //Address of Broker
        public string Address {get;set;}
        //Email address of Broker
        public string email{get;set;}
    }
}