using ToDoDesignPatternsAPI.Models;

namespace ToDoDesignPatternsAPI.Decorator;

public class TaskWithReminderDecorator : TaskDecorator
{
    public DateTime Reminder { get; set; }
    
    public TaskWithReminderDecorator(ITodoTask task, DateTime reminder) : base(task)
    {
        Reminder = reminder;
    }
}