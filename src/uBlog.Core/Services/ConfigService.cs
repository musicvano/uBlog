using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class ConfigService : IConfigService
    {
        IUnitOfWork uow;
        Config config;

        public ConfigService(IUnitOfWork uow)
        {
            this.uow = uow;
            config = uow.Configs.SingleOrDefault(s => s.Id == 1);
        }

        public string Author
        {
            get { return config.Author; }
        }

        public string About
        {
            get { return config.About; }
        }

        public string Photo
        {
            get { return config.Photo; }
        }

        public string Email
        {
            get { return config.Email; }
        }

        public string Url
        {
            get { return config.Url; }
        }

        public string Github
        {
            get { return config.Github; }
        }

        public string Facebook
        {
            get { return config.Facebook; }
        }

        public string Twitter
        {
            get { return config.Twitter; }
        }

        public string Skype
        {
            get { return config.Skype; }
        }

        public string Location
        {
            get { return config.Location; }
        }
    }
}