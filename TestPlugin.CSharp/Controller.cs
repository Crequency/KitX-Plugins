using KitX.Contract.CSharp;
using KitX.Shared.Plugin;
using KitX.Shared.WebCommand;
using KitX.Shared.WebCommand.Details;
using System.Text.Json;

namespace TestPlugin.CSharp;

public class Controller : IController
{
    private Action<Request>? sendCommandAction;

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
        return [];
    }

    public void SetSendCommandAction(Action<Request> action) => sendCommandAction = action;

    public void SetWorkingDetail(PluginWorkingDetail workingDetail) => Console.WriteLine(
        $"WorkingDetail: {JsonSerializer.Serialize(workingDetail)}"
    );
}
