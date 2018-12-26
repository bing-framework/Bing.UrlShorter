namespace Bing.UrlShorter.Abstractions
{
    /// <summary>
    /// Url短地址生成器
    /// </summary>
    /// <typeparam name="T">短地址获取器类型</typeparam>
    public interface IUrlShorterGenerator<T> where T : IShorterGetter<T>
    {
        /// <summary>
        /// 短链接生成器
        /// </summary>
        IStringGenerator Generator { get; set; }

        /// <summary>
        /// 短链接存储器
        /// </summary>
        IShorterStorage<T> Storage { get; set; }


        /// <summary>
        /// 生成一个短链接对象
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <returns></returns>
        T Generate(string url);
    }
}
