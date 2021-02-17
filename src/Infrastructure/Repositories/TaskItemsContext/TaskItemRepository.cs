using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.TaskItems;
using Domain.Interfaces.TaskContext;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.TaskItemsContext
{
    public class TaskItemRepository : EfRepository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(TimetrackerContext timetrackerContext) : base(timetrackerContext) { }

        public async Task<TaskItem> GetByIdAsync(Guid id)
        {
            return await _timetrackerContext.TaskItems.SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<List<TaskItem>> ListAllAsync()
        {
            return await _timetrackerContext.TaskItems.ToListAsync();
        }

        public async Task<TaskItem> TaskCreateNewAsync(TaskItem taskItem)
        {
            await _timetrackerContext.AddAsync(taskItem);
            return taskItem;
        }
    }
}
