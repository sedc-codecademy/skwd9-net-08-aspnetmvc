using Microsoft.EntityFrameworkCore;
using SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels;
using SEDC.AspNet.Mvc.Class07.CodeFirst.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<NewsletterSubscription> Subscriptions { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Entity configuration
            // Address
            modelBuilder.Entity<Address>()
                .Property(x => x.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithOne(u => u.Address);

            // Subscription
            modelBuilder.Entity<NewsletterSubscription>()
                .Property(x => x.IsSubscribed)
                .IsRequired();

            modelBuilder.Entity<NewsletterSubscription>()
                .HasOne(ns => ns.User)
                .WithOne(u => u.Subscription);

            // User
            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Address)
                .WithOne(x => x.User);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Subscription)
                .WithOne(x => x.User);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            #endregion

            #region Initial data
            modelBuilder.Entity<Address>()
                .HasData(
                    new Address
                    {
                        Id = 1,
                        Name = "Temnica"
                    }
                );

            modelBuilder.Entity<NewsletterSubscription>()
                .HasData(
                    new NewsletterSubscription
                    {
                        Id = 1,
                        IsSubscribed = true,
                    }
                );

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Trajan",
                        LastName = "Stevkovski",
                        Phone = 123432123,
                        AddressId = 1,
                        SubscriptionId = 1
                    }
                );

            modelBuilder.Entity<Pizza>()
                .HasData(
                    new Pizza()
                    {
                        Id = 1,
                        Name = "Kapri",
                        Price = 7,
                        Size = PizzaSize.Medium
                    },
                    new Pizza()
                    {
                        Id = 2,
                        Name = "Kapri",
                        Price = 8,
                        Size = PizzaSize.Large
                    },
                    new Pizza()
                    {
                        Id = 3,
                        Name = "Kapri",
                        Price = 9,
                        Size = PizzaSize.Family
                    }
                );

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
