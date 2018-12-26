using Bing.UrlShorter.Abstractions;
using Bing.UrlShorter.Shorter;

namespace Bing.UrlShorter.Generators
{
    /// <summary>
    /// 有效期短链接生成器。用于生成指定长度的地址，限制访问时间
    /// </summary>
    public class UrlShorterGeneratorLimitPeriod:IUrlShorterGenerator<ShorterWithPeriod>
    {
        /// <summary>
        /// 短链接生成器
        /// </summary>
        public IStringGenerator Generator { get; set; }

        /// <summary>
        /// 短链接存储器
        /// </summary>
        public IShorterStorage<ShorterWithPeriod> Storage { get; set; }

        /// <summary>
        /// 有效时长。单位：秒
        /// </summary>
        public long Period { get; set; }

        /// <summary>
        /// 生成一个短链接对象
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <returns></returns>
        public ShorterWithPeriod Generate(string url)
        {
            var shorter = Generator.Generate(url);
            while (Storage.Get(shorter) != null)
            {
                shorter = Generator.Generate(url);
            }

            ShorterWithPeriod entity = new ShorterWithPeriod(shorter, Period);
            Storage.Save(url, entity);
            return entity;
        }
    }
}
