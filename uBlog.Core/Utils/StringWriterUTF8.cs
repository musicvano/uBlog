﻿using System.IO;
using System.Text;

namespace uBlog.Core.Utils
{
    /// <summary>
    /// String writer with UTF-8 encoding
    /// </summary>
    public class StringWriterUTF8 : StringWriter
    {
        public override Encoding Encoding
        {
            get => Encoding.UTF8;
        }
    }
}