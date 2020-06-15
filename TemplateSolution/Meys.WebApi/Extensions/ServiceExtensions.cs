using Meys.Data;
using Meys.WebApi.Dependecy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Meys.WebApi.Extentions
{
    /// <summary>
    /// An extension to register all the services
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// register/inject all the dependencies
        /// </summary>
        /// <param name="services">Collection of Services provided in the stratup</param>
        /// <param name="connectionString"> A Connection String to the DB, required to create ApplicationDBContext</param>
        public static void RegisterAllDependencies(this IServiceCollection services, string connectionString)
        {
            //Adding ApplicationDbContext before everything else
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            RegisterRepositories.Register(services);
            RegisterServices.Register(services);
        }

        /// <summary>
        /// Adds Jwt Authentication
        /// </summary>
        /// <param name="services"> Collection of Services provided in the stratup</param>
        /// <param name="secretKey">this is the secret key that JWT uses to encrypt the token. Recommended to be read from Appsettings</param>
        public static void AddJwtAuthentication(this IServiceCollection services, string secretKey)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) 
                };
            });

        }

    }
}
