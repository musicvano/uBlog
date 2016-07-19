using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IConfigService
    {
        /// <summary>
        /// Returns current configurations from database
        /// </summary>
        Config Get();

        /// <summary>
        /// Saves configurations to database
        /// </summary>
        /// <param name="config">Configurations to be saved</param>
        void Update(Config config);

        /// <summary>
        /// Count of posts per page
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Disqus short name
        /// </summary>
        string DisqusName { get; }

        /// <summary>
        /// AddThis profile ID
        /// </summary>
        string AddThisId { get; }

        /// <summary>
        /// Google Analytics tracking ID
        /// </summary>
        string GoogleId { get; }
    }
}