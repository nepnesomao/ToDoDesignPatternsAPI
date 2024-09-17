using ToDoDesignPatternsAPI.Models;
using ToDoDesignPatternsAPI.Services.Abstraction;

namespace ToDoDesignPatternsAPI.Services;

public class TaskManager : ITaskManager
{
    private List<TodoTask> _tasks = new List<TodoTask>();
    private List<ITaskObserver> _observers = new List<ITaskObserver>();


    public void AddTask(TodoTask task)
    {
        _tasks.Add(task);
    }

    public void MarkTaskAsCompleted(int taskId)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            task.IsCompleted = true;
            NotifyObservers(task);
        }
    }

    public void RegisterObserver(ITaskObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(ITaskObserver observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyObservers(TodoTask task)
    {
        foreach (var observer in _observers)
        {
            observer.Update(task);
        }
    }
}