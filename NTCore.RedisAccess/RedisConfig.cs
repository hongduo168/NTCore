using System;
using StackExchange.Redis;

namespace NTCore.RedisAccess
{
    public class RedisConfig
    {
        public static string Get()
        {
            using (var redis = ConnectionMultiplexer.Connect("127.0.0.1,password=hongduo"))
            {
                return redis.GetDatabase(0).HashGet("aa", "aa");
            }
        }

    }
}
