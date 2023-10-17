using System.Reflection;

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

            return services;
        }
    }
}
