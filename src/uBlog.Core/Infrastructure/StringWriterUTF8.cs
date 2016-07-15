using System.IO;
using System.Text;

namespace uBlog.Core.Infrastructure
{
    public class StringWriterUTF8 : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}