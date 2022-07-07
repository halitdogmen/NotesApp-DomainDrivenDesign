using NotesApp.Infrastructure.Caching.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Infrastructure.Caching.Concrete
{
    public class RedisCacheService : ICacheService
    {
        public void Remove(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public T Set<T>(string cacheKey, T value, TimeSpan cacheDuration)
        {
            throw new NotImplementedException();
        }

        public bool TryGet<T>(string cacheKey, out T value)
        {
            throw new NotImplementedException();
        }
    }
}
