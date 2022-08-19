using MarsRover.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Core
{
    public static class ServiceRegistration
    {
        public static void AddMarsRoverService(this IServiceCollection services)
        {
            services.AddTransient<IMarsRoverService, MarsRoverService>();
        }
    }
}
