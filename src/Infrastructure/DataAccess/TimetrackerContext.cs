using Microsoft.EntityFrameworkCore;
using Domain.TaskItems;
using System;

namespace Infrastructure.DataAccess
{
    public sealed class TimetrackerContext : DbContext
    {
        public TimetrackerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ApplyConfigurationsFromAssembly(typeof(TimetrackerContext).Assembly);
            SeedData.Seed(builder);
        }
    }
}
