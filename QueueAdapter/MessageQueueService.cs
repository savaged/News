using System;
using System.Messaging;

namespace QueueAdapter;

public class MessageQueueService : IMessageQueueService
{
    private readonly MessageQueue _messageQueue;

    public MessageQueueService(string queueName)
    {
        _messageQueue = new MessageQueue(
            $".\\{queueName ?? nameof(MessageQueue).ToLower()}");
    }

    public void Send<T>(T messageBody, string subQueueName = "")
    {
        SetFormatter<T>();
        _messageQueue.Send(messageBody);
    }

    public T Receive<T>(string subQueueName = "")
    {
        SetFormatter<T>();
        var m = _messageQueue.Receive();
        return m?.Body is not null ? (T)m.Body : default;
    }

    private void SetFormatter<T>() =>
        _messageQueue.Formatter =
            new XmlMessageFormatter(new Type[] { typeof(T) });
}
