using Meys.Data.Repositories;
using Meys.Data.Repositories.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Meys.WebApi.Dependecy
{
    public static class RegisterRepositories
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
