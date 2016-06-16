using System.Collections.Generic;
using System.Linq;

namespace uBlog.Web.Helpers
{
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int parts)
        {
            int chunksize = source.Count() % parts;
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
}