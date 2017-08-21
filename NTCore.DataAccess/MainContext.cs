using System;
using Microsoft.EntityFrameworkCore;

namespace NTCore.DataAccess
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
