using Microsoft.Extensions.Caching.Memory;
using NotesApp.Infrastructure.Caching.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Infrastructure.Caching.Concrete
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }

        public T Set<T>(string cacheKey, T value, TimeSpan cacheDuration)
        {
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(cacheDuration.Hours).AddMinutes(cacheDuration.Minutes).AddSeconds(cacheDuration.Seconds),
                Priority = CacheItemPriority.High,
                SlidingExpiration = cacheDuration
            };
            return _memoryCache.Set(cacheKey, value, cacheOptions);
        }

        public bool TryGet<T>(string cacheKey, out T value)
        {
            _memoryCache.TryGetValue(cacheKey, out value);
            if (value == null) return false;
            else return true;
        }
    }
}
