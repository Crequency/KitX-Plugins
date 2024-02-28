using KitX.Contract.CSharp;
using KitX.Shared.CSharp.WebCommand;
using KitX.Shared.CSharp.WebCommand.Details;
using System.Text.Json;

namespace TestPlugin.Winform.Core;

public class Controller : IController
{
    private Action<Request>? sendCommandAction;

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

    public void SetSendCommandAction(Action<Request> action) => sendCommandAction = action;

    public void SetWorkingDetail(PluginWorkingDetail workingDetail) => MessageBox.Show(
        JsonSerializer.Serialize(workingDetail)
    );
}
