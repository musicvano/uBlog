using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Services
{
    public class SettingService : ISettingService
    {
        BlogContext context;

        public SettingService(BlogContext context)
        {
            this.context = context;
        }

        public Settings Settings
        {
            get
            {
                return context.Settings.Find(1);
            }

            set
            {
                context.Settings.Attach(value);
                context.SaveChanges();
            }
        }
    }
}