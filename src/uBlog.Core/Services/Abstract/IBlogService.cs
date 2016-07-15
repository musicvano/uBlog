using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uBlog.Core.Services
{
    interface IBlogService
    {
        string Title  { get; }
        string SiteAddress { get; }
        string AdminName { get; }
    }
}
