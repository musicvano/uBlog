namespace uBlog.Core.Services
{
    public interface IInstallService
    {
        /// <summary>
        /// Creates a database and saves demo data
        /// </summary>
        void Seed(string blogTitle, string username, string password, string email);
    }
}