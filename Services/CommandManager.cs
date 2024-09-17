using ToDoDesignPatternsAPI.Services.Abstraction;

namespace ToDoDesignPatternsAPI.Services;

public class CommandManager
{
    private readonly Stack<ICommand> _commandHistory = new();
    
    
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }
    
    public void Undo()
    {
        if (_commandHistory.Count == 0)
        {
            return;
        }
        
        var command = _commandHistory.Pop();
        command.Undo();
    }
}