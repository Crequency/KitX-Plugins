using System;
using System.Windows;
using KitX.Contract.CSharp;
using KitX.Shared.CSharp.WebCommand;
using KitX.Shared.CSharp.WebCommand.Details;

namespace TestPlugin.WPF.Core;

public class Controller(MainWindow mainwin) : IController
{
    private readonly MainWindow mainwin = mainwin;

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
            MessageBox.Show("Hello KitX !");
        }
    }

    public void SetWorkingDetail(PluginWorkingDetail workingDetail) => WorkingDetail = workingDetail;

    public void SetSendCommandAction(Action<Request> action) => mainwin.sendCommandAction = action;
}
