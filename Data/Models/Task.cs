using System.ComponentModel.DataAnnotations.Schema;
using Akvelon_Task_Manager.Data.Enums;
using TaskStatus = Akvelon_Task_Manager.Data.Enums.TaskStatus;

namespace Akvelon_Task_Manager.Data.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int TaskPriority { get; set; }
        
        // Navigation properties
        [ForeignKey(nameof(ProjectId))]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}