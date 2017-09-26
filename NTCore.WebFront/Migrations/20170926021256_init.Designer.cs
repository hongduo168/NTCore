﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NTCore.DataAccess;
using NTCore.DataModel;
using System;

namespace NTCore.WebFront.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20170926021256_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NTCore.DataModel.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnName("avatar")
                        .HasMaxLength(255);

                    b.Property<bool>("Confirmed")
                        .HasColumnName("confirmed")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnName("create_time");

                    b.Property<int>("CreatorId")
                        .HasColumnName("creator_id");

                    b.Property<int>("DataState")
                        .HasColumnName("data_state");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(50);

                    b.Property<int>("HotelId")
                        .HasColumnName("hotel_id");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnName("mobile_number")
                        .HasMaxLength(50);

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnName("nickname")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnName("update_time");

                    b.Property<int>("UpdaterId")
                        .HasColumnName("updater_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("varchar(32)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
