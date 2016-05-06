using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class SettingService : ISettingService
    {
        IUnitOfWork uow;

        public SettingService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Settings Settings
        {
            get
            {
                return uow.Settings.SingleOrDefault(s => s.Id == 1);
            }

            set
            {
                uow.Settings.Update(value);
                uow.Save();
            }
        }
    }
}