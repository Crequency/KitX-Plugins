using System.Text.Json;
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

        if (cmd.FunctionName == "SayHello")
        {
            // 从参数中获取 name
            var name = "World"; // 默认值

            if (cmd.FunctionArgs is not null && cmd.FunctionArgs.Count > 0)
            {
                var firstArg = cmd.FunctionArgs[0];
                name = firstArg.Value ?? "World";
            }

            var result = $"Hello, {name}!";
            Console.WriteLine($"SayHello result: {result}");
        }
    }

    public List<Function> GetFunctions()
    {
        return [
            new Function()
            {
                Name = "SayHello",
                DisplayNames = new()
                {
                    { "zh-cn", "打招呼" },
                    { "zh-tw", "打招呼" },
                    { "en-us", "Say Hello" },
                },
                ReturnValueType = "string",
                Parameters = [
                    new Parameter()
                    {
                        Name = "name",
                        Type = "string",
                        DisplayNames = new()
                        {
                            { "zh-cn", "姓名" },
                            { "zh-tw", "姓名" },
                            { "en-us", "Name" },
                        },
                        IsOptional = false,
                    }
                ],
            }
        ];
    }

    public void SetSendCommandAction(Action<Request> action) => sendCommandAction = action;

    public void SetWorkingDetail(PluginWorkingDetail workingDetail) => Console.WriteLine(
        $"WorkingDetail: {JsonSerializer.Serialize(workingDetail)}"
    );
}
