using Newtonsoft.Json;
using RabbitMQ.Client;
using SportReserve_Shared.Models;
using SportReserve_Shared.Models.User;
using SportReserve_Users.Interfaces;
using System.Text;

namespace SportReserve_Users.RabbitMq
{
    public class ProducerUser : IProducerUser
    {
        public void RegisterEvent(UserRegisteredEventDto dto)
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            factory.ClientProvidedName = "Rabbit Sender App";

            IConnection cnn = factory.CreateConnection();

            IModel channel = cnn.CreateModel();


            var rabbitMqRoutingInfo = new RabbitMqRoutingInfoProducer
            {
                ExchangeName = "sportreserve.exchange",
                RoutingKey = "user.register.mail"
            };

            channel.ExchangeDeclare(rabbitMqRoutingInfo.ExchangeName, ExchangeType.Direct);

            var jsonPayload = JsonConvert.SerializeObject(dto);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(jsonPayload);
            channel.BasicPublish(rabbitMqRoutingInfo.ExchangeName, rabbitMqRoutingInfo.RoutingKey, null, messageBodyBytes);

            channel.Close();
            cnn.Close();
        }
    }
}
