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

        public DbSet<ActionRecordInfo> ActionRecord { get; set; }
        public DbSet<UserInfo> User { get; set; }
        public DbSet<SiteInfo> Hotel { get; set; }
        public DbSet<ArticleInfo> Article { get; set; }



        #region View 视图

        //public DbSet<DataModel.DbView.Class1> Class1 { get; set; }
        #endregion



    }
}
