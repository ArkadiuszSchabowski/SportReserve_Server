namespace SportReserve_Shared.Models
{
    public class RabbitMqRoutingInfoProducer
    {
        public string ExchangeName { get; set; } = string.Empty;
        public string RoutingKey { get; set; } = string.Empty;
    }
}
