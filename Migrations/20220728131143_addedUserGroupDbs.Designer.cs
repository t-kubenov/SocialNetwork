﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Data;

#nullable disable

namespace SocialNetwork.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220728131143_addedUserGroupDbs")]
    partial class addedUserGroupDbs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SocialNetwork.Data.CommunityDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AvatarPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerIdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerIdId");

                    b.ToTable("Communities");
                });

            modelBuilder.Entity("SocialNetwork.Data.CommunityMemberDB", b =>
                {
                    b.Property<int>("CommunityIdId")
                        .HasColumnType("int");

                    b.Property<int>("UserIdId")
                        .HasColumnType("int");

                    b.HasIndex("CommunityIdId");

                    b.HasIndex("UserIdId");

                    b.ToTable("CommunityMembers");
                });

            modelBuilder.Entity("SocialNetwork.Data.FriendsDB", b =>
                {
                    b.Property<int>("AddresseeIdId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateInitiated")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequesterIdId")
                        .HasColumnType("int");

                    b.Property<int>("StatusCode")
                        .HasColumnType("int");

                    b.HasIndex("AddresseeIdId");

                    b.HasIndex("RequesterIdId");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("SocialNetwork.Data.UserDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AvatarPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialNetwork.Data.CommunityDB", b =>
                {
                    b.HasOne("SocialNetwork.Data.UserDB", "OwnerId")
                        .WithMany()
                        .HasForeignKey("OwnerIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnerId");
                });

            modelBuilder.Entity("SocialNetwork.Data.CommunityMemberDB", b =>
                {
                    b.HasOne("SocialNetwork.Data.CommunityDB", "CommunityId")
                        .WithMany()
                        .HasForeignKey("CommunityIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Data.UserDB", "UserId")
                        .WithMany()
                        .HasForeignKey("UserIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommunityId");

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("SocialNetwork.Data.FriendsDB", b =>
                {
                    b.HasOne("SocialNetwork.Data.UserDB", "AddresseeId")
                        .WithMany()
                        .HasForeignKey("AddresseeIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Data.UserDB", "RequesterId")
                        .WithMany()
                        .HasForeignKey("RequesterIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddresseeId");

                    b.Navigation("RequesterId");
                });
#pragma warning restore 612, 618
        }
    }
}