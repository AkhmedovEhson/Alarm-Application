using System.Reflection;
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

            services.AddHostedService<AlarmJob>();
            return services;
        }
    }
}
