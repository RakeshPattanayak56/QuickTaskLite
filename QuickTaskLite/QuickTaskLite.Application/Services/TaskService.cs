using QuickTaskLite.Application.Interfaces;
using QuickTaskLite.Domain.Entities;
using QuickTaskLite.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTaskLite.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<(bool IsSuccess, string Message)> CreateTaskAsync(TaskItem task)
        {
            task.Id = Guid.NewGuid();
            await _repository.AddAsync(task); 
            Console.WriteLine($"Task added: {task.Title}");
            return (true, "Task created successfully");

        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
