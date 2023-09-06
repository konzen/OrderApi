using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Order.Repository
{
    public static class RepositoryExt
    {
        public static void AddRepository(this IServiceCollection services, string? connectionString)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddDbContext<Context>(o => { o.UseSqlServer(connectionString ?? throw new ArgumentNullException(nameof(connectionString))); });
        }
    }
}
