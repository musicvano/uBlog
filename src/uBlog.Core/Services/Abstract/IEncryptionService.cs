﻿namespace uBlog.Core.Services
{
    public interface IEncryptionService
    {
        /// <summary>
        /// Creates a random salt
        /// </summary>
        /// <returns></returns>
        string CreateSalt();
        /// <summary>
        /// Generates a Hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        string EncryptPassword(string password, string salt);
    }
}