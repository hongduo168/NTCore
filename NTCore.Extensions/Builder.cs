using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NTCore.Extensions
{
    public static class Builder
    {
        public static void UseWSBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            //services.TryAddTransient<ActionRecordRepository>();
            //services.TryAddTransient<HotelRoomRepository>();



        }

    }
}
