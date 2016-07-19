using Xunit;

namespace uBlog.Test
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal("Hello test", "Hello test");
        }
    }
}