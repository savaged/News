namespace NewsServer;

public interface INewsService
{
    string Receive(string subQueueName = "");
    void Send(string news, string subQueueName = "");
}