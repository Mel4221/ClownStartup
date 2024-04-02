using System;
namespace ClownStartup
{
    public partial class StartupManager
    {
        public void AssingVariable(ref Command command)
        {
            this.SetOrUpdateVariable(ref command);
        }
      
    }
}
