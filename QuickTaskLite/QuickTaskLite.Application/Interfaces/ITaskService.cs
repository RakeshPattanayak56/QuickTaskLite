using QuickTaskLite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTaskLite.Application.Interfaces
{
    public interface ITaskService
    {
        Task<(bool IsSuccess, string Message)> CreateTaskAsync(TaskItem task);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
    }
}
