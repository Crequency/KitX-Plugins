using KitX.Contract.CSharp;
using KitX.Shared.Plugin;
using KitX.Shared.WebCommand;
using System;
using System.Collections.Generic;
using System.Windows;

namespace TestPlugin.WPF.Core
{
    public class Controller : IController
    {
        private readonly MainWindow mainwin;

        public Controller(MainWindow mainwin)
        {
            this.mainwin = mainwin;
        }

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

        public List<Function> GetFunctions()
        {
            return new List<Function>()
            {
                new()
                {
                    Name = "HelloWorld",
                    DisplayNames = new Dictionary<string, string>()
                    {
                        { "zh-cn", "你好, 世界!" },
                        { "en-us", "Hello, World!" }
                    },
                    Parameters = new List<Parameter>()
                    {
                        new ()
                        {
                            Name = "par1",
                            DisplayNames = new Dictionary<string, string>()
                            {
                                { "zh-cn", "参数1" },
                                { "en-us", "Parameter1" }
                            },
                            Type = "string",
                            IsAppendable = false
                        }
                    },
                    ReturnValueType = "void"
                }
            };
        }

        public void Execute(Command command)
        {

        }

        public void SetRootPath(string path)
        {
            MessageBox.Show($"SetRootPath({path})");
        }

        public void SetSendCommandAction(Action<Command> action) => mainwin.sendCommandAction = action;

        public void SetWorkPath(string path)
        {
            MessageBox.Show($"SetWorkPath({path})");
        }

        public void SetCommandsSendBuffer(ref Queue<Command> commands)
        {
            throw new NotImplementedException();
        }
    }
}
