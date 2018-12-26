using Bing.UrlShorter.Abstractions;

namespace Bing.UrlShorter.Shorter
{
    /// <summary>
    /// 有效期短链接。存放短链接和超时时间
    /// </summary>
    public class ShorterWithPeriod:IShorterGetter<ShorterWithPeriod>
    {
        /// <summary>
        /// 短链接
        /// </summary>
        public string Shorter { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public long Period { get; set; }

        /// <summary>
        /// 初始化一个<see cref="ShorterWithPeriod"/>类型的实例
        /// </summary>
        public ShorterWithPeriod() { }

        /// <summary>
        /// 初始化一个<see cref="ShorterWithPeriod"/>类型的实例
        /// </summary>
        /// <param name="shorter">短链接</param>
        /// <param name="period">有效期</param>
        public ShorterWithPeriod(string shorter, long period)
        {
            Shorter = shorter;
            Period = period;
        }
    }
}
