﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace ReceiveOrders
{
    public class Receive
    {
        private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

        private static readonly ILogger _logger = WebApplication.CreateBuilder().Build().Logger;

        public static void Main()
        {
            _logger.LogInformation("Starting the app");

            var linkRabbitMQ = _configuration.GetConnectionString("RabbitMQ");
            var queueName = _configuration.GetValue<string>("QueueName");
            _logger.LogInformation("Queue from {0}", queueName);

            var factory = new ConnectionFactory() { HostName = linkRabbitMQ };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation($"[x] Received {message}");

            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);

            _logger.LogInformation("Press [enter] to exit");
            Console.ReadLine();
        }
    }
}