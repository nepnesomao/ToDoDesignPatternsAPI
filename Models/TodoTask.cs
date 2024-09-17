using ToDoDesignPatternsAPI.Models.Helpers;

namespace ToDoDesignPatternsAPI.Models;

public class TodoTask : ITodoTask
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public void CompleteTask()
    {
        IsCompleted = true;
    }

    public TodoTask(string name)
    {
        this.Name = name;
        this.IsCompleted = false;
    }
}