using QueueAdapter;
using System;

namespace NewsServer;

public class NewsService : INewsService
{
    private readonly IMessageQueueService _messageQueueService;

    public NewsService(IMessageQueueService messageQueueService) =>
        _messageQueueService = messageQueueService ??
            throw new ArgumentNullException(nameof(messageQueueService));

    public void Send(string news, string subQueueName = "") =>
        _messageQueueService.Send(news);

    public string Receive(string subQueueName = "") =>
        _messageQueueService.Receive<string>();
}
