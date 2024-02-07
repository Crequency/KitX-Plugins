using KitX.Contract.CSharp;
using KitX.Web.Rules;
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
                    DisplayNames = new Dictionary<string, string>()
                    {
                        { "zh-cn", "你好, 世界!" },
                        { "en-us", "Hello, World!" }
                    },
                    Parameters = new Dictionary<string, Dictionary<string, string>>()
                    {
                        {
                            "par1",
                            new Dictionary<string, string>()
                            {
                                { "zh-cn", "参数1" },
                                { "en-us", "Parameter1" }
                            }
                        }
                    },
                    ParametersType = new List<string>()
                    {
                        "void"
                    },
                    HasAppendParameters = false,
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
