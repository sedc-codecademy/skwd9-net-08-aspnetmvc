using Microsoft.EntityFrameworkCore;
using SEDC.AspNet.Mvc.PizzaApp.DataAccess.Mappings;
using SEDC.AspNet.Mvc.PizzaApp.Domain.Enums;
using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;

namespace SEDC.AspNet.Mvc.PizzaApp.DataAccess
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
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            #region Model mappings
            // Pizza model mapping
            modelBuilder.Entity<Pizza>()
                .ToTable("Pizzas")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Pizza>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Pizza>()
                .Property(p => p.Price)
                .IsRequired();

            modelBuilder.Entity<Pizza>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Pizza)
                .HasForeignKey(x => x.PizzaId);

            // Order model mapping
            modelBuilder.Entity<Order>()
                .ToTable("Orders")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasMany(p => p.PizzaOrders)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId);

            // Feedback model mapping
            modelBuilder.Entity<Feedback>()
                .ToTable("Feedbacks")
                .HasKey(x => x.Id);

            #endregion

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // user data
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Trajan",
                        LastName = "Stevkovski",
                        Address = "Temnica",
                        Phone = 1234321
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Vlatko",
                        LastName = "Tasevski",
                        Address = "Partizanska",
                        Phone = 82363812
                    }
                );

            // pizza data
            modelBuilder.Entity<Pizza>()
                .HasData(
                    new Pizza()
                    {
                        Id = 1,
                        Name = "Kapri",
                        Price = 7,
                        Size = PizzaSize.Medium,
                        Image = "Kapri.png"
                    },
                   new Pizza()
                   {
                       Id = 2,
                       Name = "Kapri",
                       Price = 7,
                       Size = PizzaSize.Large,
                       Image = "Kapri.png"
                   },
                   new Pizza()
                   {
                       Id = 3,
                       Name = "Kapri",
                       Price = 7,
                       Size = PizzaSize.Family,
                       Image = "Kapri.png"
                   },
                   new Pizza()
                   {
                       Id = 4,
                       Name = "Peperoni",
                       Price = 9,
                       Size = PizzaSize.Medium,
                       Image = "Peperoni.png"
                   },
                   new Pizza()
                   {
                       Id = 5,
                       Name = "Peperoni",
                       Price = 8,
                       Size = PizzaSize.Large,
                       Image = "Peperoni.png"
                   },
                   new Pizza()
                   {
                       Id = 6,
                       Name = "Peperoni",
                       Price = 8,
                       Size = PizzaSize.Family,
                       Image = "Peperoni.png"
                   },
                   new Pizza()
                   {
                       Id = 7,
                       Name = "Margarita",
                       Price = 10.5,
                       Size = PizzaSize.Medium,
                       Image = "Margarita.png"
                   },
                   new Pizza()
                   {
                       Id = 8,
                       Name = "Margarita",
                       Price = 10.5,
                       Size = PizzaSize.Large,
                       Image = "Margarita.png"
                   },
                   new Pizza()
                   {
                       Id = 9,
                       Name = "Margarita",
                       Price = 10.5,
                       Size = PizzaSize.Family,
                       Image = "Margarita.png"
                   },
                   new Pizza()
                   {
                       Id = 10,
                       Name = "Siciliana",
                       Price = 6.5,
                       Size = PizzaSize.Medium,
                       Image = "Siciliana.png"
                   },
                   new Pizza()
                   {
                       Id = 11,
                       Name = "Siciliana",
                       Price = 9.5,
                       Size = PizzaSize.Large,
                       Image = "Siciliana.png"
                   },
                   new Pizza()
                   {
                       Id = 12,
                       Name = "Siciliana",
                       Price = 9.5,
                       Size = PizzaSize.Family,
                       Image = "Siciliana.png"
                   }
                );
            
            // porder data
            modelBuilder.Entity<Order>()
                .HasData(
                    new Order
                    {
                        Id = 1,
                        UserId = 1
                    },
                    new Order
                    {
                        Id = 2,
                        UserId = 1
                    },
                    new Order
                    {
                        Id = 3,
                        UserId = 2
                    }
                );

            // pizza order data
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
                    }
                );
        }
    }
}
