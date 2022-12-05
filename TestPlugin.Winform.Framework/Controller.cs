using KitX.Contract.CSharp;
using KitX.Web.Rules;
using System.Collections.Generic;

namespace TestPlugin.Winform.Framework
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

        public List<Function> GetFunctions() => new List<Function>();
        
        public object Execute(string cmd, object arg = null)
        {
            return null;
        }

        public void SetRootPath(string path)
        {
            
        }

        public void SetWorkPath(string path)
        {
            
        }
    }
}
