using KitX.Contract.CSharp;
using KitX.Web.Rules;
using System.Text.Json;

namespace TestPlugin.CSharp;

public class Controller : IController
{
    private Queue<Command>? commands;

    public void Start()
    {
        Console.WriteLine("Started");
    }

    public void Pause()
    {
        Console.WriteLine("Paused");
    }

    public void End()
    {
        Console.WriteLine("Ended");
    }

    public void Execute(Command cmd)
    {
        Console.WriteLine($"Execute: {JsonSerializer.Serialize(cmd)}");
    }

    public List<Function> GetFunctions()
    {
        return new();
    }

    public void SetCommandsSendBuffer(ref Queue<Command> commands)
    {
        this.commands = commands;
    }

    public void SetRootPath(string path)
    {
        Console.WriteLine($"Root path: {path}");
    }

    public void SetWorkPath(string path)
    {
        Console.WriteLine($"Work path: {path}");
    }
}
