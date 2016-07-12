namespace uBlog.Core.Services
{
    public interface IInstallService
    {
        bool RecreateDatabase();
        void SeedDatabase();
    }
}