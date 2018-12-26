namespace Bing.UrlShorter.Abstractions
{
    /// <summary>
    /// 短地址存储器。用来存储字符串短地址，针对不同的生成器需要有不同的存储器
    /// </summary>
    /// <typeparam name="T">短地址获取器类型</typeparam>
    public interface IShorterStorage<T> where T : IShorterGetter<T>
    {
        /// <summary>
        /// 获取短地址
        /// </summary>
        /// <param name="shorter">短地址</param>
        /// <returns></returns>
        string Get(string shorter);

        /// <summary>
        /// 清空指定Url地址的短地址器
        /// </summary>
        /// <param name="url">Url地址</param>
        void Clean(string url);

        /// <summary>
        /// 清空短地址器
        /// </summary>
        /// <param name="shorter">短地址</param>
        void CleanShorter(string shorter);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <param name="shorter">短地址器</param>
        void Save(string url, T shorter);

        /// <summary>
        /// 清空
        /// </summary>
        void Clean();
    }
}
