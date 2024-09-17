using ToDoDesignPatternsAPI.Models;
using ToDoDesignPatternsAPI.Services.Abstraction;

namespace ToDoDesignPatternsAPI.Services;

public class RegularTaskFactory : ITaskFactory
{
    public TodoTask CreateTask(string name)
    {
        return new RegularTask(name);
    }
}