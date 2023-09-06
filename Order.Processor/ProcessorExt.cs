using Order.Config;
using Order.Model;
using Order.Processor;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProcessorExt
    {
        public static IServiceCollection AddProcessors(this IServiceCollection services)
        {
            services.AddScoped<IProcessor<Pedido>, ProcessorPedido>();
            services.AddSingleton<IUniqueId>(provider => new ConcurrentUniqueId(provider.GetRequiredService<IAppConfig>().NodeId));

            return services;
        }
    }
}
