using Akvelon_Task_Manager.Contracts;
using Akvelon_Task_Manager.Data;
using Akvelon_Task_Manager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Akvelon_Task_Manager.Repository
{
    public class ProjectsRepository : GenericRepository<Project>, IProjectsRepository  // Inheriting from generic repository with iprojects repository
    {                                                                                  // together to implement aldo tasks specific methods
        public AkvelonTaskManagerDbContext _context { get; set;}
        public ProjectsRepository(AkvelonTaskManagerDbContext context) : base(context)    // Injecting database context
        {
            _context = context;
        }

        public async Task<Project> GetDetails(int id)
        {
            return await _context.Projects.Include(q => q.Tasks)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<ActionResult<List<Project>>> GetSortedProjects(string orderBy)
        {
            var query = _context.Projects.AsQueryable();

            query = orderBy switch
            {
                "status" => query.OrderBy(s => s.ProjectStatus),
                "statusDesc" => query.OrderByDescending(s => s.ProjectStatus),
                "priority" => query.OrderBy(p => p.ProjectPriority),
                "priorityDesc" => query.OrderByDescending(p => p.ProjectPriority),
                "startDate" => query.OrderBy(s => s.StartDate),
                "completionDate" => query.OrderBy(c => c.CompletionDate),
                _ => query.OrderBy(n => n.ProjectName)
            };

            return await query.ToListAsync();
        }

        public async Task<ActionResult<List<Project>>> GetProjectsByName(string projectName)
        {
            var query = _context.Projects.AsQueryable();
            projectName = projectName.ToLower();

            query = query.Where(t => t.ProjectName.ToLower().Contains(projectName));

            return await query.ToListAsync();
        }

        public async Task<Project> StartProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            try {
                project.ProjectStatus = Akvelon_Task_Manager.Data.Enums.ProjectStatus.Active;
                await _context.SaveChangesAsync();
            }
            catch(ArgumentNullException) {
                throw;
            }

            return project;
        }

        public async Task<Project> EndProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            try {
                project.ProjectStatus = Akvelon_Task_Manager.Data.Enums.ProjectStatus.Completed;
                await _context.SaveChangesAsync();
            }
            catch(ArgumentNullException) {
                throw;
            }

            return project;
        }
    }
}