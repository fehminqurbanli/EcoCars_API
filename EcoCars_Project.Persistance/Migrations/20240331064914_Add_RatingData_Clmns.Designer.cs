﻿// <auto-generated />
using System;
using EcoCars_Project.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoCars_Project.Persistance.Migrations
{
    [DbContext(typeof(EcoCarsDbContext))]
    [Migration("20240331064914_Add_RatingData_Clmns")]
    partial class Add_RatingData_Clmns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.GeneralInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("GeneralInfos");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.GeneralType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GeneralTypes");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.RatingData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RatingStar")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RatingDatas");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.TB_Ads", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ban_Type")
                        .HasColumnType("int");

                    b.Property<Guid>("Brand_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Color_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Condisioner")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Currency_Id")
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("Distance_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Leather_Salon")
                        .HasColumnType("bit");

                    b.Property<bool>("Lyuk")
                        .HasColumnType("bit");

                    b.Property<Guid>("Model_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Park_Radar")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("Rear_Camera")
                        .HasColumnType("bit");

                    b.Property<bool>("Seat_Heating")
                        .HasColumnType("bit");

                    b.Property<int>("Speed_Box")
                        .HasColumnType("int");

                    b.Property<int>("Transmission_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seat_count")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_Ads");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.TB_AdsImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Ads_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("imageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("Ads_Id");

                    b.ToTable("TB_AdsImages");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.GeneralInfo", b =>
                {
                    b.HasOne("EcoCars_Project.Domain.Entities.GeneralType", "GeneralType")
                        .WithMany("GeneralInfo")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GeneralType");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.Model", b =>
                {
                    b.HasOne("EcoCars_Project.Domain.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.TB_AdsImages", b =>
                {
                    b.HasOne("EcoCars_Project.Domain.Entities.TB_Ads", "TB_Ads")
                        .WithMany("TB_AdsImages")
                        .HasForeignKey("Ads_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TB_Ads");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.GeneralType", b =>
                {
                    b.Navigation("GeneralInfo");
                });

            modelBuilder.Entity("EcoCars_Project.Domain.Entities.TB_Ads", b =>
                {
                    b.Navigation("TB_AdsImages");
                });
#pragma warning restore 612, 618
        }
    }
}
