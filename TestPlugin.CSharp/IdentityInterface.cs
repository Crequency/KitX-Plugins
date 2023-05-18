using KitX.Contract.CSharp;

namespace TestPlugin.CSharp;

public class IdentityInterface : IIdentityInterface
{
    public string GetName() => "TestPlugin.CSharp";

    public string GetVersion() => "v0.1.0";

    public Dictionary<string, string> GetDisplayName() => new()
        {
            { "zh-cn", "适用于 C# 的 KitX 测试用插件" },
            { "zh-cnt", "適用於 C# 的 KitX 測試用插件" },
            { "en-us", "KitX Testing Plugin for C#" },
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
            { "zh-cn", "KitX 测试用插件, 使用 KitX.Loader.CSharp 作为加载器." },
            { "zh-cnt", "KitX 測試用插件, 使用 KitX.Loader.CSharp 作爲加載器." },
            { "en-us", "KitX Test Plugin, use KitX.Loader.CSharp as loader." },
        };

    public Dictionary<string, string> GetTotalDescriptionInMarkdown() => new()
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
                "zh-cnt",
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
        };

    public string GetIconInBase64() => "图标";

    public DateTime GetPublishDate() => DateTime.Now;

    public DateTime GetLastUpdateDate() => DateTime.Now;

    public IController GetController() => new Controller();

    public bool IsMarketVersion() => false;

    public IMarketPluginContract GetMarketPluginContract() => null;

    public string GetRootStartupFileName() => "TestPlugin.CSharp.dll";
}
