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
        public DbSet<HotelInfo> Hotel { get; set; }
        public DbSet<ActionRecordInfo> ActionRecord { get; set; }
        public DbSet<CustomerRequestDefineInfo> CustomerRequestDefine { get; set; }
        public DbSet<CustomerRequestInfo> CustomerRequest { get; set; }
        public DbSet<CustomerRequestItemInfo> CustomerRequestItem { get; set; }
        public DbSet<HotelRoleInfo> HotelRole { get; set; }
        public DbSet<HotelRoomInfo> HotelRoom { get; set; }
        public DbSet<HotelUserInfo> HotelUser { get; set; }
        public DbSet<MinibarConsumeInfo> MinibarConsume { get; set; }
        public DbSet<MinibarConsumeItemInfo> MinibarConsumeItem { get; set; }
        public DbSet<MinibarProductInfo> MinibarProduct { get; set; }
        public DbSet<MinibarTypeInfo> MinibarType { get; set; }
        public DbSet<PmsProductDefineInfo> PmsProductDefine { get; set; }
        public DbSet<RoomMinibarInfo> RoomMinibar { get; set; }
        public DbSet<RoomProductPackageInfo> RoomProductPackage { get; set; }
        public DbSet<RowhouseHistoryInfo> RowhouseHistory { get; set; }
        public DbSet<RowhouseInfo> Rowhouse { get; set; }
        public DbSet<UserGroupInfo> UserGroup { get; set; }
        public DbSet<UserGroupMemberInfo> UserGroupMember { get; set; }
        public DbSet<VerificationCodeInfo> VerificationCode { get; set; }
        public DbSet<WelcomePlanInfo> WelcomePlan { get; set; }
        public DbSet<WorkloadInfo> Workload { get; set; }


    }
}
