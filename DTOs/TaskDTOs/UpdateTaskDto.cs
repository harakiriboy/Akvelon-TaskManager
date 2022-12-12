using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon_Task_Manager.DTOs.TaskDTOs
{
    public class UpdateTaskDto : BaseTaskDto
    {
        public int Id { get; set; }
    }
}