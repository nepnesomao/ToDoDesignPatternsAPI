using ToDoDesignPatternsAPI.Models;
using ToDoDesignPatternsAPI.Services.Abstraction;

namespace ToDoDesignPatternsAPI.Services;

public class AddTaskCommand : ICommand
{
    private readonly TaskService _taskService;
    private readonly string _taskName;
    private TodoTask _task;

    public AddTaskCommand(TaskService service, string taskName)
    {
        _taskService = service;
        _taskName = taskName;
    }
    
    public void Execute()
    {
        _task = new TodoTask(_taskName);
        _taskService.AddTaskAsync(_taskName, new RegularTaskFactory()).Wait();
    }

    public void Undo()
    {
        if (_task != null)
        {
            _taskService.RemoveTaskAsync(_task.Id);
        }
    }
}