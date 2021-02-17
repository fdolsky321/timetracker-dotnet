using Domain.Enums;
using Domain.SharedKernel;
using System;

namespace Domain.TaskItems
{
    public class TaskItem : BaseUpdateEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryEnum Category { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public TaskItem() { }
        public TaskItem(string name, CategoryEnum category, DateTime startDateTime, DateTime endDateTime) 
        {
            Name = name;
            Category = category;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

    }
}
