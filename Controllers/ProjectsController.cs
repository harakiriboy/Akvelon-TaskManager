using Akvelon_Task_Manager.Contracts;
using Akvelon_Task_Manager.Data.Models;
using Akvelon_Task_Manager.DTOs.ProjectDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Akvelon_Task_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMapper _mapper;  // Injecting mapper to map entities and visible to user controller DTOs
        private readonly IProjectsRepository _repo;  // Injecting repo to use methods from Projects repository 
        public ProjectsController(IMapper mapper, IProjectsRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Implementing contoller endpoint methods

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProjectDto>>> GetProjects()
        {
            var projects = await _repo.GetAllAsync();
            var records = _mapper.Map<List<GetProjectDto>>(projects);
            return Ok(records);
        }

        [HttpGet("getSortedProjects")]
        public async Task<ActionResult<IEnumerable<GetProjectDto>>> GetSortedProjects(string orderBy)
        {
            var projects = await _repo.GetSortedProjects(orderBy);
            //var records = _mapper.Map<List<GetProjectDto>>(projects);
            return Ok(projects);
        }

        [HttpGet("getProjectsByName")]
        public async Task<ActionResult<IEnumerable<GetProjectDto>>> GetProjectsByName(string projectName)
        {
            var projects = await _repo.GetProjectsByName(projectName);
            return Ok(projects);
        }

        [HttpGet("startProject")]
        public async Task<ActionResult<GetProjectDto>> StartProject(int id)
        {
            var project = await _repo.StartProject(id);
            return Ok(project);
        }

        [HttpGet("endProject")]
        public async Task<ActionResult<GetProjectDto>> EndProject(int id)
        {
            var project = await _repo.EndProject(id);
            return Ok(project);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var project = await _repo.GetDetails(id);

            if (project == null) return NotFound();

            var record = _mapper.Map<ProjectDto>(project);

            return Ok(record);
        }

        private async Task<bool> ProjectExists(int id)
        {
            return await _repo.Exists(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, UpdateProjectDto updateProjectDto)
        {
            if (id != updateProjectDto.Id) return BadRequest("Invalid record Id");

            var project = await _repo.GetAsync(id);
            if(project == null) return NotFound();

            _mapper.Map(updateProjectDto, project);

            try {
                await _repo.UpdateAsync(project);
            }
            catch(DbUpdateConcurrencyException) {
                if (!await ProjectExists(id))
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
        public async Task<ActionResult<Project>> PostProject(CreateProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _repo.AddAsync(project);
            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _repo.GetAsync(id);
            if(project == null) return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}