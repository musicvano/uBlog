using Serilog;
using System.IO;

namespace uBlog.Web
{
    public static class AppSettings
    {
        public const string Version = "0.1";
        public const string DatabasePath = "AppData/uBlog.db";
        public const string LoggerPath = "AppData/Logs/log-{Date}.txt";

        public static bool IsInstalled()
        {
            var dbFile = Path.Combine(Directory.GetCurrentDirectory(), DatabasePath);
            Log.Error(dbFile);
            return File.Exists(dbFile) && (new FileInfo(dbFile).Length > 0);
        }
    }
}