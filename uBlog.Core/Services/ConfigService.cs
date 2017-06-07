using System.Linq;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IBlogContext context;

        public ConfigService(IBlogContext context)
        {
            this.context = context;
            var config = Get();
            PageSize = config.PageSize;
            DisqusName = config.DisqusName;
            AddThisId = config.AddThisId;
            GoogleId = config.GoogleId;
        }

        public Config Get()
        {
            return context.Configs.SingleOrDefault(c => c.Id == 1);
        }

        public void Update(Config config)
        {
            context.Configs.Update(config);
            context.SaveChanges();
        }

        public int PageSize { get; private set; }
        public string DisqusName { get; private set; }
        public string AddThisId { get; private set; }
        public string GoogleId { get; private set; }
    }
}