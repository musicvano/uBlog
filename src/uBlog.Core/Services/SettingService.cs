using uBlog.Data;
using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Core.Services
{
    public class SettingService : ISettingService
    {
        ISettingRepository repo;

        public SettingService(ISettingRepository repo)
        {
            this.repo = repo;
        }

        public Settings Settings
        {
            get
            {
                return null;
                //return context.Settings.Find(1);
            }

            set
            {
                //context.Settings.Attach(value);
                //context.SaveChanges();
            }
        }
    }
}