namespace uBlog.Core.Services
{
    public interface IConfigService
    {
        string Version { get; }
        string RootPath { get; }
        string LoggerPath { get; }
        string DatabasePath { get; }
        int PageSize { get; }
    }
}