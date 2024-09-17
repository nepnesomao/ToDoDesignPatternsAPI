using ToDoDesignPatternsAPI.Models;

namespace ToDoDesignPatternsAPI.Repositories.Abstraction;

public interface ITaskRepository
{
    Task<IEnumerable<TodoTask>> GetAllTasksAsync();
    Task<TodoTask> GetTaskByIdAsync(int id);
    Task AddTaskAsync(TodoTask task);
    Task UpdateTaskAsync(TodoTask task);
    Task RemoveTaskAsync(int taskId);
}