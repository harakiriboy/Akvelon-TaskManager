using Akvelon_Task_Manager.Contracts;
using Akvelon_Task_Manager.Data.Models;
using Akvelon_Task_Manager.DTOs.TaskDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = Akvelon_Task_Manager.Data.Models.Task;

namespace Akvelon_Task_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMapper _mapper;  // Injecting mapper to map entities and visible to user controller DTOs
        private readonly ITasksRepository _repo;  // Injecting repo to use methods from Tasks repository 
        public TasksController(IMapper mapper, ITasksRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var tasks = await _repo.GetAllAsync();
            var records = _mapper.Map<List<TaskDto>>(tasks);
            return Ok(records);
        }

        [HttpGet("getSortedTasks")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetSortedTasks(string orderBy)
        {
            var tasks = await _repo.GetSortedTasks(orderBy);
            //var records = _mapper.Map<List<GetProjectDto>>(projects);
            return Ok(tasks);
        }

        [HttpGet("getTasksByName")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksByName(string taskName)
        {
            var tasks = await _repo.GetTasksByName(taskName);
            return Ok(tasks);
        }

        [HttpGet("startTask")]
        public async Task<ActionResult<TaskDto>> StartTask(int id)
        {
            var task = await _repo.StartTask(id);
            return Ok(task);
        }

        [HttpGet("endTask")]
        public async Task<ActionResult<TaskDto>> EndTask(int id)
        {
            var task = await _repo.EndTask(id);
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(int id)
        {
            var task = await _repo.GetAsync(id);

            if (task == null) return NotFound();

            var record = _mapper.Map<TaskDto>(task);

            return Ok(record);
        }

        private async Task<bool> TaskExists(int id)
        {
            return await _repo.Exists(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, UpdateTaskDto updateTaskDto)
        {
            if (id != updateTaskDto.Id) return BadRequest("Invalid record Id");

            var task = await _repo.GetAsync(id);
            if(task == null) return NotFound();

            _mapper.Map(updateTaskDto, task);

            try {
                await _repo.UpdateAsync(task);
            }
            catch(DbUpdateConcurrencyException) {
                if (!await TaskExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Task>> PostTask(CreateTaskDto taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);
            await _repo.AddAsync(task);
            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var project = await _repo.GetAsync(id);
            if(project == null) return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent();
        }  
    }
}