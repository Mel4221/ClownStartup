using System;
using System.Diagnostics;
using System.Threading;
using QuickTools.QColors;

namespace ClownStartup
{
    public partial class StartupManager
    {
        public static Thread ExecutionThread { get; set; } 
        public static Process StarupProcess { get; set; }
        public static ProcessStartInfo Info { get; set; }

        public void CallFunction(ref Command function)
        {
            string cmd, f, return_value, argument, variable;
            Command v;
            cmd = function.Key;
            Console.WriteLine(cmd);
            f = cmd.Substring(0, cmd.IndexOf('('));
            Console.WriteLine(f);
            //Console.WriteLine($"{cmd.IndexOf('(')} : {cmd.IndexOf(')')}");
            //Console.ReadLine();
            argument = cmd.Substring(cmd.IndexOf('(')).Replace("(","").Replace(")","");
            v = this.GetVariable(argument);
            Color.Pink($"{v}");
            if(v.Value != null)
            {
                argument = v.Value; 
            }
            Console.WriteLine(argument);

            return_value = null;
            Color.Green($"CMD: [{cmd}] FUNCTION: [{f}] ARG: [{argument}] RETURN: [{return_value}]");

            switch (f)
            {
                case "SYS_CALL":
                    v = this.GetVariable("$SYS_CALL_ARG");
                    variable = v.Value == null || v.Value == "" ? "" : v.Value;
                    ExecutionThread = new Thread(() => {
                        try
                        {
                            Info = new ProcessStartInfo(); 
                            Info.FileName = argument;
                            Info.Arguments = variable;
                            StarupProcess = Process.Start(Info);
                            StarupProcess.WaitForExit();
                        }
                        catch(Exception ex)
                        {
                            Color.Red($"\nFAIL TO PROCESS SYS_CALL DUE TO: [{ex.Message}]\n");
                        }
                    });
                    ExecutionThread.Start();
                    while (ExecutionThread.IsAlive)
                    {
                        Color.Green($"WAITTING TO FINISH: [{f}]");
                        Thread.Sleep(1000);
                    }
                    break;
                case "SLEEP":
                    int number;
                    bool isNumber = int.TryParse(argument,out number);
                    if (isNumber)
                    {
                        Thread.Sleep(number); 
                        return;
                    }
                    else
                    {
                        throw new Exception($"FAILED TO SLEEP DUE TO ARGUMENT NOT BEING A VALID INT VALUE: [{argument}]");
                    }
                default:
                    throw new Exception($"INVALID FUNCTION CALL: [{f}]");
            }
        }
    }
}
