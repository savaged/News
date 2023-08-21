using Autofac;
using NewsBootstrapper;
using NewsServer;
using System;

namespace NewsClient.Privileged;

internal class Program
{
    static void Main() => new Program().Run();

    private readonly IContainer _container;

    private Program() => _container = new Bootstrapper("news").Build();

    public void Run()
    {
        using var scope = _container.BeginLifetimeScope();
        Console.WriteLine(scope.Resolve<INewsService>()?.Receive("privileged") ?? string.Empty);
    }
}
