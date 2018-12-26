using Bing.UrlShorter.Generators;
using Bing.UrlShorter.Shorter;
using Bing.UrlShorter.Storages;
using Xunit;
using Xunit.Abstractions;

namespace Bing.UrlShorter.Tests.Generators
{
    public class UrlShorterGeneratorSimpleTest:TestBase
    {
        public UrlShorterGeneratorSimpleTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Generate()
        {
            for (int i = 4; i <= 8; i++)
            {
                var simple = new UrlShorterGeneratorSimple();
                simple.Generator = new StringGeneratorRandom(i);
                simple.Storage = new ShorterStorageMemory<ShorterString>();
                for (var j = 0; j < 100; j++)
                {
                    var shorter = simple.Generate("").Shorter;
                    Assert.Equal(shorter.Length, i);
                    Output.WriteLine(shorter);
                }
            }
        }
    }
}
