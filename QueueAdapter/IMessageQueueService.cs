namespace QueueAdapter;

public interface IMessageQueueService
{
    T Receive<T>(string subQueueName = "");
    void Send<T>(T messageBody, string subQueueName = "");
}