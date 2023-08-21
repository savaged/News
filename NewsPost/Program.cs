using Autofac;
using NewsBootstrapper;
using NewsServer;
using System;

namespace NewsPost;

internal class Program
{
    static void Main() => new Program().Run();

    private readonly IContainer _container;

    private Program() => _container = new Bootstrapper("news").Build();

    public void Run()
    {
        using var scope = _container.BeginLifetimeScope();
        var newsService = scope.Resolve<INewsService>();
        newsService?.Send(
            $"This is some public news at {DateTime.Now.ToShortTimeString()}");
        newsService?.Send(
            $"This is some privileged news at {DateTime.Now.ToShortTimeString()}", "privileged");
    }
}
