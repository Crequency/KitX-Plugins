using KitX.Contract.CSharp;
using KitX.Shared.Plugin;
using KitX.Shared.WebCommand;
using System;
using System.Reflection;
using System.Windows;

namespace TestPlugin.WPF.Core;

public partial class MainWindow : Window, IIdentityInterface
{
    private readonly Controller controller;

    internal Action<Request>? sendCommandAction;

    public MainWindow()
    {
        InitializeComponent();

        controller = new(this);

        Closed += (_, _) => Environment.Exit(0);
    }

    public PluginInfo GetPluginInfo() => new()
    {
        Name = "TestPlugin.WPF.Core",
        DisplayName = new()
        {
            { "zh-cn", "TestPlugin.WPF.Core" },
            { "en-us", "TestPlugin.WPF.Core" },
        },
        Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "",
        AuthorLink = "https://github.com/Crequency/KitX/",
        AuthorName = "Crequency",
        PublisherLink = "https://github.com/Crequency/",
        PublisherName = "Crequency",
        PublishDate = DateTime.Now,
        LastUpdateDate = DateTime.Now,
        SimpleDescription = new()
        {
            { "zh-cn", "TestPlugin.WPF.Core" },
            { "en-us", "TestPlugin.WPF.Core" },
        },
        ComplexDescription = new()
        {
            { "zh-cn", "用于测试于验证 WPF.Core 框架下的插件可行性" },
            { "en-us", "Used to test and verify the feasibility of plug-ins under the WPF.Core framework" },
        },
        TotalDescriptionInMarkdown = new()
        {
            {
                "zh-cn",
                """
                # 你好!
                ```cpp
                void helloWorld(string greet) {
                    std::cout << "Hello, World!";
                }
                ```
                """
            },
            {
                "en-us",
                """
                # Hi, there!
                ```cpp
                void helloWorld(string greet) {
                    std::cout << "Hello, World!";
                }
                ```
                """
            },
        },
        IconInBase64 = "",
        IsMarketVersion = false,
        RootStartupFileName = "TestPlugin.WPF.Core.dll",
        Functions = [
            new Function()
            {
                Name = "HelloKitX",
                DisplayNames = new()
                {
                    { "zh-cn", "你好 KitX !" },
                    { "en-us", "Hello KitX !" },
                },
                ReturnValueType = "void",
                Parameters = [],
            },
        ],
        Tags = new()
        {
            { "IsTestPlugin", "true" }
        },
    };

    public IController GetController() => controller;

    public IMarketPluginContract GetMarketPluginContract() => null!;
}
