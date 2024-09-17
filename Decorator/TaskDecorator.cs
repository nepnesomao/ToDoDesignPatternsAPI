using ToDoDesignPatternsAPI.Models;

namespace ToDoDesignPatternsAPI.Decorator;

public class TaskDecorator : ITodoTask
{
    protected ITodoTask _task;

    public TaskDecorator(ITodoTask task)
    {
        _task = task;
    }
    
    public int Id
    {
        get => _task.Id;
        set => _task.Id = value;
    }

    public string Name
    {
        get => _task.Name;
        set => _task.Name = value;
    }

    public bool IsCompleted
    {
        get => _task.IsCompleted;
        set => _task.IsCompleted = value;
    }

    public virtual void CompleteTask()
    {
        _task.CompleteTask();
    }
}