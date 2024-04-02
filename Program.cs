using System;
using QuickTools.QColors;
namespace ClownStartup
{
   public class MainClass
    {
        public static int Main(string[] args)
        {
            StartupManager manager;

            if (args.Length > 0)
            {
                try
                {
                    manager = new StartupManager(args);
                    manager.Start();
                    return 0;
                }catch(Exception ex)
                {
                    Color.Red(ex);
                    return 1; 
                }
            }
            else
            {
                try 
                { 
                    manager = new StartupManager();
                    manager.Start();
                    return 0; 
                }
                catch (Exception ex)
                {
                    Color.Red(ex);
                    return 1;
                }
            }
        }
    }
}
