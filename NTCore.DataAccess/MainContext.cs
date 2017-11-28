using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NTCore.DataModel;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace NTCore.DataAccess
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
            //this.ChangeTracker.TrackGraph(this.HotelRoom, TrackAction);
        }

        //private void TrackAction(EntityEntryGraphNode obj)
        //{
        //    switch (obj.Entry.State)
        //    {
        //        case EntityState.Added:
        //            break;

        //        case EntityState.Modified:
        //            break;

        //        case EntityState.Deleted:
        //            break;;

        //        case EntityState.Unchanged:
        //            break;
        //    }
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var baseType = typeof(BaseEntity);
            //var types = Assembly.GetAssembly(baseType).GetTypes().Where(x => x.BaseType == baseType);
            //if (types != null)
            //{
            //    LambdaExpression lambdaExpr = Expression.Lambda(
            //        Expression.Add(
            //            Expression.Field(typeof(int), "data_state"),
            //            Expression.Constant((int)EnumState.Normal)
            //        )
            //    );

            //    foreach (var t in types)
            //    {

            //        modelBuilder.Entity(t).HasQueryFilter(lambdaExpr);

            //        //modelBuilder.Entity<BaseEntity>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            //    }
            //}

            modelBuilder.Entity<ActionRecordInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<AssignRoomHistoryInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<AssignRoomInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<AttachmentInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<CustomerRequestInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<CustomerRequestItemInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<HotelInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<HotelRoleInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<HotelRoomInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<HotelSupplyDefineInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<HotelUserInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MessageCenterInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MessageReceiverInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MessageTemplateInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MinibarConsumeInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MinibarConsumeItemInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MinibarProductInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MinibarTypeInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<PmsProductDefineInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<RepairPlaceDefineInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<RoomMinibarInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<RoomProductPackageInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<UserGroupInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<UserGroupMemberInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<UserInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<VerificationCodeInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<WelcomePlanInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<WorkloadInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<WorkloadStepInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<ActionRecordInfo> ActionRecord { get; set; }
        public virtual DbSet<AssignRoomHistoryInfo> AssignRoomHistory { get; set; }
        public virtual DbSet<AssignRoomInfo> AssignRoom { get; set; }
        public virtual DbSet<AttachmentInfo> Attachment { get; set; }
        public virtual DbSet<CustomerRequestInfo> CustomerRequest { get; set; }
        public virtual DbSet<CustomerRequestItemInfo> CustomerRequestItem { get; set; }
        public virtual DbSet<HotelInfo> Hotel { get; set; }
        public virtual DbSet<HotelRoleInfo> HotelRole { get; set; }
        public virtual DbSet<HotelRoomInfo> HotelRoom { get; set; }
        public virtual DbSet<HotelSupplyDefineInfo> HotelSupplyDefine { get; set; }
        public virtual DbSet<MessageCenterInfo> MessageCente { get; set; }
        public virtual DbSet<MessageReceiverInfo> MessageReceiver { get; set; }
        public virtual DbSet<MessageTemplateInfo> MessageTemplate { get; set; }
        public virtual DbSet<MinibarConsumeInfo> MinibarConsume { get; set; }
        public virtual DbSet<MinibarConsumeItemInfo> MinibarConsumeItem { get; set; }
        public virtual DbSet<MinibarProductInfo> MinibarProduct { get; set; }
        public virtual DbSet<MinibarTypeInfo> MinibarType { get; set; }
        public virtual DbSet<PmsProductDefineInfo> PmsProductDefine { get; set; }
        public virtual DbSet<RepairPlaceDefineInfo> RepairPlaceDefine { get; set; }
        public virtual DbSet<RoomMinibarInfo> RoomMinibar { get; set; }
        public virtual DbSet<RoomProductPackageInfo> RoomProductPackage { get; set; }
        public virtual DbSet<UserGroupInfo> UserGroup { get; set; }
        public virtual DbSet<UserGroupMemberInfo> UserGroupMember { get; set; }
        public virtual DbSet<UserInfo> User { get; set; }
        public virtual DbSet<VerificationCodeInfo> VerificationCode { get; set; }
        public virtual DbSet<WelcomePlanInfo> WelcomePlan { get; set; }
        public virtual DbSet<WorkloadInfo> Workload { get; set; }
        public virtual DbSet<WorkloadStepInfo> WorkloadStep { get; set; }


    }
}
