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
