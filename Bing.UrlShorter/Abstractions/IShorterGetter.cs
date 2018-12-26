namespace Bing.UrlShorter.Abstractions
{
    /// <summary>
    /// 短链接获取器
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IShorterGetter<T>
    {
        /// <summary>
        /// 短链接
        /// </summary>
        string Shorter { get; set; }
    }
}
