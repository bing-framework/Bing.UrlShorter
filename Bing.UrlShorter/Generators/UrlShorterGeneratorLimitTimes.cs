using Bing.UrlShorter.Abstractions;
using Bing.UrlShorter.Shorter;

namespace Bing.UrlShorter.Generators
{
    /// <summary>
    /// 限制访问短链接生成器。用于生成指定长度的串，限制访问次数
    /// </summary>
    public class UrlShorterGeneratorLimitTimes : IUrlShorterGenerator<ShorterWithTimes>
    {
        /// <summary>
        /// 短链接生成器
        /// </summary>
        public IStringGenerator Generator { get; set; }

        /// <summary>
        /// 短链接存储器
        /// </summary>
        public IShorterStorage<ShorterWithTimes> Storage { get; set; }

        /// <summary>
        /// 最多使用次数
        /// </summary>
        public long Times { get; set; }

        /// <summary>
        /// 生成一个短链接对象
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <returns></returns>
        public ShorterWithTimes Generate(string url)
        {
            var shorter = Generator.Generate(url);
            while (Storage.Get(shorter) != null)
            {
                shorter = Generator.Generate(url);
            }

            ShorterWithTimes entity = new ShorterWithTimes(shorter, Times);
            Storage.Save(url, entity);
            return entity;
        }
    }
}
