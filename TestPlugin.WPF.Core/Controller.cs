using System;
using System.Text;
using System.Text.Json;
using System.Windows;
using KitX.Contract.CSharp;
using KitX.Shared.CSharp.WebCommand;
using KitX.Shared.CSharp.WebCommand.Details;

namespace TestPlugin.WPF.Core;

public class Controller(MainWindow mainwin) : IController
{
    private readonly MainWindow mainwin = mainwin;

    private static readonly JsonSerializerOptions _serializerOptions = new()
    {
        WriteIndented = false,
        IncludeFields = true,
        PropertyNameCaseInsensitive = true,
    };

    public PluginWorkingDetail? WorkingDetail { get; set; }

    public void End()
    {
        mainwin.Close();
    }

    public void Pause()
    {
        mainwin.Hide();
    }

    public void Start()
    {
        mainwin.Show();
    }

    public void Execute(Command command)
    {
        if (command.FunctionName.Equals("HelloKitX"))
        {
            Functions.HelloKitX();
        }
        else if (command.FunctionName.Equals("HelloAnything"))
        {
            var name = command.FunctionArgs != null && command.FunctionArgs.Count > 0 ? command.FunctionArgs[0].Value : "Anything";
            Functions.HelloAnything(name);
        }
        else if (command.FunctionName.Equals("GetInput"))
        {
            var inputText = mainwin.GetInputText();
            var bodyBytes = Encoding.UTF8.GetBytes(inputText);
            mainwin.sendCommandAction?.Invoke(new Request
            {
                Type = RequestTypes.Command,
                Version = RequestVersions.V1,
                Content = JsonSerializer.Serialize(new Command
                {
                    Tags = command.Tags, // 保留 RequestId 用于响应匹配
                    Body = bodyBytes,
                    BodyLength = bodyBytes.Length
                }, _serializerOptions)
            });
        }
    }

    public void SetWorkingDetail(PluginWorkingDetail workingDetail) => WorkingDetail = workingDetail;

    public void SetSendCommandAction(Action<Request> action) => mainwin.sendCommandAction = action;
}
