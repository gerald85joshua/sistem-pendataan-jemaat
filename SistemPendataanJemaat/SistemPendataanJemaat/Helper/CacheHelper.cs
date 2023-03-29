using Microsoft.Extensions.Caching.Memory;
using SistemPendataanJemaat.Interfaces;
using System;

namespace SistemPendataanJemaat.Helper
{
    public class CacheHelper : ICacheHelper
    {
        private readonly IMemoryCache _memoryCache;

        public CacheHelper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public string GetCache(string key)
        {
            _memoryCache.TryGetValue(key, out string value);
            return value;
        }

        public void SetCache(string key, string value)
        {
            if(GetCache(key) != null)
            {
                RemoveCache(key);
            }

            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(2),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromHours(1),
                Size = 2048,
            };
            _memoryCache.Set(key, value, cacheExpiryOptions);
        }

        public void RemoveCache(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
