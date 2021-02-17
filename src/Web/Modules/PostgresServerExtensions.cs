using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Infrastructure.DataAccess;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.TaskContext;
using Infrastructure.Repositories.TaskItemsContext;

namespace Web.Modules
{
    public static class PostgresServerExtensions
    {
        public static IServiceCollection AddPostgresServer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TimetrackerContext>(
                options => options.UseNpgsql(configuration.GetValue<string>("PersistenceModule:DefaultConnection")));
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            return services;
        }
    }

}
