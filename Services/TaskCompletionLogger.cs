using ToDoDesignPatternsAPI.Models;
using ToDoDesignPatternsAPI.Services.Abstraction;

namespace ToDoDesignPatternsAPI.Services;

public class TaskCompletionLogger : ITaskObserver
{
    public void Update(TodoTask task)
    {
        if (task.IsCompleted)
        {
            Console.WriteLine($"Task {task.Name} has been completed.");
        }
    }
}