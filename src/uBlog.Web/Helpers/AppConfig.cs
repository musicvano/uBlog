using Microsoft.Extensions.Configuration;

namespace uBlog.Web.Helpers
{
    public class AppConfig: IAppConfig
    {
        const string configFile = "project.json";
        IConfigurationRoot configRoot;

        public AppConfig()
        {
            var builder = new ConfigurationBuilder().AddJsonFile(configFile);
            configRoot = builder.Build();
        }

        public string Version
        {
            get
            {
                return configRoot["version"];
            }
        }
    }
}