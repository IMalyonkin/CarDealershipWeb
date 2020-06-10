using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Models
{
    public partial class CarsContext : IdentityDbContext<User_>
    {
        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {

        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }
        public virtual DbSet<Kit> Kit { get; set; }
        public virtual DbSet<Kit_Option> Kit_Option { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Model_Color> Model_Color { get; set; }
        public virtual DbSet<Model_Engine> Model_Engine { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<OptionType> OptionType { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Vehicle_Option> Vehicle_Option { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contract>().Property(p => p.Total_Price).HasColumnType($"decimal(10,2)");

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.ClientFK);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.VehicleFK);
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.VehicleFK);
            });

            modelBuilder.Entity<Kit>(entity =>
            {
                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Kit)
                    .HasForeignKey(d => d.ModelFK);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.BrandFK);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.ModelFK);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasOne(d => d.OptionType)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.OptionTypeFK);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.ColorFK);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.EngineFK);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.StatusFK);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(d => d.Kit)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.KitFK);
            });

            modelBuilder.Entity<Vehicle_Option>(entity =>
            {
                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Vehicle_Option)
                    .HasForeignKey(d => d.VehicleFK);
            });

            modelBuilder.Entity<Vehicle_Option>(entity =>
            {
                entity.HasOne(d => d.Option)
                    .WithMany(p => p.Vehicle_Option)
                    .HasForeignKey(d => d.OptionFK);
            });

            modelBuilder.Entity<Model_Color>(entity =>
            {
                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Model_Color)
                    .HasForeignKey(d => d.ModelFK);
            });

            modelBuilder.Entity<Model_Color>(entity =>
            {
                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Model_Color)
                    .HasForeignKey(d => d.ColorFK);
            });

            modelBuilder.Entity<Model_Engine>(entity =>
            {
                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Model_Engine)
                    .HasForeignKey(d => d.ModelFK);
            });

            modelBuilder.Entity<Model_Engine>(entity =>
            {
                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.Model_Engine)
                    .HasForeignKey(d => d.EngineFK);
            });

            modelBuilder.Entity<Kit_Option>(entity =>
            {
                entity.HasOne(d => d.Kit)
                    .WithMany(p => p.Kit_Option)
                    .HasForeignKey(d => d.KitFK);
            });

            modelBuilder.Entity<Kit_Option>(entity =>
            {
                entity.HasOne(d => d.Option)
                    .WithMany(p => p.Kit_Option)
                    .HasForeignKey(d => d.OptionFK)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
