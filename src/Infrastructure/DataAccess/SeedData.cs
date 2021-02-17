using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.TaskItems;
using Domain.Enums;

namespace Infrastructure.DataAccess
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Entity<TaskItem>()
                .HasData(
                    new TaskItem
                    {
                        Id = new Guid("04c7ff42-6c43-11eb-9439-0242ac130002"),
                        Name = "Seeded Task 1",
                        Category = CategoryEnum.Development,
                        StartDateTime = DateTime.Now,
                        EndDateTime = DateTime.Now.AddDays(10),
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Frantisek Dolsky",
                        ModifiedAt = DateTime.Now,
                        ModifiedBy = "Frantisek Dolsky"
                    }
                );
        }
    }
}
