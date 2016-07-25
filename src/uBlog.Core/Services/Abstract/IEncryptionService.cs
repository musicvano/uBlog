namespace uBlog.Core.Services
{
    /// <summary>
    /// Provides methods for password hashing
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Creates a random salt
        /// </summary>
        /// <returns>Random salt string</returns>
        string CreateSalt();

        /// <summary>
        /// Generates a Hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns>Encripted password by SHA256 algorithm</returns>
        string EncryptPassword(string password, string salt);
    }
}