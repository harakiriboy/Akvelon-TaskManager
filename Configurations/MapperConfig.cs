using Akvelon_Task_Manager.Data.Models;
using Akvelon_Task_Manager.DTOs.ProjectDTOs;
using Akvelon_Task_Manager.DTOs.TaskDTOs;
using AutoMapper;

namespace Akvelon_Task_Manager.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()   /// Mapper config file to automatically map entities with dtos
        {
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, GetProjectDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();

            CreateMap<Data.Models.Task, TaskDto>().ReverseMap();
            CreateMap<Data.Models.Task, CreateTaskDto>().ReverseMap();
            CreateMap<Data.Models.Task, UpdateTaskDto>().ReverseMap();
        }
    }
}