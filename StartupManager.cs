using System;
using System.IO;
using QuickTools.QColors; 
namespace ClownStartup
{
    public partial class StartupManager
    {



        public void Start()
        {
            if (!File.Exists(this.FileName)) { Color.Red($"FILE NOT FOUND: [{this.FileName}]"); return; }
            Color.Yellow($"STARTUP FILE LOCATED: [{this.FileName}]");
            this.Load();
            if (this.Commands.Count == 0) return;
            this.RunCommands();
        }

    }
}
