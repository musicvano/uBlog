using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IConfigService
    {
        Config Get();
        void Update(Config config);

        int PageSize { get; }
        string DisqusName { get;}
    }
}