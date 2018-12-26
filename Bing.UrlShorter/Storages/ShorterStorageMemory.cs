using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bing.UrlShorter.Abstractions;

namespace Bing.UrlShorter.Storages
{
    /// <summary>
    /// 基于内存的短地址存储器
    /// </summary>
    /// <typeparam name="T">短地址获取器类型</typeparam>
    public class ShorterStorageMemory<T> : IShorterStorage<T> where T : IShorterGetter<T>
    {
        /// <summary>
        /// 短地址获取器字典，存储shorter-url
        /// </summary>
        private readonly IDictionary<IShorterGetter<T>, string> _shorterDict =
            new ConcurrentDictionary<IShorterGetter<T>, string>();

        /// <summary>
        /// 地址字典，存储url-shorter
        /// </summary>
        private readonly IDictionary<string, IShorterGetter<T>> _urlDict = new ConcurrentDictionary<string, IShorterGetter<T>>();

        /// <summary>
        /// 短地址字典，存储shorter.shorter,shorter
        /// </summary>
        private readonly IDictionary<string, IShorterGetter<T>> _shoterUrlDict =
            new ConcurrentDictionary<string, IShorterGetter<T>>();

        public string Get(string shorterKey)
        {
            if (_shoterUrlDict.TryGetValue(shorterKey, out var result))
            {
                return _shorterDict[result];
            }

            return null;
        }

        public void Clean(string url)
        {
            if (_urlDict.TryGetValue(url, out var result))
            {
                _urlDict.Remove(url);
                _shorterDict.Remove(result);
                _shoterUrlDict.Remove(result.Shorter);
            }
        }

        public void CleanShorter(string shorterKey)
        {
            if (_shoterUrlDict.TryGetValue(shorterKey, out var result))
            {
                _urlDict.Remove(_shorterDict[result]);
                _shorterDict.Remove(result);
                _shoterUrlDict.Remove(result.Shorter);
            }
        }

        public void Save(string url, T shorter)
        {
            _urlDict[url] = shorter;
            _shorterDict[shorter] = url;
            _shoterUrlDict[shorter.Shorter] = shorter;
        }

        public void Clean()
        {
            _urlDict.Clear();
            _shorterDict.Clear();
            _shoterUrlDict.Clear();
        }
    }
}
