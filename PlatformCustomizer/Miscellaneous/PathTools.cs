using System.IO;
using System.Reflection;

namespace PlatformCustomizer.Miscellaneous
{
    public static class PathTools
    {
        public static string RelativeExtension;
        public static DirectoryInfo GetDirectory(this DirectoryInfo dir, string dirName, bool create = false)
        {
            if (create)
            {
                return dir.CreateSubdirectory(dirName);
            }

            return new DirectoryInfo(Path.Combine(dir.FullName, dirName));
        }

        public static FileInfo GetFile(this DirectoryInfo dir, string fileName)
        {
            return new FileInfo(Path.Combine(dir.FullName, fileName));
        }
    }
}
