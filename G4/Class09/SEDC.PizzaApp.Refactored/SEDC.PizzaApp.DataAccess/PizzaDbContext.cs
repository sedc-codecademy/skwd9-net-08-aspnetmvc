using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.DataAccess
{
    // Install nugets:
    // Microsoft.EntityFrameworkCore latest stable
    // Microsoft.EntityFrameworkCore.Design latest stable
    // Microsoft.EntityFrameworkCore.SqlServer latest stable
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations
            modelBuilder.Entity<Order>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<Pizza>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Pizza)
                .HasForeignKey(x => x.PizzaId);
            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User);
            // Seeding
            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Martin",
                    LastName = "Jankuloski",
                    Address = "Street 01",
                    Phone = 38977123456
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = "Unknown",
                    Phone = 38977654321
                });

            modelBuilder.Entity<Pizza>()
                .HasData(
                new Pizza()
                {
                    Id = 1,
                    Name = "Pepperoni",
                    Price = 250,
                    Size = PizzaSize.Medium
                },
                new Pizza()
                {
                    Id = 2,
                    Name = "Pepperoni",
                    Price = 250,
                    Size = PizzaSize.Large
                },
                new Pizza()
                {
                    Id = 3,
                    Name = "Pepperoni",
                    Price = 350,
                    Size = PizzaSize.Family
                },
                new Pizza()
                {
                    Id = 5,
                    Name = "Margherita",
                    Price = 200,
                    Size = PizzaSize.Medium
                },
                new Pizza()
                {
                    Id = 6,
                    Name = "Margherita",
                    Price = 240,
                    Size = PizzaSize.Large
                },
                new Pizza()
                {
                    Id = 7,
                    Name = "Margherita",
                    Price = 280,
                    Size = PizzaSize.Family
                },
                new Pizza()
                {
                    Id = 8,
                    Name = "Capri",
                    Price = 200,
                    Size = PizzaSize.Medium
                },
                new Pizza()
                {
                    Id = 9,
                    Name = "Capri",
                    Price = 200,
                    Size = PizzaSize.Large
                },
                new Pizza()
                {
                    Id = 10,
                    Name = "Capri",
                    Price = 200,
                    Size = PizzaSize.Family
                }
                );

        }
    }
}
