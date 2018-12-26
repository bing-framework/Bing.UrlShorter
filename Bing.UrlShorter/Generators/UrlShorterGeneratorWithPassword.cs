using Bing.UrlShorter.Abstractions;
using Bing.UrlShorter.Shorter;

namespace Bing.UrlShorter.Generators
{
    /// <summary>
    /// 加密短链接生成器。用于生成指定长度的地址，带密码
    /// </summary>
    public class UrlShorterGeneratorWithPassword:IUrlShorterGenerator<ShorterWithPassword>
    {
        /// <summary>
        /// 短链接生成器
        /// </summary>
        public IStringGenerator Generator { get; set; }

        /// <summary>
        /// 短链接存储器
        /// </summary>
        public IShorterStorage<ShorterWithPassword> Storage { get; set; }

        /// <summary>
        /// 密码生成器
        /// </summary>
        public IStringGenerator PasswordGenerator { get; set; }

        /// <summary>
        /// 生成一个短链接对象
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <returns></returns>
        public ShorterWithPassword Generate(string url)
        {
            var shorter = Generator.Generate(url);
            while (Storage.Get(shorter) != null)
            {
                shorter = Generator.Generate(url);
            }

            ShorterWithPassword entity = new ShorterWithPassword(shorter, PasswordGenerator.Generate(url));
            Storage.Save(url, entity);
            return entity;
        }
    }
}
