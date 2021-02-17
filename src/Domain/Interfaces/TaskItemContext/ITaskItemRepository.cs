using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.TaskItems;

namespace Domain.Interfaces.TaskContext
{
    public interface ITaskItemRepository : IRepository<TaskItem>
    {
        Task<TaskItem> GetByIdAsync(Guid id);
        Task<List<TaskItem>> ListAllAsync();
        Task<TaskItem> TaskCreateNewAsync(TaskItem taskItem);
    }
}
