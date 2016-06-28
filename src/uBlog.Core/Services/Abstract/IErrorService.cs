using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IErrorService
    {
        void Add(Error error);
        void Save();
    }
}