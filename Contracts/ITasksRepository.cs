using Microsoft.AspNetCore.Mvc;
using Task = Akvelon_Task_Manager.Data.Models.Task;

namespace Akvelon_Task_Manager.Contracts
{
    public interface ITasksRepository : IGenericRepository<Task>
    {
        Task<ActionResult<List<Task>>> GetSortedTasks(string orderBy);
        Task<ActionResult<List<Task>>> GetTasksByName(string taskName);
        Task<Task> StartTask(int id);
        Task<Task> EndTask(int id);
    }
}