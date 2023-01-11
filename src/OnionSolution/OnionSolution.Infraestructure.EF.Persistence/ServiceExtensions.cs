using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionSolution.Core.Application.Interfaces;
using OnionSolution.Infraestructure.EF.Persistence.Contexts;
using OnionSolution.Infraestructure.EF.Persistence.Repository;

namespace OnionSolution.Infraestructure.EF.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #region Repositories
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            #endregion

            #region Caching
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = configuration.GetValue<string>("Caching:RedisConnection");
            //});
            #endregion
        }
    }
}
