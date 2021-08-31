using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.DataAccess
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CONFIGURATIONS OF CONSTRAINTS AND DATA SEED

    
        // MANY-TO-MANY relation configuration

            // 1. Configuration for Order model with the middle table
            modelBuilder.Entity<Order>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            // 2. Configuration for Pizza model with the middle table
            modelBuilder.Entity<Pizza>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Pizza)
                .HasForeignKey(x => x.PizzaId);

            // ONE-TO-MANY relation configuration
            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);


            // SEED OF DATA 
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Bob",
                        LastName = "Bobsky",
                        Address = "Bob Street",
                        Phone = 1231123123123
                    },
                    new User()
                    {
                        Id = 2,
                        FirstName = "Jill",
                        LastName = "Wayne",
                        Address = "Jill Street",
                        Phone = 080044455123
                    }
                );



            modelBuilder.Entity<Pizza>()
                .HasData(
                new Pizza()
                {
                    Id = 1,
                    Name = "Kapri",
                    Price = 7,
                    PizzaSize = PizzaSize.Medium,
                    Image = "Kapri.png"
                },
                new Pizza()
                {
                    Id = 2,
                    Name = "Kapri",
                    Price = 7,
                    PizzaSize = PizzaSize.Large,
                    Image = "Kapri.png"
                },
                new Pizza()
                {
                    Id = 3,
                    Name = "Kapri",
                    Price = 7,
                    PizzaSize = PizzaSize.Family,
                    Image = "Kapri.png"
                },
                new Pizza()
                {
                    Id = 4,
                    Name = "Peperoni",
                    Price = 9,
                    PizzaSize = PizzaSize.Medium,
                    Image = "Peperoni.png"
                },
                new Pizza()
                {
                    Id = 5,
                    Name = "Peperoni",
                    Price = 8,
                    PizzaSize = PizzaSize.Large,
                    Image = "Peperoni.png"
                },
                new Pizza()
                {
                    Id = 6,
                    Name = "Peperoni",
                    Price = 8,
                    PizzaSize = PizzaSize.Family,
                    Image = "Peperoni.png"
                },
                new Pizza()
                {
                    Id = 7,
                    Name = "Margarita",
                    Price = 10.5,
                    PizzaSize = PizzaSize.Medium,
                    Image = "Margarita.png"
                },
                new Pizza()
                {
                    Id = 8,
                    Name = "Margarita",
                    Price = 10.5,
                    PizzaSize = PizzaSize.Large,
                    Image = "Margarita.png"
                },
                new Pizza()
                {
                    Id = 9,
                    Name = "Margarita",
                    Price = 10.5,
                    PizzaSize = PizzaSize.Family,
                    Image = "Margarita.png"
                },
                new Pizza()
                {
                    Id = 10,
                    Name = "Siciliana",
                    Price = 6.5,
                    PizzaSize = PizzaSize.Medium,
                    Image = "Siciliana.png"
                },
                new Pizza()
                {
                    Id = 11,
                    Name = "Siciliana",
                    Price = 9.5,
                    PizzaSize = PizzaSize.Large,
                    Image = "Siciliana.png"
                },
                new Pizza()
                {
                    Id = 12,
                    Name = "Siciliana",
                    Price = 9.5,
                    PizzaSize = PizzaSize.Family,
                    Image = "Siciliana.png"
                });

            modelBuilder.Entity<Order>()
                .HasData(
                    new Order()
                    {
                        Id = 1,
                        UserId = 1,
                        Delivered = true,
                        PaymentMethod = PaymentMethod.Card,
                        PizzaStore = "Pizza store Skopje"
                    },
                    new Order()
                    {
                        Id = 2,
                        UserId = 1,
                        Delivered = false,
                        PaymentMethod = PaymentMethod.Card,
                        PizzaStore = "Pizza store Skopje"
                    },
                    new Order()
                    {
                        Id = 3,
                        UserId = 2,
                        Delivered = true,
                        PaymentMethod = PaymentMethod.Cash,
                        PizzaStore = "Pizza store Skopje"
                    }
                );

            modelBuilder.Entity<PizzaOrder>()
                .HasData(
                new PizzaOrder()
                {
                    Id = 1,
                    OrderId = 1,
                    PizzaId = 1
                },
                new PizzaOrder()
                {
                    Id = 2,
                    OrderId = 1,
                    PizzaId = 4
                },
                new PizzaOrder()
                {
                    Id = 3,
                    OrderId = 2,
                    PizzaId = 1
                },
                new PizzaOrder()
                {
                    Id = 4,
                    OrderId = 2,
                    PizzaId = 5
                },
                new PizzaOrder()
                {
                    Id = 5,
                    OrderId = 2,
                    PizzaId = 7
                },
                new PizzaOrder()
                {
                    Id = 6,
                    OrderId = 3,
                    PizzaId = 5
                },
                new PizzaOrder()
                {
                    Id = 7,
                    OrderId = 3,
                    PizzaId = 9
                },
                new PizzaOrder()
                {
                    Id = 8,
                    OrderId = 3,
                    PizzaId = 12
                });
        }

    }
}
