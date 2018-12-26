using Bing.UrlShorter.Abstractions;

namespace Bing.UrlShorter.Shorter
{
    /// <summary>
    /// 有效期内限制访问短链接。存放短地址、超时时间、访问次数
    /// </summary>
    public class ShorterWithPeriodAndTimes:IShorterGetter<ShorterWithPeriodAndTimes>
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
        /// 访问次数
        /// </summary>
        public long Times { get; set; }

        /// <summary>
        /// 初始化一个<see cref="ShorterWithPeriodAndTimes"/>类型的实例
        /// </summary>
        public ShorterWithPeriodAndTimes() { }

        /// <summary>
        /// 初始化一个<see cref="ShorterWithPeriodAndTimes"/>类型的实例
        /// </summary>
        /// <param name="shorter">短链接</param>
        /// <param name="period">有效期</param>
        /// <param name="times">访问次数</param>
        public ShorterWithPeriodAndTimes(string shorter, long period, long times)
        {
            Shorter = shorter;
            Period = period;
            Times = times;
        }
    }
}
