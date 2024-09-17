using Microsoft.AspNetCore.Mvc;
using ToDoDesignPatternsAPI.DTOs;
using ToDoDesignPatternsAPI.Models;
using ToDoDesignPatternsAPI.Services;
using ToDoDesignPatternsAPI.Services.Abstraction;

namespace ToDoDesignPatternsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;
    private readonly ITaskManager _taskManager;

    public TasksController(TaskService taskService, ITaskManager taskManager)
    {
        _taskService = taskService;
        var logger = new TaskCompletionLogger();
        var notifier = new TaskCompletionNotifier();

        _taskManager = taskManager;
        _taskManager.RegisterObserver(logger);
        _taskManager.RegisterObserver(notifier);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpPost]
    [Route("create-regular-task")]
    public async Task<IActionResult> CreateRegularTask([FromBody] CreateTaskDto taskDTO)
    {
        var factory = new RegularTaskFactory();
        await _taskService.AddTaskAsync(taskDTO.Name, factory);
        return Ok("Regular task created successfully.");
    }

    [HttpPost]
    [Route("create-important-task")]
    public async Task<IActionResult> CreateImportantTask([FromBody] CreateTaskDto taskDTO)
    {
        var factory = new ImportantTaskFactory();
        await _taskService.AddTaskAsync(taskDTO.Name, factory);
        return Ok("Important task created successfully.");
    }

    [HttpPost]
    [Route("complete-task/{taskId}")]
    public async Task<IActionResult> CompleteTask(int taskId)
    {
        await _taskService.MarkTaskAsCompleted(taskId);
        return Ok("Task marked as completed and observers notified.");
    }
}