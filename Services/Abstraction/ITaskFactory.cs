using ToDoDesignPatternsAPI.Models;

namespace ToDoDesignPatternsAPI.Services.Abstraction;

public interface ITaskFactory
{
    TodoTask CreateTask(string name);
}