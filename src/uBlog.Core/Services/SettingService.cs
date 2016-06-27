using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class SettingService : ISettingService
    {
        IUnitOfWork uow;
        Settings settings;

        public SettingService(IUnitOfWork uow)
        {
            this.uow = uow;
            settings = uow.Settings.SingleOrDefault(s => s.Id == 1);
        }

        public string Author
        {
            get { return settings.Author; }
        }

        public string About
        {
            get { return settings.About; }
        }

        public string Photo
        {
            get { return settings.Photo; }
        }

        public string Email
        {
            get { return settings.Email; }
        }

        public string Url
        {
            get { return settings.Url; }
        }

        public string Github
        {
            get { return settings.Github; }
        }

        public string Facebook
        {
            get { return settings.Facebook; }
        }

        public string Twitter
        {
            get { return settings.Twitter; }
        }

        public string Skype
        {
            get { return settings.Skype; }
        }

        public string Location
        {
            get { return settings.Location; }
        }
    }
}