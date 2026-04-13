using System.Windows;
using KitX.Contract.CSharp.Attributes;

namespace TestPlugin.WPF.Core;

[EntryClass]
public class Functions
{
    [Function(nameof(HelloKitX))]
    public static void HelloKitX()
    {
        MessageBox.Show("Hello KitX !");
    }

    [Function(nameof(HelloAnything))]
    [Translation("DisplayName", "zh-CN", "打个招呼")]
    [Translation("DisplayName", "en-US", "Hello Anything")]
    public static void HelloAnything(
        [Parameter(nameof(name))]
        [Translation("DisplayName", "zh-CN", "名称")]
        [Translation("DisplayName", "en-US", "Name")]
        string name
        )
    {
        MessageBox.Show($"Hello {name} !");
    }

    [Function(nameof(GetInput))]
    [Translation("DisplayName", "zh-CN", "获取输入内容")]
    [Translation("DisplayName", "en-US", "Get Input Text")]
    public static string GetInput() => string.Empty; // 实际由 Controller.Execute 处理返回值
}
