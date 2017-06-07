using System;
using uBlog.Core.Services;
using Xunit;

namespace uBlog.Test
{
    public class EncryptionServiceTest: IDisposable
    {
        private readonly IEncryptionService encryptionService;

        public EncryptionServiceTest()
        {
            encryptionService = new EncryptionService();
        }

        public void Dispose()
        {
            // Nothing to clean up
        }

        [Fact]
        public void TwoSaltsShouldBeDifferent()
        {
            string first = encryptionService.CreateSalt();
            string second = encryptionService.CreateSalt();
            Assert.True(first != second);
        }
    }
}
