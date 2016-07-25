using System.IO;
using uBlog.Web;
using Xunit;

namespace uBlog.Test
{
    public class DatabaseTest
    {
        [Fact]
        public void DatabaseShouldExist()
        {
            var path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(Path.Combine(path, "../uBlog.Web/"));
            path = Path.Combine(path, AppSettings.DatabasePath);
            Assert.True(File.Exists(path) && (new FileInfo(path).Length > 0));
        }
    }
}