namespace ToDoDesignPatternsAPI.Models;

public interface ITodoTask
{
    int Id { get; set; }
    string Name { get; set; }
    bool IsCompleted { get; set; }
    void CompleteTask(); 
}