using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<AuditableEntityInterceptor>();
            services.AddDbContext<ApplicationDbContext>((sp,o) =>
            {
                o.UseNpgsql("Server=localhost;Port=5434;Userid=postgres;Password=postgres;Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;SslMode=Disable;Database=Alarm");
                o.AddInterceptors(sp.GetRequiredService<AuditableEntityInterceptor>());
            });
            services.AddScoped<ApplicationDbContextInitializer>();


            // Fill DI by repositories ...
            services.AddScoped<AlarmRepository>();

            return services;
        }
    }
}