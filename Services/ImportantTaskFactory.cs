using ToDoDesignPatternsAPI.Models;
using ToDoDesignPatternsAPI.Services.Abstraction;

namespace ToDoDesignPatternsAPI.Services;

public class ImportantTaskFactory : ITaskFactory
{
    public TodoTask CreateTask(string name)
    {
        return new ImportantTask(name);
    }
}