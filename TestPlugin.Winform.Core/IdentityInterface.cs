using KitX.Contract.CSharp;

namespace TestPlugin.Winform.Core;

public class IdentityInterface : IIdentityInterface
{
    public string GetName() => "TestPlugin.Winform.Core";

    public string GetVersion() => "v0.1.0";

    public Dictionary<string, string> GetDisplayName() => new()
        {
            { "zh-cn", "适用于 C# Winform 框架的 KitX 测试用插件" },
            { "zh-cnt", "適用於 C# Winform 框架的 KitX 測試用插件" },
            { "en-us", "KitX Testing Plugin for C# with Winform framework" },
        };

    public string GetAuthorName() => "Dynesshely";

    public string GetPublisherName() => "Crequency";

    public string GetAuthorLink() => "https://blog.catrol.cn";

    public string GetPublisherLink() => "https://catrol.cn";

    public Dictionary<string, string> GetSimpleDescription() => new()
        {
            { "zh-cn", "KitX 测试用插件" },
            { "zh-cnt", "KitX 測試用插件" },
            { "en-us", "KitX Test Plugin" },
        };

    public Dictionary<string, string> GetComplexDescription() => new()
        {
            { "zh-cn", "KitX 测试用插件, 使用 KitX.Loader.Winform.Core 作为加载器." },
            { "zh-cnt", "KitX 測試用插件, 使用 KitX.Loader.Winform.Core 作爲加載器." },
            { "en-us", "KitX Test Plugin, use KitX.Loader.Winform.Core as loader." },
        };

    public Dictionary<string, string> GetTotalDescriptionInMarkdown() => new()
        {
            { "zh-cn", "Nope" },
            { "zh-cnt", "Nope" },
            { "en-us", "Nope" },
        };

    public string GetIconInBase64() => "图标";

    public DateTime GetPublishDate() => DateTime.Now;

    public DateTime GetLastUpdateDate() => DateTime.Now;

    public IController GetController() => new Controller();

    public bool IsMarketVersion() => false;

    public IMarketPluginContract GetMarketPluginContract() => null;

    public string GetRootStartupFileName() => "TestPlugin.Winform.Core.dll";
}
