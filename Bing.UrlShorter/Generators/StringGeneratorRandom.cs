using System;
using Bing.UrlShorter.Abstractions;

namespace Bing.UrlShorter.Generators
{
    /// <summary>
    /// 随机字符串生成器
    /// </summary>
    public class StringGeneratorRandom : IStringGenerator
    {
        /// <summary>
        /// 有效字符数组
        /// </summary>
        private static readonly char[] ValidChars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        /// <summary>
        /// 随机数器
        /// </summary>
        private static Random _random = new Random(Environment.TickCount);

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; } = 4;

        /// <summary>
        /// 初始化一个<see cref="StringGeneratorRandom"/>类型的实例
        /// </summary>
        public StringGeneratorRandom() { }

        /// <summary>
        /// 初始化一个<see cref="StringGeneratorRandom"/>类型的实例
        /// </summary>
        /// <param name="length">长度</param>
        public StringGeneratorRandom(int length)
        {
            Length = length;
        }

        /// <summary>
        /// 生成。
        /// 这里的实现不考虑url，直接生成随机字符串即可，这个算法如果容量比较大的时候，性能会变低，因此要根据使用情况选择合适的长度
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <returns></returns>
        public string Generate(string url)
        {
            return Generate(_random.Next(int.MaxValue));
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="seed">种子数</param>
        /// <returns></returns>
        private string Generate(int seed)
        {
            char[] sortUrl = new char[Length];
            for (var i = 0; i < Length; i++)
            {
                sortUrl[i] = ValidChars[seed % ValidChars.Length];
                seed = _random.Next(int.MaxValue) % ValidChars.Length;
            }

            return sortUrl.ToString();
        }

    }
}
