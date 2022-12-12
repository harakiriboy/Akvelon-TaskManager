using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akvelon_Task_Manager.Data.Enums;

namespace Akvelon_Task_Manager.Data.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public int ProjectPriority { get; set; }

        public IList<Task> Tasks { get; set; }
    }
}