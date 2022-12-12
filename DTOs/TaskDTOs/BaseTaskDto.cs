using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon_Task_Manager.DTOs.TaskDTOs
{
    public class BaseTaskDto
    {
        public string TaskName { get; set; }
        public int TaskPriority { get; set; }
        public int ProjectId { get; set; }
    }
}