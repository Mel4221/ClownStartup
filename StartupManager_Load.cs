using System;
using System.IO;
using System.Collections.Generic;
using QuickTools.QColors;

namespace ClownStartup
{
   
    public partial class StartupManager
    {
 
        private void Load()
        {
            this.Commands = new List<Command>(); 
            string[] lines = File.ReadAllLines(this.FileName); 
            for(int line = 0; line < lines.Length; line++)
            {
                string cmd,key,value;
                cmd = lines[line];
                if (!string.IsNullOrEmpty(cmd))
                {
                    if (!cmd.Contains("=") || !cmd.Contains(";")) { throw new Exception($"INVALID FORMAT AT LINE: [{line + 1}]"); }
                    Color.Yellow(cmd);

                    key = cmd.Substring(0, cmd.LastIndexOf('='));
                    Color.Yellow(key);

                    value = cmd.Substring(cmd.IndexOf('=')).Replace("=", "").Replace(";", "");
                    Color.Yellow(value);

                    Color.Green($"KEY: [{key}] VALUE: [{value}]\n");
                    this.Commands.Add(new Command() { Key = key, Value = value });
                }

            }
            Color.Yellow($"CMD COUNT: [{this.Commands.Count}]");
        }
    }
}
