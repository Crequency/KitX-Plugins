﻿using System.Text.Json;
using KitX.Contract.CSharp;
using KitX.Shared.CSharp.Plugin;
using KitX.Shared.CSharp.WebCommand;
using KitX.Shared.CSharp.WebCommand.Details;

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
