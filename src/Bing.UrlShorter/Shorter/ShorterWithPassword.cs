using Bing.UrlShorter.Abstractions;

namespace Bing.UrlShorter.Shorter
{
    /// <summary>
    /// 加密短链接。存放短链接和密码
    /// </summary>
    public class ShorterWithPassword : IShorterGetter<ShorterWithPassword>
    {
        /// <summary>
        /// 短地址
        /// </summary>
        public string Shorter { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }        

        /// <summary>
        /// 初始化一个<see cref="ShorterWithPassword"/>类型的实例
        /// </summary>
        public ShorterWithPassword() { }

        /// <summary>
        /// 初始化一个<see cref="ShorterWithPassword"/>类型的实例
        /// </summary>
        /// <param name="shorter">短链接</param>
        /// <param name="password">密码</param>
        public ShorterWithPassword(string shorter, string password)
        {
            Shorter = shorter;
            Password = password;
        }       
    }
}
