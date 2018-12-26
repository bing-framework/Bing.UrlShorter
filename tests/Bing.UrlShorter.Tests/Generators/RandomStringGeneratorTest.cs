using Bing.UrlShorter.Abstractions;
using Bing.UrlShorter.Generators;
using Xunit;
using Xunit.Abstractions;

namespace Bing.UrlShorter.Tests.Generators
{
    public class RandomStringGeneratorTest:TestBase
    {
        public RandomStringGeneratorTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Generate_4()
        {
            IStringGenerator generator = new StringGeneratorRandom(4);
            for (var i = 0; i < 100; i++)
            {
                var result = generator.Generate(null);
                Output.WriteLine(result);
                Assert.Equal(4, result.Length);
            }
        }

        [Fact]
        public void Test_Generate_6()
        {
            IStringGenerator generator = new StringGeneratorRandom(6);
            for (var i = 0; i < 100; i++)
            {
                var result = generator.Generate(null);
                Output.WriteLine(result);
                Assert.Equal(6, result.Length);
            }
        }
    }
}
