using Meys.Service.Abstraction;
using Meys.Service.Helpers;
using Meys.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Meys.WebApi.Dependecy
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHashService, HasheService>();
        }
    }
}
