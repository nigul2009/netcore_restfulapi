using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionSolution.Core.Application.Interfaces;
using OnionSolution.Infraestructure.Shared.Services;

namespace OnionSolution.Infraestructure.Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDateTimeService, DateTimeService>();
        }
    }
}
