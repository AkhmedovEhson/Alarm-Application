using System.Reflection;
using WebTimer.Security;
using WebTimer.Worker;

namespace WebTimer
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebTimerServices(this IServiceCollection services)
        {
            // e.g Swagger ... 
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCorsConfigurations();
            services.ProvideJsonWebTokensConfigurations();
            services.AddHostedService<AlarmJob>();
            return services;
        }
        private static IServiceCollection AddCorsConfigurations(this IServiceCollection services)
        {
           services.AddCors(
               options =>
                   options.AddPolicy(
                       "UnsecurePolicy",
                       builder =>
                       {
                           builder.WithOrigins("http://localhost:3000");
                           builder.AllowAnyHeader();
                           builder.AllowAnyMethod();
                           builder.AllowCredentials();

                       }
                   )
                );
            return services;
        }
    }
}
