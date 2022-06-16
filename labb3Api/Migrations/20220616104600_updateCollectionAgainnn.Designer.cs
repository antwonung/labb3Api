﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using labb3Api.Models;

namespace labb3Api.Migrations
{
    [DbContext(typeof(ApiDatabaseContext))]
    [Migration("20220616104600_updateCollectionAgainnn")]
    partial class updateCollectionAgainnn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("labb3Api.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("InterestId");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("labb3Api.Models.Links", b =>
                {
                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<string>("InterestLink")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("InterestId", "InterestLink")
                        .HasName("Primary_Key_Links");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("labb3Api.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("labb3Api.Models.UserInterest", b =>
                {
                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("InterestId", "UserId")
                        .HasName("Primary_Key_UserInterest");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserInterest");
                });

            modelBuilder.Entity("labb3Api.Models.UserInterest", b =>
                {
                    b.HasOne("labb3Api.Models.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .HasConstraintName("FK_UserInterest_Interest")
                        .IsRequired();

                    b.HasOne("labb3Api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserInterest_User")
                        .IsRequired();

                    b.HasOne("labb3Api.Models.User", null)
                        .WithMany("UserInterests")
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
