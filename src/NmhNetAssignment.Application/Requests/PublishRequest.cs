namespace NmhNetAssignment.Application.Requests
{
    public class PublishRequest
    {
        public object Message { get; set; } = null!;
        public string QueueName { get; set; } = "default-queue";
    }
}
