using McDonaldsTest.Interfaces;
using McDonaldsTest.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace McDonaldsTest.Services
{
    public class RabbitMqSender : IMessageSender
    {
        private readonly IConfiguration _configuration;
        public RabbitMqSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Publish the order in the correct RabbitMq queueu
        /// </summary>
        /// <param name="order">Order to publish</param>
        public void SendOrder(Order order)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration.GetConnectionString("RabbitMQ")
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: order.KitechenArea.ToString(),
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var message = JsonConvert.SerializeObject(order);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: order.KitechenArea.ToString(),
                                 basicProperties: null,
                                 body: body);
        }
    }
}
