using System;
using System.IO;

namespace ClownStartup
{
    public static class Tools
    {
        /// <summary>
        /// Ises the window.
        /// </summary>
        /// <returns><c>true</c>, if window was ised, <c>false</c> otherwise.</returns>
        public static bool IsWindow()
        {
            //Microsoft Windows NT 6.2.9200.0
            if (Environment.OSVersion.ToString().ToUpper()[0] == 'M')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Slash this instance.
        /// </summary>
        /// <returns>The slash.</returns>
        public static string Slash()
        {
            string path = null;
            switch (IsWindow())
            {
                case true:
                    path = @"\";
                    break;
                case false:
                    path = "/";
                    break;
            }
            return path;
        }
        /// <summary>
        /// Datas the path.
        /// </summary>
        /// <returns>The path.</returns>
        public static string DataPath()
        {
            string folder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Slash()}qt{Slash()}";
            if (Directory.Exists(folder) == true)
            {
                return folder;
            }
            else
            {
                Directory.CreateDirectory(folder);
                return folder;
            }

        }

        /// <summary>
        /// Datas the path.
        /// </summary>
        /// <returns>The path.</returns>
        /// <param name="newDirectory">New directory.</param>
        public static string DataPath(string newDirectory)
        {
            string bar = Slash();
            string folder = $"{DataPath()}{newDirectory}{Slash()}";
            if (Directory.Exists(folder) == true)
            {
                return folder;
            }
            else
            {
                Directory.CreateDirectory(folder);

                return folder;
            }

        }
    }
}
