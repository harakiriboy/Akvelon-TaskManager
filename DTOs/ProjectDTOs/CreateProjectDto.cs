using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon_Task_Manager.DTOs.ProjectDTOs
{
    public class CreateProjectDto : BaseProjectDto
    {
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}