using Microsoft.Extensions.Configuration;
using NmhNetAssignment.Application.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace NmhNetAssignment.Infrastructure.Services
{
    public class RabbitMqService : IRabbitMqService, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private bool _disposed;

        public RabbitMqService(IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:HostName"] ?? "localhost",
                Port = int.Parse(configuration["RabbitMQ:Port"] ?? "5672"),
                UserName = configuration["RabbitMQ:Username"] ?? "guest",
                Password = configuration["RabbitMQ:Password"] ?? "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public Task PublishMessageAsync<T>(T message, string queueName = "default-queue", CancellationToken cancellationToken = default)
        {
            // Ensure queue exists
            _channel.QueueDeclare(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            // Serialize message
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            // Publish message
            _channel.BasicPublish(
                exchange: "",
                routingKey: queueName,
                basicProperties: null,
                body: body
            );

            return Task.CompletedTask;
        }

        public Task ConsumeMessagesAsync(
            string queueName,
            Func<string, Task> messageHandler,
            CancellationToken cancellationToken = default)
        {
            // Ensure queue exists
            _channel.QueueDeclare(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                try
                {
                    await messageHandler(message);
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (JsonException ex)
                {
                    // Handle JSON serialization/deserialization errors
                    _channel.BasicNack(ea.DeliveryTag, false, false);
                    throw new InvalidOperationException("Error processing message", ex);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    _channel.BasicNack(ea.DeliveryTag, false, true);
                    throw new InvalidOperationException("Error processing message", ex);
                }
            };

            _channel.BasicConsume(queueName, false, consumer);

            // Keep the task running
            var completionSource = new TaskCompletionSource<bool>();
            cancellationToken.Register(() => completionSource.TrySetResult(true));
            return completionSource.Task;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _channel?.Close();
                    _connection?.Close();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
