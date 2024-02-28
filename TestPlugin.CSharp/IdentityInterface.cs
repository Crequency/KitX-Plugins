using KitX.Contract.CSharp;
using KitX.Shared.CSharp.Plugin;

namespace TestPlugin.CSharp;

public class IdentityInterface : IIdentityInterface
{
    public IController GetController() => new Controller();

    public IMarketPluginContract GetMarketPluginContract() => null!;

    public PluginInfo GetPluginInfo() => new()
    {
        Name = "TestPlugin.CSharp",
        Version = "v0.1.0",
        DisplayName = new()
        {
            { "zh-cn", "适用于 C# 的 KitX 测试用插件" },
            { "zh-tw", "適用於 C# 的 KitX 測試用插件" },
            { "en-us", "KitX Testing Plugin for C#" },
        },
        AuthorName = "Dynesshely",
        AuthorLink = "https://blog.catrol.cn",
        PublisherName = "Crequency",
        PublisherLink = "https://catrol.cn",
        SimpleDescription = new()
        {
            { "zh-cn", "KitX 测试用插件" },
            { "zh-tw", "KitX 測試用插件" },
            { "en-us", "KitX Test Plugin" },
        },
        ComplexDescription = new()
        {
            { "zh-cn", "KitX 测试用插件, 使用 KitX.Loader.CSharp 作为加载器." },
            { "zh-tw", "KitX 測試用插件, 使用 KitX.Loader.CSharp 作爲加載器." },
            { "en-us", "KitX Test Plugin, use KitX.Loader.CSharp as loader." },
        },
        TotalDescriptionInMarkdown = new()
        {
            {
                "zh-cn",
                """
                # 关于
                这是一个适用于 C# 的 KitX 测试用插件
                使用 KitX.Loader.CSharp 作为加载器
                """
            },
            {
                "zh-tw",
                """
                # 關於
                這是一個適用於 C# 的 KitX 測試用插件
                使用 KitX.Loader.CSharp 作爲加載器
                """
            },
            {
                "en-us",
                """
                # About
                This is a KitX Test Plugin for C#
                Use KitX.Loader.CSharp as loader
                """
            },
        },
        IconInBase64 = "Icon",
        PublishDate = DateTime.Now,
        LastUpdateDate = DateTime.Now,
        IsMarketVersion = false,
        RootStartupFileName = "TestPlugin.CSharp.dll",
        Tags = [],
        Functions = []
    };
}
