using ToDoDesignPatternsAPI.Decorator;
using ToDoDesignPatternsAPI.Models;
using ToDoDesignPatternsAPI.Repositories.Abstraction;
using ToDoDesignPatternsAPI.Services.Abstraction;

namespace ToDoDesignPatternsAPI.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly ITaskManager _taskManager;
    private readonly CommandManager _commandManager = new();

    private readonly object lockObject = new object();

    // Singleton instance
    private static TaskService _instance;

    private TaskService(ITaskRepository taskRepository, ITaskManager taskManager)
    {
        _taskRepository = taskRepository;
        _taskManager = taskManager;
    }

    public static TaskService GetInstance(ITaskRepository taskRepository, ITaskManager taskManager)
    {
        if (_instance == null)
        {
            _instance = new TaskService(taskRepository, taskManager);
        }

        return _instance;
    }

    public async Task<IEnumerable<TodoTask>> GetAllTasksAsync()
    {
        return await _taskRepository.GetAllTasksAsync();
    }

    public async Task AddTaskAsync(string name, ITaskFactory taskFactory)
    {
        var task = taskFactory.CreateTask(name);
        await _taskRepository.AddTaskAsync(task);
        var command = new AddTaskCommand(this, task.Name);
        _taskManager.AddTask(task);
    }

    public async Task AddTaskWithReminderAsync(string name, DateTime reminderDate)
    {
        var task = new TodoTask(name);
        var reminder = new TaskWithReminderDecorator(task, reminderDate);
        await _taskRepository.AddTaskAsync(task);
        _taskManager.AddTask(task);
    }

    public async Task MarkTaskAsCompleted(int taskId)
    {
        var task = await _taskRepository.GetTaskByIdAsync(taskId);
        if (task is null)
        {
            return;
        }

        task.IsCompleted = true;
        await _taskRepository.UpdateTaskAsync(task);
        _taskManager.MarkTaskAsCompleted(taskId);
    }

    public void RemoveTaskAsync(int taskId)
    {
        _taskRepository.RemoveTaskAsync(taskId).Wait();
    }

    public async Task<TodoTask?> GetTaskByIdAsync(int taskId)
    {
        return await _taskRepository.GetTaskByIdAsync(taskId);
    }

    public async Task UpdateTaskAsync(TodoTask task)
    {
        await _taskRepository.UpdateTaskAsync(task);
    }
}