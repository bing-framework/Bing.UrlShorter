using Bing.UrlShorter.Abstractions;

namespace Bing.UrlShorter.Shorter
{
    /// <summary>
    /// 字符串短链接。存放短链接
    /// </summary>
    public class ShorterString : IShorterGetter<ShorterString>
    {
        /// <summary>
        /// 短链接
        /// </summary>
        public string Shorter { get; set; }

        /// <summary>
        /// 初始化一个<see cref="ShorterString"/>类型的实例
        /// </summary>
        public ShorterString() { }

        /// <summary>
        /// 初始化一个<see cref="ShorterString"/>类型的实例
        /// </summary>
        /// <param name="shorter">短链接</param>
        public ShorterString(string shorter)
        {
            Shorter = shorter;
        }
    }
}
