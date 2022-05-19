using Microsoft.Extensions.DependencyInjection;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brilliance_Test.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUserCreatedServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            });
        }
    }
}
