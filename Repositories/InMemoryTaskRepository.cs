using ToDoDesignPatternsAPI.Models;
using ToDoDesignPatternsAPI.Repositories.Abstraction;

namespace ToDoDesignPatternsAPI.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private List<TodoTask> _tasks = new List<TodoTask>();

    public async Task<IEnumerable<TodoTask>> GetAllTasksAsync()
    {
        return await Task.FromResult(_tasks);
    }

    public async Task<TodoTask> GetTaskByIdAsync(int id)
    {
        return await Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));
    }

    public async Task AddTaskAsync(TodoTask task)
    {
        _tasks.Add(task);
        await Task.CompletedTask;
    }

    public Task UpdateTaskAsync(TodoTask task)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask == null)
        {
            return Task.CompletedTask;
        }

        existingTask.Name = task.Name;
        existingTask.IsCompleted = task.IsCompleted;
        return Task.CompletedTask;
    }

    public Task RemoveTaskAsync(int taskId)
    {
        var task = _tasks.First(x => x.Id==taskId);
       _tasks.Remove(task);
       return Task.CompletedTask;
    }
}