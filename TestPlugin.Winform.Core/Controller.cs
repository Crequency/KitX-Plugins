using KitX.Contract.CSharp;
using KitX.Web.Rules;
using System.Text.Json;

namespace TestPlugin.Winform.Core;

public class Controller : IController
{
    private Action<Command>? sendCommandAction;

    public void Start()
    {
        Application.Run(new MainForm());
        Environment.Exit(0);
    }

    public void Pause()
    {

    }

    public void End()
    {
        Application.Exit();
        Environment.Exit(0);
    }

    public void Execute(Command cmd)
    {
        Console.WriteLine($"Execute: {JsonSerializer.Serialize(cmd)}");
    }

    public List<Function> GetFunctions()
    {
        return new();
    }

    public void SetSendCommandAction(Action<Command> action) => sendCommandAction = action;

    public void SetRootPath(string path)
    {
        Console.WriteLine($"Root path: {path}");
    }

    public void SetWorkPath(string path)
    {
        Console.WriteLine($"Work path: {path}");
    }
}
