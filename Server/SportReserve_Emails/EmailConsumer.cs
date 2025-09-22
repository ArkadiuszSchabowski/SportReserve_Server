using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SportReserve_Emails.Interfaces;
using SportReserve_Shared.Interfaces.Events;
using SportReserve_Shared.Models.User;
using System.Text;

namespace SportReserve_Emails
{
    public class EmailConsumer : IUserRegisteredEventConsumer
    {
        private readonly IEmailService _emailService;

        public EmailConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public void ConsumeUserRegisteredEvent()
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            factory.ClientProvidedName = "Rabbit Receiver App";

            IConnection cnn = factory.CreateConnection();

            IModel channel = cnn.CreateModel();

            string exchangeName = "sportreserve.exchange";
            string queueName = "user.register.mail";
            string routingKey = "user.register.mail";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);
            channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();

                var rabbitMqRoutingInfoString = Encoding.UTF8.GetString(body);
                var userRegisteredEvent = JsonConvert.DeserializeObject<UserRegisteredEventDto>(rabbitMqRoutingInfoString);

                if (userRegisteredEvent == null)
                {
                    return;
                }


                _emailService.SendRegisterEmail(userRegisteredEvent);

                channel.BasicAck(args.DeliveryTag, false);
            };

            string consumerTag = channel.BasicConsume(queueName, false, consumer);
        }
    }
}
