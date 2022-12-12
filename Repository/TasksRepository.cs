using Akvelon_Task_Manager.Contracts;
using Akvelon_Task_Manager.Data;
using Akvelon_Task_Manager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = Akvelon_Task_Manager.Data.Models.Task;

namespace Akvelon_Task_Manager.Repository
{
    public class TasksRepository : GenericRepository<Task>, ITasksRepository  // Inheriting from generic repository with itasks repository 
    {                                                                         // together to implement aldo tasks specific methods
        private readonly AkvelonTaskManagerDbContext _context;
        public TasksRepository(AkvelonTaskManagerDbContext context) : base(context)  // Injecting database context
        {
            _context = context;
        }

        // Just implementing methods
        public async Task<ActionResult<List<Task>>> GetSortedTasks(string orderBy)
        {
            var query = _context.Tasks.AsQueryable();

            query = orderBy switch
            {
                "status" => query.OrderBy(s => s.TaskStatus),
                "statusDesc" => query.OrderByDescending(s => s.TaskStatus),
                "priority" => query.OrderBy(p => p.TaskPriority),
                "priorityDesc" => query.OrderByDescending(p => p.TaskPriority),
                _ => query.OrderBy(n => n.TaskName)
            };

            return await query.ToListAsync();
        }

        public async Task<ActionResult<List<Task>>> GetTasksByName(string taskName)
        {
            var query = _context.Tasks.AsQueryable();
            taskName = taskName.ToLower();

            query = query.Where(t => t.TaskName.ToLower().Contains(taskName));

            return await query.ToListAsync();
        }

        public async Task<Task> StartTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            try {
                task.TaskStatus = Akvelon_Task_Manager.Data.Enums.TaskStatus.InProgress;
                await _context.SaveChangesAsync();
            }
            catch(ArgumentNullException) {
                throw;
            }

            return task;
        }

        public async Task<Task> EndTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            try {
                task.TaskStatus = Akvelon_Task_Manager.Data.Enums.TaskStatus.Done;
                await _context.SaveChangesAsync();
            }
            catch(ArgumentNullException) {
                throw;
            }

            return task;
        }
    }
}