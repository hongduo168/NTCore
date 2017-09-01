using System;
using StackExchange.Redis;

namespace NTCore.RedisAccess
{
    public class RedisConfig
    {
        public static string ConnectionString
        {
            get { return "127.0.0.1,password=hongduo"; }
        }

    }
}
