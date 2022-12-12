using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akvelon_Task_Manager.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Akvelon_Task_Manager.Contracts
{
    public interface IProjectsRepository : IGenericRepository<Project>
    {
        Task<Project> GetDetails(int id);
        Task<ActionResult<List<Project>>> GetSortedProjects(string orderBy);
        Task<ActionResult<List<Project>>> GetProjectsByName(string projectName);
        Task<Project> StartProject(int id);
        Task<Project> EndProject(int id);
    }
}