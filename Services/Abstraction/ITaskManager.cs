using ToDoDesignPatternsAPI.Models;

namespace ToDoDesignPatternsAPI.Services.Abstraction;

public interface ITaskManager
{
    void AddTask(TodoTask task);
    void MarkTaskAsCompleted(int taskId);
    void RegisterObserver(ITaskObserver observer);
    void RemoveObserver(ITaskObserver observer);
}