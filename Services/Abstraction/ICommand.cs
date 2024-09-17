namespace ToDoDesignPatternsAPI.Services.Abstraction;

public interface ICommand
{
    void Execute();
    void Undo();
}