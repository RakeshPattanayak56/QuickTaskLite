using QuickTaskLite.Domain.Entities;
using QuickTaskLite.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTaskLite.Infrastructure.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new();

        public Task AddAsync(TaskItem task)
        {
            _tasks.Add(task);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<TaskItem>>(_tasks);
        }
    }
}
