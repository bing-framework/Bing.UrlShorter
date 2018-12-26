using Bing.UrlShorter.Abstractions;

namespace Bing.UrlShorter.Shorter
{
    /// <summary>
    /// 限制访问短链接
    /// </summary>
    public class ShorterWithTimes:IShorterGetter<ShorterWithTimes>
    {
        /// <summary>
        /// 短链接
        /// </summary>
        public string Shorter { get; set; }

        /// <summary>
        /// 访问次数
        /// </summary>
        public long Times { get; set; }

        /// <summary>
        /// 初始化一个<see cref="ShorterWithTimes"/>类型的实例
        /// </summary>
        public ShorterWithTimes() { }

        /// <summary>
        /// 初始化一个<see cref="ShorterWithTimes"/>类型的实例
        /// </summary>
        /// <param name="shorter">短链接</param>
        /// <param name="times">访问次数</param>
        public ShorterWithTimes(string shorter, long times)
        {
            Shorter = shorter;
            Times = times;
        }
    }
}
