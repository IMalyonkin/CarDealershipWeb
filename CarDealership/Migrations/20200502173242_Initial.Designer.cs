﻿// <auto-generated />
using System;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarDealership.Migrations
{
    [DbContext(typeof(CarsContext))]
    [Migration("20200502173242_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASPNetCoreApp.Models.User_", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CarDealership.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("CarDealership.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CarDealership.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("CarDealership.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientFK");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("Total_Price")
                        .HasColumnName("Total Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("VehicleFK");

                    b.HasKey("Id");

                    b.HasIndex("ClientFK");

                    b.HasIndex("VehicleFK");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("CarDealership.Models.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Power");

                    b.Property<decimal>("Price");

                    b.Property<string>("Type")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Engine");
                });

            modelBuilder.Entity("CarDealership.Models.Kit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModelFK");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("ModelFK");

                    b.ToTable("Kit");
                });

            modelBuilder.Entity("CarDealership.Models.Kit_Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KitFK");

                    b.Property<int>("OptionFK");

                    b.HasKey("Id");

                    b.HasIndex("KitFK");

                    b.HasIndex("OptionFK");

                    b.ToTable("Kit_Option");
                });

            modelBuilder.Entity("CarDealership.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandFK");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("BrandFK");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("CarDealership.Models.Model_Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorFK");

                    b.Property<byte[]>("Image");

                    b.Property<int>("ModelFK");

                    b.HasKey("Id");

                    b.HasIndex("ColorFK");

                    b.HasIndex("ModelFK");

                    b.ToTable("Model_Color");
                });

            modelBuilder.Entity("CarDealership.Models.Model_Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EngineFK");

                    b.Property<int>("ModelFK");

                    b.HasKey("Id");

                    b.HasIndex("EngineFK");

                    b.HasIndex("ModelFK");

                    b.ToTable("Model_Engine");
                });

            modelBuilder.Entity("CarDealership.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModelFK");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("OptionTypeFK");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("ModelFK");

                    b.HasIndex("OptionTypeFK");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("CarDealership.Models.OptionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("OptionType");
                });

            modelBuilder.Entity("CarDealership.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("CarDealership.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorFK");

                    b.Property<int>("EngineFK");

                    b.Property<int?>("KitFK");

                    b.Property<int>("StatusFK");

                    b.Property<string>("VIN")
                        .HasMaxLength(17);

                    b.HasKey("Id");

                    b.HasIndex("ColorFK");

                    b.HasIndex("EngineFK");

                    b.HasIndex("KitFK");

                    b.HasIndex("StatusFK");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("CarDealership.Models.Vehicle_Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OptionFK");

                    b.Property<decimal>("Price");

                    b.Property<int>("VehicleFK");

                    b.HasKey("Id");

                    b.HasIndex("OptionFK");

                    b.HasIndex("VehicleFK");

                    b.ToTable("Vehicle_Option");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CarDealership.Models.Contract", b =>
                {
                    b.HasOne("CarDealership.Models.Client", "Client")
                        .WithMany("Contract")
                        .HasForeignKey("ClientFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Vehicle", "Vehicle")
                        .WithMany("Contract")
                        .HasForeignKey("VehicleFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarDealership.Models.Kit", b =>
                {
                    b.HasOne("CarDealership.Models.Model", "Model")
                        .WithMany("Kit")
                        .HasForeignKey("ModelFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarDealership.Models.Kit_Option", b =>
                {
                    b.HasOne("CarDealership.Models.Kit", "Kit")
                        .WithMany("Kit_Option")
                        .HasForeignKey("KitFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Option", "Option")
                        .WithMany("Kit_Option")
                        .HasForeignKey("OptionFK")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CarDealership.Models.Model", b =>
                {
                    b.HasOne("CarDealership.Models.Brand", "Brand")
                        .WithMany("Model")
                        .HasForeignKey("BrandFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarDealership.Models.Model_Color", b =>
                {
                    b.HasOne("CarDealership.Models.Color", "Color")
                        .WithMany("Model_Color")
                        .HasForeignKey("ColorFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Model", "Model")
                        .WithMany("Model_Color")
                        .HasForeignKey("ModelFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarDealership.Models.Model_Engine", b =>
                {
                    b.HasOne("CarDealership.Models.Engine", "Engine")
                        .WithMany("Model_Engine")
                        .HasForeignKey("EngineFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Model", "Model")
                        .WithMany("Model_Engine")
                        .HasForeignKey("ModelFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarDealership.Models.Option", b =>
                {
                    b.HasOne("CarDealership.Models.Model", "Model")
                        .WithMany("Option")
                        .HasForeignKey("ModelFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.OptionType", "OptionType")
                        .WithMany("Option")
                        .HasForeignKey("OptionTypeFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarDealership.Models.Vehicle", b =>
                {
                    b.HasOne("CarDealership.Models.Color", "Color")
                        .WithMany("Vehicle")
                        .HasForeignKey("ColorFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Engine", "Engine")
                        .WithMany("Vehicle")
                        .HasForeignKey("EngineFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Kit", "Kit")
                        .WithMany("Vehicle")
                        .HasForeignKey("KitFK");

                    b.HasOne("CarDealership.Models.Status", "Status")
                        .WithMany("Vehicle")
                        .HasForeignKey("StatusFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarDealership.Models.Vehicle_Option", b =>
                {
                    b.HasOne("CarDealership.Models.Option", "Option")
                        .WithMany("Vehicle_Option")
                        .HasForeignKey("OptionFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.Vehicle", "Vehicle")
                        .WithMany("Vehicle_Option")
                        .HasForeignKey("VehicleFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ASPNetCoreApp.Models.User_")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ASPNetCoreApp.Models.User_")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ASPNetCoreApp.Models.User_")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ASPNetCoreApp.Models.User_")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
