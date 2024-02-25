using KitX.Contract.CSharp;
using KitX.Shared.Plugin;

namespace TestPlugin.Winform.Core;

public class IdentityInterface : IIdentityInterface
{
    public IController GetController() => new Controller();

    public IMarketPluginContract GetMarketPluginContract() => null!;

    public PluginInfo GetPluginInfo() => new()
    {
        Name = "TestPlugin.Winform.Core",
        Version = "v0.1.0",
        AuthorName = "Dynesshely",
        AuthorLink = "https://blog.catrol.cn",
        PublisherName = "Crequency",
        PublisherLink = "https://catrol.cn",
        DisplayName = new()
        {
            { "zh-cn", "适用于 C# Winform 框架的 KitX 测试用插件" },
            { "zh-tw", "適用於 C# Winform 框架的 KitX 測試用插件" },
            { "en-us", "KitX Testing Plugin for C# with Winform framework" },

        },
        SimpleDescription = new()
        {
            { "zh-cn", "KitX 测试用插件" },
            { "zh-tw", "KitX 測試用插件" },
            { "en-us", "KitX Test Plugin" },
        },
        ComplexDescription = new()
        {
            { "zh-cn", "KitX 测试用插件, 使用 KitX.Loader.Winform.Core 作为加载器." },
            { "zh-tw", "KitX 測試用插件, 使用 KitX.Loader.Winform.Core 作爲加載器." },
            { "en-us", "KitX Test Plugin, use KitX.Loader.Winform.Core as loader." },
        },
        TotalDescriptionInMarkdown = new()
        {
            { "zh-cn", "Nope" },
            { "zh-tw", "Nope" },
            { "en-us", "Nope" },
        },
        IconInBase64 = "Icon",
        PublishDate = DateTime.Now,
        LastUpdateDate = DateTime.Now,
        IsMarketVersion = false,
        RootStartupFileName = "TestPlugin.Winform.Core.dll",
    };
}
