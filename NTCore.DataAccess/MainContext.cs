﻿using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using NTCore.DataModel;

namespace NTCore.DataAccess
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<HotelInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<ActionRecordInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<CustomerRequestDefineInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<CustomerRequestInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<CustomerRequestItemInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<HotelRoleInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<HotelRoomInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<HotelUserInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MinibarConsumeInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MinibarConsumeItemInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MinibarProductInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<MinibarTypeInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<PmsProductDefineInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<RoomMinibarInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<RoomProductPackageInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<RowhouseHistoryInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<RowhouseInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<UserGroupInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<UserGroupMemberInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<VerificationCodeInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<WelcomePlanInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);
            modelBuilder.Entity<WorkloadInfo>().HasQueryFilter(x => x.DataState == EnumState.Normal);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<UserInfo> User { get; set; }
        public virtual DbSet<HotelInfo> Hotel { get; set; }
        public virtual DbSet<ActionRecordInfo> ActionRecord { get; set; }
        public virtual DbSet<CustomerRequestDefineInfo> CustomerRequestDefine { get; set; }
        public virtual DbSet<CustomerRequestInfo> CustomerRequest { get; set; }
        public virtual DbSet<CustomerRequestItemInfo> CustomerRequestItem { get; set; }
        public virtual DbSet<HotelRoleInfo> HotelRole { get; set; }
        public virtual DbSet<HotelRoomInfo> HotelRoom { get; set; }
        public virtual DbSet<HotelUserInfo> HotelUser { get; set; }
        public virtual DbSet<MinibarConsumeInfo> MinibarConsume { get; set; }
        public virtual DbSet<MinibarConsumeItemInfo> MinibarConsumeItem { get; set; }
        public virtual DbSet<MinibarProductInfo> MinibarProduct { get; set; }
        public virtual DbSet<MinibarTypeInfo> MinibarType { get; set; }
        public virtual DbSet<PmsProductDefineInfo> PmsProductDefine { get; set; }
        public virtual DbSet<RoomMinibarInfo> RoomMinibar { get; set; }
        public virtual DbSet<RoomProductPackageInfo> RoomProductPackage { get; set; }
        public virtual DbSet<RowhouseHistoryInfo> RowhouseHistory { get; set; }
        public virtual DbSet<RowhouseInfo> Rowhouse { get; set; }
        public virtual DbSet<UserGroupInfo> UserGroup { get; set; }
        public virtual DbSet<UserGroupMemberInfo> UserGroupMember { get; set; }
        public virtual DbSet<VerificationCodeInfo> VerificationCode { get; set; }
        public virtual DbSet<WelcomePlanInfo> WelcomePlan { get; set; }
        public virtual DbSet<WorkloadInfo> Workload { get; set; }


    }
}
