using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NTCore.Utility
{
    public static class CacheHelper
    {
        static MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        public static string Get(string key)
        {
            if (string.IsNullOrEmpty(key)) return string.Empty;

            return cache.Get<string>(key);
        }

        public static string TryGet(string key)
        {
            if (string.IsNullOrEmpty(key)) return string.Empty;

            string result = string.Empty;
            if (!cache.TryGetValue<string>(key, out result))
            {
                result = string.Empty;
            }

            return (result ?? string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="seconds"></param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        public static void Set(string key, object value, double seconds = 60, bool isSliding = false)
        {
            if (string.IsNullOrEmpty(key))
            {
                var options = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(seconds)
                };

                if (isSliding)
                {
                    options.SetAbsoluteExpiration(options.SlidingExpiration.Value);
                    options.SlidingExpiration = (null);
                }
                cache.Set(key, value, options);
            }
        }


        public static void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                cache.Remove(key);
            }
        }


    }
}
