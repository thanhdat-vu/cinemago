using CinemaGo.Application;
using CinemaGo.Application.Abstractions;
using CinemaGo.Application.Common.PipelineMiddlewares;
using CinemaGo.IntegrationTests.Shared.Fakes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wolverine;

namespace CinemaGo.IntegrationTests.ApplicationTests
{
    /// <summary>
    /// En Minimal Wolverine host for <see cref="CachingMiddleware"/> integration tests (no database).
    /// </summary>
    public static class CachingMiddlewareTestHostFactory
    {
        public static async Task<IHost> StartAsync(CancellationToken ct = default)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services => { services.AddSingleton<ICacheService, InMemoryCacheService>(); })
                .UseWolverine(opts =>
                {
                    opts.Discovery.IncludeAssembly(typeof(IRequest).Assembly);
                    opts.Discovery.IncludeAssembly(typeof(CachingMiddlewareProbeQuery).Assembly);
                    opts.Policies.ForMessagesOfType<ICachableQuery>().AddMiddleware(typeof(CachingMiddleware));
                })
                .Build();

            await host.StartAsync(ct);
            return host;
        }
    }
}
