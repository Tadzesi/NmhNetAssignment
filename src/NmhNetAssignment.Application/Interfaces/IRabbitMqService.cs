namespace NmhNetAssignment.Application.Interfaces
{
    public interface IRabbitMqService
    {
        Task PublishMessageAsync<T>(T message, string queueName = "default-queue", CancellationToken cancellationToken = default);
        Task ConsumeMessagesAsync(string queueName, Func<string, Task> messageHandler, CancellationToken cancellationToken = default);
    }
}

