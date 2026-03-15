using System.Text;
using System.Text.Json;
using KitX.Contract.CSharp;
using KitX.Shared.CSharp.Plugin;
using KitX.Shared.CSharp.WebCommand;
using KitX.Shared.CSharp.WebCommand.Details;
using KitX.Shared.CSharp.WebCommand.Infos;

namespace TestPlugin.CSharp;

public class Controller : IController
{
    private Action<Request>? sendCommandAction;

    private static readonly JsonSerializerOptions serializerOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true,
        PropertyNameCaseInsensitive = true,
    };

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

        // 从 Tags 中获取 RequestId，用于发送响应
        string? requestId = null;
        if (cmd.Tags is not null && cmd.Tags.TryGetValue("RequestId", out var reqId))
        {
            requestId = reqId;
        }

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

            // 如果有 RequestId，发送响应
            if (requestId is not null && sendCommandAction is not null)
            {
                var responseBytes = Encoding.UTF8.GetBytes(result);

                var responseCommand = new Command
                {
                    Request = CommandRequestInfo.ReceiveCommand,
                    PluginConnectionId = cmd.PluginConnectionId ?? string.Empty,
                    Body = responseBytes,
                    BodyLength = responseBytes.Length,
                    Tags = new Dictionary<string, string>
                    {
                        { "RequestId", requestId }
                    }
                };

                var responseRequest = new Request
                {
                    Content = JsonSerializer.Serialize(responseCommand, serializerOptions)
                };

                sendCommandAction.Invoke(responseRequest);
                Console.WriteLine($"[DEBUG] Response sent via sendCommandAction: {result}");
            }
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
