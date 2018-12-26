using Bing.UrlShorter.Abstractions;
using Bing.UrlShorter.Shorter;

namespace Bing.UrlShorter.Generators
{
    /// <summary>
    /// 简单短链接生成器。用于生成指定长度的地址
    /// </summary>
    public class UrlShorterGeneratorSimple : IUrlShorterGenerator<ShorterString>
    {
        /// <summary>
        /// 短链接生成器
        /// </summary>
        public IStringGenerator Generator { get; set; }

        /// <summary>
        /// 短链接存储器
        /// </summary>
        public IShorterStorage<ShorterString> Storage { get; set; }

        /// <summary>
        /// 生成一个短链接对象
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <returns></returns>
        public ShorterString Generate(string url)
        {
            var shorter = Generator.Generate(url);
            while (Storage.Get(shorter) != null)
            {
                shorter = Generator.Generate(url);
            }

            ShorterString entity = new ShorterString(shorter);
            Storage.Save(url, entity);
            return entity;
        }
    }
}
