using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class ErrorService: IErrorService
    {
        private readonly IUnitOfWork uow;

        public ErrorService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Add(Error error)
        {
            uow.Errors.Add(error);
        }

        public void Save()
        {
            uow.Save();
        }
    }
}