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
        _container = Builder.Build();
        return _container;
    }

    protected ContainerBuilder Builder { get; }

    private void BindCommon()
    {
        // TODO register services
    }

}
