using System.IO;
using IPA.Utilities;
using PlatformCustomizer.Miscellaneous;

namespace PlatformCustomizer.CustomFeet
{
    public class CustomFeetDir
    {
        private const string CustomFeetDirName = "CustomFeet";
        public DirectoryInfo CustomFeetDirectory;
        public DirectoryInfo CustomFeet;
        
        public CustomFeetDir()
        {
            var baseDir = new DirectoryInfo(UnityGame.InstallPath);
            
            CustomFeetDirectory = baseDir.GetDirectory(CustomFeetDirName);

            if (!CustomFeetDirectory.Exists)
            {
                CustomFeetDirectory = baseDir.CreateSubdirectory(CustomFeetDirName);
                PathTools.RelativeExtension = null;
            }

        }
    }
}
