# Akvelon-TaskManager
This is the API for managing Projects and Tasks using differnt restAPI commands

## Installation and usage
Firslty you need to clone this repository to your environment. And then you have one of two options to run the code.

### On local machine
For this you need sdk and runtime for dotnet6 to run it on your machine.
Run this command on terminal inside project's directory:
```dotnet run```<br>
You can use it with swagger


### On docker container
For this you need Docker installed on your machine.
To run docker container run this command inside project's directory:
```docker-compose up```<br>
You can use app by going to the link: `http://localhost/api/Projects`<br>
To use sorting or filtering type: `http://localhost/api/Projects/getSortedProjects?orderBy=priority` or `http://localhost/api/Projects/getProjectsByName?projectName=someName`<br>
And the same procedures for Tasks endpoint<br><br>
You can sort Projects by priority, in the reverse order "priorityDesc", startDate, completionDate, by status/statusDesc.<br>
For the Tasks, you can use status/statusDesc and priority/priorityDesc.

## Project structure
### Presentation layer
The Presentation Layer consists of two Controllers. For Projects and Tasks. Inside they are uses injected Project and Task Repository Services. 
### Business logic layer
The Repository classes are core of my Business Logic Layer. They are injecting Context form DatabaseContext Service to get access to request data from Database. In the Logic Layer there are not another Service classes because this is simple CRUD application and it doesn't require any additional Services.
### Data access layer
The DAL consists of Models(schemas for Entities), Database Context class to managing Entities and it has 'Initializer' method for seeding the Database.<br>

## 'Program.cs' class Pipeline
  using System.Text.Json.Serialization;
  using Akvelon_Task_Manager.Configurations;
  using Akvelon_Task_Manager.Contracts;
  using Akvelon_Task_Manager.Converters;
  using Akvelon_Task_Manager.Data;
  using Akvelon_Task_Manager.Data.Managers;
  using Akvelon_Task_Manager.Repository;
  using Microsoft.EntityFrameworkCore;

  var builder = WebApplication.CreateBuilder(args);

  // Add services to the container.

  var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");  
  builder.Services.AddDbContext<AkvelonTaskManagerDbContext>(options => {                 // Establishing connection to sql server via dbcontext service
      options.UseSqlServer(connectionString);
  });

  builder.Services.AddControllers().AddJsonOptions(options => {
      options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());   // Adding json enum converter to properly work with them in swagger
      options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
      options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());  // Adding custom datetime converter we created
  });

  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();

  builder.Services.AddCors(options => {
      options.AddPolicy("AllowAll", b => b.AllowAnyHeader()   // Allowing cors to freely establish connection with other servers
          .AllowAnyMethod()                                    //  Also specifying policy options that will be available
          .AllowAnyOrigin());
  });

  builder.Services.AddAutoMapper(typeof(MapperConfig));   // Adding automapper service to app using our defined MapperConfig

  builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
  builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();                   // Adding Generic, Project and Task Repository services
  builder.Services.AddScoped<ITasksRepository, TasksRepository>();

  var app = builder.Build();

  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
      app.UseSwagger();
      app.UseSwaggerUI();
  }

  app.UseCors("AllowAll");

  app.UseHttpsRedirection();

  app.UseAuthorization();

  app.MapControllers();

  app.MigrateDatabase();  // Executing our automated databse migration method before running

  app.Run();



