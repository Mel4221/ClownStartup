using System;
using QuickTools.QColors;
namespace ClownStartup
{
    public partial class StartupManager
    {
       
        public void RunCommands()
        {
            for(int cmd = 0; cmd < this.Commands.Count; cmd++)
            {
                 Command command = this.Commands[cmd];
                 if(command.Key[0] == '$')
                {
                    this.AssingVariable(ref command);
                }if(command.Key.Contains("(")&&
                    command.Key.Contains(")")&&
                    command.Key[0] != '#')
                {
                    this.CallFunction(ref command);
                }
            }
        }
    }
}
