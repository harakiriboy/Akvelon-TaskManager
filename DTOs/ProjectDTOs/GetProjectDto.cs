using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon_Task_Manager.DTOs.ProjectDTOs
{
    public class GetProjectDto : BaseProjectDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}