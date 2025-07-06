using Microsoft.AspNetCore.Mvc;
using QuickTaskLite.Application.Interfaces;
using QuickTaskLite.Domain.Entities;
using QuickTaskLite.Domain.Extensions;

namespace QuickTaskLite.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
                return BadRequest("Title is required.");

            var (isSuccess, message) = await _taskService.CreateTaskAsync(task);
            return isSuccess ? Ok(message) : StatusCode(500, "Failed to create task.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            var result = tasks.Select(t => new
            {
                t.Id,
                t.Title,
                t.DueDate,
                t.IsCompleted,
                StatusLabel = t.GetStatusLabel()
            });

            return Ok(result);
        }
    }
}
