namespace Bing.UrlShorter.Abstractions
{
    /// <summary>
    /// 随机字符串生成器
    /// </summary>
    public interface IStringGenerator
    {
        /// <summary>
        /// 长度
        /// </summary>
        int Length { get; set; }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <returns></returns>
        string Generate(string url);
    }
}
