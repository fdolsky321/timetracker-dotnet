using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Modules.Common
{
    public static class CustomControllersExtensions
    {

        public static IServiceCollection AddCustomContollers(this IServiceCollection services)
        {
            services
                .AddMvc();

            services
                .AddHttpContextAccessor()
                .AddControllers()
                .AddControllersAsServices();
            return services;
        }
    }
}
