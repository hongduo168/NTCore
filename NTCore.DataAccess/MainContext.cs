using System;
using Microsoft.EntityFrameworkCore;
using NTCore.DataModel;

namespace NTCore.DataAccess
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<UserInfo> User { get; set; }
        public DbSet<SiteInfo> Hotel { get; set; }



    }
}
