using QuickTaskLite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTaskLite.Domain.Extensions
{
    public static class TaskExtensions
    {
        public static string GetStatusLabel(this TaskItem task)
        {
            if (task.IsCompleted) return "Completed";
            return task.DueDate < DateTime.UtcNow ? "Overdue" : "Pending";
        }
    }
}
