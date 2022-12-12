using Akvelon_Task_Manager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Task = Akvelon_Task_Manager.Data.Models.Task;

namespace Akvelon_Task_Manager.Data
{
    public class AkvelonTaskManagerDbContext : DbContext
    {
        public AkvelonTaskManagerDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    ProjectName = "Web Api Project",
                    StartDate = new DateTime(2022, 12, 08),
                    CompletionDate = new DateTime(2022, 12, 23),
                    ProjectStatus = Enums.ProjectStatus.NotStarted,
                    ProjectPriority = 1
                },
                new Project
                {
                    Id = 2,
                    ProjectName = "Client Server Project",
                    StartDate = new DateTime(2022, 12, 15),
                    CompletionDate = new DateTime(2022, 12, 20),
                    ProjectStatus = Enums.ProjectStatus.NotStarted,
                    ProjectPriority = 2
                },
                new Project
                {
                    Id = 3,
                    ProjectName = "Machine Learning Project",
                    StartDate = new DateTime(2022, 12, 20),
                    CompletionDate = new DateTime(2022, 12, 29),
                    ProjectStatus = Enums.ProjectStatus.NotStarted,
                    ProjectPriority = 3
                }
            );

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1,
                    TaskName = "Create Models",
                    TaskStatus = Enums.TaskStatus.ToDo,
                    TaskPriority = 1,
                    ProjectId = 2
                }, 
                new Task
                {
                    Id = 2,
                    TaskName = "Collect Dataset",
                    TaskStatus = Enums.TaskStatus.ToDo,
                    TaskPriority = 2,
                    ProjectId = 3
                }, 
                new Task
                {
                    Id = 3,
                    TaskName = "Create From CLI",
                    TaskStatus = Enums.TaskStatus.ToDo,
                    TaskPriority = 3,
                    ProjectId = 1
                } 
            );
        }
    }
}