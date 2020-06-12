using Meys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meys.WebApi.Dependecy
{
    /// <summary>
    /// An extension to register all the services
    /// </summary>
    public static class ServiceExtensions
    {
        public static void RegisterAllDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Adding ApplicationDbContext before everything else
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            RegisterRepositories.Register(services);

            RegisterServices.Register(services);
        }
    }
}
