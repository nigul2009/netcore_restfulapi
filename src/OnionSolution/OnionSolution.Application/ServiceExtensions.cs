using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionSolution.Core.Application.Behaviours;
using System.Reflection;

namespace OnionSolution.Core.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
