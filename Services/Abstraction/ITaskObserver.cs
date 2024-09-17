using ToDoDesignPatternsAPI.Models;

namespace ToDoDesignPatternsAPI.Services.Abstraction;

public interface ITaskObserver
{
    void Update(TodoTask task);
}