using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NmhNetAssignment.Application.Interfaces;

namespace NmhNetAssignment.Infrastructure.Services
{
    public class MessageConsumerBackgroundService : BackgroundService
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly ILogger<MessageConsumerBackgroundService> _logger;
        private readonly IConfiguration _configuration;
        public MessageConsumerBackgroundService(
            IRabbitMqService rabbitMqService,
            ILogger<MessageConsumerBackgroundService> logger,
            IConfiguration configuration)
        {
            _rabbitMqService = rabbitMqService;
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await _rabbitMqService.ConsumeMessagesAsync(
                _configuration["RabbitMQ:QueueName"]!,
                async (message) =>
                {
                    _logger.LogInformation("Received message: {Message}", message);
                    // Process message as needed
                    await Task.CompletedTask;
                },
                cancellationToken
            );
        }
    }
}
