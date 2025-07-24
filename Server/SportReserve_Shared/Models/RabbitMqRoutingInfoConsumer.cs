namespace SportReserve_Shared.Models
{
    public class RabbitMqRoutingInfoConsumer
    {
        public string ExchangeName { get; set; } = string.Empty;
        public string QueueName { get; set; } = string.Empty;
        public string RoutingKey { get; set; } = string.Empty;
    }
}
