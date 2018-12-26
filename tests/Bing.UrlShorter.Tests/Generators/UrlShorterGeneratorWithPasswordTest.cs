using Bing.UrlShorter.Generators;
using Bing.UrlShorter.Shorter;
using Bing.UrlShorter.Storages;
using Xunit;
using Xunit.Abstractions;

namespace Bing.UrlShorter.Tests.Generators
{
    public class UrlShorterGeneratorWithPasswordTest:TestBase
    {
        public UrlShorterGeneratorWithPasswordTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Generate()
        {
            for (var i = 4; i <= 8; i++)
            {
                UrlShorterGeneratorWithPassword generator = new UrlShorterGeneratorWithPassword();
                generator.Generator = new StringGeneratorRandom(i);
                generator.PasswordGenerator=new StringGeneratorRandom(4);
                generator.Storage = new ShorterStorageMemory<ShorterWithPassword>();
                for (var j = 0; j < 5; j++)
                {
                    var shorter = generator.Generate("");
                    Assert.Equal(i, shorter.Shorter.Length);
                    Output.WriteLine($"{shorter.Shorter} {shorter.Password}");
                }
            }
        }
    }
}
