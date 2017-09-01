using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace NTCore.RedisAccess
{
    public class RedisManager
    {
        private static ConnectionMultiplexer _redis;
        private static object _locker = new object();

        public static ConnectionMultiplexer Manager
        {
            get
            {
                if (_redis == null)
                {
                    lock (_locker)
                    {
                        if (_redis == null)
                        {
                            _redis = GetManager();
                        }

                    }
                }

                return _redis;
            }
        }

        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = RedisConfig.ConnectionString;
            }

            return ConnectionMultiplexer.Connect(connectionString);
        }
    }
}
