using ToDoDesignPatternsAPI.Repositories;
using ToDoDesignPatternsAPI.Repositories.Abstraction;
using ToDoDesignPatternsAPI.Services;
using ToDoDesignPatternsAPI.Services.Abstraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITaskManager, TaskManager>();
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddSingleton(provider => TaskService.GetInstance(provider.GetService<ITaskRepository>(), provider.GetService<ITaskManager>()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();