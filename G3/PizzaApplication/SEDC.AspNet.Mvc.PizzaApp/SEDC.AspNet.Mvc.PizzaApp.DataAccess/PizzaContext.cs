using Microsoft.EntityFrameworkCore;
using SEDC.AspNet.Mvc.PizzaApp.DataAccess.Mappings;
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
