using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace uBlog.Core.Services
{
    public class ConfigService : IConfigService
    {
        public ConfigService(IConfigurationRoot config, string rootPath)
        {
            Version = config["Version"];
            RootPath = rootPath;
            DatabasePath = Path.Combine(rootPath, config["DatabasePath"]);
            LoggerPath = Path.Combine(rootPath, config["LoggerPath"]);
            PageSize = Convert.ToInt32(config["PageSize"]);
        }

        public string Version { get; private set; }
        public string RootPath { get; private set; }
        public string DatabasePath { get; private set; }
        public string LoggerPath { get; private set; }
        public int PageSize { get; private set; }
    }
}