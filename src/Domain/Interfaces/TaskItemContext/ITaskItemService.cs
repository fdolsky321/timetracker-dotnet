using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.TaskItems;

namespace Domain.Interfaces.TaskItemContext
{
    interface ITaskItemService 
    {
        Task<TaskItem> TaskItemCreateNewAsync(TaskItem task);
        Task<TaskItem> TaskEditAsync(Task task);
    }
}
