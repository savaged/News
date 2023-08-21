using Autofac;
using NewsServer;
using QueueAdapter;

namespace NewsBootstrapper;

public class Bootstrapper
{
    private readonly string _messageQueueName;
    private IContainer _container;

    public Bootstrapper(string messageQueueName)
    {
        _messageQueueName = !string.IsNullOrEmpty(messageQueueName) ? messageQueueName : string.Empty;
        Builder = new ContainerBuilder();
    }

    public IContainer Build()
    {
        BindCommon();
        BindApplicationSpecific();
        _container = Builder.Build();
        return _container;
    }

    protected ContainerBuilder Builder { get; }

    protected virtual void BindApplicationSpecific() { }

    private void BindCommon()
    {
        Builder.RegisterType<MessageQueueService>().As<IMessageQueueService>()
            .WithParameter("queueName", _messageQueueName)
            .SingleInstance();
        Builder.RegisterType<NewsService>().As<INewsService>();
    }

}
