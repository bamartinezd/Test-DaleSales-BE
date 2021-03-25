using Microsoft.Extensions.DependencyInjection;
using TestDaleSalesBE.Data.DataAccess.Repositories;
using TestDaleSalesBE.Domain.Contracts;
using TestDaleSalesBE.Domain.Entities;

namespace TestDaleSalesBE.Services.Api.Extension
{
    public static class ServiceExtension
    {

        #region Cors Implementation
        /// <summary>
        /// Configuring Cors policies for allow/deny remote connections
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }
        #endregion

        #region Dependency Injection
        /// <summary>
        /// Configuring dependencies as a personalized services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDependencies(this IServiceCollection services){
            services.AddScoped<IGenericRepository<Client>, ClientRepository>();
            services.AddScoped<IGenericRepository<Product>, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
        }
        #endregion
    }
}