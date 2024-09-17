using ToDoDesignPatternsAPI.Models;
using ToDoDesignPatternsAPI.Services.Abstraction;

namespace ToDoDesignPatternsAPI.Services;

public class CompleteTaskCommand : ICommand
{
    private readonly TaskService _taskService;
    private readonly int _taskId;
    private bool _previousState;

    public CompleteTaskCommand(TaskService service, int taskId)
    {
        _taskService = service;
        _taskId = taskId;
    }
    
    public void Execute()
    {
        var task = _taskService.GetTaskByIdAsync(_taskId).Result;
        if (task is null)
        {
            return;
        }
        
        _previousState = task.IsCompleted;
        _taskService.MarkTaskAsCompleted(_taskId).Wait();
    }

    public void Undo()
    {
        var task = _taskService.GetTaskByIdAsync(_taskId).Result;
        if (task is null)
        {
            return;
        }
        
        task.IsCompleted = _previousState;
        _taskService.UpdateTaskAsync(task).Wait();
    }
}