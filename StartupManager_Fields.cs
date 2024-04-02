using System;
using System.Collections.Generic;
using QuickTools.QColors;

namespace ClownStartup
{
    public partial class StartupManager
    {
        private string FileName { get; set; } = $"{Tools.DataPath("db")}startup.db";
        public class Command
        {
            public string Key { get; set; } = null;
            public string Value { get; set; } = null;
            public int Pointer { get; set; } = 0;
            public override string ToString()
            {
                return $"KEY: [{this.Key}] VALUE: [{this.Value}] POINTER: [{this.Pointer}]";
            }
        }

        public List<Command> Commands { get; set; } = new List<Command>();
        public List<Command> Variables { get; set; } = new List<Command>();

        public Command GetVariable(string name)
        {
            for(int c =0; c < this.Variables.Count; c++)
            {
                if(this.Variables[c].Key == name)
                {
                    Color.Green($"MATCH: [{this.Variables[c].Key}]\n{this.Variables[c].ToString()}");
                    return new Command()
                    {
                        Key = this.Variables[c].Key,
                        Value = this.Variables[c].Value,
                        Pointer = c
                    };
                }
            }
            return new Command();
        }
        public void SetOrUpdateVariable(ref Command variable)
        {
                Command c = GetVariable(variable.Key);
                if (c.Key == null)
                {
                    Color.Pink($"ASSING: {variable}");
                    this.Variables.Add(variable);
                    return;
                }
                else
                {
                    Color.Pink($"UPDATE: {variable}");
                    this.Variables[c.Pointer] = c;
                }
        }

        public StartupManager() { }

        public StartupManager(string[] args)
        {
            this.FileName = args[0];
        }

    }
}
