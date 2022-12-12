using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Akvelon_Task_Manager.Data.Enums;

namespace Akvelon_Task_Manager.DTOs.ProjectDTOs
{
    public class BaseProjectDto
    {
        [Required]
        public string ProjectName { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public int ProjectPriority { get; set; }
    }
}